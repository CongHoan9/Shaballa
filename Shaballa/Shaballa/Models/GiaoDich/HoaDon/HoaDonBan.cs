namespace Shaballa
{
    public class HoaDonBan(string id, string idaccount, string diemphucvu, string paytype, DateTime time, QuanLyChiTietHoaDon items, string note = null) : HoaDon(id, idaccount, time, items, note)
    {
        public string DiemPhucVu => GetString(diemphucvu, "Không có dữ liệu");
        public string PayType => GetString(paytype, "Không có phương thức thanh toán");
    }
}
