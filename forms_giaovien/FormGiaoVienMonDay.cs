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
    public partial class FormGiaoVienMonDay : Form
    {
        private readonly string chuoiKetNoi =
            @"Data Source=DESKTOP-1EBSNGJ\SQLEXPRESS;Initial Catalog=QuanLyGioDay;Integrated Security=True;TrustServerCertificate=True;";

        private string cheDo = ""; 
        private string maGVChon = "";
        private string maMonChon = "";
        private bool dangNap = false;
        public FormGiaoVienMonDay()
        {
            InitializeComponent();
        }

        private DataTable DocDuLieu(
            string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn =
                new SqlConnection(chuoiKetNoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(thamSo);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private int GhiDuLieu(
            string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn =
                new SqlConnection(chuoiKetNoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        private SqlParameter ThamSo(string ten, string giaTri)
        {
            SqlParameter p =
                new SqlParameter(ten, SqlDbType.NVarChar);

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
                MessageBox.Show(
                    "Giáo viên đã được phân công môn này.");
            }
            else if (loiSQL != null && loiSQL.Number == 547)
            {
                MessageBox.Show(
                    "Giáo viên hoặc môn học không còn tồn tại.");
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
            cbo.DisplayMember = "HienThi";
            cbo.ValueMember = cotMa;
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }

        private void TaiGiaoVien()
        {
            dangNap = true;

            try
            {
                DataTable dt = DocDuLieu(
                    @"SELECT gv.MaGV, gv.MaKhoa,
                             k.TenKhoa,
                             gv.MaGV + N' — ' + gv.TenGV AS HienThi
                      FROM GiaoVien gv
                      JOIN Khoa k ON gv.MaKhoa = k.MaKhoa
                      ORDER BY gv.MaGV");

                GanCombo(cboMaGV, dt, "MaGV");
                txtKhoa.Clear();
                cboMaMon.DataSource = null;
            }
            finally
            {
                dangNap = false;
            }
        }

        private void TaiMonTheoGiaoVien()
        {
            txtKhoa.Clear();
            cboMaMon.DataSource = null;

            DataRowView gv = cboMaGV.SelectedItem as DataRowView;
            if (gv == null) return;

            string maKhoa = gv["MaKhoa"].ToString();

            txtKhoa.Text =
                maKhoa + " — " + gv["TenKhoa"].ToString();

            DataTable dt = DocDuLieu(
                @"SELECT MaMon,
                         MaMon + N' — ' + TenMon AS HienThi
                  FROM MonHoc
                  WHERE MaKhoa = @MaKhoa
                  ORDER BY MaMon",
                ThamSo("@MaKhoa", maKhoa));

            GanCombo(cboMaMon, dt, "MaMon");
        }

        private void cboMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNap) return;

            try
            {
                TaiMonTheoGiaoVien();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void TaiDanhSach(string tuKhoa = "")
        {
            DataTable dt = DocDuLieu(
                @"SELECT pc.MaGV, gv.TenGV, gv.MaKhoa,
                         pc.MaMon, mh.TenMon, pc.GhiChu
                  FROM GiaoVien_MonDay pc
                  JOIN GiaoVien gv ON pc.MaGV = gv.MaGV
                  JOIN MonHoc mh ON pc.MaMon = mh.MaMon
                  WHERE pc.MaGV LIKE @Tim
                     OR gv.TenGV LIKE @Tim
                     OR pc.MaMon LIKE @Tim
                     OR mh.TenMon LIKE @Tim
                  ORDER BY pc.MaGV, pc.MaMon",
                ThamSo("@Tim", "%" + tuKhoa.Trim() + "%"));

            dgvMonDay.DataSource = dt;

            string[] cot =
            {
                "MaGV", "TenGV", "MaKhoa",
                "MaMon", "TenMon", "GhiChu"
            };

            string[] nhan =
            {
                "Mã GV", "Tên giáo viên", "Khoa",
                "Mã môn", "Tên môn", "Ghi chú"
            };

            for (int i = 0; i < cot.Length; i++)
                dgvMonDay.Columns[cot[i]].HeaderText = nhan[i];

            dgvMonDay.ClearSelection();
            dgvMonDay.CurrentCell = null;

            lblTongSo.Text =
                "Tổng số: " + dt.Rows.Count + " bản ghi";
        }

        private void DatCheDo(string moi)
        {
            cheDo = moi;
            bool dangNhap = moi != "";
            bool daChon = maGVChon != "" && maMonChon != "";

            grpPhanCong.Enabled = dangNhap;

            cboMaGV.Enabled = moi == "Them";
            cboMaMon.Enabled = moi == "Them";

            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = btnXoa.Enabled = !dangNhap && daChon;

            btnLamMoi.Enabled = !dangNhap;
            txtTimKiem.Enabled = !dangNhap;
            btnTimKiem.Enabled = !dangNhap;
            dgvMonDay.Enabled = !dangNhap;
        }

        private void XoaO()
        {
            dangNap = true;

            try
            {
                maGVChon = "";
                maMonChon = "";

                cboMaGV.SelectedIndex = -1;
                cboMaMon.DataSource = null;
                txtKhoa.Clear();
                txtGhiChu.Clear();
            }
            finally
            {
                dangNap = false;
            }
        }

        private void CanGiua()
        {
            pnlNoiDung.Left = Math.Max(
                0, (ClientSize.Width - pnlNoiDung.Width) / 2);

            pnlNoiDung.Top = 10;
        }

        private void FormGiaoVienMonDay_Resize(object sender, EventArgs e)
        {
            CanGiua();
        }

        private void FormGiaoVienMonDay_Load(object sender, EventArgs e)
        {
            try
            {
                cboMaGV.DropDownStyle = ComboBoxStyle.DropDownList;
                cboMaMon.DropDownStyle = ComboBoxStyle.DropDownList;

                txtKhoa.ReadOnly = true;
                txtGhiChu.Multiline = true;
                txtGhiChu.MaxLength = 250;

                dgvMonDay.ReadOnly = true;
                dgvMonDay.AllowUserToAddRows = false;
                dgvMonDay.AllowUserToDeleteRows = false;
                dgvMonDay.MultiSelect = false;
                dgvMonDay.AutoGenerateColumns = true;
                dgvMonDay.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvMonDay.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvMonDay.EnableHeadersVisualStyles = false;
                dgvMonDay.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.LightSteelBlue;
                dgvMonDay.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.AliceBlue;

                DatCheDo("");
                TaiGiaoVien();
                TaiDanhSach();
                XoaO();
                CanGiua();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void dgvMonDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || cheDo != "") return;

            try
            {
                DataRowView banGhi =
                    dgvMonDay.Rows[e.RowIndex].DataBoundItem
                    as DataRowView;

                if (banGhi == null) return;

                DataRow r = banGhi.Row;
                dangNap = true;

                maGVChon = r["MaGV"].ToString();
                maMonChon = r["MaMon"].ToString();

                cboMaGV.SelectedValue = maGVChon;

                TaiMonTheoGiaoVien();
                cboMaMon.SelectedValue = maMonChon;

                txtGhiChu.Text = r["GhiChu"].ToString();

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
            cboMaGV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maGVChon == "" || maMonChon == "")
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng.");
                return;
            }

            DatCheDo("Sua");
            txtGhiChu.Focus();
        }

        private bool KiemTra(string maGV, string maMon)
        {
            if (maGV == "" || maMon == "")
            {
                MessageBox.Show("Hãy chọn giáo viên và môn học.");
                return false;
            }

            DataTable dt = DocDuLieu(
                @"SELECT gv.MaGV
                  FROM GiaoVien gv
                  JOIN MonHoc mh ON gv.MaKhoa = mh.MaKhoa
                  WHERE gv.MaGV = @GV AND mh.MaMon = @Mon",
                ThamSo("@GV", maGV),
                ThamSo("@Mon", maMon));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Môn học không thuộc khoa của giáo viên " +
                    "hoặc dữ liệu đã thay đổi.");
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cheDo == "") return;

            try
            {
                string maGV = cheDo == "Them"
                    ? LayMa(cboMaGV) : maGVChon;

                string maMon = cheDo == "Them"
                    ? LayMa(cboMaMon) : maMonChon;

                if (!KiemTra(maGV, maMon)) return;

                string sql;

                if (cheDo == "Them")
                {
                    sql = @"INSERT INTO GiaoVien_MonDay
                            (MaGV, MaMon, GhiChu)
                            VALUES (@GV, @Mon, @GhiChu)";
                }
                else
                {
                    sql = @"UPDATE GiaoVien_MonDay
                            SET GhiChu = @GhiChu
                            WHERE MaGV = @GV AND MaMon = @Mon";
                }

                int soDong = GhiDuLieu(sql,
                    ThamSo("@GV", maGV),
                    ThamSo("@Mon", maMon),
                    ThamSo("@GhiChu", txtGhiChu.Text.Trim()));

                if (soDong == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy phân công để cập nhật.");
                    return;
                }

                maGVChon = "";
                maMonChon = "";
                DatCheDo("");

                MessageBox.Show("Đã lưu phân công môn dạy.");

                txtTimKiem.Clear();
                TaiDanhSach();
                XoaO();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maGVChon == "" || maMonChon == "") return;

            DialogResult kq = MessageBox.Show(
                "Xóa phân công " + maGVChon + " – " + maMonChon + "?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes) return;

            try
            {
                int soDong = GhiDuLieu(
                    @"DELETE FROM GiaoVien_MonDay
                      WHERE MaGV = @GV AND MaMon = @Mon",
                    ThamSo("@GV", maGVChon),
                    ThamSo("@Mon", maMonChon));

                MessageBox.Show(soDong > 0
                    ? "Đã xóa phân công."
                    : "Phân công không còn tồn tại.");

                TaiDanhSach(txtTimKiem.Text.Trim());
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
                TaiGiaoVien();
                TaiDanhSach();
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cheDo != "") return;

            try
            {
                TaiDanhSach(txtTimKiem.Text.Trim());
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (cheDo != "")
            {
                DialogResult kq = MessageBox.Show(
                    "Dữ liệu chưa lưu. Bạn muốn quay lại?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (kq != DialogResult.Yes)
                    return;
            }

            this.Close();
        }
    }
}
