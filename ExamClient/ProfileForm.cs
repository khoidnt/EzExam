using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class ProfileForm : Form
    {
        private int _userId;
        public ProfileForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtStudentCode.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Tạo đối tượng StudentInfo từ thông tin vừa nhập
            StudentInfo student = new StudentInfo
            {
                FullName = txtFullName.Text,
                StudentCode = txtStudentCode.Text
            };

            // Mở Form thi và truyền dữ liệu
            new ExamForm(_userId, student).Show();
            this.Hide(); // Ẩn form nhập thông tin
        }
    }
}
