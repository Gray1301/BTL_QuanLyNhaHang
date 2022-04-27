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
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khuyếnMạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhuyenMai khuyenMaiForm = new FormKhuyenMai();
            khuyenMaiForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            fillChart();
        }


        private void trangChủToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormQLNhanVien quanLyThongTinNhanVien = new FormQLNhanVien();
            quanLyThongTinNhanVien.ShowDialog();
        }

        private void bànToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormBan quanLyBan = new FormBan();
            quanLyBan.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormHoaDon quanlyhoadon = new FormHoaDon();
            quanlyhoadon.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormKhangHang quanlykhachhang = new FormKhangHang();
            quanlykhachhang.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dangNhap = new Form1();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham qlSP = new FormSanPham();
            qlSP.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

        }
        QlNhaHang db = new QlNhaHang();
        private void fillChart()
        {
            int all = 0;
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            var date1 = DateTime.Now.Day;
            var date2 = DateTime.Now.Month;
            var date3 = DateTime.Now.Year;
            HoaDon hd = new HoaDon();
            for (int i = date1 - 6; i <= date1; i++)
            {
                var dsHoaDon = db.HoaDons.Join(db.NhanViens, d => d.ma_nv, e => e.ma_nv,
           (e, d) => new
           {
               e.ma_hd,
               e.NhanVien.ten_nv,
               e.Ban.ten_ban,
               e.ngay,
               e.ma_kh
           }).Where(o => o.ngay.Value.Day == i && o.ngay.Value.Month == date2 && o.ngay.Value.Year == date3).Select(o => o).ToList();
                var ct = (from c in db.ChiTietHoaDons
                          join s in db.Menu_SanPham on c.ma_sp equals s.ma_sp
                          join x in db.HoaDons on c.ma_hd equals x.ma_hd
                          where x.ngay.Value.Day == i && x.ngay.Value.Month == date2 && x.ngay.Value.Year == date3
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
                foreach (var k in ct)
                {
                    all += (int)k.tong;
                }
                chart1.Series["Doanh thu"].Points.AddXY(i + "/" + date2, all);
            }


            //foreach(var k in dsHoaDon)
            //{
            //    MessageBox.Show(k.ngay.ToString());
            //}
           
            //MessageBox.Show(dsHoaDon.ToString());
            
            //chart1.Series["Doanh thu"].Points.AddXY(date1 +"/" + date.Month, "55");
            //chart1.Series["Doanh thu"].Points.AddXY(date1 + 1 + "/" + date.Month, "55");
            //chart1.Series["Doanh thu"].Points.AddXY(date1 + 2 + "/" + date.Month, "55");
            //chart1.Series["Doanh thu"].Points.AddXY(date1 + 3 + "/" + date.Month, "55");
            //chart1.Series["Doanh thu"].Points.AddXY(date1 + 4 + "/" + date.Month, "55");
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        public FormQuanLy nv;

        private void trangChủToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FormQLNhanVien quanLyThongTinNhanVien = new FormQLNhanVien();
            quanLyThongTinNhanVien.ShowDialog();
        }

        private void bànToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FormBan quanLyBan = new FormBan();
            quanLyBan.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FormHoaDon quanlyhoadon = new FormHoaDon();
            quanlyhoadon.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FormKhangHang quanlykhachhang = new FormKhangHang();
            quanlykhachhang.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormSanPham qlSP = new FormSanPham();
            qlSP.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dangNhap = new Form1();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void khuyếnMạiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormKhuyenMai KM = new FormKhuyenMai();
            KM.ShowDialog();
        }

        private void trangChủToolStripMenuItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hướngPhátTriểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongPhatTrien huongPhatTrien = new HuongPhatTrien();
            huongPhatTrien.ShowDialog();
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
