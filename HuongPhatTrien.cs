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
    public partial class HuongPhatTrien : Form
    {
        public HuongPhatTrien()
        {
            InitializeComponent();
        }
        QlNhaHang db = new QlNhaHang();

        private void HuongPhatTrien_Load(object sender, EventArgs e)
        {
            var query = (from T in db.ChiTietHoaDons
                         select new
                         {
                             T.ma_sp
                         }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            foreach(var item in query)
            {

            }
        }
    }
}
