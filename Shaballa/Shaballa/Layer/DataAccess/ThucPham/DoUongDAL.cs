using Microsoft.Data.SqlClient;
using System.Data;
namespace Shaballa
{
    public class DoUongDAL : DAL_Layer
    {
        public IEnumerable<DoUong> GetDoUong(string id = null, string name = null, string group = null, decimal? price = null, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetDoUong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Group", group);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Key", key);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new DoUong
                (
                    GetString(reader, "ID"),
                    GetString(reader, "Name"),
                    GetDecimal(reader, "Price"),
                    Conveter(GetInt(reader, "State")),
                    GetString(reader, "GroupName"),
                    GetString(reader, "Note"),
                    GetBytes(reader, "Image")
                );
            }
        }
        public TrangThaiMatHang Conveter(int state)
        {
            return state switch
            {
                0 => TrangThaiMatHang.Dangban,
                1 => TrangThaiMatHang.Ngungban,
                _ => TrangThaiMatHang.None,
            };
        }
    }
}
