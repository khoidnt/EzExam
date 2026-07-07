using System.Drawing;
using System.Windows.Forms;

namespace ExamClient
{
    public static class UIHelper
    {
        public static void ApplyModernStyle(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10);
        }

        public static void ApplyButtonStyle(Button btn, Color? backgroundColor = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backgroundColor ?? Color.FromArgb(0, 122, 204);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;
        }

        public static void ApplyTextBoxStyle(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 11);
            txt.Height = 28;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void CenterControls(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is GroupBox grp)
                {
                    int centerX = (container.Width - grp.Width) / 2;
                    grp.Left = centerX;
                }
                else if (ctrl is Panel pnl)
                {
                    int centerX = (container.Width - pnl.Width) / 2;
                    pnl.Left = centerX;
                }
            }
        }
    }
}
