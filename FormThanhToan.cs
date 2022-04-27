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
    public partial class FormThanhToan : Form
    {
        public int maBan;
        public int maHD;
        int tongTien;
        public string maGiamGia;
        QlNhaHang db = new QlNhaHang();
        public FormThanhToan()
        {
            InitializeComponent();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Đã Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormNhanVien formNhanVien = new FormNhanVien();
            this.Hide();
            formNhanVien.ShowDialog();
           
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = TenKhach;
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

                dtgvChiTiet.DataSource = null;
                dtgvChiTiet.DataSource = ct;
                dtgvChiTiet.Columns[0].HeaderText = "Mã sản phẩm";
                dtgvChiTiet.Columns[1].HeaderText = "Tên sản phẩm";
                dtgvChiTiet.Columns[2].HeaderText = "Đơn giá";
                dtgvChiTiet.Columns[3].HeaderText = "Số lượng";
                dtgvChiTiet.Columns[4].HeaderText = "Thành tiền";
                dtgvChiTiet.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dtgvChiTiet.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dtgvChiTiet.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dtgvChiTiet.Columns[3].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dtgvChiTiet.Columns[4].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                dtgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                foreach (var tt in ct)
                 {
                   tongTien += (int)tt.tong;
                 }
                lblTongTien.Text = tongTien + " VNĐ";
                var KM = (from K in db.KhuyenMais
                          select new                        
                          {
                              K.ma_km,
                              K.ten_km,
                              K.yeu_cau,
                              K.tien_giam
                          }).OrderByDescending(K => K.tien_giam).ToList();
                foreach (var tt in KM)
                {
                    if (tongTien >= tt.yeu_cau)
                    {
                        lblGiamGia.Text = tt.tien_giam.ToString(); 
                        int Tong = tongTien - int.Parse(lblGiamGia.Text);
                        lblThanhToan.Text = Tong + " VNĐ";
                        break;
                    }
                    else
                    {
                        lblGiamGia.Text = "0" + " VNĐ";
                        lblThanhToan.Text = tongTien + " VNĐ";
                    }
                }
              
                
            }
           
        }
        private string TenKhach;
        public string tenkhach
        {
            get { return TenKhach; }
            set { TenKhach = value; }
        }
        private string MaHD;
        public string mahoadon
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
