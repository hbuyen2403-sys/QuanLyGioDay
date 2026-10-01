using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyGioDay
{
    public class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGioDayConn"].ConnectionString;

        // 1. Hàm lấy dữ liệu nạp vào DataGridView / ComboBox (Chạy câu lệnh SELECT)
        public static DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Hàm thực thi Thêm / Sửa / Xóa (Chạy câu lệnh INSERT, UPDATE, DELETE)
        public static bool ExecuteSql(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}