using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGioDay.Forms_LichDay;

namespace QuanLyGioDay
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        
        // --- DÁN HÀM DÙNG CHUNG VÀO ĐÂY ---
        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra nếu Form con đã mở rồi thì activate nó
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            // Thiết lập Form con nằm bên trong FormMain
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void menuKhoa_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Khoa" };
            OpenChildForm(frm);
        }

        private void menuBoMon_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Bộ môn" };
            OpenChildForm(frm);
        }

        private void menuTrinhDo_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Trình độ" };
            OpenChildForm(frm);
        }

        private void menuChuyenNganh_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Chuyên ngành" };
            OpenChildForm(frm);
        }

        private void menuMonHoc_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Môn học" };
            OpenChildForm(frm);
        }

        private void menuGiaoVien_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Giáo viên" };
            OpenChildForm(frm);
        }

        private void menuLopHoc_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Quản lý Lớp học" };
            OpenChildForm(frm);
        }

        private void menuGVMonDay_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Giáo viên - Môn dạy" };
            OpenChildForm(frm);
        }

        private void menuPhanCongLichDay_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Phân công Lịch dạy" };
            OpenChildForm(frm);
        }

        private void menuTimKiemLichHoc_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Tìm kiếm Lịch học" };
            OpenChildForm(frm);
        }

        private void menuTimKiemGiaoVien_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Tìm kiếm Giáo viên" };
            OpenChildForm(frm);
        }

        private void menuBaoCaoTienDay_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Thống kê Tiền dạy" };
            OpenChildForm(frm);
        }

        private void menuBaoCaoTienThi_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Text = "Thống kê Tiền thi" };
            OpenChildForm(frm);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        
    }
}


