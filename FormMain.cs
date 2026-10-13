using QuanLyGioDay.Forms_BaoCao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyGioDay
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            HienThiThongTinTaiKhoan();
            HienThiThongBao();
            LoadThongKe();
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
            childForm.WindowState = FormWindowState.Maximized;

        }


        // --- CÁC SỰ KIỆN CLICK (ĐÃ DỌN SẠCH RUỘT ĐỂ THÀNH VIÊN TỰ ĐIỀN) ---

        // 1. Nhóm Danh Mục
        private void menuKhoa_Click(object sender, EventArgs e)
        {
            // Thành viên phụ trách Danh Mục điền Form vào đây
            Forms_DanhMuc.FormKhoa frm = new Forms_DanhMuc.FormKhoa();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuBoMon_Click(object sender, EventArgs e)
        {
            Forms_DanhMuc.FormBoMon frm = new Forms_DanhMuc.FormBoMon();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuTrinhDo_Click(object sender, EventArgs e)
        {
            Forms_DanhMuc.FormTrinhDo frm = new Forms_DanhMuc.FormTrinhDo();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuChuyenNganh_Click(object sender, EventArgs e)
        {
            Forms_DanhMuc.FormChuyenNganh frm = new Forms_DanhMuc.FormChuyenNganh();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuMonHoc_Click(object sender, EventArgs e)
        {
            Forms_DanhMuc.FormMonHoc frm = new Forms_DanhMuc.FormMonHoc();
            OpenChildForm(frm);
            panel2.SendToBack();
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
            Forms_BaoCao.FormMenuBaoCaoTienDay frm = new Forms_BaoCao.FormMenuBaoCaoTienDay();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuBaoCaoTienThi_Click(object sender, EventArgs e)
        {
            Forms_BaoCao.FormMenuBaoCaoTienThi frm = new Forms_BaoCao.FormMenuBaoCaoTienThi();
            OpenChildForm(frm);
            panel2.SendToBack();
        }

        private void menuInLichChuaKetThuc_Click(object sender, EventArgs e)
        {
            FormInLichChuaKetThuc frm = new FormInLichChuaKetThuc();
            frm.ShowDialog();
        }
        //Phần admin bên trái
        private void HienThiThongTinTaiKhoan()
        {
            lblTenDangNhap.Text = "Admin";
            lblVaiTro.Text = "Quản trị viên";
            lblTrangThai.Text = "Đã đăng nhập";

            lblNgayDangNhap.Text =
                "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void menuInTKBGiaoVien_Click(object sender, EventArgs e)
        {
            FormInThoiKhoaBieu frm = new FormInThoiKhoaBieu();
            frm.Show();
            lblThoiGian.Text =
                "Giờ: " + DateTime.Now.ToString("HH:mm:ss");
        }
        private void HienThiThongBao()
        {
            lstThongBao.Items.Clear();

            lstThongBao.Items.Add(
                "Hệ thống đã sẵn sàng");

            lstThongBao.Items.Add(
                "Kết nối cơ sở dữ liệu thành công");

            lstThongBao.Items.Add(
                "Chào mừng quản trị viên");
        }
        

        private void LoadThongKe()
        {
            try
            {
                string sql = @"
            SELECT
                (SELECT COUNT(*) FROM GiaoVien) AS TongGiaoVien,
                (SELECT COUNT(*) FROM MonHoc) AS TongMonHoc,
                (SELECT COUNT(*) FROM LopHoc) AS TongLopHoc,
                (SELECT COUNT(*) FROM LichDay) AS TongLichDay
        ";

                DataTable dt = Database.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    label1.Text =
                        dt.Rows[0]["TongGiaoVien"].ToString();

                    lbl2.Text =
                        dt.Rows[0]["TongMonHoc"].ToString();

                    lbl3.Text =
                        dt.Rows[0]["TongLopHoc"].ToString();

                    lbl4.Text =
                        dt.Rows[0]["TongLichDay"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải thống kê: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void RefreshThongKe()
        {
            LoadThongKe();
        }

    }
}