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
    public partial class FormChuyenNganh : Form
    {
        private bool isAdding = false;

        public FormChuyenNganh()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadDanhSachChuyenNganh();
            SetState(false);
        }

        private void LoadDanhSachChuyenNganh(string keyword = "")
        {
            try
            {
                string sql = @"SELECT MaChNganh AS [Mã Chuyên Ngành], 
                                     TenChNganh AS [Tên Chuyên Ngành]
                              FROM ChuyenNganh";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += " WHERE MaChNganh LIKE @Keyword OR TenChNganh LIKE @Keyword";
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
                dgvChuyenNganh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Chuyên ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetState(bool editing)
        {
            txtMaCN.Enabled = editing && isAdding; // Chỉ cho sửa Mã khi bấm Thêm mới
            txtTenCN.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
        }

        private void dgvChuyenNganh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow row = dgvChuyenNganh.Rows[e.RowIndex];
                if (row.Cells["Mã Chuyên Ngành"].Value != null)
                {
                    txtMaCN.Text = row.Cells["Mã Chuyên Ngành"].Value.ToString();
                    txtTenCN.Text = row.Cells["Tên Chuyên Ngành"].Value?.ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ResetForm();
            SetState(true);
            txtMaCN.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Vui lòng chọn Chuyên ngành cần sửa từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            SetState(true);
            txtTenCN.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text) || string.IsNullOrWhiteSpace(txtTenCN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã chuyên ngành và Tên chuyên ngành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isAdding) // THỰC HIỆN THÊM MỚI
                {
                    string sql = "INSERT INTO ChuyenNganh(MaChNganh, TenChNganh) VALUES(@MaCN, @TenCN)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaCN", txtMaCN.Text.Trim()),
                        new SqlParameter("@TenCN", txtTenCN.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm mới Chuyên ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // THỰC HIỆN CẬP NHẬT
                {
                    string sql = "UPDATE ChuyenNganh SET TenChNganh = @TenCN WHERE MaChNganh = @MaCN";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaCN", txtMaCN.Text.Trim()),
                        new SqlParameter("@TenCN", txtTenCN.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật Chuyên ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadDanhSachChuyenNganh();
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
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Vui lòng chọn Chuyên ngành cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chuyên ngành [{txtTenCN.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM ChuyenNganh WHERE MaChNganh = @MaCN";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaCN", txtMaCN.Text.Trim())
                    };

                    int result = Database.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa Chuyên ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachChuyenNganh();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa Chuyên ngành này vì đang có dữ liệu Giáo viên/Lớp liên kết!", "Lỗi ràng buộc CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDanhSachChuyenNganh(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            SetState(false);
            txtTimKiem.Text = "";
            LoadDanhSachChuyenNganh();
        }

        private void ResetForm()
        {
            txtMaCN.Text = "";
            txtTenCN.Text = "";
        }
    }
}