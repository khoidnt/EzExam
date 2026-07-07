using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class AdminForm : Form
    {
        public class ExamItem
        {
            public int ExamID { get; set; }
            public string ExamName { get; set; }

            public override string ToString()
            {
                return ExamName;
            }
        }

        public AdminForm()
        {
            InitializeComponent();

            // Áp dụng giao diện hiện đại
            UIHelper.ApplyModernStyle(this);

            SetupQuestionGrid();
            SetupResultGrid();
            LoadExamsToComboBox();

            toolStripStatusLabel1.Text = "Admin | Server: 127.0.0.1:5000";

            btnLoad_Click(null, null);
            btnLoadResults_Click(null, null);
        }

        private void SetupQuestionGrid()
        {
            dgvQuestions.Columns.Clear();

            dgvQuestions.Columns.Add("QuestionID", "Mã câu hỏiD");
            dgvQuestions.Columns.Add("QuestionText", "Nội dung câu hỏi");
            dgvQuestions.Columns.Add("OptionA", "Đáp án A");
            dgvQuestions.Columns.Add("OptionB", "Đáp án B");
            dgvQuestions.Columns.Add("OptionC", "Đáp án C");
            dgvQuestions.Columns.Add("OptionD", "Đáp án D");
            dgvQuestions.Columns.Add("CorrectAnswer", "Câu trả lời");
          

            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestions.ReadOnly = true;
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void SetupResultGrid()
        {
            dgvResults.Columns.Clear();

            dgvResults.Columns.Add("ResultID", "Mã kết quả");
            dgvResults.Columns.Add("Username", "Sinh viên");
            dgvResults.Columns.Add("ExamName", "Đề thi");
            dgvResults.Columns.Add("Score", "Điểm");
            dgvResults.Columns.Add("CreatedAt", "Ngày thi");

            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblTotalQuestions.Text = "0";
            lblTotalAttempts.Text = "0";
            lblAverageScore.Text = "0";
            lblTotalStudents.Text = "0";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "User: admin | Connected to OnlineExam";
        }

        private string SendRequest(string request)
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(request);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024 * 50];
                    int read = stream.Read(buffer, 0, buffer.Length);

                    return Encoding.UTF8.GetString(buffer, 0, read);
                }
            }
            catch
            {
                return "ERR_NETWORK";
            }
        }

        private void LoadExamsToComboBox()
        {
            string response = SendRequest("GET_EXAMS");

            cmbExam.Items.Clear();

            if (!response.StartsWith("EXAM_LIST"))
            {
                MessageBox.Show("Không tải được danh sách đề thi: " + response);
                return;
            }

            string[] parts = response.Split('#');

            for (int i = 1; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i])) continue;

                string[] row = parts[i].Split('|');

                if (row.Length >= 2)
                {
                    cmbExam.Items.Add(new ExamItem
                    {
                        ExamID = int.Parse(row[0]),
                        ExamName = row[1]
                    });
                }
            }

            if (cmbExam.Items.Count > 0)
                cmbExam.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string response = SendRequest("GET_QUESTIONS");
            LoadDataToGrid(response);
            lblTotalQuestions.Text = dgvQuestions.Rows.Count.ToString();
        }

        private void LoadDataToGrid(string data)
        {
            dgvQuestions.Rows.Clear();

            if (!data.StartsWith("QUESTIONS_LIST"))
            {
                MessageBox.Show("Không tải được câu hỏi: " + data);
                return;
            }

            string[] parts = data.Split('#');

            for (int i = 1; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i])) continue;

                string[] cells = parts[i].Split('|');

                if (cells.Length >= 7)
                {
                    dgvQuestions.Rows.Add(
                        cells[0],
                        cells[1],
                        cells[2],
                        cells[3],
                        cells[4],
                        cells[5],
                        cells[6]
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi!");
                return;
            }

            string correct = GetCorrectAnswer();

            if (string.IsNullOrWhiteSpace(correct))
            {
                MessageBox.Show("Vui lòng chọn đáp án đúng!");
                return;
            }

            string request =
                $"ADD_QUESTION|{txtQuestion.Text}|{txtOptionA.Text}|{txtOptionB.Text}|{txtOptionC.Text}|{txtOptionD.Text}|{correct}";

            string response = SendRequest(request);

            if (response.StartsWith("ADD_QUESTION_SUCCESS"))
            {
                MessageBox.Show("Thêm câu hỏi thành công!");
                ClearInput();
                btnLoad_Click(null, null);
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + response);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để sửa!");
                return;
            }

            string id = dgvQuestions.SelectedRows[0].Cells[0].Value.ToString();
            string correct = GetCorrectAnswer();

            string request =
                $"UPDATE_QUESTION|{id}|{txtQuestion.Text}|{txtOptionA.Text}|{txtOptionB.Text}|{txtOptionC.Text}|{txtOptionD.Text}|{correct}";

            string response = SendRequest(request);

            if (response.StartsWith("UPDATE_QUESTION_SUCCESS"))
            {
                MessageBox.Show("Cập nhật câu hỏi thành công!");
                ClearInput();
                btnLoad_Click(null, null);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + response);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string id = dgvQuestions.SelectedRows[0].Cells[0].Value.ToString();
            string response = SendRequest("DELETE_QUESTION|" + id);

            if (response.StartsWith("DELETE_SUCCESS"))
            {
                MessageBox.Show("Xóa thành công!");
                ClearInput();
                btnLoad_Click(null, null);
            }
            else
            {
                MessageBox.Show("Xóa thất bại: " + response);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadExamsToComboBox();
            btnLoad_Click(null, null);
            btnLoadResults_Click(null, null);
        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvQuestions.Rows[e.RowIndex];

            txtQuestion.Text = row.Cells[1].Value?.ToString();
            txtOptionA.Text = row.Cells[2].Value?.ToString();
            txtOptionB.Text = row.Cells[3].Value?.ToString();
            txtOptionC.Text = row.Cells[4].Value?.ToString();
            txtOptionD.Text = row.Cells[5].Value?.ToString();

            SetCorrectAnswer(row.Cells[6].Value?.ToString());
        }

        private void btnLoadResults_Click(object sender, EventArgs e)
        {
            string response = SendRequest("GET_RESULTS");

            dgvResults.Rows.Clear();

            if (!response.StartsWith("RESULT_LIST"))
            {
                MessageBox.Show("Không tải được kết quả: " + response);
                return;
            }

            string[] parts = response.Split('#');

            double total = 0;
            int count = 0;

            for (int i = 1; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i])) continue;

                string[] row = parts[i].Split('|');

                if (row.Length >= 5)
                {
                    dgvResults.Rows.Add(row[0], row[1], row[2], row[3], row[4]);

                    double score = double.Parse(row[3]);
                    total += score;
                    count++;
                }
            }

            if (count > 0)
            {
                double avg = Math.Round(total / count, 2);

                lblTotalQuestions.Text = dgvQuestions.Rows.Count.ToString();
                lblTotalAttempts.Text = count.ToString();
                lblAverageScore.Text = avg.ToString();

                int studentCount = dgvResults.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => r.Cells[1].Value?.ToString())
                    .Distinct()
                    .Count();

                lblTotalStudents.Text = studentCount.ToString();
            }
            else
            {
                lblTotalAttempts.Text = "0";
                lblAverageScore.Text = "0";
                lblTotalStudents.Text = "0";
            }
        }

        private string GetCorrectAnswer()
        {
            if (cmbCorrect.SelectedItem != null)
                return cmbCorrect.SelectedItem.ToString();

            return cmbCorrect.Text.Trim();
        }

        private void SetCorrectAnswer(string value)
        {
            cmbCorrect.SelectedItem = value;
            cmbCorrect.Text = value;
        }

        private void ClearInput()
        {
            txtQuestion.Clear();
            txtOptionA.Clear();
            txtOptionB.Clear();
            txtOptionC.Clear();
            txtOptionD.Clear();

            cmbCorrect.SelectedIndex = -1;
            cmbCorrect.Text = "";
        }

        private void cmbExam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}