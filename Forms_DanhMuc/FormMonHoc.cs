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
    public partial class FormMonHoc : Form
    {
        private bool isAdding = false;

        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            LoadComboBoxKhoa();
            LoadDanhSachMonHoc();
            SetState(false);
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
                DataTable dt = Database.ExecuteQuery(sql);

                cboKhoa.DataSource = dt;
                cboKhoa.DisplayMember = "TenKhoa"; // Hiển thị Tên khoa trên giao diện
                cboKhoa.ValueMember = "MaKhoa";     // Giá trị ẩn bên dưới là Mã khoa
                cboKhoa.SelectedIndex = -1;       // Để trống khi mới mở form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachMonHoc(string keyword = "")
        {
            try
            {
                string sql = @"SELECT mh.MaMon AS [Mã Môn Học], 
                                     mh.TenMon AS [Tên Môn Học], 
                                     mh.SoTiet AS [Số Tiết], 
                                     k.TenKhoa AS [Khoa Quản Lý],
                                     mh.MaKhoa
                              FROM MonHoc mh 
                              LEFT JOIN Khoa k ON mh.MaKhoa = k.MaKhoa";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += " WHERE mh.MaMon LIKE @Keyword OR mh.TenMon LIKE @Keyword";
                }

                SqlParameter[] parameters = null;
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Keyword", "%" + keyword.Trim() + "%")
                    };
                }

                DataTable dt = Database.ExecuteQuery(sql, parameters);
                dgvMonHoc.DataSource = dt;

                // Ẩn cột MaKhoa ẩn ở lưới
                if (dgvMonHoc.Columns["MaKhoa"] != null)
                {
                    dgvMonHoc.Columns["MaKhoa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Quản lý trạng thái Nút bấm và các ô nhập liệu
        private void SetState(bool editing)
        {
            txtMaMH.Enabled = editing && isAdding; // Ô Mã chỉ mở khi thêm mới
            txtTenMH.Enabled = editing;
            txtSoTiet.Enabled = editing;
            cboKhoa.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing; // Nút Lưu sáng lên khi Thêm hoặc Sửa
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
                if (row.Cells["Mã Môn Học"].Value != null && row.Cells["Mã Môn Học"].Value != DBNull.Value)
                {
                    txtMaMH.Text = row.Cells["Mã Môn Học"].Value.ToString();
                    txtTenMH.Text = row.Cells["Tên Môn Học"].Value?.ToString();
                    txtSoTiet.Text = row.Cells["Số Tiết"].Value?.ToString();

                    // Chọn đúng Khoa tương ứng trên ComboBox
                    if (row.Cells["MaKhoa"].Value != DBNull.Value && row.Cells["MaKhoa"].Value != null)
                    {
                        cboKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
                    }
                    else
                    {
                        cboKhoa.SelectedIndex = -1;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ResetForm();
            SetState(true);
            txtMaMH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng chọn Môn học cần sửa từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            SetState(true);
            txtTenMH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã môn học và Tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiếm tra định dạng kiểu số cho Số tiết
            int soTiet = 0;
            if (!string.IsNullOrWhiteSpace(txtSoTiet.Text) && !int.TryParse(txtSoTiet.Text.Trim(), out soTiet))
            {
                MessageBox.Show("Số tiết phải là một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTiet.Focus();
                return;
            }

            object maKhoaValue = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : (object)DBNull.Value;

            try
            {
                if (isAdding) // THỰC HIỆN THÊM MỚI
                {
                    string sql = "INSERT INTO MonHoc(MaMon, TenMon, SoTiet, MaKhoa) VALUES(@MaMon, @TenMon, @SoTiet, @MaKhoa)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaMon", txtMaMH.Text.Trim()),
                        new SqlParameter("@TenMon", txtTenMH.Text.Trim()),
                        new SqlParameter("@SoTiet", string.IsNullOrWhiteSpace(txtSoTiet.Text) ? (object)DBNull.Value : soTiet),
                        new SqlParameter("@MaKhoa", maKhoaValue)
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm mới Môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // THỰC HIỆN CẬP NHẬT
                {
                    string sql = "UPDATE MonHoc SET TenMon = @TenMon, SoTiet = @SoTiet, MaKhoa = @MaKhoa WHERE MaMon = @MaMon";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaMon", txtMaMH.Text.Trim()),
                        new SqlParameter("@TenMon", txtTenMH.Text.Trim()),
                        new SqlParameter("@SoTiet", string.IsNullOrWhiteSpace(txtSoTiet.Text) ? (object)DBNull.Value : soTiet),
                        new SqlParameter("@MaKhoa", maKhoaValue)
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật Môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadDanhSachMonHoc();
                SetState(false);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng chọn Môn học cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa môn học [{txtTenMH.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaMon", txtMaMH.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa Môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachMonHoc();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa Môn học này vì đã có dữ liệu Phân công giảng dạy liên kết!", "Lỗi ràng buộc CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSachMonHoc(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            SetState(false);
            txtTimKiem.Text = "";
            LoadDanhSachMonHoc();
        }

        private void ResetForm()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtSoTiet.Text = "";
            cboKhoa.SelectedIndex = -1;
        }
    }
}