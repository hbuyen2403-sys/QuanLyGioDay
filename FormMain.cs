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

        // --- HÀM MỞ FORM CON DÙNG CHUNG ---
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

        // --- CÁC SỰ KIỆN CLICK (ĐÃ DỌN SẠCH RUỘT ĐỂ THÀNH VIÊN TỰ ĐIỀN) ---

        // 1. Nhóm Danh Mục
        private void menuKhoa_Click(object sender, EventArgs e)
        {
            // Thành viên phụ trách Danh Mục điền Form vào đây
        }

        private void menuBoMon_Click(object sender, EventArgs e)
        {

        }

        private void menuTrinhDo_Click(object sender, EventArgs e)
        {

        }

        private void menuChuyenNganh_Click(object sender, EventArgs e)
        {

        }

        private void menuMonHoc_Click(object sender, EventArgs e)
        {

        }

        // 2. Nhóm Hồ Sơ & Giáo Viên
        private void menuGiaoVien_Click(object sender, EventArgs e)
        {

        }

        private void menuLopHoc_Click(object sender, EventArgs e)
        {

        }

        private void menuGVMonDay_Click(object sender, EventArgs e)
        {

        }

        // 3. Nhóm Lịch Dạy
        private void menuPhanCongLichDay_Click(object sender, EventArgs e)
        {

        }

        // 4. Nhóm Tìm Kiếm
        private void menuTimKiemLichHoc_Click(object sender, EventArgs e)
        {

        }

        private void menuTimKiemGiaoVien_Click(object sender, EventArgs e)
        {

        }

        // 5. Nhóm Báo Cáo
        private void menuBaoCaoTienDay_Click(object sender, EventArgs e)
        {

        }

        private void menuBaoCaoTienThi_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}