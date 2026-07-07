using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExamServer
{
    public partial class Form1 : Form
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=OnlineExam;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(() =>
            {
                try
                {
                    TcpListener server = new TcpListener(IPAddress.Any, 5000);
                    server.Start();

                    AddLog("Server đã khởi động trên cổng 5000...");

                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        Thread t = new Thread(() => HandleClient(client));
                        t.IsBackground = true;
                        t.Start();
                    }
                }
                catch (Exception ex)
                {
                    AddLog("Lỗi khởi động: " + ex.Message);
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();
            btnStart.Enabled = false;
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream ns = client.GetStream())
                {
                    byte[] buf = new byte[8192];

                    int read = ns.Read(buf, 0, buf.Length);
                    if (read == 0) return;

                    string req = Encoding.UTF8.GetString(buf, 0, read);
                    AddLog("Yêu cầu: " + req);

                    string res = ProcessRequest(req);

                    byte[] resBuf = Encoding.UTF8.GetBytes(res);
                    ns.Write(resBuf, 0, resBuf.Length);
                    ns.Flush();

                    AddLog("Phản hồi: " + res);
                }
            }
            catch (Exception ex)
            {
                AddLog("Client ngắt kết nối: " + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private string ProcessRequest(string req)
        {
            try
            {
                string[] p = req.Split('|');

                if (p.Length == 0)
                    return "ERROR|Empty request";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    if (p[0] == "REGISTER")
                    {
                        if (p.Length < 3)
                            return "ERROR|Thiếu username hoặc password";

                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn);
                        checkCmd.Parameters.AddWithValue("@u", p[1]);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                            return "REGISTER_EXISTS";

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Users (Username, Password, Role, FullName, StudentCode) VALUES (@u, @p, 0, N'', N'')",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@u", p[1]);
                        cmd.Parameters.AddWithValue("@p", p[2]);
                        cmd.ExecuteNonQuery();

                        return "REGISTER_SUCCESS";
                    }

                    if (p[0] == "FORGOT")
                    {
                        if (p.Length < 2)
                            return "ERROR|Thiếu username";

                        SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE Username=@u", conn);
                        cmd.Parameters.AddWithValue("@u", p[1]);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            return "FORGOT_SUCCESS|" + result.ToString();

                        return "FORGOT_FAILED";
                    }

                    if (p[0] == "LOGIN")
                    {
                        if (p.Length < 3)
                            return "ERROR|Thiếu username hoặc password";

                        SqlCommand cmd = new SqlCommand(
                            "SELECT UserID, Role, FullName, StudentCode FROM Users WHERE Username=@u AND Password=@p",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@u", p[1]);
                        cmd.Parameters.AddWithValue("@p", p[2]);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string fName = dr["FullName"] != DBNull.Value ? dr["FullName"].ToString() : "";
                                string sCode = dr["StudentCode"] != DBNull.Value ? dr["StudentCode"].ToString() : "";

                                return $"LOGIN_SUCCESS|{dr["UserID"]}|{dr["Role"]}|{fName}|{sCode}";
                            }

                            return "LOGIN_FAILED";
                        }
                    }

                    if (p[0] == "GET_QUESTIONS")
                    {
                        SqlCommand cmd = new SqlCommand(
                            "SELECT QuestionID, QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer FROM Questions",
                            conn
                        );

                        return BuildQuestionList(cmd);
                    }

                    if (p[0] == "GET_QUESTIONS_BY_EXAM")
                    {
                        if (p.Length < 2)
                            return "ERROR|Thiếu ExamID";

                        SqlCommand cmd = new SqlCommand(
                            "SELECT QuestionID, QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer FROM Questions WHERE ExamID=@eid",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@eid", p[1]);

                        return BuildQuestionList(cmd);
                    }

                    if (p[0] == "ADD_QUESTION")
                    {
                        if (p.Length < 7)
                            return "ERROR|Thiếu dữ liệu câu hỏi";

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Questions (QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) " +
                            "VALUES (@q, @a, @b, @c, @d, @correct)",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@q", p[1]);
                        cmd.Parameters.AddWithValue("@a", p[2]);
                        cmd.Parameters.AddWithValue("@b", p[3]);
                        cmd.Parameters.AddWithValue("@c", p[4]);
                        cmd.Parameters.AddWithValue("@d", p[5]);
                        cmd.Parameters.AddWithValue("@correct", p[6]);
                        cmd.ExecuteNonQuery();

                        return "ADD_QUESTION_SUCCESS";
                    }

                    if (p[0] == "UPDATE_QUESTION")
                    {
                        if (p.Length < 8)
                            return "ERROR|Thiếu dữ liệu cập nhật";

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Questions SET QuestionText=@q, AnswerA=@a, AnswerB=@b, AnswerC=@c, AnswerD=@d, CorrectAnswer=@correct " +
                            "WHERE QuestionID=@id",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@id", p[1]);
                        cmd.Parameters.AddWithValue("@q", p[2]);
                        cmd.Parameters.AddWithValue("@a", p[3]);
                        cmd.Parameters.AddWithValue("@b", p[4]);
                        cmd.Parameters.AddWithValue("@c", p[5]);
                        cmd.Parameters.AddWithValue("@d", p[6]);
                        cmd.Parameters.AddWithValue("@correct", p[7]);
                        cmd.ExecuteNonQuery();

                        return "UPDATE_QUESTION_SUCCESS";
                    }

                    if (p[0] == "GET_EXAMS")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ExamID, ExamName FROM Exams", conn);

                        StringBuilder sb = new StringBuilder("EXAM_LIST");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                sb.Append($"#{dr[0]}|{dr[1]}");
                            }
                        }

                        return sb.ToString();
                    }

                    if (p[0] == "SAVE_RESULT")
                    {
                        if (p.Length < 4)
                            return "ERROR|Thiếu dữ liệu lưu điểm";

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO ExamResults (UserID, ExamID, Score) VALUES (@uid, @eid, @sc)",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@uid", p[1]);
                        cmd.Parameters.AddWithValue("@eid", p[2]);
                        cmd.Parameters.AddWithValue("@sc", p[3]);
                        cmd.ExecuteNonQuery();

                        return "SAVE_RESULT_SUCCESS";
                    }

                    if (p[0] == "GET_HISTORY")
                    {
                        if (p.Length < 2)
                            return "ERROR|Thiếu UserID";

                        SqlCommand cmd = new SqlCommand(
                            @"SELECT 
                                r.ResultID,
                                ISNULL(e.ExamName, N'Đề thi mặc định') AS ExamName,
                                r.Score,
                                r.CreatedAt
                              FROM ExamResults r
                              LEFT JOIN Exams e ON r.ExamID = e.ExamID
                              WHERE r.UserID = @uid
                              ORDER BY r.CreatedAt DESC",
                            conn
                        );

                        cmd.Parameters.AddWithValue("@uid", p[1]);

                        StringBuilder sb = new StringBuilder("HISTORY_LIST");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                sb.Append(
                                    $"#{dr["ResultID"]}" +
                                    $"|{dr["ExamName"]}" +
                                    $"|{dr["Score"]}" +
                                    $"|{Convert.ToDateTime(dr["CreatedAt"]).ToString("dd/MM/yyyy HH:mm")}"
                                );
                            }
                        }

                        return sb.ToString();
                    }

                    if (p[0] == "GET_RESULTS")
                    {
                        SqlCommand cmd = new SqlCommand(
                            @"SELECT 
                                r.ResultID,
                                u.Username,
                                ISNULL(e.ExamName, N'Đề thi mặc định') AS ExamName,
                                r.Score,
                                r.CreatedAt
                              FROM ExamResults r
                              LEFT JOIN Users u ON r.UserID = u.UserID
                              LEFT JOIN Exams e ON r.ExamID = e.ExamID
                              ORDER BY r.CreatedAt DESC",
                            conn
                        );

                        StringBuilder sb = new StringBuilder("RESULT_LIST");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                sb.Append(
                                    $"#{dr["ResultID"]}" +
                                    $"|{dr["Username"]}" +
                                    $"|{dr["ExamName"]}" +
                                    $"|{dr["Score"]}" +
                                    $"|{Convert.ToDateTime(dr["CreatedAt"]).ToString("dd/MM/yyyy HH:mm")}"
                                );
                            }
                        }

                        return sb.ToString();
                    }

                    if (p[0] == "DELETE_QUESTION")
                    {
                        if (p.Length < 2)
                            return "ERROR|Thiếu QuestionID";

                        if (int.TryParse(p[1], out int id))
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM Questions WHERE QuestionID=@id", conn);

                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();

                            return "DELETE_SUCCESS";
                        }

                        return "ERROR|Invalid ID";
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("Lỗi SQL: " + ex.Message);
                return "ERROR|" + ex.Message;
            }

            return "UNKNOWN";
        }

        private string BuildQuestionList(SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder("QUESTIONS_LIST");

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    sb.Append($"#{dr[0]}|{dr[1]}|{dr[2]}|{dr[3]}|{dr[4]}|{dr[5]}|{dr[6]}");
                }
            }

            return sb.ToString();
        }

        private void AddLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AddLog(log)));
            }
            else
            {
                lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {log}");
            }
        }

       
    }
    
}