namespace QuanLyGioDay.Forms_DanhMuc
{
    partial class FormKhoa
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
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
            this.gbThongTin.SuspendLayout();
            this.gbDanhSach.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Location = new System.Drawing.Point(125, 57);
            this.txtMaKhoa.Multiline = true;
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Size = new System.Drawing.Size(206, 31);
            this.txtMaKhoa.TabIndex = 0;
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Location = new System.Drawing.Point(125, 117);
            this.txtTenKhoa.Multiline = true;
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(206, 31);
            this.txtTenKhoa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label1.Location = new System.Drawing.Point(25, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã khoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label2.Location = new System.Drawing.Point(25, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên khoa";
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Location = new System.Drawing.Point(16, 47);
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.ReadOnly = true;
            this.dgvKhoa.RowHeadersWidth = 51;
            this.dgvKhoa.RowTemplate.Height = 24;
            this.dgvKhoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoa.Size = new System.Drawing.Size(1171, 456);
            this.dgvKhoa.TabIndex = 4;
            this.dgvKhoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoa_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(71)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(30, 293);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 42);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "➕Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(152)))), ((int)(((byte)(91)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoa.Location = new System.Drawing.Point(30, 369);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 42);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "🗑️Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(174)))), ((int)(((byte)(130)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLamMoi.Location = new System.Drawing.Point(211, 369);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "🔄Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // gbThongTin
            // 
            this.gbThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.gbThongTin.Controls.Add(this.txtDienThoai);
            this.gbThongTin.Controls.Add(this.txtDiaChi);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.txtMaKhoa);
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.txtTenKhoa);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.gbThongTin.Location = new System.Drawing.Point(20, 94);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(463, 518);
            this.gbThongTin.TabIndex = 10;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "THÔNG TIN CHI TIẾT KHOA";
            this.gbThongTin.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(125, 228);
            this.txtDienThoai.Multiline = true;
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(206, 31);
            this.txtDienThoai.TabIndex = 13;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(125, 173);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(206, 31);
            this.txtDiaChi.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label5.Location = new System.Drawing.Point(25, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
            this.label4.Location = new System.Drawing.Point(28, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Địa chỉ";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(189)))), ((int)(((byte)(101)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSua.Location = new System.Drawing.Point(211, 293);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 42);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "✏️Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.gbDanhSach.Controls.Add(this.textBox1);
            this.gbDanhSach.Controls.Add(this.dgvKhoa);
            this.gbDanhSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.gbDanhSach.Location = new System.Drawing.Point(489, 94);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Size = new System.Drawing.Size(1231, 518);
            this.gbDanhSach.TabIndex = 11;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "DANH SÁCH CÁC KHOA";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(473, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1711, 59);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(70, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "QUẢN LÝ KHOA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyGioDay.Properties.Resources.icons8_university_50__1_2;
            this.pictureBox1.Location = new System.Drawing.Point(20, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1711, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.gbThongTin);
            this.Name = "FormKhoa";
            this.Text = "Quản lý Khoa";
            this.Load += new System.EventHandler(this.FormKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbDanhSach.ResumeLayout(false);
            this.gbDanhSach.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}