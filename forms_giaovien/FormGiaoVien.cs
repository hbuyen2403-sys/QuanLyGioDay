using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGioDay.Forms_GiaoVien
{
    public partial class FormGiaoVien : Form
    {
        public FormGiaoVien()
        {
            InitializeComponent();
        }

        //private void FormGiaoVien_Load(object sender, EventArgs e)
        //{
        //    LoadComboBoxKhoa();

        //    // 2. Load dữ liệu lên bảng DataGridView ở dưới
        //    LoadDanhSachGiaoVien();
        //}

        //private void LoadComboBoxKhoa()
        //{
        //    string query = "SELECT MaKhoa, TenKhoa FROM Khoa";
        //    DataTable dt = DatabaseHelper.ExecuteQuery(query);

        //    cboKhoa.DataSource = dt;
        //    cboKhoa.DisplayMember = "TenKhoa"; // Hiển thị tên khoa cho người dùng dễ chọn
        //    cboKhoa.ValueMember = "MaKhoa";     // Giá trị ngầm bên trong là Mã Khoa
        //}

        //private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboKhoa.SelectedValue != null && cboKhoa.SelectedValue.ToString() != "System.Data.DataRowView")
        //    {
        //        string maKhoa = cboKhoa.SelectedValue.ToString();

        //        // Câu lệnh SQL lọc các bộ môn có MaKhoa khớp với Khoa đang được chọn
        //        string query = $"SELECT MaBM, TenBM FROM BoMon WHERE MaKhoa = '{maKhoa}'";
        //        DataTable dt = DatabaseHelper.ExecuteQuery(query);

        //        // Đổ dữ liệu bộ môn vừa lọc vào ComboBox Bộ môn
        //        cboBoMon.DataSource = dt;
        //        cboBoMon.DisplayMember = "TenBM"; // Hiển thị tên bộ môn
        //        cboBoMon.ValueMember = "MaBM";   // Giá trị ngầm là Mã bộ môn
        //    }
        //}

        //private void LoadDanhSachGiaoVien()
        //{
        //    string query = "SELECT * FROM GiaoVien";
        //    DataTable dt = DatabaseHelper.ExecuteQuery(query);
        //    dgvGiaoVien.DataSource = dt;
        //}
    }
}
