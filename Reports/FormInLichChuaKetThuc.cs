using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    public partial class FormInLichChuaKetThuc : Form
    {
        public FormInLichChuaKetThuc() { InitializeComponent(); }

        private void FormInLichChuaKetThuc_Load(object sender, EventArgs e)
        {
            LoadDanhSachLichChuaKetThuc();
        }

        private void LoadDanhSachLichChuaKetThuc()
        {
            try
            {
                const string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY ld.ThoiGianBD) AS STT,
    ld.MaLop AS MaLop, lh.TenLop AS TenLop, mh.TenMon AS TenMon,
    gv.TenGV AS TenGV, ld.ThuDay1 AS ThuDay1, ld.CaDay1 AS CaDay1,
    ld.ThoiGianBD AS ThoiGianBD, ld.ThoiGianKT AS ThoiGianKT
FROM LichDay ld
JOIN LopHoc lh ON ld.MaLop = lh.MaLop
JOIN MonHoc mh ON ld.MaMon = mh.MaMon
JOIN GiaoVien gv ON ld.MaGV = gv.MaGV
WHERE ld.ThoiGianKT >= GETDATE()";
                DataTable data = Database.GetData(sql);
                ReportData.Bind(dgvLichChuaKetThuc, data);
                lblTongSoLich.Text = string.Format("Tổng số lịch học chưa kết thúc: {0} lịch", data.Rows.Count);
                if (data.Rows.Count == 0)
                    MessageBox.Show("Hiện tại không có lịch học nào chưa kết thúc trong cơ sở dữ liệu!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lịch học chưa kết thúc: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
