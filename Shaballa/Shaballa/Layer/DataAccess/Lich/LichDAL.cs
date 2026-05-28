

using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Windows;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shaballa
{
    public class LichDAL : DAL_Layer
    {
        public Lich CreateLichLam(string idaccount, RoleOnCaLam role, DateTime time, CaLam calam)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("CreateLichLam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDAccount", idaccount);
                cmd.Parameters.AddWithValue("@RoleOnCaLam", LichLamNhanVien.ConverterVaiTroToString(role));
                cmd.Parameters.AddWithValue("@Time", time);
                cmd.Parameters.AddWithValue("@Ca", Lich.ConverterCaToString(calam));
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Lich
                    (
                        GetString(reader, "ID"),
                        GetDateTime(reader, "Time"),
                        Lich.ConverterStringToCa(GetString(reader, "Ca")),
                        new(GetNhanVienLichLam(GetString(reader, "ID")))
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Không thể thêm lịch làm");
            }
            return null;
        }
        public IEnumerable<Lich> GetLichLam(string id = null, DateTime? time = null, CaLam calam = CaLam.None, string key = null, bool isWeek = true)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetLichLam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Time", time);
            cmd.Parameters.AddWithValue("@Ca", Lich.ConverterCaToString(calam));
            cmd.Parameters.AddWithValue("@Key", key);
            cmd.Parameters.AddWithValue("@TrongTuanHienTai", isWeek);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new Lich
                (
                    GetString(reader, "ID"),
                    GetDateTime(reader, "Time"),
                    Lich.ConverterStringToCa(GetString(reader, "Ca")),
                    new(GetNhanVienLichLam(GetString(reader, "ID")))
                );
            }
        }
        public IEnumerable<LichLamNhanVien> GetNhanVienLichLam(string idlichlam = null, string idaccount = null, RoleOnCaLam role = RoleOnCaLam.None, DateTime? time = null, CaLam calam = CaLam.None, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetNhanVienLichLam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDLichLam", idlichlam);
            cmd.Parameters.AddWithValue("@IDAccount", idaccount);
            cmd.Parameters.AddWithValue("@RoleOnCaLam", LichLamNhanVien.ConverterVaiTroToString(role));
            cmd.Parameters.AddWithValue("@Time", time);
            cmd.Parameters.AddWithValue("@Ca", Lich.ConverterCaToString(calam));
            cmd.Parameters.AddWithValue("@Key", key);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new(Account_DAL.GetAccountOnReader(reader), LichLamNhanVien.ConverterStringToVaiTro(GetString(reader, "RoleOnCaLam")));
            }
        }
    }
}
