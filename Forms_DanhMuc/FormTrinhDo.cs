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
    public partial class FormTrinhDo : Form
    {
        public FormTrinhDo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            // Đổi màu nâu (ví dụ: SaddleBrown) và độ dày viền (ví dụ: 3 hoặc 4px)
            using (Pen pen = new Pen(Color.SaddleBrown, 4))
            {
                // Vẽ lại khung hình chữ nhật bao quanh GroupBox
                e.Graphics.DrawRectangle(pen, 0, 0, box.Width - 1, box.Height - 1);
            }
        }

        private void FormTrinhDo_Load(object sender, EventArgs e)
        {
            LoadDanhSachTrinhDo();
        }
        private void LoadDanhSachTrinhDo()
        {
            try
            {
                // Nếu CSDL ghi tắt MaTD, TenTD thì sửa tương ứng
                string sql = "SELECT MaTrinhDo AS [Mã Trình Độ], TenTrinhDo AS [Tên Trình Độ] FROM TrinhDo";
                DataTable dt = Database.ExecuteQuery(sql);
                dgvTrinhDo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Trình độ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTrinhDo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTrinhDo.Rows[e.RowIndex];
                if (row.Cells["Mã Trình Độ"].Value != null)
                {
                    txtMaTrinhDo.Text = row.Cells["Mã Trình Độ"].Value.ToString();
                    txtTenTrinhDo.Text = row.Cells["Tên Trình Độ"].Value?.ToString();

                    txtMaTrinhDo.Enabled = false; // Khóa Mã trình độ khi chọn sửa
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTrinhDo.Text) || string.IsNullOrWhiteSpace(txtTenTrinhDo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã trình độ và Tên trình độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO TrinhDo(MaTrinhDo, TenTrinhDo) VALUES(@MaTrinhDo, @TenTrinhDo)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTrinhDo", txtMaTrinhDo.Text.Trim()),
                    new SqlParameter("@TenTrinhDo", txtTenTrinhDo.Text.Trim())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm mới Trình độ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachTrinhDo();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu (có thể do trùng Mã trình độ): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTrinhDo.Text))
            {
                MessageBox.Show("Vui lòng chọn Trình độ cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE TrinhDo SET TenTrinhDo = @TenTrinhDo WHERE MaTrinhDo = @MaTrinhDo";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTrinhDo", txtMaTrinhDo.Text.Trim()),
                    new SqlParameter("@TenTrinhDo", txtTenTrinhDo.Text.Trim())
                };

                int result = Database.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật Trình độ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachTrinhDo();
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
            if (string.IsNullOrWhiteSpace(txtMaTrinhDo.Text))
            {
                MessageBox.Show("Vui lòng chọn Trình độ cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa trình độ [{txtTenTrinhDo.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM TrinhDo WHERE MaTrinhDo = @MaTrinhDo";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaTrinhDo", txtMaTrinhDo.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa Trình độ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachTrinhDo();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa Trình độ này vì đang có dữ liệu Giáo viên liên kết!", "Lỗi ràng buộc CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            txtMaTrinhDo.Text = "";
            txtTenTrinhDo.Text = "";
            txtMaTrinhDo.Enabled = true; // Mở lại ô nhập Mã
            txtMaTrinhDo.Focus();
        }
    }
}
