using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Windows;

namespace Shaballa
{
    public class HoaDon_DAL : DAL_Layer
    {
        private readonly ChiTiet_DAL DAL = new();
        public IEnumerable<HoaDonBan> GetHoaDonBan(string id = null, string idaccount = null, string idnoithat = null, string paytype = null, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetHoaDonBan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@IDAccount", idaccount);
            cmd.Parameters.AddWithValue("@IDNoiThat", idnoithat);
            cmd.Parameters.AddWithValue("@PayType", paytype);
            cmd.Parameters.AddWithValue("@Key", key);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new HoaDonBan
                (
                    GetString(reader, "ID"),
                    GetString(reader, "IDAccount"),
                    GetString(reader, "IDNoiThat"),
                    GetString(reader, "PayType"),
                    GetDateTime(reader, "Time"),
                    new(DAL.GetChiTietHoaDon(idhoadon: GetString(reader, "ID"))),
                    GetString(reader, "Note")
                );
            }
        }
        public HoaDonBan CreateHoaDonBan(string idaccount, string idnoithat, string paytype, ListCombinableItem<ChiTietDonHang<IMatHang>> chitiets, string note = null)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("CreateHoaDonBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDAccount", idaccount);
                cmd.Parameters.AddWithValue("@IDNoiThat", idnoithat);
                cmd.Parameters.AddWithValue("@PayType", paytype);
                cmd.Parameters.AddWithValue("@Note", note);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new HoaDonBan
                    (
                        GetString(reader, "ID"),
                        GetString(reader, "IDAccount"),
                        GetString(reader, "IDNoiThat"),
                        GetString(reader, "PayType"),
                        GetDateTime(reader, "Time"),
                        DAL.CreateChiTietHoaDonBans(GetString(reader, "ID"), chitiets),
                        GetString(reader, "Note")
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Tạo hóa đơn thất bại");
            }
            return null;
        }
    }
}
