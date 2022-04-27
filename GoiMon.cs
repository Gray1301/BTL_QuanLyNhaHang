using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom11
{
    public partial class GoiMon : Form
    {
        public GoiMon()
        {
            InitializeComponent();
        }

        private void KhoiTaoBoPhan()
        {
            db.Menu_SanPham.Load();
            cbxDSMon.DataSource = db.Menu_SanPham.Local;
            cbxDSMon.DisplayMember = "ten_sp";
            cbxDSMon.ValueMember = "ma_sp";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public NhanVien nv;
        private void button1_Click(object sender, EventArgs e)
        {
        }
        QlNhaHang db = new QlNhaHang();
        private void GoiMon_Load(object sender, EventArgs e)
        {
            txtKH.Text = TenKhach;
            txtTenBan.Text = tenBan;
            var MAKH = db.KhachHangs.FirstOrDefault(b => b.ho_ten == txtKH.Text).ma_kh;
            var maHD = db.HoaDons.FirstOrDefault(b => b.ma_kh == MAKH).ma_hd;
            txtMaHD.Text = maHD.ToString();
            KhoiTaoBoPhan();
        }
        private string tenBan;

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }

        private string SDT;

        public string sdt
        {
            get { return SDT; }
            set { SDT = value; }
        }

        private string TenKhach;
        public string tenkhach
        {
            get { return TenKhach; }
            set { TenKhach = value; }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void cbxDSMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = cbxDSMon.SelectedValue.ToString();

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChiTietHoaDon CT = new ChiTietHoaDon()
            {
                ma_sp = Convert.ToInt32(txtMaSP.Text),
                ma_hd = int.Parse(txtMaHD.Text),
                SoLuong = Convert.ToInt32(soluong.Value),
            };
            db.ChiTietHoaDons.Add(CT);
            db.SaveChanges();
            MessageBox.Show("Đã thêm chi tiết hóa đơn.");
            var CTHD = (from C in db.ChiTietHoaDons
                       select new { C.ma_hd, C.ma_sp, C.SoLuong }).ToList();
            var x = CTHD.Max(s=>s.ma_hd);
            MessageBox.Show(x.ToString());
           dataGridView1.DataSource = (from c in CTHD where(c.ma_hd == x) 
                                      select new { c.ma_hd, c.ma_sp, c.SoLuong }).ToList();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            FormThanhToan thanhToan = new FormThanhToan();
            thanhToan.tenkhach = txtKH.Text;
            thanhToan.maHD = Convert.ToInt32(txtMaHD.Text);
            thanhToan.ShowDialog();
        }
    }
}
