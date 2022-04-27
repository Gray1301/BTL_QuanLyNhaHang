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
    public partial class FormQLNhanVien : Form
    {
        public FormQLNhanVien()
        {
            InitializeComponent();
        }

        private void dtgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            txtManv.Enabled = false;
            txtManv.Text = dtgvNV.Rows[selectedRow].Cells[0].Value.ToString();
            txtTennv.Text = dtgvNV.Rows[selectedRow].Cells[1].Value.ToString();
            txtUsername.Text = dtgvNV.Rows[selectedRow].Cells[2].Value.ToString();
            txtPassword.Text = dtgvNV.Rows[selectedRow].Cells[3].Value.ToString();
            dateTimePicker1.Text = dtgvNV.Rows[selectedRow].Cells[4].Value.ToString();
            cbxChucVu.Text = dtgvNV.Rows[selectedRow].Cells[5].Value.ToString();
        }
        private void resetForm()
        {
            txtManv.Text = "";

            txtTennv.Text = "";

            txtUsername.Text = "";

            txtPassword.Text = "";
        }
        private void FormQLNhanVien_Load(object sender, EventArgs e)
        {
            txtManv.Enabled = false;
            updateData();
            dtgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dtgvNV.Columns[1].HeaderText = "Tên nhân viên";
            dtgvNV.Columns[2].HeaderText = "Username";
            dtgvNV.Columns[3].HeaderText = "Password";
            dtgvNV.Columns[4].HeaderText = "Ngày sinh";
            dtgvNV.Columns[5].HeaderText = "Chức vụ";
            dtgvNV.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.Columns[3].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.Columns[4].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.Columns[5].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvNV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            IDictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("Nhân viên", "Nhân viên");
            comboSource.Add("Quản lý", "Quản lý");
            comboSource.Add("Lao công", "Lao công");
            comboSource.Add("Bảo vệ", "Bảo vệ");

            cbxChucVu.DataSource = new BindingSource(comboSource, null);
            cbxChucVu.DisplayMember = "Key";
            cbxChucVu.ValueMember = "Value";
        }
        QlNhaHang db = new QlNhaHang();
        int selectedRow = 0;
        void themNhanVien()
        {
            string tennv = txtTennv.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            DateTime ngaysinh = dateTimePicker1.Value;
            string chucvu = cbxChucVu.SelectedValue.ToString();
            db.NhanViens.Add(new NhanVien()
            {
                ten_nv = tennv,
                username = Username,
                password = Password,
                ngay_sinh = ngaysinh,
                chuc_vu = chucvu
            });

            db.SaveChanges();
        }
        private void updateData()
        {
            var dsNV = (from nv in db.NhanViens select new { ma_nv = nv.ma_nv, ten_nv = nv.ten_nv, username = nv.username, password = nv.password, ngay_sinh = nv.ngay_sinh, chuc_vu = nv.chuc_vu }).ToList();
            dtgvNV.DataSource = dsNV;
        }
        void suaNhanVien()
        {
            int manv = Convert.ToInt32(txtManv.Text);
            NhanVien nv = db.NhanViens.Find(manv);
            nv.ten_nv = txtTennv.Text;
            nv.username = txtUsername.Text;
            nv.password = txtPassword.Text;
            nv.ngay_sinh = dateTimePicker1.Value;
            nv.chuc_vu = cbxChucVu.SelectedValue.ToString();
            db.SaveChanges();
        }
        void xoaNhanVien()
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                int manv = Convert.ToInt32(txtManv.Text);
                NhanVien nv = db.NhanViens.Find(manv);
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            themNhanVien();
            resetForm();
            updateData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaNhanVien();
            resetForm();
            updateData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaNhanVien();
            resetForm();
            updateData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.Text = " ";
            txtTennv.Text = " ";
            txtUsername.Text = " ";
        }
    }
}
