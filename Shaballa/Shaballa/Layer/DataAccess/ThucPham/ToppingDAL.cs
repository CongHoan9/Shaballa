using Microsoft.Data.SqlClient;
using System.Data;

namespace Shaballa
{
    public class ToppingDAL : DAL_Layer
    {
        public IEnumerable<Topping> GetTopping(string ten = null, decimal gia = -1, string donvi = null, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetTopping", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", (object)ten ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Gia", gia >= 0 ? gia : DBNull.Value);
            cmd.Parameters.AddWithValue("@DonVi", (object)donvi ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Key", (object)key ?? DBNull.Value);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new Topping
                (
                    $"{reader["ID"]}",
                    $"{reader["Name"]}",
                    Convert.ToDecimal(reader["Gia"]),
                    TrangThaiMatHang.Dangban,
                    TrangThaiNguyenLieu.None,
                    (int)reader["DonVi"],
                    $"{reader["DonVi"]}",
                    $"{reader["GhiChu"]}",
                    reader["HinhAnh"] as byte[]
                );
            }
        }
    }
}
