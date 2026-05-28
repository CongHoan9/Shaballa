using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Shaballa
{
    public class NoiThat_DAL : DAL_Layer
    {
        public NoiThat CreateNoiThat(double x, double y, string name, string type, string idkhonggian)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("CreateNoiThat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@X", x);
                cmd.Parameters.AddWithValue("@Y", y);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@IDKhongGian", idkhonggian);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new BanGhe
                    (
                        GetString(reader, "ID"),
                        GetString(reader, "Name"),
                        GetDouble(reader, "X"),
                        GetDouble(reader, "Y"),
                        TrangThai.Trong
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Không thể thêm nội thất");
            }
            return null;
        }
        public IEnumerable<BanGhe> GetNoiThat(string id = null, string name = null, string idkhonggian = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetNoiThat", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@IDKhongGian", idkhonggian);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new BanGhe
                (
                    GetString(reader, "ID"),
                    GetString(reader, "Name"),
                    GetDouble(reader, "X"),
                    GetDouble(reader, "Y"),
                    TrangThai.Trong
                );
            }
        }
    }
}
