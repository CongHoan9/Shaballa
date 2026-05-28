using Microsoft.Data.SqlClient;
using System.Data;

namespace Shaballa
{
    public class KhongGian_DAL : DAL_Layer
    {
        private readonly NoiThat_BUS NoiThat_BUS = new();
        public IEnumerable<KhongGian> GetKhongGian(string id = null, int? number = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetKhongGian", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Number", number);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new KhongGian
                (
                    GetString(reader, "ID"),
                    GetInt(reader, "Number"),
                    new(NoiThat_BUS.GetNoiThat(idkhonggian: GetString(reader, "ID")))
                );
            }
        }
    }
}
