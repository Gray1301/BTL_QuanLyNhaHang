
namespace BTL_Nhom11
{
    partial class GoiMon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtKH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoi = new System.Windows.Forms.Button();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxDSMon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soluong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(99, 355);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(619, 239);
            this.dataGridView1.TabIndex = 42;
            // 
            // txtKH
            // 
            this.txtKH.Enabled = false;
            this.txtKH.Location = new System.Drawing.Point(468, 241);
            this.txtKH.Name = "txtKH";
            this.txtKH.Size = new System.Drawing.Size(100, 22);
            this.txtKH.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Tên khách";
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(192, 246);
            this.soluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(100, 22);
            this.soluong.TabIndex = 39;
            this.soluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Số lượng";
            // 
            // txtTenBan
            // 
            this.txtTenBan.Enabled = false;
            this.txtTenBan.Location = new System.Drawing.Point(468, 181);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(100, 22);
            this.txtTenBan.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tên bàn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 32);
            this.label1.TabIndex = 35;
            this.label1.Text = "GỌI MÓN";
            // 
            // btnGoi
            // 
            this.btnGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoi.Location = new System.Drawing.Point(192, 301);
            this.btnGoi.Name = "btnGoi";
            this.btnGoi.Size = new System.Drawing.Size(100, 33);
            this.btnGoi.TabIndex = 34;
            this.btnGoi.Text = "Gọi";
            this.btnGoi.UseVisualStyleBackColor = true;
            this.btnGoi.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(192, 181);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(100, 22);
            this.txtMaSP.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Mã SP";
            // 
            // cbxDSMon
            // 
            this.cbxDSMon.FormattingEnabled = true;
            this.cbxDSMon.Location = new System.Drawing.Point(192, 125);
            this.cbxDSMon.Name = "cbxDSMon";
            this.cbxDSMon.Size = new System.Drawing.Size(448, 24);
            this.cbxDSMon.TabIndex = 31;
            this.cbxDSMon.SelectedIndexChanged += new System.EventHandler(this.cbxDSMon_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Món";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(468, 301);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(100, 22);
            this.txtMaHD.TabIndex = 44;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Mã HD";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(316, 611);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(133, 44);
            this.btnThanhToan.TabIndex = 45;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // GoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 667);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtKH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoi);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxDSMon);
            this.Controls.Add(this.label6);
            this.Name = "GoiMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoiMon";
            this.Load += new System.EventHandler(this.GoiMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soluong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown soluong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGoi;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDSMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThanhToan;
    }
}