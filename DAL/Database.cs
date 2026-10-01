using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyGioDay.DAL
{
    public class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QuanLyGioDayConn"].ConnectionString;

        // Hàm lấy kết nối SQL
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // 1. Hàm truy vấn trả về DataTable (Dùng cho SELECT / Hiển thị lên DataGridView)
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        // 2. Hàm thực thi Thêm/Sửa/Xóa (Dùng cho INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        // 3. Hàm lấy giá trị đơn (Dùng cho COUNT, SUM, lấy ID vừa tạo...)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
    }
}