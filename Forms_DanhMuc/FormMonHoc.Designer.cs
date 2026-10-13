namespace QuanLyGioDay.Forms_DanhMuc
{
    partial class FormMonHoc
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.txtSoTiet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(189)))), ((int)(((byte)(101)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLuu.Location = new System.Drawing.Point(141, 300);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(127, 45);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = " 💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTimKiem.Location = new System.Drawing.Point(16, 42);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(336, 31);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Nhập mã môn học hoặc tên..";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(730, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 171);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEARCH";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnTim.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnTim.Location = new System.Drawing.Point(183, 95);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(128, 43);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "🔍 Tim Kiem";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1833, 69);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ DANH MỤC MÔN HỌC";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(71)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLamMoi.Location = new System.Drawing.Point(563, 300);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(122, 45);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(174)))), ((int)(((byte)(130)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnXoa.Location = new System.Drawing.Point(419, 300);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(128, 45);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(152)))), ((int)(((byte)(91)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSua.Location = new System.Drawing.Point(274, 300);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(129, 45);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(71)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThem.Location = new System.Drawing.Point(6, 300);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(127, 45);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(141, 109);
            this.txtTenMH.Multiline = true;
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(396, 32);
            this.txtTenMH.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(18, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "DANH SÁCH MÔN HỌC";
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHoc.Location = new System.Drawing.Point(12, 517);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.ReadOnly = true;
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.RowTemplate.Height = 24;
            this.dgvMonHoc.Size = new System.Drawing.Size(1737, 201);
            this.dgvMonHoc.TabIndex = 18;
            this.dgvMonHoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonHoc_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboKhoa);
            this.groupBox1.Controls.Add(this.txtSoTiet);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtTenMH);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaMH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1752, 378);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN CHI TIẾT";
            // 
            // cboKhoa
            // 
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(141, 215);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(190, 39);
            this.cboKhoa.TabIndex = 17;
            // 
            // txtSoTiet
            // 
            this.txtSoTiet.Location = new System.Drawing.Point(141, 165);
            this.txtSoTiet.Multiline = true;
            this.txtSoTiet.Name = "txtSoTiet";
            this.txtSoTiet.Size = new System.Drawing.Size(190, 32);
            this.txtSoTiet.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label5.Location = new System.Drawing.Point(6, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mã Khoa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số tiết:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label4.Location = new System.Drawing.Point(6, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên môn học";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(141, 53);
            this.txtMaMH.Multiline = true;
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(190, 32);
            this.txtMaMH.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyGioDay.Properties.Resources.icons8_university_50__1_2;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // FormMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1833, 764);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.label6);
            this.Name = "FormMonHoc";
            this.Text = "FormMonHoc";
            this.Load += new System.EventHandler(this.FormMonHoc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.TextBox txtSoTiet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}