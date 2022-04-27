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
    public partial class FormKhangHang : Form
    {
        public FormKhangHang()
        {
            InitializeComponent();
        }
        int idx = -1;
        private QlNhaHang db = new QlNhaHang();
        private void HienThi()
        {
            var dsKH = db.KhachHangs.Select(e => new { e.ma_kh, e.ho_ten, e.sdt }).ToList();
            dtgvKH.DataSource = dsKH;

            dtgvKH.DataSource = dsKH;
            dtgvKH.Columns[0].HeaderText = "Mã khách hàng";
            dtgvKH.Columns[1].HeaderText = "Họ và tên";
            dtgvKH.Columns[2].HeaderText = "Số điện thoại"; 
            dtgvKH.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvKH.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvKH.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvKH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }
        private void FormKhangHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (idx == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (QlNhaHang db = new QlNhaHang())
                {
                    int id = Convert.ToInt32(dtgvKH.Rows[idx].Cells[0].Value.ToString());
                    KhachHang kh = db.KhachHangs.Find(id);
                    kh.ho_ten = txtHoTen.Text;
                    kh.sdt = txtSdt.Text;
                    db.SaveChanges();
                }
                HienThi();
                ResetForm();
            }
            catch (FormatException)
            {
                MessageBox.Show("Điểm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            txtHoTen.Text = "";
            txtSdt.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idx == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (QlNhaHang db = new QlNhaHang())
            {
                int maKh = Convert.ToInt32(dtgvKH.Rows[idx].Cells[0].Value.ToString());
                KhachHang khach = db.KhachHangs.Find(maKh);
                db.KhachHangs.Remove(khach);
                db.SaveChanges();
            }
            HienThi();
            ResetForm();
        }
        private void dtgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            txtHoTen.Text = dtgvKH.Rows[idx].Cells[1].Value.ToString();
            txtSdt.Text = dtgvKH.Rows[idx].Cells[2].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //Tìm theo số điện thoại
            string sdt = txtSdt.Text;
            using (QlNhaHang db = new QlNhaHang())
            {
                var dsKH = db.KhachHangs.Where(kh => kh.sdt.Contains(sdt)).Select(kh => new { ma_kh = kh.ma_kh, ho_ten = kh.ho_ten, sdt = kh.sdt }).ToList();
                dtgvKH.DataSource = dsKH;
            }
        }
    }
}
