using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    partial class FormInTKBGiaoVien
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1, label2;
        private DataGridView dgvKetQua;
        private GroupBox groupBox2;
        private Label lblThongTin;
        private GroupBox groupBox1;
        private ComboBox cboGiaoVien, cboKyDay, cboNamHoc;
        private Button btnXem;
        private Label lblGiaoVien, lblKyDay, lblNamHoc;
        private DataGridViewTextBoxColumn col0;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn col5;
        private DataGridViewTextBoxColumn col6;
        private DataGridViewTextBoxColumn col7;
        private DataGridViewTextBoxColumn col8;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.dgvKetQua = new DataGridView();
            this.groupBox2 = new GroupBox();
            this.lblThongTin = new Label();
            this.groupBox1 = new GroupBox();
            this.cboGiaoVien = new ComboBox();
            this.cboKyDay = new ComboBox();
            this.cboNamHoc = new ComboBox();
            this.btnXem = new Button();
            this.lblGiaoVien = new Label();
            this.lblKyDay = new Label();
            this.lblNamHoc = new Label();
            this.col0 = new DataGridViewTextBoxColumn();
            this.col1 = new DataGridViewTextBoxColumn();
            this.col2 = new DataGridViewTextBoxColumn();
            this.col3 = new DataGridViewTextBoxColumn();
            this.col4 = new DataGridViewTextBoxColumn();
            this.col5 = new DataGridViewTextBoxColumn();
            this.col6 = new DataGridViewTextBoxColumn();
            this.col7 = new DataGridViewTextBoxColumn();
            this.col8 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvKetQua).BeginInit();
            this.SuspendLayout();

            // Thanh tiêu đề
            this.panel1.BackColor = SystemColors.HotTrack;
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Height = 110;
            this.panel1.Name = "panel1";
            this.pictureBox1.Image = global::QuanLyGioDay.Properties.Resources.calendar3;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.Location = new Point(22, 13);
            this.pictureBox1.Size = new Size(88, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(135, 17);
            this.label1.Text = "THỜI KHÓA BIỂU CHI TIẾT GIÁO VIÊN";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(138, 72);
            this.label2.Text = "Tra cứu lịch giảng dạy chi tiết theo giáo viên, kỳ học và năm học";
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);

            // Bộ lọc
            this.groupBox1.Text = "Bộ lọc tìm kiếm";
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Height = 148;
            this.lblGiaoVien.Text = "Giáo viên";
            this.lblGiaoVien.Location = new Point(20, 36);
            this.lblGiaoVien.AutoSize = true;
            this.lblKyDay.Text = "Kỳ dạy";
            this.lblKyDay.Location = new Point(300, 36);
            this.lblKyDay.AutoSize = true;
            this.lblNamHoc.Text = "Năm học";
            this.lblNamHoc.Location = new Point(580, 36);
            this.lblNamHoc.AutoSize = true;
            this.cboGiaoVien.Location = new Point(20, 64);
            this.cboGiaoVien.Size = new Size(251, 30);
            this.cboGiaoVien.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGiaoVien.FormattingEnabled = true;
            this.cboKyDay.Location = new Point(300, 64);
            this.cboKyDay.Size = new Size(251, 30);
            this.cboKyDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKyDay.FormattingEnabled = true;
            this.cboNamHoc.Location = new Point(580, 64);
            this.cboNamHoc.Size = new Size(251, 30);
            this.cboNamHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.btnXem.Location = new Point(861, 54);
            this.btnXem.Size = new Size(216, 55);
            this.btnXem.Name = "btnXem";
            this.btnXem.Text = "In Thời Khóa Biểu";
            this.btnXem.BackColor = SystemColors.HotTrack;
            this.btnXem.ForeColor = Color.White;
            this.btnXem.FlatStyle = FlatStyle.Flat;
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new EventHandler(this.btnXem_Click);
            this.groupBox1.Controls.Add(this.lblGiaoVien);
            this.groupBox1.Controls.Add(this.cboGiaoVien);
            this.groupBox1.Controls.Add(this.lblKyDay);
            this.groupBox1.Controls.Add(this.cboKyDay);
            this.groupBox1.Controls.Add(this.lblNamHoc);
            this.groupBox1.Controls.Add(this.cboNamHoc);
            this.groupBox1.Controls.Add(this.btnXem);

            // Bảng kết quả
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.Dock = DockStyle.Fill;
            this.dgvKetQua.BackgroundColor = Color.White;
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.AutoGenerateColumns = false;
            this.dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.col0.Name = "col0";
            this.col0.HeaderText = "STT";
            this.col0.DataPropertyName = "STT";
            this.col0.ReadOnly = true;
            this.col0.FillWeight = 60F;
            this.col1.Name = "col1";
            this.col1.HeaderText = "Lớp";
            this.col1.DataPropertyName = "TenLop";
            this.col1.ReadOnly = true;
            this.col1.FillWeight = 95F;
            this.col2.Name = "col2";
            this.col2.HeaderText = "Môn Học";
            this.col2.DataPropertyName = "TenMon";
            this.col2.ReadOnly = true;
            this.col2.FillWeight = 110F;
            this.col3.Name = "col3";
            this.col3.HeaderText = "Số Tiết";
            this.col3.DataPropertyName = "SoTiet";
            this.col3.ReadOnly = true;
            this.col3.FillWeight = 95F;
            this.col4.Name = "col4";
            this.col4.HeaderText = "Thứ Dạy";
            this.col4.DataPropertyName = "ThuDay1";
            this.col4.ReadOnly = true;
            this.col4.FillWeight = 95F;
            this.col5.Name = "col5";
            this.col5.HeaderText = "Ca Dạy";
            this.col5.DataPropertyName = "CaDay1";
            this.col5.ReadOnly = true;
            this.col5.FillWeight = 95F;
            this.col6.Name = "col6";
            this.col6.HeaderText = "Thời Gian BĐ";
            this.col6.DataPropertyName = "ThoiGianBD";
            this.col6.ReadOnly = true;
            this.col6.FillWeight = 95F;
            this.col6.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.col7.Name = "col7";
            this.col7.HeaderText = "Thời Gian KT";
            this.col7.DataPropertyName = "ThoiGianKT";
            this.col7.ReadOnly = true;
            this.col7.FillWeight = 95F;
            this.col7.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.col8.Name = "col8";
            this.col8.HeaderText = "Ghi Chú";
            this.col8.DataPropertyName = "GhiChu";
            this.col8.ReadOnly = true;
            this.col8.FillWeight = 110F;
            this.dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { this.col0, this.col1, this.col2, this.col3, this.col4, this.col5, this.col6, this.col7, this.col8 });

            // Tổng kết
            this.groupBox2.Dock = DockStyle.Bottom;
            this.groupBox2.Height = 106;
            this.groupBox2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.groupBox2.Text = "Tổng kết và Thông tin";
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            this.lblThongTin.ForeColor = SystemColors.HotTrack;
            this.lblThongTin.Location = new Point(23, 49);
            this.lblThongTin.Text = "Chọn bộ lọc rồi bấm Xem.";
            this.groupBox2.Controls.Add(this.lblThongTin);

            // Thứ tự Add điều khiển để Dock hiển thị đúng.
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormInTKBGiaoVien";
            this.Text = "In Thời Khóa Biểu Giáo Viên";
            this.ClientSize = new Size(1240, 730);
            this.MinimumSize = new Size(950, 610);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new EventHandler(this.FormInTKBGiaoVien_Load);
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvKetQua).EndInit();
            this.ResumeLayout(false);
        }
    }
}
