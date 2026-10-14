using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGioDay.Forms_GiaoVien
{
    public partial class FormGiaoVien : Form
    {
        
        private string cheDo = "";       
        private string maDangChon = "";
        private bool dangNap = false;
        public FormGiaoVien()
        {
            InitializeComponent();
        }

        private DataTable DocDuLieu(
    string sql, params SqlParameter[] thamSo)
        {
            return Database.ExecuteQuery(sql, thamSo);
        }

        private int GhiDuLieu(
            string sql, params SqlParameter[] thamSo)
        {
            return Database.ExecuteNonQuery(sql, thamSo);
        }
        private SqlParameter ThamSo(string ten, string giaTri)
        {
            SqlParameter p = new SqlParameter(ten, SqlDbType.NVarChar);
            p.Value = string.IsNullOrWhiteSpace(giaTri)
                ? (object)DBNull.Value : giaTri;
            return p;
        }

        private string LayMa(ComboBox cbo)
        {
            return Convert.ToString(cbo.SelectedValue);
        }

        private void BaoLoi(Exception ex)
        {
            SqlException loiSQL = ex as SqlException;

            if (loiSQL != null &&
                (loiSQL.Number == 2627 || loiSQL.Number == 2601))
            {
                MessageBox.Show("Mã giáo viên đã tồn tại.");
            }
            else if (loiSQL != null && loiSQL.Number == 547)
            {
                MessageBox.Show(
                    "Dữ liệu liên quan không hợp lệ hoặc giáo viên " +
                    "đang được dùng trong môn dạy/lịch dạy.");
            }
            else
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void GanCombo(
            ComboBox cbo, DataTable dt, string cotMa)
        {
            cbo.DataSource = null;
            cbo.DisplayMember = "Ten";
            cbo.ValueMember = cotMa;
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }

        private void TaiDanhMuc()
        {
            dangNap = true;
            try
            {
                GanCombo(cboMaKhoa,
                    DocDuLieu(
                        "SELECT MaKhoa, TenKhoa AS Ten FROM Khoa"),
                    "MaKhoa");

                GanCombo(cboMaTrinhDo,
                    DocDuLieu(
                        "SELECT MaTrinhDo, TenTrinhDo AS Ten FROM TrinhDo"),
                    "MaTrinhDo");

                GanCombo(cboMaCN,
                    DocDuLieu(
                        "SELECT MaChNganh, TenChNganh AS Ten FROM ChuyenNganh"),
                    "MaChNganh");

                cboBoMon.DataSource = null;
            }
            finally
            {
                dangNap = false;
            }
        }

        private void TaiBoMon()
        {
            DataTable dt = DocDuLieu(
            @"SELECT MaBM, TenBM AS Ten
              FROM BoMon WHERE MaKhoa=@MaKhoa",
            ThamSo("@MaKhoa", LayMa(cboMaKhoa)));

            GanCombo(cboBoMon, dt, "MaBM");
        }

        private void cboMaKhoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dangNap) return;

            try
            {
                TaiBoMon();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void TaiGiaoVien(string tuKhoa = "")
        {
            DataTable dt = DocDuLieu(
                @"SELECT MaGV, TenGV, NgaySinh, GioiTinh,
                     DiaChi, DienThoai, MaKhoa, MaBM,
                     MaTrinhDo, MaChNganh, LuongTiet
              FROM GiaoVien
              WHERE MaGV LIKE @Tim OR TenGV LIKE @Tim
              ORDER BY MaGV",
                ThamSo("@Tim", "%" + tuKhoa + "%"));

            dgvGiaoVien.DataSource = dt;

            string[] tieuDe =
            {
            "Mã GV", "Tên GV", "Ngày sinh", "Giới tính",
            "Địa chỉ", "Điện thoại", "Mã khoa", "Mã bộ môn",
            "Mã trình độ", "Mã chuyên ngành", "Lương tiết"
        };

            for (int i = 0; i < tieuDe.Length; i++)
                dgvGiaoVien.Columns[i].HeaderText = tieuDe[i];

            dgvGiaoVien.Columns["NgaySinh"]
                .DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvGiaoVien.Columns["LuongTiet"]
                .DefaultCellStyle.Format = "N2";

            dgvGiaoVien.ClearSelection();
            dgvGiaoVien.CurrentCell = null;

            lblTongSo.Text = "Tổng số: " + dt.Rows.Count + " giáo viên";
        }

        private void DatCheDo(string moi)
        {
            cheDo = moi;
            bool dangNhap = moi != "";

            grpThongTin.Enabled = dangNhap;
            txtMaGV.ReadOnly = moi == "Sua";

            btnLuu.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;
            btnLamMoi.Enabled = true;

            btnTim.Enabled = txtTimKiem.Enabled = !dangNhap;
            dgvGiaoVien.Enabled = !dangNhap;

            btnSua.Enabled = btnXoa.Enabled = !dangNhap && maDangChon != "";
        }

        private void XoaO()
        {
            dangNap = true;
            try
            {
                maDangChon = "";

                txtMaGV.Clear();
                txtTenGV.Clear();
                txtDiaChi.Clear();
                txtDienThoai.Clear();

                cboMaKhoa.SelectedIndex = -1;
                cboBoMon.DataSource = null;
                cboMaTrinhDo.SelectedIndex = -1;
                cboMaCN.SelectedIndex = -1;

                dtpNgaySinh.Value = DateTime.Today;
                dtpNgaySinh.Checked = false;

                rdoNam.Checked = rdoNu.Checked = false;
                nudLuongTiet.Value = 0;

            }
            finally
            {
                dangNap = false;
            }
        }

        private void FormGiaoVien_Load(object sender, EventArgs e)
        {
            try
            {
                cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
                cboBoMon.DropDownStyle = ComboBoxStyle.DropDownList;
                cboMaTrinhDo.DropDownStyle = ComboBoxStyle.DropDownList;
                cboMaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                dtpNgaySinh.Format = DateTimePickerFormat.Custom;
                dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
                dtpNgaySinh.ShowCheckBox = true;

                nudLuongTiet.Minimum = 0;
                nudLuongTiet.Maximum = 9999999999999999.99m;
                nudLuongTiet.DecimalPlaces = 2;
                nudLuongTiet.ThousandsSeparator = true;

                txtMaGV.MaxLength = 20;
                txtTenGV.MaxLength = 100;
                txtDiaChi.MaxLength = 200;
                txtDienThoai.MaxLength = 20;

                dgvGiaoVien.ReadOnly = true;
                dgvGiaoVien.AllowUserToAddRows = false;
                dgvGiaoVien.AllowUserToDeleteRows = false;
                dgvGiaoVien.MultiSelect = false;
                dgvGiaoVien.AutoGenerateColumns = true;
                dgvGiaoVien.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvGiaoVien.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.AllCells;

                DatCheDo("");
                TaiDanhMuc();
                TaiGiaoVien();
                XoaO();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || cheDo != "") return;

            try
            {
                DataRowView banGhi =
                    dgvGiaoVien.Rows[e.RowIndex].DataBoundItem
                    as DataRowView;

                if (banGhi == null) return;
                DataRow r = banGhi.Row;

                // Kiểm tra ngày trước khi đưa lên DateTimePicker.
                if (!r.IsNull("NgaySinh"))
                {
                    DateTime ngay = Convert.ToDateTime(r["NgaySinh"]);
                    if (ngay < dtpNgaySinh.MinDate ||
                        ngay > dtpNgaySinh.MaxDate)
                    {
                        MessageBox.Show(
                            "Ngày sinh nằm ngoài phạm vi hiển thị.");
                        return;
                    }
                }

                dangNap = true;

                maDangChon = r["MaGV"].ToString();
                txtMaGV.Text = maDangChon;
                txtTenGV.Text = r["TenGV"].ToString();
                txtDiaChi.Text = r["DiaChi"].ToString();
                txtDienThoai.Text = r["DienThoai"].ToString();

                dtpNgaySinh.Value = r.IsNull("NgaySinh")
                    ? DateTime.Today
                    : Convert.ToDateTime(r["NgaySinh"]);
                dtpNgaySinh.Checked = !r.IsNull("NgaySinh");

                rdoNam.Checked = r["GioiTinh"].ToString() == "Nam";
                rdoNu.Checked = r["GioiTinh"].ToString() == "Nữ";

                cboMaKhoa.SelectedValue = r["MaKhoa"].ToString();
                TaiBoMon();
                cboBoMon.SelectedValue = r["MaBM"].ToString();

                cboMaTrinhDo.SelectedIndex = -1;
                if (!r.IsNull("MaTrinhDo"))
                    cboMaTrinhDo.SelectedValue = r["MaTrinhDo"].ToString();

                cboMaCN.SelectedIndex = -1;
                if (!r.IsNull("MaChNganh"))
                    cboMaCN.SelectedValue =
                        r["MaChNganh"].ToString();

                decimal luong = r.IsNull("LuongTiet")
                    ? 0 : Convert.ToDecimal(r["LuongTiet"]);

                nudLuongTiet.Value = Math.Max(
                    nudLuongTiet.Minimum,
                    Math.Min(nudLuongTiet.Maximum, luong));

                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
            finally
            {
                dangNap = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaO();
            DatCheDo("Them");
            txtMaGV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Hãy chọn giáo viên trong bảng.");
                return;
            }

            DatCheDo("Sua");
            txtTenGV.Focus();
        }

        private bool KiemTra()
        {
            if (txtMaGV.Text.Trim() == "" || txtTenGV.Text.Trim() == "" || LayMa(cboMaKhoa) == "" || LayMa(cboBoMon) == "")
            {
                MessageBox.Show(
                    "Hãy nhập mã, tên, mã bộ môn và chọn khoa.");
                return false;
            }

            if (dtpNgaySinh.Checked &&
                dtpNgaySinh.Value.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "Ngày sinh không được sau ngày hiện tại.");
                return false;
            }

            DataTable dt = DocDuLieu(
                @"SELECT MaBM FROM BoMon
                   WHERE MaBM=@BM AND MaKhoa=@Khoa",
                ThamSo("@BM", LayMa(cboBoMon)),
                ThamSo("@Khoa", LayMa(cboMaKhoa)));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Mã bộ môn không tồn tại hoặc không thuộc khoa đã chọn.");
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cheDo == "") return;

            try
            {
                if (!KiemTra()) return;

                string sql;

                if (cheDo == "Them")
                {
                    sql = @"INSERT INTO GiaoVien
                    (MaGV, TenGV, NgaySinh, GioiTinh,
                     DiaChi, DienThoai, MaKhoa, MaBM,
                     MaTrinhDo, MaChNganh, LuongTiet)
                    VALUES
                    (@Ma, @Ten, @Ngay, @GT, @DC, @DT,
                     @Khoa, @BM, @TD, @CN, @Luong)";
                }
                else
                {
                    sql = @"UPDATE GiaoVien SET
                    TenGV=@Ten, NgaySinh=@Ngay, GioiTinh=@GT,
                    DiaChi=@DC, DienThoai=@DT, MaKhoa=@Khoa,
                    MaBM=@BM, MaTrinhDo=@TD, MaChNganh=@CN,
                    LuongTiet=@Luong WHERE MaGV=@Ma";
                }

                SqlParameter ngay =
                    new SqlParameter("@Ngay", SqlDbType.Date);
                ngay.Value = dtpNgaySinh.Checked
                    ? (object)dtpNgaySinh.Value.Date
                    : DBNull.Value;

                SqlParameter luong =
                    new SqlParameter("@Luong", SqlDbType.Decimal);
                luong.Precision = 18;
                luong.Scale = 2;
                luong.Value = nudLuongTiet.Value;

                string gioiTinh = "";
                if (rdoNam.Checked) gioiTinh = "Nam";
                if (rdoNu.Checked) gioiTinh = "Nữ";

                int soDong = GhiDuLieu(sql,
                    ThamSo("@Ma", cheDo == "Them"
                        ? txtMaGV.Text.Trim() : maDangChon),
                    ThamSo("@Ten", txtTenGV.Text.Trim()),
                    ngay,
                    ThamSo("@GT", gioiTinh),
                    ThamSo("@DC", txtDiaChi.Text.Trim()),
                    ThamSo("@DT", txtDienThoai.Text.Trim()),
                    ThamSo("@Khoa", LayMa(cboMaKhoa)),
                    ThamSo("@BM", LayMa(cboBoMon)),
                    ThamSo("@TD", LayMa(cboMaTrinhDo)),
                    ThamSo("@CN", LayMa(cboMaCN)),
                    luong);

                if (soDong == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy giáo viên để cập nhật.");
                    return;
                }

                maDangChon = "";
                DatCheDo("");
                MessageBox.Show("Đã lưu giáo viên.");

                TaiGiaoVien(txtTimKiem.Text.Trim());
                XoaO();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == "") return;

            DialogResult kq = MessageBox.Show(
                "Bạn muốn xóa giáo viên " + maDangChon + "?",
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes) return;

            try
            {
                int soDong = GhiDuLieu(
                    "DELETE FROM GiaoVien WHERE MaGV=@Ma",
                    ThamSo("@Ma", maDangChon));

                MessageBox.Show(soDong > 0
                    ? "Đã xóa giáo viên."
                    : "Giáo viên không còn tồn tại.");

                TaiGiaoVien(txtTimKiem.Text.Trim());
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.Clear();
                TaiDanhMuc();
                TaiGiaoVien();
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                TaiGiaoVien(txtTimKiem.Text.Trim());
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }
    }
}
