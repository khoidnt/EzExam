using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class ExamForm : Form
    {
        private int _currentUserId;
        private StudentInfo _student;
        private List<Question> qList = new List<Question>();
        private int currentIndex = 0;
        private int totalSeconds = 600;
        private int selectedExamId = 0;

        public class Question
        {
            public string ID, Text, A, B, C, D, Correct, UserAnswer;
        }

        public class ExamItem
        {
            public int ExamID { get; set; }
            public string ExamName { get; set; }

            public override string ToString()
            {
                return ExamName;
            }
        }

        public ExamForm(int userId, StudentInfo student)
        {
            InitializeComponent();

            _currentUserId = userId;
            _student = student;

            this.Load += ExamForm_Load;
        }

        private async void ExamForm_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = "Chào bạn: " + _student.FullName;
            lblMSSV.Text = "MSSV: " + _student.StudentCode;

            lblQuestion.Text = "Vui lòng chọn đề thi rồi bấm Bắt đầu.";
            lblStatus.Text = "Tổng số câu: 0 | Đã làm: 0 | Chưa làm: 0";
            lblTimer.Text = "Thời gian: 10:00";

            rdA.Text = "";
            rdB.Text = "";
            rdC.Text = "";
            rdD.Text = "";

            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            btnStart.Enabled = true;
            btnNext.Text = "Câu tiếp";
            btnSubmit.Visible = false;

            await LoadExamsAsync();
        }

        private async Task LoadExamsAsync()
        {
            string response = await SendRequestAsync("GET_EXAMS");

            lstExams.Items.Clear();

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
                    lstExams.Items.Add(new ExamItem
                    {
                        ExamID = int.Parse(row[0]),
                        ExamName = row[1]
                    });
                }
            }

            if (lstExams.Items.Count > 0)
            {
                lstExams.SelectedIndex = 0;
                selectedExamId = ((ExamItem)lstExams.SelectedItem).ExamID;
            }
        }

        private void lstExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExams.SelectedItem != null)
            {
                selectedExamId = ((ExamItem)lstExams.SelectedItem).ExamID;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (selectedExamId <= 0)
            {
                MessageBox.Show("Vui lòng chọn đề thi trước khi bắt đầu!");
                return;
            }

            btnStart.Enabled = false;
            lstExams.Enabled = false;
            lblQuestion.Text = "Đang tải câu hỏi...";

            bool success = await LoadQuestionsAsync();

            if (success && qList.Count > 0)
            {
                currentIndex = 0;
                totalSeconds = 600;

                DisplayQuestion();
                UpdateProgress();

                btnNext.Enabled = true;
                btnPrev.Enabled = false;

                timer1.Start();
            }
            else
            {
                MessageBox.Show("Không thể tải câu hỏi của đề này!");
                btnStart.Enabled = true;
                lstExams.Enabled = true;
                lblQuestion.Text = "Không có câu hỏi.";
            }
        }

        private void DisplayQuestion()
        {
            if (qList.Count == 0) return;

            Question q = qList[currentIndex];

            lblQuestion.Text = "Câu " + (currentIndex + 1) + ": " + q.Text;

            rdA.Text = "A. " + q.A;
            rdB.Text = "B. " + q.B;
            rdC.Text = "C. " + q.C;
            rdD.Text = "D. " + q.D;

            rdA.CheckedChanged -= RadioButton_CheckedChanged;
            rdB.CheckedChanged -= RadioButton_CheckedChanged;
            rdC.CheckedChanged -= RadioButton_CheckedChanged;
            rdD.CheckedChanged -= RadioButton_CheckedChanged;

            rdA.Checked = q.UserAnswer == "A";
            rdB.Checked = q.UserAnswer == "B";
            rdC.Checked = q.UserAnswer == "C";
            rdD.Checked = q.UserAnswer == "D";

            rdA.CheckedChanged += RadioButton_CheckedChanged;
            rdB.CheckedChanged += RadioButton_CheckedChanged;
            rdC.CheckedChanged += RadioButton_CheckedChanged;
            rdD.CheckedChanged += RadioButton_CheckedChanged;

            btnPrev.Enabled = currentIndex > 0;
            btnNext.Text = currentIndex == qList.Count - 1 ? "Nộp bài" : "Câu tiếp";
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (qList.Count == 0) return;

            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                if (rb == rdA) qList[currentIndex].UserAnswer = "A";
                else if (rb == rdB) qList[currentIndex].UserAnswer = "B";
                else if (rb == rdC) qList[currentIndex].UserAnswer = "C";
                else if (rb == rdD) qList[currentIndex].UserAnswer = "D";

                UpdateProgress();
            }
        }

        private void UpdateProgress()
        {
            int done = qList.Count(q => !string.IsNullOrEmpty(q.UserAnswer));
            int notDone = qList.Count - done;

            lblStatus.Text = $"Tổng số câu: {qList.Count} | Đã làm: {done} | Chưa làm: {notDone}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (qList.Count == 0) return;

            if (currentIndex < qList.Count - 1)
            {
                currentIndex++;
                DisplayQuestion();
            }
            else
            {
                SubmitExam();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (qList.Count == 0) return;

            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayQuestion();
            }
        }

        private async void SubmitExam()
        {
            int done = qList.Count(q => !string.IsNullOrEmpty(q.UserAnswer));

            if (done < qList.Count)
            {
                MessageBox.Show($"Bạn chưa làm hết bài!\nĐã làm: {done}/{qList.Count}\nVui lòng làm đủ câu trước khi nộp.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn nộp bài không?",
                "Xác nhận nộp bài",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No) return;

            timer1.Stop();

            int correct = qList.Count(q => q.UserAnswer == q.Correct);
            double score = Math.Round(((double)correct / qList.Count) * 10, 2);

            await SaveResultAsync(score);

            MessageBox.Show($"Bạn đã hoàn thành bài thi!\nSố câu đúng: {correct}/{qList.Count}\nĐiểm số của bạn: {score}/10");

            btnNext.Enabled = false;
            btnPrev.Enabled = false;
            btnSubmit.Enabled = false;
            btnStart.Enabled = false;
            lstExams.Enabled = true;
        }

        private async Task SaveResultAsync(double score)
        {
            string request = $"SAVE_RESULT|{_currentUserId}|{selectedExamId}|{score}";
            string response = await SendRequestAsync(request);

            if (!response.StartsWith("SAVE_RESULT_SUCCESS"))
            {
                MessageBox.Show("Lưu điểm thất bại: " + response);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                lblTimer.Text = $"Thời gian: {totalSeconds / 60:00}:{totalSeconds % 60:00}";
            }
            else
            {
                timer1.Stop();
                SubmitExam();
            }
        }

        private async Task<bool> LoadQuestionsAsync()
        {
            string response = await SendRequestAsync("GET_QUESTIONS_BY_EXAM|" + selectedExamId);

            if (!response.StartsWith("QUESTIONS_LIST"))
                return false;

            qList.Clear();

            string[] parts = response.Split('#');

            for (int i = 1; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i])) continue;

                string[] q = parts[i].Split('|');

                if (q.Length >= 7)
                {
                    qList.Add(new Question
                    {
                        ID = q[0],
                        Text = q[1],
                        A = q[2],
                        B = q[3],
                        C = q[4],
                        D = q[5],
                        Correct = q[6],
                        UserAnswer = ""
                    });
                }
            }

            return qList.Count > 0;
        }

        private async Task<string> SendRequestAsync(string request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                    using (NetworkStream ns = client.GetStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(request);
                        ns.Write(data, 0, data.Length);

                        byte[] buffer = new byte[1024 * 50];
                        int read = ns.Read(buffer, 0, buffer.Length);

                        return Encoding.UTF8.GetString(buffer, 0, read);
                    }
                }
                catch
                {
                    return "ERR_NETWORK";
                }
            });
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new HistoryForm(_currentUserId, _student).Show();
        }
    }
}