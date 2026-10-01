using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGioDay;

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
    }
}
