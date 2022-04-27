using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom11
{
    public partial class Form1 : Form
    {
        QlNhaHang db = new QlNhaHang();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            var user = db.NhanViens.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                if (user.chuc_vu == "Quản Lý")
                {
                    FormQuanLy formQuanLy = new FormQuanLy();
                   // formQuanLy.nv = user;
                    formQuanLy.Closed += (s, args) => this.Close();
                    formQuanLy.Show();
                }
                else
                {
                    FormNhanVien formNhanVien = new FormNhanVien();
                    formNhanVien.nv = user;
                    formNhanVien.Closed += (s, args) => this.Close();
                    formNhanVien.Show();
                }
            }
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
