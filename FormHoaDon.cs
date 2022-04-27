using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL_Nhom11
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        int idx = -1;
        private QlNhaHang db = new QlNhaHang();
        public void HienThi()
        {
            var dsHoaDon = db.HoaDons.Join(db.NhanViens, d => d.ma_nv, e => e.ma_nv,
            (e, d) => new { 
                e.ma_hd, 
                e.NhanVien.ten_nv, 
                e.Ban.ten_ban, 
                e.ngay, 
                e.ma_kh }).ToList();


            dtgvHoaDon.DataSource = dsHoaDon;

            dtgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dtgvHoaDon.Columns[1].HeaderText = "Nhân viên";
            dtgvHoaDon.Columns[2].HeaderText = "Bàn";
            dtgvHoaDon.Columns[3].HeaderText = "Ngày tạo";
            dtgvHoaDon.Columns[4].HeaderText = "Mã khách hàng";


        }
        public void HienThiLoc(DateTime from, DateTime to)
        {
            dtgvHoaDon.DataSource = null;
            using (QlNhaHang db = new QlNhaHang())
            {
                dtgvHoaDon.DataSource = db.HoaDons.Where(h => h.ngay >= from && h.ngay <= to).Select(h => new
                {
                    h.ma_hd,
                    h.NhanVien.ten_nv,
                    h.Ban.ten_ban,
                    h.ngay,
                    h.ma_kh
                }).OrderByDescending(hd => hd.ngay).ToList();

                dtgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
                dtgvHoaDon.Columns[1].HeaderText = "Nhân viên";
                dtgvHoaDon.Columns[2].HeaderText = "Bàn";
                dtgvHoaDon.Columns[3].HeaderText = "Ngày tạo";
                dtgvHoaDon.Columns[4].HeaderText = "Mã khách hàng";
                //dgvChiTiet.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                //dgvChiTiet.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                //dgvChiTiet.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                //dgvChiTiet.Columns[3].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                //dgvChiTiet.Columns[4].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            DateTime to = DateTime.Now;
            DateTime from = DateTime.Now.AddDays(-14);
            dtpFrom.Value = from;
            dtpTo.Value = to;
            HienThi();
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            int maHD = Convert.ToInt32(dtgvHoaDon.Rows[idx].Cells[0].Value.ToString());
            using (QlNhaHang db = new QlNhaHang())
            {
                var ct = (from c in db.ChiTietHoaDons
                          join s in db.Menu_SanPham on c.ma_sp equals s.ma_sp
                          where c.ma_hd == maHD
                          select new { c.ma_sp, s.ten_sp, c.SoLuong, s.don_gia } into tmp
                          group tmp by new { tmp.ma_sp, tmp.ten_sp, tmp.don_gia } into final
                          select new
                          {
                              ma_sp = final.Key.ma_sp,
                              ten_sp = final.Key.ten_sp,
                              don_gia = final.Key.don_gia,
                              so_luong = final.Sum(f => f.SoLuong),
                              tong = final.Sum(f => f.SoLuong * f.don_gia),

                          }).ToList();
           
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = ct;
            dgvChiTiet.Columns[0].HeaderText = "Mã sản phẩm";
            dgvChiTiet.Columns[1].HeaderText = "Tên sản phẩm";
            dgvChiTiet.Columns[2].HeaderText = "Đơn giá";
            dgvChiTiet.Columns[3].HeaderText = "Số lượng";
            dgvChiTiet.Columns[4].HeaderText = "Thành tiền";
            dgvChiTiet.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvChiTiet.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvChiTiet.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvChiTiet.Columns[3].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvChiTiet.Columns[4].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            HienThiLoc(from, to);

        }

        private void dtgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void XuatBaoCao(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dtgvHoaDon.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dtgvHoaDon.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtgvHoaDon.Rows.Count; i++)
            {
                for (int j = 0; j < dtgvHoaDon.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dtgvHoaDon.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
        private void dtgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất file báo cáo";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatBaoCao(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file không thành công");
                }
            }
        }

        private void FormHoaDon_Load_1(object sender, EventArgs e)
        {
            DateTime to = DateTime.Now;
            DateTime from = DateTime.Now.AddDays(-14);
            dtpFrom.Value = from;
            dtpTo.Value = to;
            HienThi();
        }

        private void btnXuat_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất file báo cáo";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatBaoCao(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file không thành công");
                }
            }
        }

        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            HienThiLoc(from, to);
        }
    }
}
