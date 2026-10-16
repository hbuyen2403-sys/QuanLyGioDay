using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    partial class FormInLichChuaKetThuc
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1, label2;
        private DataGridView dgvLichChuaKetThuc;
        private GroupBox groupBox2;
        private Label lblTongSoLich;
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
            this.dgvLichChuaKetThuc = new DataGridView();
            this.groupBox2 = new GroupBox();
            this.lblTongSoLich = new Label();
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
            ((System.ComponentModel.ISupportInitialize)this.dgvLichChuaKetThuc).BeginInit();
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
            this.label1.Text = "DANH SÁCH LỊCH HỌC CHƯA KẾT THÚC";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(138, 72);
            this.label2.Text = "Quản lý và thống kê các lớp học đang trong thời gian giảng dạy";
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);

            // Bảng kết quả
            this.dgvLichChuaKetThuc.Name = "dgvLichChuaKetThuc";
            this.dgvLichChuaKetThuc.Dock = DockStyle.Fill;
            this.dgvLichChuaKetThuc.BackgroundColor = Color.White;
            this.dgvLichChuaKetThuc.AllowUserToAddRows = false;
            this.dgvLichChuaKetThuc.AllowUserToDeleteRows = false;
            this.dgvLichChuaKetThuc.ReadOnly = true;
            this.dgvLichChuaKetThuc.RowHeadersVisible = false;
            this.dgvLichChuaKetThuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichChuaKetThuc.AutoGenerateColumns = false;
            this.dgvLichChuaKetThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.col0.Name = "col0";
            this.col0.HeaderText = "STT";
            this.col0.DataPropertyName = "STT";
            this.col0.ReadOnly = true;
            this.col0.FillWeight = 60F;
            this.col1.Name = "col1";
            this.col1.HeaderText = "Mã Lớp";
            this.col1.DataPropertyName = "MaLop";
            this.col1.ReadOnly = true;
            this.col1.FillWeight = 95F;
            this.col2.Name = "col2";
            this.col2.HeaderText = "Tên Lớp";
            this.col2.DataPropertyName = "TenLop";
            this.col2.ReadOnly = true;
            this.col2.FillWeight = 95F;
            this.col3.Name = "col3";
            this.col3.HeaderText = "Môn Học";
            this.col3.DataPropertyName = "TenMon";
            this.col3.ReadOnly = true;
            this.col3.FillWeight = 110F;
            this.col4.Name = "col4";
            this.col4.HeaderText = "Giáo Viên";
            this.col4.DataPropertyName = "TenGV";
            this.col4.ReadOnly = true;
            this.col4.FillWeight = 110F;
            this.col5.Name = "col5";
            this.col5.HeaderText = "Thứ Dạy";
            this.col5.DataPropertyName = "ThuDay1";
            this.col5.ReadOnly = true;
            this.col5.FillWeight = 95F;
            this.col6.Name = "col6";
            this.col6.HeaderText = "Ca Dạy";
            this.col6.DataPropertyName = "CaDay1";
            this.col6.ReadOnly = true;
            this.col6.FillWeight = 95F;
            this.col7.Name = "col7";
            this.col7.HeaderText = "Thời Gian BĐ";
            this.col7.DataPropertyName = "ThoiGianBD";
            this.col7.ReadOnly = true;
            this.col7.FillWeight = 95F;
            this.col7.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.col8.Name = "col8";
            this.col8.HeaderText = "Thời Gian KT";
            this.col8.DataPropertyName = "ThoiGianKT";
            this.col8.ReadOnly = true;
            this.col8.FillWeight = 95F;
            this.col8.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvLichChuaKetThuc.Columns.AddRange(new DataGridViewColumn[] { this.col0, this.col1, this.col2, this.col3, this.col4, this.col5, this.col6, this.col7, this.col8 });

            // Tổng kết
            this.groupBox2.Dock = DockStyle.Bottom;
            this.groupBox2.Height = 106;
            this.groupBox2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.groupBox2.Text = "Tổng số lịch học chưa kết thúc";
            this.lblTongSoLich.AutoSize = true;
            this.lblTongSoLich.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            this.lblTongSoLich.ForeColor = SystemColors.HotTrack;
            this.lblTongSoLich.Location = new Point(23, 49);
            this.lblTongSoLich.Text = "Đang tải dữ liệu...";
            this.groupBox2.Controls.Add(this.lblTongSoLich);

            // Thứ tự Add điều khiển để Dock hiển thị đúng.
            this.Controls.Add(this.dgvLichChuaKetThuc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Name = "FormInLichChuaKetThuc";
            this.Text = "In Lịch Chưa Kết Thúc";
            this.ClientSize = new Size(1240, 730);
            this.MinimumSize = new Size(950, 610);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new EventHandler(this.FormInLichChuaKetThuc_Load);
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvLichChuaKetThuc).EndInit();
            this.ResumeLayout(false);
        }
    }
}
