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

namespace QuanLyGioDay.Forms_DanhMuc
{
    public partial class FormBoMon : Form
    {
        public FormBoMon()
        {
            InitializeComponent();
        }

        private void FormBoMon_Load(object sender, EventArgs e)
        {
            LoadComboBoxKhoa();
            LoadDanhSachBoMon();
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
                DataTable dt = Database.ExecuteQuery(sql);

                cboKhoa.DataSource = dt;
                cboKhoa.DisplayMember = "TenKhoa"; // Hiển thị Tên khoa
                cboKhoa.ValueMember = "MaKhoa";     // Giá trị ẩn là Mã khoa
                cboKhoa.SelectedIndex = -1;       // Để trống lúc ban đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachBoMon()
        {
            try
            {
                string sql = @"SELECT bm.MaBM AS [Mã BM], 
                                     bm.TenBM AS [Tên Bộ Môn], 
                                     k.TenKhoa AS [Khoa Quản Lý],
                                     bm.DiaChi AS [Địa chỉ],
                                     bm.DienThoai AS [Điện thoại],
                                     bm.MaKhoa
                              FROM BoMon bm 
                              LEFT JOIN Khoa k ON bm.MaKhoa = k.MaKhoa";

                DataTable dt = Database.ExecuteQuery(sql);
                dgvBoMon.DataSource = dt;

                // Ẩn cột MaKhoa
                if (dgvBoMon.Columns["MaKhoa"] != null)
                {
                    dgvBoMon.Columns["MaKhoa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Bộ môn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaBoMon.Text = "";
            txtTenBoMon.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            cboKhoa.SelectedIndex = -1;
            txtMaBoMon.Enabled = true; // Mở lại ô Mã BM cho phép nhập thêm
            txtMaBoMon.Focus();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBoMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBoMon.Rows[e.RowIndex];

                // Tránh lỗi chọn dòng trống (*)
                if (row.Cells["Mã BM"].Value != null && row.Cells["Mã BM"].Value != DBNull.Value)
                {
                    txtMaBoMon.Text = row.Cells["Mã BM"].Value.ToString();
                    txtTenBoMon.Text = row.Cells["Tên Bộ Môn"].Value?.ToString();
                    txtDiaChi.Text = row.Cells["Địa chỉ"].Value?.ToString();
                    txtDienThoai.Text = row.Cells["Điện thoại"].Value?.ToString();

                    // Chọn đúng Khoa tương ứng trên ComboBox
                    if (row.Cells["MaKhoa"].Value != DBNull.Value && row.Cells["MaKhoa"].Value != null)
                    {
                        cboKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
                    }
                    else
                    {
                        cboKhoa.SelectedIndex = -1;
                    }

                    txtMaBoMon.Enabled = false; // Khóa ô Mã BM khi chọn dòng có sẵn
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBoMon.Text) || string.IsNullOrWhiteSpace(txtTenBoMon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã bộ môn và Tên bộ môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa quản lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO BoMon(MaBM, TenBM, DiaChi, DienThoai, MaKhoa) VALUES(@MaBM, @TenBM, @DiaChi, @DienThoai, @MaKhoa)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaBM", txtMaBoMon.Text.Trim()),
                    new SqlParameter("@TenBM", txtTenBoMon.Text.Trim()),
                    new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                    new SqlParameter("@DienThoai", txtDienThoai.Text.Trim()),
                    new SqlParameter("@MaKhoa", cboKhoa.SelectedValue.ToString())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm mới Bộ môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachBoMon();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu (có thể do trùng Mã BM): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBoMon.Text))
            {
                MessageBox.Show("Vui lòng chọn Bộ môn cần sửa từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa quản lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE BoMon SET TenBM = @TenBM, DiaChi = @DiaChi, DienThoai = @DienThoai, MaKhoa = @MaKhoa WHERE MaBM = @MaBM";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaBM", txtMaBoMon.Text.Trim()),
                    new SqlParameter("@TenBM", txtTenBoMon.Text.Trim()),
                    new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                    new SqlParameter("@DienThoai", txtDienThoai.Text.Trim()),
                    new SqlParameter("@MaKhoa", cboKhoa.SelectedValue.ToString())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật Bộ môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachBoMon();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBoMon.Text))
            {
                MessageBox.Show("Vui lòng chọn Bộ môn cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa bộ môn [{txtTenBoMon.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM BoMon WHERE MaBM = @MaBM";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaBM", txtMaBoMon.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa Bộ môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachBoMon();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa Bộ môn này vì đã chứa dữ liệu Giáo viên hoặc Môn học liên kết!", "Lỗi ràng buộc CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}