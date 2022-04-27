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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        int idx = -1;
        int idxBan = -1;
        public NhanVien nv;
        List<Ban> dsBan;
        List<KhachHang> dsKH;
        private void HienThiBan()
        {
            using (QlNhaHang db = new QlNhaHang())
            {
                dsBan = db.Bans.ToList();
                lvBan.View = View.LargeIcon;
                lvBan.Items.Clear();
                foreach (Ban ban in dsBan)
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = ban.ten_ban;
                    if(ban.trang_thai == 1)
                    {
                        it.ForeColor = Color.Red;
                    }
                    it.ImageIndex = (int)ban.trang_thai;

                    lvBan.Items.Add(it);
                }
            }
        }
        QlNhaHang db = new QlNhaHang();
        private void HienThiBanChuyen(int maBan)
        {
            //Hiển thị danh sách bàn trống
            using (QlNhaHang db = new QlNhaHang())
            {
                var banTrong = db.Bans.Where(b => b.trang_thai == 0 && b.ma_ban != maBan).ToList();
                cbxChuyenBan.ValueMember = "ma_ban";
                cbxChuyenBan.DisplayMember = "ten_ban";
                cbxChuyenBan.DataSource = banTrong;
            }
        }
        private void LoadBan(int maban)
        {
            Ban ban = dsBan[idxBan];

            txtTenban.Text = ban.ten_ban;
            txtTrangThai.Text = ban.trang_thai == 1 ? "Có người" : "Trống";            
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham qlSP = new FormSanPham();
            qlSP.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormHoaDon quanlyhoadon = new FormHoaDon();
            quanlyhoadon.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dangNhap = new Form1();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idCu = dsBan[idxBan].ma_ban;
                int idMoi = Convert.ToInt32(cbxChuyenBan.SelectedValue.ToString());
                using (QlNhaHang db = new QlNhaHang())
                {
                    Ban banCu = db.Bans.Where(b => b.ma_ban == idCu).FirstOrDefault();
                    banCu.trang_thai = 1;
                    Ban banMoi = db.Bans.Where(b => b.ma_ban == idMoi).FirstOrDefault();
                    banMoi.trang_thai = 0;
                    db.SaveChanges();
                }

                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã chuyển bàn", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            HienThiBan();

        }

        private void lvBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvBan_Click(object sender, EventArgs e)
        {
            idxBan = lvBan.SelectedItems[0].Index;
            LoadBan(idxBan);
            HienThiBanChuyen(dsBan[idxBan].ma_ban);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            FormThanhToan thanhToanForm = new FormThanhToan();
            thanhToanForm.maBan = dsBan[idxBan].ma_ban;

            if (thanhToanForm.ShowDialog(this) == DialogResult.OK)
            {
                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã thanh toán", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxChuyenBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtgvChiTietHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxDSMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnChuyenban_Click_1(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idCu = dsBan[idxBan].ma_ban;
                int idMoi = Convert.ToInt32(cbxChuyenBan.SelectedValue.ToString());
                using (QlNhaHang db = new QlNhaHang())
                {
                    Ban banCu = db.Bans.Where(b => b.ma_ban == idCu).FirstOrDefault();
                    banCu.trang_thai = 1;
                    Ban banMoi = db.Bans.Where(b => b.ma_ban == idMoi).FirstOrDefault();
                    banMoi.trang_thai = 0;
                    db.SaveChanges();
                }

                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã chuyển bàn", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (txtTrangThai.Text != "Có người")
            {

                MessageBox.Show("Bàn trống, không được gọi món");
            }
            else
            {
                GoiMon goiMon = new GoiMon();
                goiMon.TenBan = txtTenban.Text;
                goiMon.tenkhach = txtTenKhach.Text;
                goiMon.sdt = txtSDT.Text;
                goiMon.ShowDialog();
            }


        }

        private void bànToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBan quanLyBan = new FormBan();
            quanLyBan.ShowDialog();
        }

        private void bànToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            //thêm hóa đơn
            var maBan = db.Bans.FirstOrDefault(b => b.ten_ban == txtTenban.Text).ma_ban;
            var maKH = db.KhachHangs.FirstOrDefault(k => k.sdt == txtSDT.Text).ma_kh;

            HoaDon HD = new HoaDon()
            {
                ma_nv = nv.ma_nv,
                ma_ban = maBan,
                ngay = DateTime.Now,
                ma_kh = maKH
            };
            db.HoaDons.Add(HD);
            db.SaveChanges();
            MessageBox.Show("Đã thêm hóa đơn");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTrangThai.Text != "Có người")
            {

                MessageBox.Show("Bàn trống, không được gọi món");
            }
            else
            {
                //thêm khách hàng
                var KH = db.KhachHangs.FirstOrDefault();
                KH = new KhachHang()
                {
                    ho_ten = txtTenKhach.Text,
                    sdt = txtSDT.Text
                };
                db.KhachHangs.Add(KH);
                db.SaveChanges();
                MessageBox.Show("Đã thêm khách hàng");


            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var maKH = (from K in db.KhachHangs
                        where K.sdt == txtSDT.Text
                        select K.ma_kh);
            KhachHang KH = dsKH[idxBan];


        }

        private void btnChuyenban_Click_2(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idCu = dsBan[idxBan].ma_ban;
                int idMoi = Convert.ToInt32(cbxChuyenBan.SelectedValue.ToString());
                using (QlNhaHang db = new QlNhaHang())
                {
                    Ban banCu = db.Bans.Where(b => b.ma_ban == idCu).FirstOrDefault();
                    banCu.trang_thai = 1;
                    Ban banMoi = db.Bans.Where(b => b.ma_ban == idMoi).FirstOrDefault();
                    banMoi.trang_thai = 0;
                    db.SaveChanges();
                }

                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã chuyển bàn", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormSanPham qlSP = new FormSanPham();
            qlSP.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FormHoaDon quanlyhoadon = new FormHoaDon();
            quanlyhoadon.ShowDialog();
        }

        private void bànToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FormBan quanLyBan = new FormBan();
            quanLyBan.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dangNhap = new Form1();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (txtTrangThai.Text != "Có người")
            {

                MessageBox.Show("Bàn trống, không được gọi món");
            }
            else
            {
                GoiMon goiMon = new GoiMon();
                goiMon.TenBan = txtTenban.Text;
                goiMon.tenkhach = txtTenKhach.Text;
                goiMon.sdt = txtSDT.Text;
                goiMon.ShowDialog();
            }
        }

        private void btnHD_Click_1(object sender, EventArgs e)
        {
            //thêm hóa đơn
            var maBan = db.Bans.FirstOrDefault(b => b.ten_ban == txtTenban.Text).ma_ban;
            var maKH = db.KhachHangs.FirstOrDefault(k => k.sdt == txtSDT.Text).ma_kh;

            //var HD = db.HoaDons.FirstOrDefault();
            HoaDon HD = new HoaDon()
            {
                ma_nv = nv.ma_nv,
                ma_ban = maBan,
                ngay = DateTime.Now,
                ma_kh = maKH
            };
            db.HoaDons.Add(HD);
            db.SaveChanges();
            MessageBox.Show("Đã thêm hóa đơn");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtTrangThai.Text != "Có người")
            {

                MessageBox.Show("Bàn trống, không được gọi món");
            }
            else
            {
                //thêm khách hàng
                var KH = db.KhachHangs.FirstOrDefault(em => em.ho_ten == txtTenKhach.Text);
                KH = new KhachHang()
                {
                    ho_ten = txtTenKhach.Text,
                    sdt = txtSDT.Text
                };
                db.KhachHangs.Add(KH);
                db.SaveChanges();
                MessageBox.Show("Đã thêm khách hàng");


            }
        }

        private void lvBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbxChuyenBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormKhangHang quanlykhachhang = new FormKhangHang();
            quanlykhachhang.ShowDialog();
        }
    }
}
