using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 2. ĐĂNG NHẬP (Đã tích hợp phân quyền Role)
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            await SendAsync($"LOGIN|{username}|{password}", (res) => {
                if (res != null && res.StartsWith("LOGIN_SUCCESS"))
                {
                    // Định dạng trả về: LOGIN_SUCCESS|UserID|Role
                    string[] data = res.Split('|');
                    int userId = int.Parse(data[1]);
                    int role = int.Parse(data[2]); // 0: Sinh viên, 1: Admin

                    this.Invoke(new Action(() => {
                        this.Hide();
                        if (role == 1)
                        {
                            new AdminForm().Show(); // Mở giao diện Admin
                        }
                        else
                        {
                            new ExamForm(userId).Show(); // Mở giao diện thi
                        }
                    }));
                }
                else MessageBox.Show("Sai tài khoản hoặc mật khẩu! Phản hồi: " + res);
            });
        }

        // 3. ĐĂNG KÝ
        private async void btnRegSubmit_Click(object sender, EventArgs e)
        {
            await SendAsync($"REGISTER|{txtRegUser.Text.Trim()}|{txtRegPass.Text.Trim()}", (res) =>
            {
                if (res == "REGISTER_SUCCESS")
                    MessageBox.Show("Đăng ký thành công!");
                else if (res.Contains("Violation of UNIQUE KEY"))
                    MessageBox.Show("Tài khoản này đã tồn tại!");
                else
                    MessageBox.Show("Đăng ký thất bại: " + res);
            });
        }

        // 4. QUÊN MẬT KHẨU
        private async void btnForgotSubmit_Click(object sender, EventArgs e)
        {
            await SendAsync($"FORGOT|{txtForgotUser.Text.Trim()}", (res) => {
                if (res.StartsWith("FORGOT_SUCCESS")) MessageBox.Show("Mật khẩu của bạn là: " + res.Split('|')[1]);
                else MessageBox.Show("Không tìm thấy tài khoản!");
            });
        }

        // 5. HÀM GỬI YÊU CẦU LÊN SERVER (Giữ nguyên logic ổn định)
        private async Task SendAsync(string req, Action<string> cb)
        {
            string res = await Task.Run(() => {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        var ar = client.BeginConnect("127.0.0.1", 5000, null, null);
                        if (!ar.AsyncWaitHandle.WaitOne(3000)) return "ERR_TIMEOUT";
                        client.EndConnect(ar);
                        using (NetworkStream ns = client.GetStream())
                        {
                            byte[] b = Encoding.UTF8.GetBytes(req);
                            ns.Write(b, 0, b.Length);
                            byte[] buf = new byte[1024];
                            int read = ns.Read(buf, 0, buf.Length);
                            return Encoding.UTF8.GetString(buf, 0, read);
                        }
                    }
                }
                catch { return "ERR_NETWORK"; }
            });
            cb(res);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpRegister.Visible = true;
            grpForgot.Visible = false;
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpForgot.Visible = true;
            grpRegister.Visible = false;
        }
    }
}