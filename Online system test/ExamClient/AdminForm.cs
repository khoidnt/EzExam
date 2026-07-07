using System;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class AdminForm : Form
    {
        // 1. Khai báo biến toàn cục để các hàm dùng chung
        private System.Net.Sockets.TcpClient client;
        private System.Net.Sockets.NetworkStream stream;

        public AdminForm()
        {
            InitializeComponent();
            SetupDataGridView();
            ConnectToServer(); // 2. Kết nối ngay khi khởi tạo
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000); // Đảm bảo cổng này khớp với Server
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối Server: " + ex.Message);
            }
        }

        private void SetupDataGridView()
        {
            dgvQuestions.Columns.Clear();
            dgvQuestions.Columns.Add("QuestionID", "QuestionID");
            dgvQuestions.Columns.Add("QuestionText", "Question Text");
            dgvQuestions.Columns.Add("OptionA", "Option A");
            dgvQuestions.Columns.Add("OptionB", "Option B");
            dgvQuestions.Columns.Add("OptionC", "Option C");
            dgvQuestions.Columns.Add("OptionD", "Option D");
            dgvQuestions.Columns.Add("CorrectAnswer", "Correct Answer");
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "User: phat2122006 | Connected to 'OnlineExam' Database";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 3. Kiểm tra trước khi gửi
            if (stream == null || !client.Connected)
            {
                MessageBox.Show("Chưa kết nối tới Server!");
                return;
            }

            try
            {
                string request = "GET_QUESTIONS";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                byte[] buffer = new byte[10240];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Dữ liệu Server trả về dạng: QUESTIONS_LIST#ID|Text|A|B|C|D|Correct#ID|Text|...
                LoadDataToGrid(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truyền nhận: " + ex.Message);
            }
        }
        // --- Nút Thêm câu hỏi ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi!");
                return;
            }

            // Định dạng gửi: "ADD_QUESTION|Question|A|B|C|D|Correct"
            string request = $"ADD_QUESTION|{txtQuestion.Text}|{txtOptionA.Text}|{txtOptionB.Text}|{txtOptionC.Text}|{txtOptionD.Text}|{txtCorrect.Text}";

            byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);

            MessageBox.Show("Đã gửi yêu cầu thêm câu hỏi.");
            btnLoad_Click(sender, e); // Load lại lưới sau khi thêm
        }

        // --- Nút Cập nhật câu hỏi ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                string id = dgvQuestions.SelectedRows[0].Cells[0].Value.ToString();
                // Định dạng gửi: "UPDATE_QUESTION|ID|Question|A|B|C|D|Correct"
                string request = $"UPDATE_QUESTION|{id}|{txtQuestion.Text}|{txtOptionA.Text}|{txtOptionB.Text}|{txtOptionC.Text}|{txtOptionD.Text}|{txtCorrect.Text}";

                byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
                stream.Write(data, 0, data.Length);

                MessageBox.Show("Đã gửi yêu cầu cập nhật ID: " + id);
                btnLoad_Click(sender, e); // Load lại lưới sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi trên lưới để cập nhật!");
            }
        }
        private void LoadDataToGrid(string data)
        {
            dgvQuestions.Rows.Clear();
            if (data.StartsWith("QUESTIONS_LIST"))
            {
                string[] parts = data.Substring(14).Split('#'); // Bỏ chuỗi header và tách từng câu
                foreach (string part in parts)
                {
                    if (string.IsNullOrWhiteSpace(part)) continue;
                    string[] cells = part.Split('|');
                    dgvQuestions.Rows.Add(cells);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string id = dgvQuestions.SelectedRows[0].Cells[0].Value.ToString();
                    byte[] data = System.Text.Encoding.UTF8.GetBytes("DELETE_QUESTION|" + id);

                    // Luôn kiểm tra stream trước khi ghi
                    if (stream != null && client.Connected)
                    {
                        stream.Write(data, 0, data.Length);

                        // Đợi một chút cho Server xử lý SQL
                        System.Threading.Thread.Sleep(200);

                        // Sau đó mới tải lại danh sách
                        btnLoad_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQuestions.Rows[e.RowIndex];
                txtQuestion.Text = row.Cells[1].Value?.ToString();
                txtOptionA.Text = row.Cells[2].Value?.ToString();
                txtOptionB.Text = row.Cells[3].Value?.ToString();
                txtOptionC.Text = row.Cells[4].Value?.ToString();
                txtOptionD.Text = row.Cells[5].Value?.ToString();
                txtCorrect.Text = row.Cells[6].Value?.ToString();
            }
        }

       
    }
}