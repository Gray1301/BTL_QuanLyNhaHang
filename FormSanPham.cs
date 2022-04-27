using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom11
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            using (QlNhaHang db = new QlNhaHang())
            {
                var dsSP = (from s in db.Menu_SanPham
                            select new
                            {
                                ma_sp = s.ma_sp,
                                ten_sp = s.ten_sp,
                                mo_ta = s.mo_ta,
                                don_gia = s.don_gia,
                                loai = s.loai,

                            }).ToList();
                dtgvSanPham.DataSource = dsSP;
            }
        }
        private void resetForm()
        {

            tbxMa.Text = "";

            tbxTen.Text = "";

            tbxMoTa.Text = "";

            tbxDonGia.Text = "";

            cbxLoai.Text = "";

            ptbPreview.Image = null;
        }
        int selectedRow = 0;
        MemoryStream ms;
        Image ConvertBinaryToImage(byte[] data)
        {
            ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }
        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            tbxMa.Enabled = false;
            tbxMa.Text = dtgvSanPham.Rows[selectedRow].Cells[0].Value.ToString();

            tbxTen.Text = dtgvSanPham.Rows[selectedRow].Cells[1].Value.ToString();

            tbxMoTa.Text = dtgvSanPham.Rows[selectedRow].Cells[2].Value.ToString();

            tbxDonGia.Text = dtgvSanPham.Rows[selectedRow].Cells[3].Value.ToString();

            cbxLoai.Text = dtgvSanPham.Rows[selectedRow].Cells[4].Value.ToString();

          
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            HienThi();

            dtgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvSanPham.Columns[2].HeaderText = "Mô tả";
            dtgvSanPham.Columns[3].HeaderText = "Đơn giá";
            dtgvSanPham.Columns[4].HeaderText = "Loại";
            dtgvSanPham.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvSanPham.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvSanPham.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvSanPham.Columns[3].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvSanPham.Columns[4].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            cbxLoai.Text = "Đồ ăn";


        }
        byte[] ConvertImageToBinary(Image img)
        {
            try
            {
                ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = tbxTen.Text;
                string moTa = tbxMoTa.Text;
                if (ten == "" || moTa == "")
                {
                    throw new Exception("Thông tin sản phẩm không hợp lệ");
                }
                int donGia = Convert.ToInt32(tbxDonGia.Text);
                string loai = cbxLoai.Text;

                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = new Menu_SanPham() { ten_sp = ten, mo_ta = moTa, don_gia = donGia, loai = loai };
                    if (ptbPreview.Image != null)
                    {
                        sp.anh = ConvertImageToBinary(ptbPreview.Image);
                    }
                    db.Menu_SanPham.Add(sp);
                    db.SaveChanges();
                }

                HienThi();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ptbPreview.Image = new Bitmap(open.FileName);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = tbxTen.Text;
                string moTa = tbxMoTa.Text;
                if (ten == "" || moTa == "")
                {
                    throw new Exception("Thông tin sản phẩm không hợp lệ");
                }
                int maSp = Convert.ToInt32(tbxMa.Text);
                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = db.Menu_SanPham.Find(maSp);

                    sp.ten_sp = ten;
                    sp.mo_ta = moTa;
                    sp.don_gia = Convert.ToInt32(tbxDonGia.Text);
                    sp.loai = cbxLoai.Text;

                    if (ptbPreview.Image != null)
                    {
                        sp.anh = ConvertImageToBinary(ptbPreview.Image);
                    }

                    db.SaveChanges();
                }

                HienThi();
                resetForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maSp = Convert.ToInt32(tbxMa.Text);
                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = db.Menu_SanPham.Find(maSp);
                    db.Menu_SanPham.Remove(sp);
                    db.SaveChanges();
                }

                HienThi();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string ten = tbxTen.Text;
                string moTa = tbxMoTa.Text;
                if (ten == "" || moTa == "")
                {
                    throw new Exception("Thông tin sản phẩm không hợp lệ");
                }
                int donGia = Convert.ToInt32(tbxDonGia.Text);
                string loai = cbxLoai.Text;

                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = new Menu_SanPham() { ten_sp = ten, mo_ta = moTa, don_gia = donGia, loai = loai };
                    if (ptbPreview.Image != null)
                    {
                        sp.anh = ConvertImageToBinary(ptbPreview.Image);
                    }
                    db.Menu_SanPham.Add(sp);
                    db.SaveChanges();
                }

                HienThi();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                string ten = tbxTen.Text;
                string moTa = tbxMoTa.Text;
                if (ten == "" || moTa == "")
                {
                    throw new Exception("Thông tin sản phẩm không hợp lệ");
                }
                int maSp = Convert.ToInt32(tbxMa.Text);
                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = db.Menu_SanPham.Find(maSp);

                    sp.ten_sp = ten;
                    sp.mo_ta = moTa;
                    sp.don_gia = Convert.ToInt32(tbxDonGia.Text);
                    sp.loai = cbxLoai.Text;

                    if (ptbPreview.Image != null)
                    {
                        sp.anh = ConvertImageToBinary(ptbPreview.Image);
                    }

                    db.SaveChanges();
                }

                HienThi();
                resetForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int maSp = Convert.ToInt32(tbxMa.Text);
                using (QlNhaHang db = new QlNhaHang())
                {
                    Menu_SanPham sp = db.Menu_SanPham.Find(maSp);
                    db.Menu_SanPham.Remove(sp);
                    db.SaveChanges();
                }

                HienThi();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnChon_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ptbPreview.Image = new Bitmap(open.FileName);
            }
        }

        private void ptbPreview_Click(object sender, EventArgs e)
        {

        }
    }
}
