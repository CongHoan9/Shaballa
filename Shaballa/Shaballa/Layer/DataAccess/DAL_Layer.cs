using Microsoft.Data.SqlClient;

namespace Shaballa
{
    public abstract class DAL_Layer : Layer
    {
        protected string ConnectionString = "Data Source=HOAN\\HOAN12423TN;Initial Catalog = Shaballa; Integrated Security = True; TrustServerCertificate=True";
        public static string GetString(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? null : reader.GetString(index);
        }
        public static DateTime GetDateTime(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? DateTime.Now : reader.GetDateTime(index);
        }
        public static decimal GetDecimal(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? 0 : reader.GetDecimal(index);
        }
        public static double GetDouble(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? 0 : reader.GetDouble(index);
        }
        public static byte[] GetBytes(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? null : (byte[])reader[column];
        }
        public static int GetInt(SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);
            return reader.IsDBNull(index) ? 0 : reader.GetInt32(index);
        }
    }
}
