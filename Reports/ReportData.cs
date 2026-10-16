using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyGioDay.Reports
{
    // Các truy vấn bên dưới được đối chiếu với bản EXE do nhóm cung cấp.
    internal static class ReportData
    {
        internal static void LoadTeachers(ComboBox cbo)
        {
            DataTable dt = Database.GetData("SELECT MaGV, TenGV FROM GiaoVien");
            cbo.DisplayMember = "TenGV";
            cbo.ValueMember = "MaGV";
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }

        internal static void LoadTerms(ComboBox ky, ComboBox nam)
        {
            ky.Items.Clear();
            ky.Items.AddRange(new object[] { "1", "2", "Hè" });
            nam.Items.Clear();
            nam.Items.AddRange(new object[] { "2025-2026", "2026-2027" });
            ky.SelectedIndex = -1;
            nam.SelectedIndex = -1;
        }

        internal static bool HasSelection(ComboBox gv, ComboBox ky, ComboBox nam)
        {
            if (gv.SelectedIndex >= 0 && gv.SelectedValue != null &&
                ky.SelectedItem != null && nam.SelectedItem != null) return true;
            MessageBox.Show("Vui lòng chọn đầy đủ Giáo viên, Kỳ dạy và Năm học!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        internal static DataTable Query(string sql, ComboBox gv, ComboBox ky, ComboBox nam)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MaGV", gv.SelectedValue.ToString()),
                new SqlParameter("@KiHoc", ky.SelectedItem.ToString()),
                new SqlParameter("@NamHoc", nam.SelectedItem.ToString())
            };
            return Database.ExecuteQuery(sql, parameters);
        }

        internal static void Bind(DataGridView grid, DataTable table)
        {
            grid.AutoGenerateColumns = false;
            grid.DataSource = table;
        }

        internal static decimal Total(DataTable table, string column)
        {
            decimal total = 0m;
            foreach (DataRow row in table.Rows)
            {
                if (row[column] != DBNull.Value)
                    total += Convert.ToDecimal(row[column]);
            }
            return total;
        }

        internal static string SelectedTeacherName(ComboBox cbo)
        {
            DataRowView item = cbo.SelectedItem as DataRowView;
            return item == null ? "" : Convert.ToString(item["TenGV"]);
        }

        internal static string Summary(ComboBox gv, ComboBox ky, ComboBox nam, int count,
                                       decimal total, bool isTeaching)
        {
            return string.Format("Giáo viên: {0} ({1})\nKỳ dạy: {2} - Năm học: {3}\nSố lịch {4}: {5}\nTổng tiền {4}: {6:N0} VNĐ",
                SelectedTeacherName(gv), gv.SelectedValue,
                ky.SelectedItem, nam.SelectedItem,
                isTeaching ? "dạy" : "thi", count, total);
        }
    }
}
