using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyGioDay.Forms_LichDay
{
    public partial class FormLichDay : Form
    {
        private bool dangNapDuLieu;
        private string maLopCu, maMonCu, kiHocCu, namHocCu;
        private string ghiChuCu = "";
        private decimal tienDayHienTai;
        private decimal tienThiHienTai;

        public FormLichDay()
        {
            InitializeComponent();
            // Hoat dong ca khi su kien Load chua duoc gan trong Designer.
            this.Load -= FormLichDay_Load;
            this.Load += FormLichDay_Load;
        }

        private void FormLichDay_Load(object sender, EventArgs e)
        {
            try
            {
                dangNapDuLieu = true;
                CauHinhGiaoDien();
                GanSuKien();
                NapLopHoc();
                NapDanhSachLichDay();
            }
            catch (Exception ex)
            {
                BaoLoi("Không tải được dữ liệu lịch dạy", ex);
            }
            finally
            {
                dangNapDuLieu = false;
                LamMoiThongTin();
            }
        }

        // Cac ham rong da duoc Designer lien ket: GIU LAI de tranh loi biên dich.
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void dgvLichDay_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }

        private void CauHinhGiaoDien()
        {
            foreach (ComboBox cbo in new[]
            {
                cboLop, cboMon, cboGiaoVien, cboKiHoc,
                cboThu1, cboCa1, cboThu2, cboCa2
            })
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.IntegralHeight = false;
                cbo.DropDownHeight = 180;
            }

            cboKiHoc.Items.Clear();
            cboKiHoc.Items.AddRange(new object[] { "1", "2", "3" });

            object[] thu = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ nhật" };
            object[] ca = { "Ca 1", "Ca 2", "Ca 3", "Ca 4" };
            cboThu1.Items.Clear();
            cboThu2.Items.Clear();
            cboCa1.Items.Clear();
            cboCa2.Items.Clear();
            cboThu1.Items.AddRange(thu);
            cboThu2.Items.AddRange(thu);
            cboCa1.Items.AddRange(ca);
            cboCa2.Items.AddRange(ca);

            cboMon.Enabled = false;
            cboGiaoVien.Enabled = false;
            txtTienDay.ReadOnly = true;
            txtTienThi.ReadOnly = true;
            dtpBatDau.Format = DateTimePickerFormat.Short;
            dtpKetThuc.Format = DateTimePickerFormat.Short;

            // Thiet lap che do chon TRUOC khi DataGridView sinh cot.
            dgvLichDay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichDay.MultiSelect = false;
            dgvLichDay.ReadOnly = true;
            dgvLichDay.AllowUserToAddRows = false;
            dgvLichDay.AllowUserToDeleteRows = false;
            dgvLichDay.RowHeadersVisible = false;
            dgvLichDay.AutoGenerateColumns = true;
            dgvLichDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void GanSuKien()
        {
            // Tranh dang ky hai lan neu su kien da duoc gan qua Designer.
            cboLop.SelectedIndexChanged -= cboLop_SelectedIndexChanged;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            cboMon.SelectedIndexChanged -= cboMon_SelectedIndexChanged;
            cboMon.SelectedIndexChanged += cboMon_SelectedIndexChanged;
            cboGiaoVien.SelectedIndexChanged -= cboGiaoVien_SelectedIndexChanged;
            cboGiaoVien.SelectedIndexChanged += cboGiaoVien_SelectedIndexChanged;
            dgvLichDay.CellClick -= dgvLichDay_CellClick;
            dgvLichDay.CellClick += dgvLichDay_CellClick;

            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private static string MaDangChon(ComboBox combo)
        {
            if (combo.SelectedIndex < 0 || combo.SelectedValue == null ||
                combo.SelectedValue == DBNull.Value || combo.SelectedValue is DataRowView)
                return null;
            return Convert.ToString(combo.SelectedValue);
        }

        private static void GanDanhSach(ComboBox combo, DataTable dt, string cotMa, string cotTen)
        {
            combo.DataSource = null;
            combo.DisplayMember = cotTen;
            combo.ValueMember = cotMa;
            combo.DataSource = dt;
            combo.SelectedIndex = -1;
        }

        private void NapLopHoc()
        {
            DataTable dt = Database.GetData("SELECT MaLop, TenLop FROM LopHoc ORDER BY TenLop");
            GanDanhSach(cboLop, dt, "MaLop", "TenLop");
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu) return;
            try
            {
                NapMonTheoLop();
                TinhTien();
            }
            catch (Exception ex) { BaoLoi("Không lọc được môn học theo lớp", ex); }
        }

        private void NapMonTheoLop()
        {
            bool truocDo = dangNapDuLieu;
            dangNapDuLieu = true;
            try
            {
                cboMon.DataSource = null;
                cboGiaoVien.DataSource = null;
                cboMon.Enabled = false;
                cboGiaoVien.Enabled = false;
                string maLop = MaDangChon(cboLop);
                if (maLop == null) return;

                const string sql = @"
                    SELECT MH.MaMon, MH.TenMon
                    FROM MonHoc MH
                    INNER JOIN LopHoc LH ON MH.MaKhoa = LH.MaKhoa
                    WHERE LH.MaLop = @MaLop
                    ORDER BY MH.TenMon";
                DataTable dt = Database.ExecuteQuery(sql, new[]
                {
                    new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop }
                });
                GanDanhSach(cboMon, dt, "MaMon", "TenMon");
                cboMon.Enabled = dt.Rows.Count > 0;
            }
            finally { dangNapDuLieu = truocDo; }
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu) return;
            try
            {
                NapGiaoVienTheoMon();
                TinhTien();
            }
            catch (Exception ex) { BaoLoi("Không lọc được giáo viên theo môn", ex); }
        }

        private void NapGiaoVienTheoMon()
        {
            bool truocDo = dangNapDuLieu;
            dangNapDuLieu = true;
            try
            {
                cboGiaoVien.DataSource = null;
                cboGiaoVien.Enabled = false;
                string maMon = MaDangChon(cboMon);
                if (maMon == null) return;

                const string sql = @"
                    SELECT DISTINCT GV.MaGV, GV.TenGV
                    FROM GiaoVien GV
                    INNER JOIN GiaoVien_MonDay GVM ON GVM.MaGV = GV.MaGV
                    WHERE GVM.MaMon = @MaMon
                    ORDER BY GV.TenGV";
                DataTable dt = Database.ExecuteQuery(sql, new[]
                {
                    new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon }
                });
                GanDanhSach(cboGiaoVien, dt, "MaGV", "TenGV");
                cboGiaoVien.Enabled = dt.Rows.Count > 0;
            }
            finally { dangNapDuLieu = truocDo; }
        }

        private void cboGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu) return;
            try { TinhTien(); }
            catch (Exception ex) { BaoLoi("Không tính được tiền dạy", ex); }
        }

        private void TinhTien()
        {
            tienDayHienTai = tienThiHienTai = 0m;
            txtTienDay.Clear();
            txtTienThi.Clear();
            string maLop = MaDangChon(cboLop);
            if (maLop == null) return;

            DataTable lop = Database.ExecuteQuery(
                "SELECT ISNULL(SiSo, 0) AS SiSo FROM LopHoc WHERE MaLop = @MaLop",
                new[] { new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop } });
            if (lop.Rows.Count == 0) return;

            int siSo = Convert.ToInt32(lop.Rows[0]["SiSo"]);
            tienThiHienTai = siSo * 5000m;
            txtTienThi.Text = tienThiHienTai.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));

            string maMon = MaDangChon(cboMon);
            string maGV = MaDangChon(cboGiaoVien);
            if (maMon == null || maGV == null) return;

            const string sql = @"
                SELECT ISNULL(MH.SoTiet, 0) AS SoTiet,
                       ISNULL(GV.LuongTiet, 0) AS LuongTiet
                FROM MonHoc MH CROSS JOIN GiaoVien GV
                WHERE MH.MaMon = @MaMon AND GV.MaGV = @MaGV";
            DataTable dt = Database.ExecuteQuery(sql, new[]
            {
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon },
                new SqlParameter("@MaGV", SqlDbType.NVarChar, 20) { Value = maGV }
            });
            if (dt.Rows.Count == 0) return;

            int soTiet = Convert.ToInt32(dt.Rows[0]["SoTiet"]);
            decimal luongTiet = Convert.ToDecimal(dt.Rows[0]["LuongTiet"]);
            decimal heSo = siSo <= 60 ? 1m : siSo <= 80 ? 1.3m : 2m;
            tienDayHienTai = soTiet * luongTiet * heSo;
            txtTienDay.Text = tienDayHienTai.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        }

        private void NapDanhSachLichDay()
        {
            const string sql = @"
                SELECT LD.MaLop, LD.MaMon, LD.MaGV,
                       LH.TenLop AS [Lớp học], MH.TenMon AS [Môn học],
                       GV.TenGV AS [Giảng viên], LD.KiHoc AS [Kỳ học],
                       LD.NamHoc AS [Năm học], LD.ThoiGianBD AS [Ngày bắt đầu],
                       LD.ThoiGianKT AS [Ngày kết thúc],
                       LD.ThuDay1 AS [Thứ 1], LD.CaDay1 AS [Ca 1],
                       LD.ThuDay2 AS [Thứ 2], LD.CaDay2 AS [Ca 2],
                       LD.TienDay AS [Tiền dạy], LD.TienThi AS [Tiền thi],
                       LD.GhiChu AS [Ghi chú]
                FROM LichDay LD
                INNER JOIN LopHoc LH ON LH.MaLop = LD.MaLop
                INNER JOIN MonHoc MH ON MH.MaMon = LD.MaMon
                INNER JOIN GiaoVien GV ON GV.MaGV = LD.MaGV
                ORDER BY LD.NamHoc DESC, LD.KiHoc, LH.TenLop";

            bool truocDo = dangNapDuLieu;
            dangNapDuLieu = true;
            try
            {
                DataTable dt = Database.GetData(sql);
                dgvLichDay.DataSource = dt;
                foreach (string ten in new[] { "MaLop", "MaMon", "MaGV" })
                    if (dgvLichDay.Columns.Contains(ten)) dgvLichDay.Columns[ten].Visible = false;
                foreach (string ten in new[] { "Ngày bắt đầu", "Ngày kết thúc" })
                    if (dgvLichDay.Columns.Contains(ten))
                        dgvLichDay.Columns[ten].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (string ten in new[] { "Tiền dạy", "Tiền thi" })
                    if (dgvLichDay.Columns.Contains(ten))
                        dgvLichDay.Columns[ten].DefaultCellStyle.Format = "N0";
                dgvLichDay.ClearSelection();
                dgvLichDay.CurrentCell = null;
            }
            finally { dangNapDuLieu = truocDo; }
        }

        private void dgvLichDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dangNapDuLieu || e.RowIndex < 0) return;
            DataRowView dong = dgvLichDay.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dong == null) return;

            try
            {
                dangNapDuLieu = true;
                maLopCu = Convert.ToString(dong["MaLop"]);
                maMonCu = Convert.ToString(dong["MaMon"]);
                kiHocCu = Convert.ToString(dong["Kỳ học"]);
                namHocCu = Convert.ToString(dong["Năm học"]);
                ghiChuCu = dong["Ghi chú"] == DBNull.Value ? "" : Convert.ToString(dong["Ghi chú"]);

                cboLop.SelectedValue = maLopCu;
                NapMonTheoLop();
                cboMon.SelectedValue = maMonCu;
                NapGiaoVienTheoMon();
                cboGiaoVien.SelectedValue = Convert.ToString(dong["MaGV"]);
                ChonChuoi(cboKiHoc, kiHocCu);
                txtNamHoc.Text = namHocCu;
                dtpBatDau.Value = dong["Ngày bắt đầu"] == DBNull.Value
                    ? DateTime.Today : Convert.ToDateTime(dong["Ngày bắt đầu"]);
                dtpKetThuc.Value = dong["Ngày kết thúc"] == DBNull.Value
                    ? DateTime.Today : Convert.ToDateTime(dong["Ngày kết thúc"]);
                ChonChuoi(cboThu1, dong["Thứ 1"]);
                ChonChuoi(cboCa1, dong["Ca 1"]);
                ChonChuoi(cboThu2, dong["Thứ 2"]);
                ChonChuoi(cboCa2, dong["Ca 2"]);
                if (GhiChuTextBox != null) GhiChuTextBox.Text = ghiChuCu;
                CapNhatTrangThaiNut();
            }
            catch (Exception ex) { BaoLoi("Không lấy được thông tin lịch đã chọn", ex); }
            finally
            {
                dangNapDuLieu = false;
                try { TinhTien(); }
                catch (Exception ex) { BaoLoi("Không tính được tiền dạy", ex); }
            }
        }

        private static void ChonChuoi(ComboBox combo, object giaTri)
        {
            string giaTriChuoi = giaTri == null || giaTri == DBNull.Value ? "" : Convert.ToString(giaTri).Trim();
            combo.SelectedIndex = string.IsNullOrWhiteSpace(giaTriChuoi) ? -1 : combo.FindStringExact(giaTriChuoi);
        }

        // 'Ghi chu' trong giao dien moi co the da bi xoa.
        // Neu khong co TextBox, luu lai ghi chu goc khi SUA (khong xoa du lieu ngam).
        private TextBox GhiChuTextBox
        {
            get
            {
                Control[] ds = this.Controls.Find("txtGhiChu", true);
                return ds.Length == 0 ? null : ds[0] as TextBox;
            }
        }

        private string LayGhiChuCanLuu()
        {
            TextBox o = GhiChuTextBox;
            if (o != null) return o.Text.Trim();
            return maLopCu != null ? ghiChuCu : "";
        }

        private void CapNhatTrangThaiNut()
        {
            bool dangSua = !string.IsNullOrEmpty(maLopCu);
            btnThem.Enabled = !dangSua;
            btnSua.Enabled = dangSua;
            btnXoa.Enabled = dangSua;
            this.Text = dangSua ? "Quản lý lịch dạy - Đang sửa lịch đã chọn" : "Quản lý lịch dạy - Thêm mới";
        }

        private void LamMoiThongTin()
        {
            bool truocDo = dangNapDuLieu;
            dangNapDuLieu = true;
            try
            {
                maLopCu = maMonCu = kiHocCu = namHocCu = null;
                ghiChuCu = "";
                cboLop.SelectedIndex = -1;
                cboMon.DataSource = null;
                cboGiaoVien.DataSource = null;
                cboMon.Enabled = false;
                cboGiaoVien.Enabled = false;
                cboKiHoc.SelectedIndex = -1;
                txtNamHoc.Clear();
                dtpBatDau.Value = DateTime.Today;
                dtpKetThuc.Value = DateTime.Today;
                cboThu1.SelectedIndex = -1;
                cboCa1.SelectedIndex = -1;
                cboThu2.SelectedIndex = -1;
                cboCa2.SelectedIndex = -1;
                if (GhiChuTextBox != null) GhiChuTextBox.Clear();
                txtTienDay.Clear();
                txtTienThi.Clear();
                tienDayHienTai = tienThiHienTai = 0m;
                dgvLichDay.ClearSelection();
                dgvLichDay.CurrentCell = null;
                CapNhatTrangThaiNut();
            }
            finally { dangNapDuLieu = truocDo; }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                dangNapDuLieu = true;
                NapLopHoc();
                NapDanhSachLichDay();
            }
            catch (Exception ex) { BaoLoi("Không làm mới được dữ liệu", ex); }
            finally
            {
                dangNapDuLieu = false;
                LamMoiThongTin();
            }
        }

        private static SqlParameter PChuoi(string ten, string giaTri, int doDai)
        {
            return new SqlParameter(ten, SqlDbType.NVarChar, doDai)
            {
                Value = string.IsNullOrWhiteSpace(giaTri) ? (object)DBNull.Value : giaTri.Trim()
            };
        }

        private static SqlParameter PNgay(string ten, DateTime ngay)
        {
            return new SqlParameter(ten, SqlDbType.Date) { Value = ngay.Date };
        }

        private static SqlParameter PTien(string ten, decimal giaTri)
        {
            return new SqlParameter(ten, SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = giaTri
            };
        }

        private SqlParameter[] ThamSoLichMoi()
        {
            return new[]
            {
                PChuoi("@MaLop", MaDangChon(cboLop), 20),
                PChuoi("@MaMon", MaDangChon(cboMon), 20),
                PChuoi("@MaGV", MaDangChon(cboGiaoVien), 20),
                PChuoi("@KiHoc", cboKiHoc.Text, 10),
                PChuoi("@NamHoc", txtNamHoc.Text, 20),
                PNgay("@BD", dtpBatDau.Value),
                PNgay("@KT", dtpKetThuc.Value),
                PChuoi("@Thu1", cboThu1.Text, 20),
                PChuoi("@Ca1", cboCa1.Text, 20),
                PChuoi("@Thu2", cboThu2.SelectedIndex >= 0 ? cboThu2.Text : null, 20),
                PChuoi("@Ca2", cboCa2.SelectedIndex >= 0 ? cboCa2.Text : null, 20),
                PTien("@TienDay", tienDayHienTai),
                PTien("@TienThi", tienThiHienTai),
                PChuoi("@GhiChu", LayGhiChuCanLuu(), 250)
            };
        }

        private SqlParameter[] ThamSoKhoaCu()
        {
            return new[]
            {
                PChuoi("@LopCu", maLopCu, 20),
                PChuoi("@MonCu", maMonCu, 20),
                PChuoi("@KiCu", kiHocCu, 10),
                PChuoi("@NamCu", namHocCu, 20)
            };
        }

        private static DayOfWeek ThuTrongTuan(string thu)
        {
            switch (thu)
            {
                case "Thứ 2": return DayOfWeek.Monday;
                case "Thứ 3": return DayOfWeek.Tuesday;
                case "Thứ 4": return DayOfWeek.Wednesday;
                case "Thứ 5": return DayOfWeek.Thursday;
                case "Thứ 6": return DayOfWeek.Friday;
                case "Thứ 7": return DayOfWeek.Saturday;
                default: return DayOfWeek.Sunday;
            }
        }

        private bool KiemTraNhap()
        {
            if (MaDangChon(cboLop) == null || MaDangChon(cboMon) == null ||
                MaDangChon(cboGiaoVien) == null || cboKiHoc.SelectedIndex < 0)
            {
                CanhBao("Hãy chọn lần lượt lớp, môn học, giáo viên và kỳ học.");
                return false;
            }
            string namHoc = txtNamHoc.Text.Trim();
            if (namHoc.Length == 0 || namHoc.Length > 20)
            {
                CanhBao("Hãy nhập năm học (tối đa 20 ký tự). Ví dụ: 2025-2026.");
                txtNamHoc.Focus();
                return false;
            }
            if (dtpBatDau.Value.Date > dtpKetThuc.Value.Date)
            {
                CanhBao("Ngày bắt đầu không được sau ngày kết thúc.");
                return false;
            }
            if (cboThu1.SelectedIndex < 0 || cboCa1.SelectedIndex < 0)
            {
                CanhBao("Hãy chọn đủ Thứ và Ca của buổi dạy 1.");
                return false;
            }
            if ((cboThu2.SelectedIndex >= 0) != (cboCa2.SelectedIndex >= 0))
            {
                CanhBao("Buổi dạy 2 phải chọn cả Thứ và Ca, hoặc để trống cả hai.");
                return false;
            }
            if (cboThu2.SelectedIndex >= 0 && cboThu1.Text == cboThu2.Text && cboCa1.Text == cboCa2.Text)
            {
                CanhBao("Hai buổi trong cùng lịch không được có chung thứ và ca.");
                return false;
            }
            if (GhiChuTextBox != null && GhiChuTextBox.Text.Length > 250)
            {
                CanhBao("Ghi chú không được quá 250 ký tự.");
                return false;
            }
            // Bao dam co it nhat mot ngay hoc dung thu trong khoang ngay da chon.
            DateTime batDau = dtpBatDau.Value.Date;
            DateTime ketThuc = dtpKetThuc.Value.Date;
            if (!CoNgayThuTrongKhoang(batDau, ketThuc, ThuTrongTuan(cboThu1.Text)))
            {
                CanhBao("Khoảng ngày đã chọn không có " + cboThu1.Text + " (buổi 1).");
                return false;
            }
            if (cboThu2.SelectedIndex >= 0 &&
                !CoNgayThuTrongKhoang(batDau, ketThuc, ThuTrongTuan(cboThu2.Text)))
            {
                CanhBao("Khoảng ngày đã chọn không có " + cboThu2.Text + " (buổi 2).");
                return false;
            }
            return true;
        }

        private static bool CoNgayThuTrongKhoang(DateTime batDau, DateTime ketThuc, DayOfWeek thu)
        {
            int ngayLech = ((int)thu - (int)batDau.DayOfWeek + 7) % 7;
            return batDau.AddDays(ngayLech) <= ketThuc;
        }

        private bool KiemTraTrung(bool dangSua)
        {
            string boQuaBanGhiCu = dangSua
                ? " AND NOT (LD.MaLop = @LopCu AND LD.MaMon = @MonCu " +
                  "AND LD.KiHoc = @KiCu AND LD.NamHoc = @NamCu) "
                : "";

            // Khoa chinh (MaLop, MaMon, KiHoc, NamHoc) cua bang LichDay.
            string sqlKhoa = @"
                SELECT COUNT(*) FROM LichDay LD
                WHERE LD.MaLop = @MaLop AND LD.MaMon = @MaMon
                  AND LD.KiHoc = @KiHoc AND LD.NamHoc = @NamHoc" + boQuaBanGhiCu;
            var pk = new List<SqlParameter>
            {
                PChuoi("@MaLop", MaDangChon(cboLop), 20),
                PChuoi("@MaMon", MaDangChon(cboMon), 20),
                PChuoi("@KiHoc", cboKiHoc.Text, 10),
                PChuoi("@NamHoc", txtNamHoc.Text, 20)
            };
            if (dangSua) pk.AddRange(ThamSoKhoaCu());
            DataTable trungKhoa = Database.ExecuteQuery(sqlKhoa, pk.ToArray());
            if (trungKhoa.Rows.Count > 0 && Convert.ToInt32(trungKhoa.Rows[0][0]) > 0)
            {
                CanhBao("Đã có lịch cho lớp, môn, kỳ học và năm học này.");
                return false;
            }

            // Kiem tra 2 buoi cua lich moi voi CA 2 BUOI cua tat ca lich cu.
            // Hai khoang ngay giao nhau khi: bdCu <= ktMoi va ktCu >= bdMoi.
            string sqlTrung = @"
                SELECT LD.MaLop, LD.MaGV, LH.TenLop, GV.TenGV,
                       LD.ThoiGianBD, LD.ThoiGianKT, Buoi.Thu, Buoi.Ca
                FROM LichDay LD
                INNER JOIN LopHoc LH ON LH.MaLop = LD.MaLop
                INNER JOIN GiaoVien GV ON GV.MaGV = LD.MaGV
                CROSS APPLY (VALUES (LD.ThuDay1, LD.CaDay1),
                                    (LD.ThuDay2, LD.CaDay2)) AS Buoi(Thu, Ca)
                WHERE (LD.MaLop = @MaLop OR LD.MaGV = @MaGV)
                  AND (LD.ThoiGianBD IS NULL OR LD.ThoiGianBD <= @KT)
                  AND (LD.ThoiGianKT IS NULL OR LD.ThoiGianKT >= @BD)
                  AND ((Buoi.Thu = @Thu1 AND Buoi.Ca = @Ca1)
                    OR (Buoi.Thu = @Thu2 AND Buoi.Ca = @Ca2))" + boQuaBanGhiCu;

            var p = new List<SqlParameter>
            {
                PChuoi("@MaLop", MaDangChon(cboLop), 20),
                PChuoi("@MaGV", MaDangChon(cboGiaoVien), 20),
                PNgay("@BD", dtpBatDau.Value),
                PNgay("@KT", dtpKetThuc.Value),
                PChuoi("@Thu1", cboThu1.Text, 20),
                PChuoi("@Ca1", cboCa1.Text, 20),
                PChuoi("@Thu2", cboThu2.SelectedIndex >= 0 ? cboThu2.Text : null, 20),
                PChuoi("@Ca2", cboCa2.SelectedIndex >= 0 ? cboCa2.Text : null, 20)
            };
            if (dangSua) p.AddRange(ThamSoKhoaCu());

            // Khong phai moi khoang giao nhau deu co tiet hoc trung thuc te:
            // VD: hai lich Thu 2 nhung phan giao nhau chi co Thu 6.
            DataTable xungDot = Database.ExecuteQuery(sqlTrung, p.ToArray());
            DateTime bdMoi = dtpBatDau.Value.Date;
            DateTime ktMoi = dtpKetThuc.Value.Date;
            foreach (DataRow dong in xungDot.Rows)
            {
                DateTime bdGiao = dong["ThoiGianBD"] == DBNull.Value
                    ? bdMoi : Convert.ToDateTime(dong["ThoiGianBD"]).Date;
                DateTime ktGiao = dong["ThoiGianKT"] == DBNull.Value
                    ? ktMoi : Convert.ToDateTime(dong["ThoiGianKT"]).Date;
                if (bdGiao < bdMoi) bdGiao = bdMoi;
                if (ktGiao > ktMoi) ktGiao = ktMoi;
                if (bdGiao > ktGiao) continue;

                string thuTrung = Convert.ToString(dong["Thu"]);
                if (!CoNgayThuTrongKhoang(bdGiao, ktGiao, ThuTrongTuan(thuTrung)))
                    continue;

                string doiTuong = Convert.ToString(dong["MaLop"]) == MaDangChon(cboLop)
                    ? "lớp " + Convert.ToString(dong["TenLop"])
                    : "giáo viên " + Convert.ToString(dong["TenGV"]);
                CanhBao("Trùng lịch của " + doiTuong + " vào " +
                        thuTrung + " - " + Convert.ToString(dong["Ca"]) +
                        ", trong khoảng ngày giao nhau.");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maLopCu != null)
            {
                CanhBao("Bạn đang chọn lịch cũ. Hãy nhấn Làm mới trước khi Thêm.");
                return;
            }
            if (!KiemTraNhap()) return;
            try
            {
                TinhTien();
                if (!KiemTraTrung(false)) return;
                const string sql = @"
                    INSERT INTO LichDay
                    (MaLop, MaMon, MaGV, KiHoc, NamHoc, ThoiGianBD, ThoiGianKT,
                     ThuDay1, CaDay1, ThuDay2, CaDay2, TienDay, TienThi, GhiChu)
                    VALUES
                    (@MaLop, @MaMon, @MaGV, @KiHoc, @NamHoc, @BD, @KT,
                     @Thu1, @Ca1, @Thu2, @Ca2, @TienDay, @TienThi, @GhiChu)";
                int n = Database.ExecuteNonQuery(sql, ThamSoLichMoi());
                if (n > 0)
                {
                    NapDanhSachLichDay();
                    LamMoiThongTin();
                    ThongBao("Đã thêm lịch dạy thành công.");
                    CapNhatThongKeTrangChu();
                }
                else CanhBao("Không có bản ghi mới được thêm. Hãy kiểm tra lại dữ liệu.");
            }
            catch (SqlException ex) { BaoLoi("Không thể thêm lịch (kiểm tra trùng khóa hoặc liên kết dữ liệu)", ex); }
            catch (Exception ex) { BaoLoi("Không thêm được lịch dạy", ex); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maLopCu == null)
            {
                CanhBao("Hãy chọn một dòng ở bảng trước khi sửa.");
                return;
            }
            if (!KiemTraNhap()) return;
            try
            {
                TinhTien();
                if (!KiemTraTrung(true)) return;
                const string sql = @"
                    UPDATE LichDay SET
                       MaLop = @MaLop, MaMon = @MaMon, MaGV = @MaGV,
                       KiHoc = @KiHoc, NamHoc = @NamHoc,
                       ThoiGianBD = @BD, ThoiGianKT = @KT,
                       ThuDay1 = @Thu1, CaDay1 = @Ca1,
                       ThuDay2 = @Thu2, CaDay2 = @Ca2,
                       TienDay = @TienDay, TienThi = @TienThi, GhiChu = @GhiChu
                    WHERE MaLop = @LopCu AND MaMon = @MonCu
                      AND KiHoc = @KiCu AND NamHoc = @NamCu";
                var p = new List<SqlParameter>(ThamSoLichMoi());
                p.AddRange(ThamSoKhoaCu());
                int n = Database.ExecuteNonQuery(sql, p.ToArray());
                if (n > 0)
                {
                    NapDanhSachLichDay();
                    LamMoiThongTin();
                    ThongBao("Đã sửa lịch dạy thành công.");
                    CapNhatThongKeTrangChu();
                }
                else CanhBao("Không tìm thấy lịch đã chọn. Hãy nhấn Làm mới.");
            }
            catch (SqlException ex) { BaoLoi("Không thể sửa lịch (kiểm tra trùng khóa hoặc liên kết dữ liệu)", ex); }
            catch (Exception ex) { BaoLoi("Không sửa được lịch dạy", ex); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maLopCu == null)
            {
                CanhBao("Hãy chọn một dòng ở bảng trước khi xóa.");
                return;
            }
            if (MessageBox.Show(
                "Bạn có chắc muốn xóa lịch của lớp " + maLopCu +
                ", môn " + maMonCu + ", kỳ " + kiHocCu + ", năm học " + namHocCu + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                const string sql = @"
                    DELETE FROM LichDay
                    WHERE MaLop = @LopCu AND MaMon = @MonCu
                      AND KiHoc = @KiCu AND NamHoc = @NamCu";
                int n = Database.ExecuteNonQuery(sql, ThamSoKhoaCu());
                NapDanhSachLichDay();
                LamMoiThongTin();
                if (n > 0)
                {
                    ThongBao("Đã xóa lịch dạy.");
                    CapNhatThongKeTrangChu();
                }
                else CanhBao("Lịch này không còn tồn tại. Hãy làm mới bảng.");
            }
            catch (Exception ex) { BaoLoi("Không xóa được lịch dạy", ex); }
        }

        private void CapNhatThongKeTrangChu()
        {
            FormMain cha = MdiParent as FormMain;
            if (cha == null) return;
            try { cha.RefreshThongKe(); }
            catch (Exception ex)
            {
                // Luu du lieu da thanh cong; loi thong ke khong phai loi luu lich.
                MessageBox.Show("Đã lưu lịch nhưng chưa cập nhật được thống kê trang chủ: " +
                    ex.Message, "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void CanhBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Kiểm tra thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Quản lý lịch dạy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void BaoLoi(string moTa, Exception ex)
        {
            MessageBox.Show(moTa + ":\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Su kien do Designer gan; de trong neu khong co nghiep vu.
        private void groupBox6_Enter(object sender, EventArgs e) { }
        private void label12_Click_1(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void txtTienThi_TextChanged(object sender, EventArgs e) { }

    }
}
