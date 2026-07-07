using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class HistoryForm : Form
    {
        private int _userId;
        private StudentInfo _student;

        public HistoryForm(int userId, StudentInfo student)
        {
            InitializeComponent();

            // Áp dụng giao diện hiện đại
            UIHelper.ApplyModernStyle(this);

            _userId = userId;
            _student = student;

            this.Load += HistoryForm_Load;
            btnLoadHistory.Click += btnLoadHistory_Click;
        }

        private async void HistoryForm_Load(object sender, EventArgs e)
        {
            lblFullName.Text = "Họ tên: " + _student.FullName;
            lblStudentCode.Text = "MSSV: " + _student.StudentCode;

            SetupGrid();
            await LoadHistoryAsync();
        }

        private void SetupGrid()
        {
            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add("ResultID", "Mã kết quả");
            dgvHistory.Columns.Add("ExamName", "Tên đề thi");
            dgvHistory.Columns.Add("Score", "Điểm");
            dgvHistory.Columns.Add("CreatedAt", "Ngày thi");

            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void btnLoadHistory_Click(object sender, EventArgs e)
        {
            await LoadHistoryAsync();
        }

        private async void btnLoadHistory_Click_1(object sender, EventArgs e)
        {
            await LoadHistoryAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadHistoryAsync()
        {
            string response = await SendRequestAsync("GET_HISTORY|" + _userId);

            dgvHistory.Rows.Clear();

            if (!response.StartsWith("HISTORY_LIST"))
            {
                MessageBox.Show("Không tải được lịch sử: " + response);
                return;
            }

            string[] parts = response.Split('#');

            for (int i = 1; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i])) continue;

                string[] row = parts[i].Split('|');

                if (row.Length >= 4)
                {
                    dgvHistory.Rows.Add(row[0], row[1], row[2], row[3]);
                }
            }
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
    }
}