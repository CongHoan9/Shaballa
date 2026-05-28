namespace Shaballa
{
    public class HoaDon_BUS : BUS_layer<HoaDon_DAL>
    {
        private static readonly HoaDon_BUS _Instance = new();
        public static HoaDon_BUS Instance => _Instance;
        public ListCombinableItem<HoaDonBan> HoaDonBans { get; }
        public ListCombinableItem<HoaDonNhap> HoaDonNhaps { get; }
        public HoaDon_BUS()
        {
            HoaDonBans = new(GetHoaDonBan());
        }
        public IEnumerable<HoaDonBan> GetHoaDonBan(string id = null, string idaccount = null, string idnoithat = null, string paytype = null, string key = null)
        {
            return DAL.GetHoaDonBan(id, idaccount, idnoithat, paytype, key);
        }
        public HoaDonBan CreateHoaDonBan(string idaccount, string idnoithat, string paytype, ListCombinableItem<ChiTietDonHang<IMatHang>> chitiets, string note = null)
        {
            if (CheckString(idaccount) && CheckString(idnoithat) && CheckString(paytype))
            {
                return DAL.CreateHoaDonBan(idaccount, idnoithat, paytype, chitiets, note);
            }
            else
            {
                return null;
            }
        }
    }
}
