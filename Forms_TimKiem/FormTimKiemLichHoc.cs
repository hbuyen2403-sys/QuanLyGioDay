using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyGioDay.Forms_TimKiem
{
    public partial class FormTimKiemLichHoc : Form
    {
        public FormTimKiemLichHoc()
        {
            InitializeComponent();

            // Dang ky su kien mot lan, ke ca khi Designer da gan truoc do.
            Load -= FormTimKiemLichHoc_Load;
            Load += FormTimKiemLichHoc_Load;
            btnTimKiem.Click -= btnTimKiem_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void FormTimKiemLichHoc_Load(object sender, EventArgs e)
        {
            try
            {
                CauHinhBangKetQua();
                NapBoLoc();
                TimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu tìm kiếm: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhBangKetQua()
        {
            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            cboCaDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGiaoVien.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void NapBoLoc()
        {
            const string sqlCa = @"
                SELECT DISTINCT LTRIM(RTRIM(B.CaDay)) AS CaDay
                FROM LichDay LD
                CROSS APPLY (VALUES (LD.CaDay1), (LD.CaDay2)) AS B(CaDay)
                WHERE B.CaDay IS NOT NULL
                  AND LTRIM(RTRIM(B.CaDay)) <> N''
                ORDER BY CaDay";

            NapComboBox(cboCaDay, sqlCa, "CaDay", "CaDay");
            NapComboBox(cboLop,
                "SELECT MaLop, TenLop FROM LopHoc ORDER BY TenLop",
                "MaLop", "TenLop");
            NapComboBox(cboGiaoVien,
                "SELECT MaGV, TenGV FROM GiaoVien ORDER BY TenGV",
                "MaGV", "TenGV");
        }

        private void NapComboBox(ComboBox cbo, string sql,
            string cotGiaTri, string cotHienThi)
        {
            DataTable dt = Database.GetData(sql);
            DataRow tatCa = dt.NewRow();
            tatCa[cotHienThi] = "Tất cả";
            dt.Rows.InsertAt(tatCa, 0);

            cbo.DisplayMember = cotHienThi;
            cbo.ValueMember = cotGiaTri;
            cbo.DataSource = dt;
            cbo.SelectedIndex = 0;
        }

        private object GiaTriLoc(ComboBox cbo)
        {
            if (cbo.SelectedIndex <= 0 || cbo.SelectedValue == null ||
                cbo.SelectedValue is DataRowView)
                return DBNull.Value;

            return cbo.SelectedValue;
        }

        private void TimKiem()
        {
            // Moi cap Thu/Ca la mot buoi trong thoi khoa bieu hang tuan.
            // CROSS APPLY giup tim ca 1 lan ca 2 ma khong bo sot lich.
            const string sql = @"
                SELECT
                    LH.TenLop AS [Lớp học],
                    MH.TenMon AS [Môn học],
                    GV.TenGV AS [Giáo viên],
                    Buoi.ThuDay AS [Thứ dạy],
                    Buoi.CaDay AS [Ca dạy],
                    LD.KiHoc AS [Kỳ học],
                    LD.NamHoc AS [Năm học],
                    LD.ThoiGianBD AS [Ngày bắt đầu],
                    LD.ThoiGianKT AS [Ngày kết thúc],
                    LH.SiSo AS [Sĩ số],
                    LD.GhiChu AS [Ghi chú]
                FROM LichDay LD
                INNER JOIN LopHoc LH ON LH.MaLop = LD.MaLop
                INNER JOIN MonHoc MH ON MH.MaMon = LD.MaMon
                INNER JOIN GiaoVien GV ON GV.MaGV = LD.MaGV
                CROSS APPLY (
                    VALUES (LD.ThuDay1, LD.CaDay1),
                           (LD.ThuDay2, LD.CaDay2)
                ) AS Buoi(ThuDay, CaDay)
                WHERE LTRIM(RTRIM(ISNULL(Buoi.CaDay, N''))) <> N''
                  AND (@CaDay IS NULL OR LTRIM(RTRIM(Buoi.CaDay)) = @CaDay)
                  AND (@MaLop IS NULL OR LD.MaLop = @MaLop)
                  AND (@MaGV IS NULL OR LD.MaGV = @MaGV)
                ORDER BY LH.TenLop, LD.ThoiGianBD, Buoi.ThuDay, Buoi.CaDay";

            SqlParameter[] thamSo =
            {
                new SqlParameter("@CaDay", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboCaDay) },
                new SqlParameter("@MaLop", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboLop) },
                new SqlParameter("@MaGV", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboGiaoVien) }
            };

            DataTable ketQua = Database.ExecuteQuery(sql, thamSo);
            dgvKetQua.DataSource = ketQua;

            if (dgvKetQua.Columns.Contains("Ngày bắt đầu"))
                dgvKetQua.Columns["Ngày bắt đầu"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvKetQua.Columns.Contains("Ngày kết thúc"))
                dgvKetQua.Columns["Ngày kết thúc"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvKetQua.ClearSelection();
            dgvKetQua.CurrentCell = null;
            lblSoKetQua.Text = "Tìm thấy: " + ketQua.Rows.Count + " buổi dạy";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                TimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm lịch học: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                cboCaDay.SelectedIndex = 0;
                cboLop.SelectedIndex = 0;
                cboGiaoVien.SelectedIndex = 0;
                TimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mới dữ liệu: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Giữ lại vì Designer có thể đang liên kết sự kiện này.
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}
