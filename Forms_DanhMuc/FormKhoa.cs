using QuanLyGioDay;
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
    public partial class FormKhoa : Form
    {
        public FormKhoa()
        {
            InitializeComponent();
        }
        private void LoadDanhSachKhoa()
        {
            try
            {
                string sql = "SELECT MaKhoa AS [Mã Khoa], TenKhoa AS [Tên Khoa] FROM Khoa";
                DataTable dt = Database.ExecuteQuery(sql);
                dgvKhoa.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormKhoa_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];
                txtMaKhoa.Text = row.Cells["Mã Khoa"].Value?.ToString();
                txtTenKhoa.Text = row.Cells["Tên Khoa"].Value?.ToString();

                // Khóa ô Mã khoa khi chọn sửa (vì Mã khoa là Khóa chính)
                txtMaKhoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtMaKhoa.Text) || string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã khoa và Tên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@MaKhoa, @TenKhoa)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhoa", txtMaKhoa.Text.Trim()),
                    new SqlParameter("@TenKhoa", txtTenKhoa.Text.Trim())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhoa();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu (có thể do trùng Mã khoa): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtMaKhoa.Enabled = true; // Mở lại ô Mã khoa cho phép nhập thêm
            txtMaKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Vui lòng chọn Khoa cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE Khoa SET TenKhoa = @TenKhoa WHERE MaKhoa = @MaKhoa";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhoa", txtMaKhoa.Text.Trim()),
                    new SqlParameter("@TenKhoa", txtTenKhoa.Text.Trim())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhoa();
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
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Vui lòng chọn Khoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaKhoa", txtMaKhoa.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhoa();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa Khoa này vì đã có dữ liệu Bộ môn/Giáo viên liên kết!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
