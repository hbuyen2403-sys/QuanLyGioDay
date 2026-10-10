using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyGioDay.Forms_TimKiem
{
    public partial class FormTimKiemGiaoVien : Form
    {
        private bool dangNapDuLieu = false;

        public FormTimKiemGiaoVien()
        {
            InitializeComponent();

            // Gan su kien mot lan, tranh phu thuoc vao thao tac trong Designer.
            Load -= FormTimKiemGiaoVien_Load;
            Load += FormTimKiemGiaoVien_Load;
            btnTimKiem.Click -= btnTimKiem_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            cboKhoa.SelectedIndexChanged -= cboKhoa_SelectedIndexChanged;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
        }

        private void FormTimKiemGiaoVien_Load(object sender, EventArgs e)
        {
            try
            {
                CauHinhGiaoDien();
                dangNapDuLieu = true;
                NapKhoa();
                dangNapDuLieu = false;
                NapBoLocTheoKhoa();
                TimKiem();
            }
            catch (Exception ex)
            {
                dangNapDuLieu = false;
                BaoLoi("Không tải được dữ liệu giáo viên", ex);
            }
        }

        private void CauHinhGiaoDien()
        {
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonDay.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void NapKhoa()
        {
            DataTable dt = Database.GetData(
                "SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa");
            GanCombo(cboKhoa, dt, "MaKhoa", "TenKhoa");
        }

        private void NapBoLocTheoKhoa()
        {
            bool truocDo = dangNapDuLieu;
            dangNapDuLieu = true;
            try
            {
                object maKhoa = GiaTriLoc(cboKhoa);

                // Chuyen nganh va mon day chi hien cac gia tri ma giao vien
                // cua khoa dang chon thuc su co, giup tranh loc ra ket qua rong.
                const string sqlChuyenNganh = @"
                    SELECT DISTINCT CN.MaChNganh, CN.TenChNganh
                    FROM ChuyenNganh CN
                    INNER JOIN GiaoVien GV ON GV.MaChNganh = CN.MaChNganh
                    WHERE (@MaKhoa IS NULL OR GV.MaKhoa = @MaKhoa)
                    ORDER BY CN.TenChNganh";

                DataTable chuyenNganh = Database.ExecuteQuery(sqlChuyenNganh,
                    new[] { ThamSoKhoa(maKhoa) });
                GanCombo(cboChuyenNganh, chuyenNganh, "MaChNganh", "TenChNganh");

                const string sqlMonDay = @"
                    SELECT DISTINCT MH.MaMon, MH.TenMon
                    FROM MonHoc MH
                    INNER JOIN GiaoVien_MonDay GVM ON GVM.MaMon = MH.MaMon
                    INNER JOIN GiaoVien GV ON GV.MaGV = GVM.MaGV
                    WHERE (@MaKhoa IS NULL OR GV.MaKhoa = @MaKhoa)
                    ORDER BY MH.TenMon";

                DataTable monDay = Database.ExecuteQuery(sqlMonDay,
                    new[] { ThamSoKhoa(maKhoa) });
                GanCombo(cboMonDay, monDay, "MaMon", "TenMon");
            }
            finally
            {
                dangNapDuLieu = truocDo;
            }
        }

        private static SqlParameter ThamSoKhoa(object maKhoa)
        {
            return new SqlParameter("@MaKhoa", SqlDbType.NVarChar, 20)
            {
                Value = maKhoa
            };
        }

        private static void GanCombo(ComboBox cbo, DataTable dt,
            string cotMa, string cotTen)
        {
            cbo.DataSource = null;
            DataRow tatCa = dt.NewRow();
            tatCa[cotTen] = "Tất cả";
            dt.Rows.InsertAt(tatCa, 0);

            cbo.DisplayMember = cotTen;
            cbo.ValueMember = cotMa;
            cbo.DataSource = dt;
            cbo.SelectedIndex = 0;
        }

        private static object GiaTriLoc(ComboBox cbo)
        {
            if (cbo.SelectedIndex <= 0 || cbo.SelectedValue == null ||
                cbo.SelectedValue == DBNull.Value ||
                cbo.SelectedValue is DataRowView)
                return DBNull.Value;

            return cbo.SelectedValue;
        }

        private void TimKiem()
        {
            // EXISTS loc theo mon ma khong lam trung dong giao vien.
            // STUFF + FOR XML PATH gom nhieu mon day thanh mot o hien thi.
            const string sql = @"
                SELECT
                    GV.MaGV AS [Mã GV],
                    GV.TenGV AS [Họ tên giáo viên],
                    K.TenKhoa AS [Khoa],
                    ISNULL(CN.TenChNganh, N'Chưa cập nhật') AS [Chuyên ngành],
                    BM.TenBM AS [Bộ môn],
                    ISNULL(GV.DienThoai, N'') AS [Điện thoại],
                    ISNULL(
                        STUFF((
                            SELECT N', ' + MH.TenMon
                            FROM GiaoVien_MonDay GVM2
                            INNER JOIN MonHoc MH ON MH.MaMon = GVM2.MaMon
                            WHERE GVM2.MaGV = GV.MaGV
                            ORDER BY MH.TenMon
                            FOR XML PATH(''), TYPE
                        ).value('.', 'NVARCHAR(MAX)'), 1, 2, N''),
                        N'Chưa phân công'
                    ) AS [Môn dạy]
                FROM GiaoVien GV
                INNER JOIN Khoa K ON K.MaKhoa = GV.MaKhoa
                LEFT JOIN ChuyenNganh CN ON CN.MaChNganh = GV.MaChNganh
                LEFT JOIN BoMon BM ON BM.MaBM = GV.MaBM
                WHERE (@HoTen = N'' OR GV.TenGV LIKE N'%' + @HoTen + N'%')
                  AND (@MaKhoa IS NULL OR GV.MaKhoa = @MaKhoa)
                  AND (@MaChNganh IS NULL OR GV.MaChNganh = @MaChNganh)
                  AND (@MaMon IS NULL OR EXISTS (
                      SELECT 1 FROM GiaoVien_MonDay GVM
                      WHERE GVM.MaGV = GV.MaGV AND GVM.MaMon = @MaMon
                  ))
                ORDER BY GV.TenGV, GV.MaGV";

            SqlParameter[] thamSo =
            {
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100)
                { Value = txtHoTen.Text.Trim() },
                new SqlParameter("@MaKhoa", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboKhoa) },
                new SqlParameter("@MaChNganh", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboChuyenNganh) },
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20)
                { Value = GiaTriLoc(cboMonDay) }
            };

            DataTable ketQua = Database.ExecuteQuery(sql, thamSo);
            dgvKetQua.DataSource = ketQua;

            if (dgvKetQua.Columns.Contains("Môn dạy"))
                dgvKetQua.Columns["Môn dạy"].Width = 220;

            dgvKetQua.ClearSelection();
            dgvKetQua.CurrentCell = null;
            lblSoKetQua.Text = "Tìm thấy: " + ketQua.Rows.Count + " giáo viên";
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu) return;
            try
            {
                NapBoLocTheoKhoa();
            }
            catch (Exception ex)
            {
                BaoLoi("Không lọc được chuyên ngành và môn dạy theo khoa", ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                TimKiem();
            }
            catch (Exception ex)
            {
                BaoLoi("Lỗi tìm kiếm giáo viên", ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                dangNapDuLieu = true;
                txtHoTen.Clear();
                if (cboKhoa.Items.Count > 0)
                    cboKhoa.SelectedIndex = 0;
                dangNapDuLieu = false;

                NapBoLocTheoKhoa();
                TimKiem();
            }
            catch (Exception ex)
            {
                dangNapDuLieu = false;
                BaoLoi("Lỗi làm mới tìm kiếm", ex);
            }
        }

        private static void BaoLoi(string thongBao, Exception ex)
        {
            MessageBox.Show(thongBao + ": " + ex.Message,
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
