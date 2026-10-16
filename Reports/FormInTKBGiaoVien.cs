using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    public partial class FormInTKBGiaoVien : Form
    {
        public FormInTKBGiaoVien() { InitializeComponent(); }

        private void FormInTKBGiaoVien_Load(object sender, EventArgs e)
        {
            try
            {
                ReportData.LoadTeachers(cboGiaoVien);
                ReportData.LoadTerms(cboKyDay, cboNamHoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách giáo viên: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!ReportData.HasSelection(cboGiaoVien, cboKyDay, cboNamHoc)) return;
            try
            {
                const string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY ld.ThoiGianBD) AS STT,
    l.TenLop AS TenLop, m.TenMon AS TenMon, m.SoTiet AS SoTiet,
    ld.ThuDay1 AS ThuDay1, ld.CaDay1 AS CaDay1,
    ld.ThoiGianBD AS ThoiGianBD, ld.ThoiGianKT AS ThoiGianKT,
    ld.GhiChu AS GhiChu
FROM LichDay ld
JOIN LopHoc l ON ld.MaLop = l.MaLop
JOIN MonHoc m ON ld.MaMon = m.MaMon
WHERE ld.MaGV = @MaGV AND ld.KiHoc = @KiHoc AND ld.NamHoc = @NamHoc";
                DataTable dt = ReportData.Query(sql, cboGiaoVien, cboKyDay, cboNamHoc);
                ReportData.Bind(dgvKetQua, dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có thời khóa biểu nào phù hợp với lựa chọn này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongTin.Text = "Không có dữ liệu thời khóa biểu.";
                    return;
                }
                lblThongTin.Text = string.Format(
                    "Giáo viên: {0} ({1}) | Kỳ: {2} - Năm học: {3} | Tổng số lớp giảng dạy: {4}",
                    ReportData.SelectedTeacherName(cboGiaoVien), cboGiaoVien.SelectedValue,
                    cboKyDay.SelectedItem, cboNamHoc.SelectedItem, dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
