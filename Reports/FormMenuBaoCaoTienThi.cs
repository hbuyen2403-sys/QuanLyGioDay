using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    public partial class FormMenuBaoCaoTienThi : Form
    {
        public FormMenuBaoCaoTienThi() { InitializeComponent(); }

        private void FormMenuBaoCaoTienThi_Load(object sender, EventArgs e)
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
                const string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY m.TenMon) AS STT,
    l.TenLop AS TenLop, m.TenMon AS TenMon, m.SoTiet AS SoTiet,
    l.SiSo AS SiSo, 5000 AS DonGia, ld.TienThi AS TienThi
FROM LichDay ld
JOIN LopHoc l ON ld.MaLop = l.MaLop
JOIN MonHoc m ON ld.MaMon = m.MaMon
JOIN GiaoVien g ON ld.MaGV = g.MaGV
WHERE ld.MaGV = @MaGV AND ld.KiHoc = @KiHoc AND ld.NamHoc = @NamHoc";
                DataTable dt = ReportData.Query(sql, cboGiaoVien, cboKyDay, cboNamHoc);
                ReportData.Bind(dgvKetQua, dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu tiền thi phù hợp với lựa chọn này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTongTienThi.Text = "0 VNĐ";
                    lblThongTin.Text = "Không có dữ liệu lịch thi.";
                    return;
                }
                decimal total = ReportData.Total(dt, "TienThi");
                lblTongTienThi.Text = total.ToString("N0") + " VNĐ";
                lblThongTin.Text = ReportData.Summary(
                    cboGiaoVien, cboKyDay, cboNamHoc, dt.Rows.Count, total,
                    false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tiền thi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trong bản EXE tham chiếu, chức năng in giấy vẫn chưa được triển khai.
        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in báo cáo đang được phát triển!", "Thông báo");
        }
    }
}
