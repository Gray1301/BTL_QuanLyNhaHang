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
    public partial class FormBan : Form
    {
        public FormBan()
        {
            InitializeComponent();
        }
        private QlNhaHang db = new QlNhaHang();
        int id;
        private void HienThi()
        {

            var dsBan = db.Bans.Select(e => new { e.ma_ban, e.ten_ban, e.trang_thai }).ToList();

            dtgvBan.DataSource = dsBan;

            dtgvBan.Columns[0].HeaderText = "Mã bàn";
            dtgvBan.Columns[1].HeaderText = "Tên bàn";
            dtgvBan.Columns[2].HeaderText = "Trạng thái";
            dtgvBan.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvBan.Columns[1].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvBan.Columns[2].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dtgvBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }
        private void FormBan_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (QlNhaHang db = new QlNhaHang())
            {
                db.Bans.Add(new Ban()
                {
                    //Thêm bàn vào thì auto là 1 vì có người
                    ten_ban = txtTenBan.Text,
                    trang_thai = 1
                });
                db.SaveChanges();
            }
            HienThi();
            txtTenBan.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[id].Cells[0].Value.ToString());
            using (QlNhaHang db = new QlNhaHang())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                b.ten_ban = txtTenBan.Text;
                db.SaveChanges();
            }
            HienThi();
            txtTenBan.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[id].Cells[0].Value.ToString());
            using (QlNhaHang db = new QlNhaHang())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                db.Bans.Remove(b);
                db.SaveChanges();
            }
            HienThi();
        }
        int trangthai;
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = e.RowIndex;
            txtTenBan.Text = dtgvBan.Rows[id].Cells[1].Value.ToString();
            txtTrangThai.Text = dtgvBan.Rows[trangthai].Cells[2].Value.ToString();
        }   

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            using (QlNhaHang db = new QlNhaHang())
            {
                db.Bans.Add(new Ban()
                {
                    //Thêm bàn vào thì auto là 1 vì có người
                    ten_ban = txtTenBan.Text,
                    trang_thai = 1
                });
                db.SaveChanges();
            }
            HienThi();
            txtTenBan.Text = "";
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[id].Cells[0].Value.ToString());
            using (QlNhaHang db = new QlNhaHang())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                b.ten_ban = txtTenBan.Text;
                b.trang_thai = Convert.ToInt32(txtTrangThai.Text);
                db.SaveChanges();
            }
            HienThi();
            txtTenBan.Text = "";
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[id].Cells[0].Value.ToString());
            using (QlNhaHang db = new QlNhaHang())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                db.Bans.Remove(b);
                db.SaveChanges();
            }
            HienThi();
        }
    }
}
