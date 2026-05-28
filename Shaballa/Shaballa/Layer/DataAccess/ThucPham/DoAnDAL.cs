using Microsoft.Data.SqlClient;
using System.Data;
namespace Shaballa
{
    public class DoAnDAL : DAL_Layer
    {
        public IEnumerable<DoAn> GetDoAn(string nhom = null, string ten = null, decimal gia = -1, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetDoAn", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nhom", (object)nhom ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ten", (object)ten ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Gia", gia >= 0 ? gia : DBNull.Value);
            cmd.Parameters.AddWithValue("@Key", (object)key ?? DBNull.Value);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new DoAn
                (
                    $"{reader["ID"]}",
                    $"{reader["Name"]}",
                    Convert.ToDecimal(reader["Gia"]),
                    TrangThaiMatHang.Dangban,
                    $"{reader["Nhom"]}",
                    $"{reader["GhiChu"]}",
                    reader["Image"] as byte[]
                );
            }
        }
    }
}
