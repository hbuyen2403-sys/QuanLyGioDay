namespace QuanLyGioDay.Forms_TimKiem
{
    partial class FormTimKiemGiaoVien
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
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboMonDay = new System.Windows.Forms.ComboBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.cboChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.lblSoKetQua = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.grpBoLoc.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.Controls.Add(this.txtHoTen);
            this.grpBoLoc.Controls.Add(this.btnLamMoi);
            this.grpBoLoc.Controls.Add(this.btnTimKiem);
            this.grpBoLoc.Controls.Add(this.cboMonDay);
            this.grpBoLoc.Controls.Add(this.cboKhoa);
            this.grpBoLoc.Controls.Add(this.cboChuyenNganh);
            this.grpBoLoc.Controls.Add(this.label4);
            this.grpBoLoc.Controls.Add(this.label3);
            this.grpBoLoc.Controls.Add(this.label2);
            this.grpBoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoLoc.Location = new System.Drawing.Point(19, 55);
            this.grpBoLoc.Margin = new System.Windows.Forms.Padding(5);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(5);
            this.grpBoLoc.Size = new System.Drawing.Size(580, 252);
            this.grpBoLoc.TabIndex = 2;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(159, 185);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(97, 34);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.LightGreen;
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTimKiem.Location = new System.Drawing.Point(32, 185);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(102, 34);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // cboMonDay
            // 
            this.cboMonDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonDay.FormattingEnabled = true;
            this.cboMonDay.Location = new System.Drawing.Point(325, 138);
            this.cboMonDay.Name = "cboMonDay";
            this.cboMonDay.Size = new System.Drawing.Size(210, 26);
            this.cboMonDay.TabIndex = 5;
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(325, 67);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(210, 26);
            this.cboKhoa.TabIndex = 4;
            // 
            // cboChuyenNganh
            // 
            this.cboChuyenNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChuyenNganh.FormattingEnabled = true;
            this.cboChuyenNganh.Location = new System.Drawing.Point(35, 138);
            this.cboChuyenNganh.Name = "cboChuyenNganh";
            this.cboChuyenNganh.Size = new System.Drawing.Size(221, 26);
            this.cboChuyenNganh.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(322, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Môn dạy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên giáo viên";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Green;
            this.lblTieuDe.Location = new System.Drawing.Point(14, 9);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(379, 26);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "TRA CỨU THÔNG TIN GIÁO VIÊN";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(35, 67);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(221, 24);
            this.txtHoTen.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chuyên ngành";
            // 
            // grpKetQua
            // 
            this.grpKetQua.Controls.Add(this.lblSoKetQua);
            this.grpKetQua.Controls.Add(this.dgvKetQua);
            this.grpKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKetQua.Location = new System.Drawing.Point(19, 315);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(994, 452);
            this.grpKetQua.TabIndex = 4;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Kết quả tra cứu";
            // 
            // lblSoKetQua
            // 
            this.lblSoKetQua.AutoSize = true;
            this.lblSoKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoKetQua.Location = new System.Drawing.Point(835, 20);
            this.lblSoKetQua.Name = "lblSoKetQua";
            this.lblSoKetQua.Size = new System.Drawing.Size(142, 18);
            this.lblSoKetQua.TabIndex = 10;
            this.lblSoKetQua.Text = "Tìm thấy: 0 giáo viên";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvKetQua.Location = new System.Drawing.Point(6, 49);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(982, 397);
            this.dgvKetQua.TabIndex = 1;
            // 
            // FormTimKiemGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 779);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "FormTimKiemGiaoVien";
            this.Text = "FormTimKiemGiaoVien";
            this.Load += new System.EventHandler(this.FormTimKiemGiaoVien_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboMonDay;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.ComboBox cboChuyenNganh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.Label lblSoKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
    }
}