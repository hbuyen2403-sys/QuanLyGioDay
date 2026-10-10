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
            dtpNgayXem.Value = DateTime.Today;

            dtpNgayXem.ValueChanged += dtpNgayXem_ValueChanged;
            btnHomNay.Click += btnHomNay_Click;

            TaiLichTrongNgay();
        }

        // --- HÀM MỞ FORM CON DÙNG CHUNG ---
        private void menuTrangChu_Click(object sender, EventArgs e)
{
    // Đóng các Form con đang mở
    foreach (Form frm in this.MdiChildren)
    {
        frm.Close();
    }

    // Hiện lại Dashboard
    panel2.BringToFront();

    // Tải lại lịch của ngày đang chọn
    TaiLichTrongNgay();
}
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
            Forms_LichDay.FormLichDay frm =
      new Forms_LichDay.FormLichDay();

            OpenChildForm(frm);
            panel2.SendToBack();
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
        //Phần admin bên trái
        private void HienThiThongTinTaiKhoan()
        {
            lblTenDangNhap.Text = "Admin";
            lblVaiTro.Text = "Quản trị viên";
            lblTrangThai.Text = "Đã đăng nhập";

            lblNgayDangNhap.Text =
                "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // ===== DASHBOARD: LỊCH GIẢNG DẠY TRONG NGÀY =====

        private string LayThuTrongTuan(DateTime ngay)
        {
            switch (ngay.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                default: return "Chủ nhật";
            }
        }

        private void TaiLichTrongNgay()
        {
            try
            {
                DateTime ngay = dtpNgayXem.Value.Date;
                string thu = LayThuTrongTuan(ngay);

                string sql = @"
                    SELECT
                        Buoi.CaDay AS [Ca học],
                        LH.TenLop AS [Lớp học],
                        MH.TenMon AS [Môn học],
                        GV.TenGV AS [Giảng viên],
                        LH.SiSo AS [Sĩ số],
                        LD.GhiChu AS [Ghi chú]
                    FROM LichDay LD
                    INNER JOIN LopHoc LH ON LD.MaLop = LH.MaLop
                    INNER JOIN MonHoc MH ON LD.MaMon = MH.MaMon
                    INNER JOIN GiaoVien GV ON LD.MaGV = GV.MaGV
                    CROSS APPLY (
                        VALUES
                            (LD.ThuDay1, LD.CaDay1),
                            (LD.ThuDay2, LD.CaDay2)
                    ) AS Buoi(ThuDay, CaDay)
                    WHERE
                        @Ngay BETWEEN LD.ThoiGianBD AND LD.ThoiGianKT
                        AND LTRIM(RTRIM(Buoi.ThuDay)) = @Thu
                        AND Buoi.CaDay IS NOT NULL
                    ORDER BY Buoi.CaDay, LH.TenLop;
                ";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Ngay", SqlDbType.Date)
                    {
                        Value = ngay
                    },
                    new SqlParameter("@Thu", SqlDbType.NVarChar, 20)
                    {
                        Value = thu
                    }
                };

                DataTable dt = Database.ExecuteQuery(sql, parameters);

                dgvLichTrongNgay.AutoGenerateColumns = true;
                dgvLichTrongNgay.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                dgvLichTrongNgay.DataSource = dt;

                dgvLichTrongNgay.ReadOnly = true;
                dgvLichTrongNgay.AllowUserToAddRows = false;
                dgvLichTrongNgay.AllowUserToDeleteRows = false;
                dgvLichTrongNgay.RowHeadersVisible = false;
                dgvLichTrongNgay.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải lịch dạy: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dtpNgayXem_ValueChanged(object sender, EventArgs e)
        {
            TaiLichTrongNgay();
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            if (dtpNgayXem.Value.Date == DateTime.Today)
                TaiLichTrongNgay();
            else
                dtpNgayXem.Value = DateTime.Today;
        }

        private void toolStripTrangChủ_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            panel2.BringToFront();
            TaiLichTrongNgay();
        }
    }
}