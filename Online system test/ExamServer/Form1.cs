using System;
using System.Data;
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
        // Đảm bảo Connection String đúng với cấu hình máy bạn
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=OnlineExam;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(() => {
                try
                {
                    TcpListener server = new TcpListener(IPAddress.Any, 5000);
                    server.Start();
                    AddLog("Server đã khởi động trên cổng 5000...");
                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        // Mỗi client được xử lý trong 1 luồng riêng
                        new Thread(() => HandleClient(client)).Start();
                    }
                }
                catch (Exception ex) { AddLog("Lỗi khởi động: " + ex.Message); }
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
                    byte[] buf = new byte[4096];
                    // Vòng lặp giữ kết nối liên tục cho 1 client
                    while (client.Connected)
                    {
                        int read = ns.Read(buf, 0, buf.Length);
                        if (read == 0) break; // Client ngắt kết nối

                        string req = Encoding.UTF8.GetString(buf, 0, read);
                        AddLog("Yêu cầu: " + req);

                        string res = ProcessRequest(req);

                        byte[] resBuf = Encoding.UTF8.GetBytes(res);
                        ns.Write(resBuf, 0, resBuf.Length);
                        ns.Flush();
                        AddLog("Phản hồi: " + res);
                    }
                }
            }
            catch (Exception ex) { AddLog("Client ngắt kết nối: " + ex.Message); }
            finally { client.Close(); }
        }

        private string ProcessRequest(string req)
        {
            try
            {
                string[] p = req.Split('|');
                if (p.Length == 0) return "ERROR|Empty request";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    if (p[0] == "GET_QUESTIONS")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT QuestionID, QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer FROM Questions", conn);
                        StringBuilder sb = new StringBuilder("QUESTIONS_LIST");
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read()) sb.Append($"#{dr[0]}|{dr[1]}|{dr[2]}|{dr[3]}|{dr[4]}|{dr[5]}|{dr[6]}");
                        }
                        return sb.ToString();
                    }

                    if (p[0] == "DELETE_QUESTION")
                    {
                        // Kiểm tra an toàn: ID phải là số
                        if (int.TryParse(p[1], out int id))
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM Questions WHERE QuestionID=@id", conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            return "DELETE_SUCCESS";
                        }
                        return "ERROR|Invalid ID format";
                    }

                    if (p[0] == "UPDATE_QUESTION")
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Questions SET QuestionText=@t, AnswerA=@a, AnswerB=@b, AnswerC=@c, AnswerD=@d, CorrectAnswer=@cor WHERE QuestionID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", p[1]);
                        cmd.Parameters.AddWithValue("@t", p[2]);
                        cmd.Parameters.AddWithValue("@a", p[3]);
                        cmd.Parameters.AddWithValue("@b", p[4]);
                        cmd.Parameters.AddWithValue("@c", p[5]);
                        cmd.Parameters.AddWithValue("@d", p[6]);
                        cmd.Parameters.AddWithValue("@cor", p[7]);
                        cmd.ExecuteNonQuery();
                        return "UPDATE_SUCCESS";
                    }

                    if (p[0] == "LOGIN")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT UserID, Role FROM Users WHERE Username=@u AND Password=@p", conn);
                        cmd.Parameters.AddWithValue("@u", p[1]);
                        cmd.Parameters.AddWithValue("@p", p[2]);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read()) return $"LOGIN_SUCCESS|{dr[0]}|{dr[1]}";
                            else return "LOGIN_FAILED";
                        }
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

        private void AddLog(string log)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() => AddLog(log)));
            else lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {log}");
        }
    }
}