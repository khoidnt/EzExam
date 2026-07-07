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

            // Áp dụng giao diện hiện đại
            UIHelper.ApplyModernStyle(this);
            UIHelper.ApplyButtonStyle(btnLogin);
            UIHelper.ApplyButtonStyle(btnRegSubmit);
            UIHelper.ApplyButtonStyle(btnForgotSubmit);

            UIHelper.ApplyTextBoxStyle(txtUser);
            UIHelper.ApplyTextBoxStyle(txtPass);
            UIHelper.ApplyTextBoxStyle(txtRegUser);
            UIHelper.ApplyTextBoxStyle(txtRegPass);
            UIHelper.ApplyTextBoxStyle(txtForgotUser);

            grpRegister.Visible = false;
            grpForgot.Visible = false;

            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            lnkForgot.LinkClicked += lnkForgot_LinkClicked;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            await SendAsync($"LOGIN|{username}|{password}", (res) =>
            {
                if (res != null && res.StartsWith("LOGIN_SUCCESS"))
                {
                    string[] data = res.Split('|');

                    if (data.Length >= 3)
                    {
                        int userId = int.Parse(data[1]);
                        int role = int.Parse(data[2]);

                        this.Invoke(new Action(() =>
                        {
                            this.Hide();

                            if (role == 1)
                            {
                                new AdminForm().Show();
                            }
                            else
                            {
                                new ProfileForm(userId).Show();
                            }
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhận từ Server không đầy đủ: " + res);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu: " + res);
                }
            });
        }

        private async void btnRegSubmit_Click(object sender, EventArgs e)
        {
            string username = txtRegUser.Text.Trim();
            string password = txtRegPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu đăng ký!");
                return;
            }

            await SendAsync($"REGISTER|{username}|{password}", (res) =>
            {
                if (res == "REGISTER_SUCCESS")
                {
                    MessageBox.Show("Đăng ký thành công!");
                    grpRegister.Visible = false;
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại: " + res);
                }
            });
        }

        private async void btnForgotSubmit_Click(object sender, EventArgs e)
        {
            string username = txtForgotUser.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tài khoản cần lấy lại mật khẩu!");
                return;
            }

            await SendAsync($"FORGOT|{username}", (res) =>
            {
                if (res != null && res.StartsWith("FORGOT_SUCCESS"))
                    MessageBox.Show("Mật khẩu của bạn là: " + res.Split('|')[1]);
                else
                    MessageBox.Show("Không tìm thấy tài khoản!");
            });
        }

        private async Task SendAsync(string req, Action<string> cb)
        {
            string res = await Task.Run(() =>
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        var ar = client.BeginConnect("127.0.0.1", 5000, null, null);

                        if (!ar.AsyncWaitHandle.WaitOne(3000))
                            return "ERR_TIMEOUT";

                        client.EndConnect(ar);

                        using (NetworkStream ns = client.GetStream())
                        {
                            byte[] data = Encoding.UTF8.GetBytes(req);
                            ns.Write(data, 0, data.Length);

                            byte[] buffer = new byte[4096];
                            int read = ns.Read(buffer, 0, buffer.Length);

                            return Encoding.UTF8.GetString(buffer, 0, read);
                        }
                    }
                }
                catch
                {
                    return "ERR_NETWORK";
                }
            });

            cb(res);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpRegister.Visible = true;
            grpForgot.Visible = false;
            grpRegister.BringToFront();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpForgot.Visible = true;
            grpRegister.Visible = false;
            grpForgot.BringToFront();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}