namespace QuanLyGioDay
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Khoa");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lớp học");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Quản lí Hồ sơ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Quản lí Lịch dạy");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lịch học");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Báo cáo & In ấn");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("DANH MỤC CHỨC NĂNG", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrinhDo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChuyenNganh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLopHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGVMonDay = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLịchDạyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhanCongLichDay = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứTìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimKiemLichHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimKiemGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoInẤnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoTienDay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoTienThi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInLichChuaKetThuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInTKBGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.ForestGreen;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.quảnLýHồSơToolStripMenuItem,
            this.quảnLýLịchDạyToolStripMenuItem,
            this.traCứTìmKiếmToolStripMenuItem,
            this.báoCáoInẤnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1129, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView2);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 501);
            this.panel1.TabIndex = 3;
            // 
            // treeView2
            // 
            this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Margin = new System.Windows.Forms.Padding(4);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Khoa";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Lớp học";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Quản lí Hồ sơ";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Quản lí Lịch dạy";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Lịch học";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Báo cáo & In ấn";
            treeNode7.Name = "Node0";
            treeNode7.Text = "DANH MỤC CHỨC NĂNG";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(265, 497);
            this.treeView2.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder (2).png");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(267, 501);
            this.treeView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1129, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 20);
            this.toolStripStatusLabel1.Text = "Sẵn sàng";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(89, 20);
            this.toolStripStatusLabel2.Text = "User: Admin";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(127, 20);
            this.toolStripStatusLabel3.Text = "Ngày: 04/09/2026";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(290, 20);
            this.toolStripStatusLabel4.Text = "Kết nối CSDL: [QuanLyGioDay] Thành công";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuKhoa,
            this.menuBoMon,
            this.menuTrinhDo,
            this.menuChuyenNganh,
            this.menuMonHoc});
            this.danhMụcToolStripMenuItem.Image = global::QuanLyGioDay.Properties.Resources.list;
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // menuKhoa
            // 
            this.menuKhoa.Image = global::QuanLyGioDay.Properties.Resources.books__1_1;
            this.menuKhoa.Name = "menuKhoa";
            this.menuKhoa.Size = new System.Drawing.Size(185, 26);
            this.menuKhoa.Text = "Khoa";
            this.menuKhoa.Click += new System.EventHandler(this.menuKhoa_Click);
            // 
            // menuBoMon
            // 
            this.menuBoMon.Image = global::QuanLyGioDay.Properties.Resources.folder;
            this.menuBoMon.Name = "menuBoMon";
            this.menuBoMon.Size = new System.Drawing.Size(185, 26);
            this.menuBoMon.Text = "Bộ môn";
            this.menuBoMon.Click += new System.EventHandler(this.menuBoMon_Click);
            // 
            // menuTrinhDo
            // 
            this.menuTrinhDo.Image = global::QuanLyGioDay.Properties.Resources.baccalaureate1;
            this.menuTrinhDo.Name = "menuTrinhDo";
            this.menuTrinhDo.Size = new System.Drawing.Size(185, 26);
            this.menuTrinhDo.Text = "Trình độ";
            this.menuTrinhDo.Click += new System.EventHandler(this.menuTrinhDo_Click);
            // 
            // menuChuyenNganh
            // 
            this.menuChuyenNganh.Image = global::QuanLyGioDay.Properties.Resources.education2;
            this.menuChuyenNganh.Name = "menuChuyenNganh";
            this.menuChuyenNganh.Size = new System.Drawing.Size(185, 26);
            this.menuChuyenNganh.Text = "Chuyên ngành";
            this.menuChuyenNganh.Click += new System.EventHandler(this.menuChuyenNganh_Click);
            // 
            // menuMonHoc
            // 
            this.menuMonHoc.Image = global::QuanLyGioDay.Properties.Resources.books2;
            this.menuMonHoc.Name = "menuMonHoc";
            this.menuMonHoc.Size = new System.Drawing.Size(185, 26);
            this.menuMonHoc.Text = "Môn học";
            this.menuMonHoc.Click += new System.EventHandler(this.menuMonHoc_Click);
            // 
            // quảnLýHồSơToolStripMenuItem
            // 
            this.quảnLýHồSơToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGiaoVien,
            this.menuLopHoc,
            this.menuGVMonDay});
            this.quảnLýHồSơToolStripMenuItem.Image = global::QuanLyGioDay.Properties.Resources.folder__3_;
            this.quảnLýHồSơToolStripMenuItem.Name = "quảnLýHồSơToolStripMenuItem";
            this.quảnLýHồSơToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.quảnLýHồSơToolStripMenuItem.Text = "Quản lý Hồ sơ";
            // 
            // menuGiaoVien
            // 
            this.menuGiaoVien.Image = global::QuanLyGioDay.Properties.Resources.teacher1;
            this.menuGiaoVien.Name = "menuGiaoVien";
            this.menuGiaoVien.Size = new System.Drawing.Size(226, 26);
            this.menuGiaoVien.Text = "Giáo viên";
            this.menuGiaoVien.Click += new System.EventHandler(this.menuGiaoVien_Click);
            // 
            // menuLopHoc
            // 
            this.menuLopHoc.Image = global::QuanLyGioDay.Properties.Resources.lecture1;
            this.menuLopHoc.Name = "menuLopHoc";
            this.menuLopHoc.Size = new System.Drawing.Size(226, 26);
            this.menuLopHoc.Text = "Lớp học";
            this.menuLopHoc.Click += new System.EventHandler(this.menuLopHoc_Click);
            // 
            // menuGVMonDay
            // 
            this.menuGVMonDay.Image = global::QuanLyGioDay.Properties.Resources.teacher__1_1;
            this.menuGVMonDay.Name = "menuGVMonDay";
            this.menuGVMonDay.Size = new System.Drawing.Size(226, 26);
            this.menuGVMonDay.Text = "Giáo viên - Môn dạy";
            this.menuGVMonDay.Click += new System.EventHandler(this.menuGVMonDay_Click);
            // 
            // quảnLýLịchDạyToolStripMenuItem
            // 
            this.quảnLýLịchDạyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPhanCongLichDay});
            this.quảnLýLịchDạyToolStripMenuItem.Image = global::QuanLyGioDay.Properties.Resources.calendar__1_;
            this.quảnLýLịchDạyToolStripMenuItem.Name = "quảnLýLịchDạyToolStripMenuItem";
            this.quảnLýLịchDạyToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.quảnLýLịchDạyToolStripMenuItem.Text = "Quản lý Lịch dạy";
            // 
            // menuPhanCongLichDay
            // 
            this.menuPhanCongLichDay.Image = global::QuanLyGioDay.Properties.Resources.calendar1;
            this.menuPhanCongLichDay.Name = "menuPhanCongLichDay";
            this.menuPhanCongLichDay.Size = new System.Drawing.Size(222, 26);
            this.menuPhanCongLichDay.Text = "Phân công Lịch dạy.";
            this.menuPhanCongLichDay.Click += new System.EventHandler(this.menuPhanCongLichDay_Click);
            // 
            // traCứTìmKiếmToolStripMenuItem
            // 
            this.traCứTìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTimKiemLichHoc,
            this.menuTimKiemGiaoVien});
            this.traCứTìmKiếmToolStripMenuItem.Image = global::QuanLyGioDay.Properties.Resources.folder__4_;
            this.traCứTìmKiếmToolStripMenuItem.Name = "traCứTìmKiếmToolStripMenuItem";
            this.traCứTìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.traCứTìmKiếmToolStripMenuItem.Text = "Tra cứ & Tìm kiếm";
            // 
            // menuTimKiemLichHoc
            // 
            this.menuTimKiemLichHoc.Image = global::QuanLyGioDay.Properties.Resources.calendar__2_;
            this.menuTimKiemLichHoc.Name = "menuTimKiemLichHoc";
            this.menuTimKiemLichHoc.Size = new System.Drawing.Size(224, 26);
            this.menuTimKiemLichHoc.Text = "Lịch học";
            // 
            // menuTimKiemGiaoVien
            // 
            this.menuTimKiemGiaoVien.Image = global::QuanLyGioDay.Properties.Resources.user_avatar1;
            this.menuTimKiemGiaoVien.Name = "menuTimKiemGiaoVien";
            this.menuTimKiemGiaoVien.Size = new System.Drawing.Size(224, 26);
            this.menuTimKiemGiaoVien.Text = "Giáo viên";
            this.menuTimKiemGiaoVien.Click += new System.EventHandler(this.menuTimKiemGiaoVien_Click);
            // 
            // báoCáoInẤnToolStripMenuItem
            // 
            this.báoCáoInẤnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBaoCaoTienDay,
            this.menuBaoCaoTienThi,
            this.menuInLichChuaKetThuc,
            this.menuInTKBGiaoVien});
            this.báoCáoInẤnToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.báoCáoInẤnToolStripMenuItem.Image = global::QuanLyGioDay.Properties.Resources.file;
            this.báoCáoInẤnToolStripMenuItem.Name = "báoCáoInẤnToolStripMenuItem";
            this.báoCáoInẤnToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.báoCáoInẤnToolStripMenuItem.Text = "Báo cáo & In ấn";
            // 
            // menuBaoCaoTienDay
            // 
            this.menuBaoCaoTienDay.Image = global::QuanLyGioDay.Properties.Resources.health_check1;
            this.menuBaoCaoTienDay.Name = "menuBaoCaoTienDay";
            this.menuBaoCaoTienDay.Size = new System.Drawing.Size(224, 26);
            this.menuBaoCaoTienDay.Text = "Thống kê Tiền dạy";
            this.menuBaoCaoTienDay.Click += new System.EventHandler(this.menuBaoCaoTienDay_Click);
            // 
            // menuBaoCaoTienThi
            // 
            this.menuBaoCaoTienThi.Image = global::QuanLyGioDay.Properties.Resources.business_report1;
            this.menuBaoCaoTienThi.Name = "menuBaoCaoTienThi";
            this.menuBaoCaoTienThi.Size = new System.Drawing.Size(224, 26);
            this.menuBaoCaoTienThi.Text = "Thống kê Tiền thi";
            this.menuBaoCaoTienThi.Click += new System.EventHandler(this.menuBaoCaoTienThi_Click);
            // 
            // menuInLichChuaKetThuc
            // 
            this.menuInLichChuaKetThuc.Image = global::QuanLyGioDay.Properties.Resources.printing2;
            this.menuInLichChuaKetThuc.Name = "menuInLichChuaKetThuc";
            this.menuInLichChuaKetThuc.Size = new System.Drawing.Size(224, 26);
            this.menuInLichChuaKetThuc.Text = "In lịch chưa kết thúc";
            // 
            // menuInTKBGiaoVien
            // 
            this.menuInTKBGiaoVien.Image = global::QuanLyGioDay.Properties.Resources.printing2;
            this.menuInTKBGiaoVien.Name = "menuInTKBGiaoVien";
            this.menuInTKBGiaoVien.Size = new System.Drawing.Size(224, 26);
            this.menuInTKBGiaoVien.Text = "In TKB Giáo viên.";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ GIỜ DẠY GIÁO VIÊN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Click += new System.EventHandler(this.menuTimKiemLichHoc_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuKhoa;
        private System.Windows.Forms.ToolStripMenuItem menuBoMon;
        private System.Windows.Forms.ToolStripMenuItem menuTrinhDo;
        private System.Windows.Forms.ToolStripMenuItem menuChuyenNganh;
        private System.Windows.Forms.ToolStripMenuItem menuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHồSơToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem menuLopHoc;
        private System.Windows.Forms.ToolStripMenuItem menuGVMonDay;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLịchDạyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPhanCongLichDay;
        private System.Windows.Forms.ToolStripMenuItem traCứTìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTimKiemLichHoc;
        private System.Windows.Forms.ToolStripMenuItem menuTimKiemGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem báoCáoInẤnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTienDay;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTienThi;
        private System.Windows.Forms.ToolStripMenuItem menuInLichChuaKetThuc;
        private System.Windows.Forms.ToolStripMenuItem menuInTKBGiaoVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ImageList imageList1;
    }
}

