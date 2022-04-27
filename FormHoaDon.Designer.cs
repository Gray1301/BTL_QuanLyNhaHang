
namespace BTL_Nhom11
{
    partial class FormHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHoaDon));
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(456, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 53);
            this.label5.TabIndex = 27;
            this.label5.Text = "HÓA ĐƠN";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(373, 120);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(316, 22);
            this.dtpTo.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 29);
            this.label4.TabIndex = 24;
            this.label4.Text = "Đến";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(34, 120);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(319, 22);
            this.dtpFrom.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Các hóa đơn";
            // 
            // dtgvHoaDon
            // 
            this.dtgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHoaDon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHoaDon.Location = new System.Drawing.Point(34, 206);
            this.dtgvHoaDon.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtgvHoaDon.Name = "dtgvHoaDon";
            this.dtgvHoaDon.RowHeadersWidth = 51;
            this.dtgvHoaDon.Size = new System.Drawing.Size(639, 313);
            this.dtgvHoaDon.TabIndex = 20;
            this.dtgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClick);
            this.dtgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHoaDon_CellContentClick);
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
            this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnXuat.Location = new System.Drawing.Point(737, 109);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(180, 33);
            this.btnXuat.TabIndex = 28;
            this.btnXuat.Text = "Xuất báo cáo";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click_1);
            // 
            // btnLoc
            // 
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoc.Location = new System.Drawing.Point(737, 55);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(119, 33);
            this.btnLoc.TabIndex = 26;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click_1);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(721, 206);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.Size = new System.Drawing.Size(546, 313);
            this.dgvChiTiet.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(641, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Chi tiết hóa đơn";
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 608);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvHoaDon);
            this.Name = "FormHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHoaDon";
            this.Load += new System.EventHandler(this.FormHoaDon_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvHoaDon;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label label2;
    }
}