using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Windows;

namespace Shaballa
{
    public class ChiTiet_DAL : DAL_Layer
    {
        public IEnumerable<ChiTietHoaDon> GetChiTietHoaDon(string id = null, string idhoadon = null, string item = null, string key = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("GetChiTietHoaDonBan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@IDHoaDon", idhoadon);
            cmd.Parameters.AddWithValue("@IDThucPham", item);
            cmd.Parameters.AddWithValue("@Key", key);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new ChiTietHoaDon
                (
                    GetString(reader, "ID"),
                    GetString(reader, "IDThucPham"),
                    GetInt(reader, "Quantity"),
                    GetDecimal(reader, "DonGia")
                );
            }
        }
        public QuanLyChiTietHoaDon CreateChiTietHoaDonBans(string idhoadon, ListCombinableItem<ChiTietDonHang<IMatHang>> chitiets)
        {
            QuanLyChiTietHoaDon newchitiets = [];
            try
            {
                foreach (var i in chitiets)
                {
                    if (CreateChiTietHoaDonBan(idhoadon, i.Item.ID, i.Quantity, i.DonGia) is ChiTietHoaDon newchitiet)
                    {
                        newchitiets.Add(newchitiet);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return newchitiets;
        }
        public ChiTietHoaDon CreateChiTietHoaDonBan(string idhoadon, string idthucpham, int quantity, decimal dongia)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("CreateChiTietHoaDonBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDHoaDon", idhoadon);
                cmd.Parameters.AddWithValue("@IDThucPham", idthucpham);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@DonGia", dongia);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ChiTietHoaDon
                    (
                        GetString(reader, "ID"),
                        GetString(reader, "IDThucPham"),
                        GetInt(reader, "Quantity"),
                        GetDecimal(reader, "DonGia")
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return null;
        }
    }
}
