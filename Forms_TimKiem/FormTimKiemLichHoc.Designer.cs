namespace QuanLyGioDay.Forms_TimKiem
{
    partial class FormTimKiemLichHoc
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCaDay = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboGiaoVien = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.lblSoKetQua = new System.Windows.Forms.Label();
            this.grpBoLoc.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Green;
            this.lblTieuDe.Location = new System.Drawing.Point(9, 9);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(317, 26);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TRA CỨU LỊCH GIẢNG DẠY";
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.label6);
            this.grpBoLoc.Controls.Add(this.btnLamMoi);
            this.grpBoLoc.Controls.Add(this.btnTimKiem);
            this.grpBoLoc.Controls.Add(this.cboGiaoVien);
            this.grpBoLoc.Controls.Add(this.cboLop);
            this.grpBoLoc.Controls.Add(this.cboCaDay);
            this.grpBoLoc.Controls.Add(this.label4);
            this.grpBoLoc.Controls.Add(this.label3);
            this.grpBoLoc.Controls.Add(this.label2);
            this.grpBoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoLoc.Location = new System.Drawing.Point(14, 51);
            this.grpBoLoc.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grpBoLoc.Size = new System.Drawing.Size(704, 162);
            this.grpBoLoc.TabIndex = 1;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ca dạy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lớp học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(495, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gíao viên";
            // 
            // cboCaDay
            // 
            this.cboCaDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCaDay.FormattingEnabled = true;
            this.cboCaDay.Location = new System.Drawing.Point(35, 67);
            this.cboCaDay.Name = "cboCaDay";
            this.cboCaDay.Size = new System.Drawing.Size(175, 26);
            this.cboCaDay.TabIndex = 3;
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(271, 67);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(165, 26);
            this.cboLop.TabIndex = 4;
            // 
            // cboGiaoVien
            // 
            this.cboGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGiaoVien.FormattingEnabled = true;
            this.cboGiaoVien.Location = new System.Drawing.Point(498, 67);
            this.cboGiaoVien.Name = "cboGiaoVien";
            this.cboGiaoVien.Size = new System.Drawing.Size(178, 26);
            this.cboGiaoVien.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.LightGreen;
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTimKiem.Location = new System.Drawing.Point(35, 122);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(102, 23);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(154, 122);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(97, 23);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(495, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Có thể kết hợp nhiều tiêu chí";
            // 
            // grpKetQua
            // 
            this.grpKetQua.Controls.Add(this.lblSoKetQua);
            this.grpKetQua.Controls.Add(this.dgvKetQua);
            this.grpKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKetQua.Location = new System.Drawing.Point(14, 221);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(994, 364);
            this.grpKetQua.TabIndex = 2;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Kết quả tra cứu";
            this.grpKetQua.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            this.dgvKetQua.Size = new System.Drawing.Size(982, 309);
            this.dgvKetQua.TabIndex = 1;
            // 
            // lblSoKetQua
            // 
            this.lblSoKetQua.AutoSize = true;
            this.lblSoKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoKetQua.Location = new System.Drawing.Point(835, 20);
            this.lblSoKetQua.Name = "lblSoKetQua";
            this.lblSoKetQua.Size = new System.Drawing.Size(68, 18);
            this.lblSoKetQua.TabIndex = 10;
            this.lblSoKetQua.Text = "Tìm thấy:";
            // 
            // FormTimKiemLichHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 597);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormTimKiemLichHoc";
            this.Text = "TimKiemLichHoc";
            this.Load += new System.EventHandler(this.FormTimKiemLichHoc_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.ComboBox cboGiaoVien;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboCaDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Label lblSoKetQua;
    }
}