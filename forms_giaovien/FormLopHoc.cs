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
    public partial class FormLopHoc : Form
    {
        

        private string cheDo = "";
        private string maDangChon = "";
        private string tuKhoaDaTim = "";
        private bool dangNap = false;

        public FormLopHoc()
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
            return new SqlParameter(ten, SqlDbType.NVarChar)
            {
                Value = giaTri
            };
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
                MessageBox.Show("Mã lớp đã tồn tại.");
            }
            else if (loiSQL != null && loiSQL.Number == 547)
            {
                MessageBox.Show(
                    "Khoa không hợp lệ hoặc lớp đang có lịch dạy.");
            }
            else
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void GanCombo(ComboBox cbo, DataTable dt)
        {
            cbo.DataSource = null;
            cbo.DisplayMember = "HienThi";
            cbo.ValueMember = "MaKhoa";
            cbo.DataSource = dt;
        }

        private void TaiKhoa()
        {
            dangNap = true;

            try
            {
                DataTable dt = DocDuLieu(
                    @"SELECT MaKhoa,
                             MaKhoa + N' — ' + TenKhoa AS HienThi
                      FROM Khoa
                      ORDER BY MaKhoa");

                GanCombo(cboMaKhoa, dt);
                cboMaKhoa.SelectedIndex = -1;

                DataTable dtLoc = dt.Copy();
                DataRow dong = dtLoc.NewRow();

                dong["MaKhoa"] = "";
                dong["HienThi"] = "Tất cả khoa";
                dtLoc.Rows.InsertAt(dong, 0);

                GanCombo(cboLocKhoa, dtLoc);
                cboLocKhoa.SelectedIndex = 0;
            }
            finally
            {
                dangNap = false;
            }
        }

        private void TaiLopHoc()
        {
            DataTable dt = DocDuLieu(
                @"SELECT l.MaLop, l.TenLop, l.MaKhoa,
                         k.TenKhoa, l.SiSo
                  FROM LopHoc l
                  JOIN Khoa k ON l.MaKhoa = k.MaKhoa
                  WHERE (l.MaLop LIKE @Tim OR l.TenLop LIKE @Tim)
                    AND (@Khoa = N'' OR l.MaKhoa = @Khoa)
                  ORDER BY l.MaLop",
                ThamSo("@Tim", "%" + tuKhoaDaTim + "%"),
                ThamSo("@Khoa", LayMa(cboLocKhoa)));

            dgvLopHoc.DataSource = dt;

            dgvLopHoc.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvLopHoc.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvLopHoc.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dgvLopHoc.Columns["TenKhoa"].HeaderText = "Tên khoa";
            dgvLopHoc.Columns["SiSo"].HeaderText = "Sĩ số";

            dgvLopHoc.ClearSelection();
            dgvLopHoc.CurrentCell = null;

            lblTongSo.Text = "Tổng số lớp: " + dt.Rows.Count;
        }

        private void DatCheDo(string moi)
        {
            cheDo = moi;
            bool dangNhap = moi != "";

            grpThongTin.Enabled = dangNhap;
            txtMaLop.ReadOnly = moi == "Sua";

            btnLuu.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;

            btnSua.Enabled = btnXoa.Enabled =
                !dangNhap && maDangChon != "";

            txtTim.Enabled = btnTim.Enabled = !dangNhap;
            cboLocKhoa.Enabled = !dangNhap;
            dgvLopHoc.Enabled = !dangNhap;

            btnLamMoi.Enabled = true;
        }

        private void XoaO()
        {
            maDangChon = "";
            txtMaLop.Clear();
            txtTenLop.Clear();
            cboMaKhoa.SelectedIndex = -1;
            nudSiSo.Value = 0;
        }

        private void CanGiua()
        {
            pnlNoiDung.Left = Math.Max(
                0, (ClientSize.Width - pnlNoiDung.Width) / 2);

            pnlNoiDung.Top = 10;
        }

        private void FormLopHoc_Resize(
            object sender, EventArgs e)
        {
            CanGiua();
        }

        private void FormLopHoc_Load(object sender, EventArgs e)
        {
            try
            {
                cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLocKhoa.DropDownStyle = ComboBoxStyle.DropDownList;

                txtMaLop.MaxLength = 20;
                txtTenLop.MaxLength = 100;

                nudSiSo.Minimum = 0;
                nudSiSo.Maximum = int.MaxValue;
                nudSiSo.DecimalPlaces = 0;

                dgvLopHoc.ReadOnly = true;
                dgvLopHoc.AllowUserToAddRows = false;
                dgvLopHoc.AllowUserToDeleteRows = false;
                dgvLopHoc.MultiSelect = false;
                dgvLopHoc.AutoGenerateColumns = true;

                dgvLopHoc.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvLopHoc.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvLopHoc.EnableHeadersVisualStyles = false;
                dgvLopHoc.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.LightSteelBlue;

                dgvLopHoc.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.AliceBlue;

                tuKhoaDaTim = "";
                txtTim.Clear();

                DatCheDo("");
                TaiKhoa();
                TaiLopHoc();
                XoaO();
                CanGiua();
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || cheDo != "") return;

            try
            {
                DataRowView banGhi =
                    dgvLopHoc.Rows[e.RowIndex].DataBoundItem
                    as DataRowView;

                if (banGhi == null) return;

                DataRow r = banGhi.Row;

                decimal siSo = r.IsNull("SiSo")
                    ? 0 : Convert.ToDecimal(r["SiSo"]);

                if (siSo < nudSiSo.Minimum ||
                    siSo > nudSiSo.Maximum)
                {
                    MessageBox.Show(
                        "Sĩ số trong database không hợp lệ.");
                    return;
                }

                maDangChon = r["MaLop"].ToString();

                txtMaLop.Text = maDangChon;
                txtTenLop.Text = r["TenLop"].ToString();
                cboMaKhoa.SelectedValue = r["MaKhoa"].ToString();
                nudSiSo.Value = siSo;

                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaO();
            DatCheDo("Them");
            txtMaLop.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == "")
            {
                MessageBox.Show("Hãy chọn lớp trong bảng.");
                return;
            }

            DatCheDo("Sua");
            txtTenLop.Focus();
        }

        private bool KiemTra()
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lớp.");
                txtMaLop.Focus();
                return false;
            }

            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên lớp.");
                txtTenLop.Focus();
                return false;
            }

            if (LayMa(cboMaKhoa) == "")
            {
                MessageBox.Show("Bạn chưa chọn khoa.");
                cboMaKhoa.Focus();
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
                    sql = @"INSERT INTO LopHoc
                            (MaLop, TenLop, MaKhoa, SiSo)
                            VALUES (@Ma, @Ten, @Khoa, @SiSo)";
                }
                else
                {
                    sql = @"UPDATE LopHoc
                            SET TenLop=@Ten,
                                MaKhoa=@Khoa,
                                SiSo=@SiSo
                            WHERE MaLop=@Ma";
                }

                SqlParameter siSo =
                    new SqlParameter("@SiSo", SqlDbType.Int);

                siSo.Value = Convert.ToInt32(nudSiSo.Value);

                int soDong = GhiDuLieu(sql,
                    ThamSo("@Ma", cheDo == "Them"
                        ? txtMaLop.Text.Trim() : maDangChon),
                    ThamSo("@Ten", txtTenLop.Text.Trim()),
                    ThamSo("@Khoa", LayMa(cboMaKhoa)),
                    siSo);

                if (soDong == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy lớp để cập nhật.");
                    return;
                }

                maDangChon = "";
                DatCheDo("");
                MessageBox.Show("Đã lưu lớp học.");

                TaiLopHoc();
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
                "Bạn muốn xóa lớp " + maDangChon + "?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes) return;

            try
            {
                int soDong = GhiDuLieu(
                    "DELETE FROM LopHoc WHERE MaLop=@Ma",
                    ThamSo("@Ma", maDangChon));

                MessageBox.Show(soDong > 0
                    ? "Đã xóa lớp."
                    : "Lớp không còn tồn tại.");

                TaiLopHoc();
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
            if (cheDo != "")
            {
                DialogResult kq = MessageBox.Show(
                    "Làm mới sẽ bỏ dữ liệu đang nhập. Tiếp tục?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (kq != DialogResult.Yes) return;
            }

            try
            {
                txtTim.Clear();
                tuKhoaDaTim = "";

                TaiKhoa();
                TaiLopHoc();
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
            if (cheDo != "") return;

            try
            {
                tuKhoaDaTim = txtTim.Text.Trim();

                TaiLopHoc();
                XoaO();
                DatCheDo("");
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        private void cboLocKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNap || cheDo != "") return;

            try
            {
                TaiLopHoc();
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
