using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Shaballa
{
    public class Account_DAL : DAL_Layer
    {
        public Account CreateAccount(string name, string matkhau, string number, string address, string role = null)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("CreateAccount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Password", matkhau);
                cmd.Parameters.AddWithValue("@Phone", number);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Role", role);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Account
                    (
                        GetString(reader, "ID"),
                        GetString(reader, "Name"),
                        GetString(reader, "Phone"),
                        GetString(reader, "Address"),
                        GetString(reader, "Note"),
                        GetBytes(reader, "Image")
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Tạo tài khoản thất bại");
            }
            return null;
        }
        public IEnumerable<Account> GetAccount(string id = null, string name = null, string phone = null, string address = null, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Role", "Nhân viên");
            cmd.Parameters.AddWithValue("@Key", key);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return GetAccountOnReader(reader);
            }
        }
        public static Account GetAccountOnReader(SqlDataReader reader)
        {
            return new Account
            (
                GetString(reader, "ID"),
                GetString(reader, "Name"),
                GetString(reader, "Phone"),
                GetString(reader, "Address"),
                GetString(reader, "Note"),
                GetBytes(reader, "Image")
            );
        }
    }
}
