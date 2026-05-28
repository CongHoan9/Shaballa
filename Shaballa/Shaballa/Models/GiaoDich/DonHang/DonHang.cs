namespace Shaballa
{
    public abstract class DonHang<T>(string id, DateTime time, QuanLyChiTietDonHang<T> items, string note = null) : GiaoDich<ChiTietDonHang<T>>(id, time, items, note) where T : IThucPham
    {
        public abstract void XuatHoaDon();
        public override string ToString()
        {
            return "Đơn hàng";
        }
        public override void Gop(ICombine icombine)
        {
            if (icombine is DonHang<T> other && other != this)
            {
                if (!Note.Contains(other.Note))
                {
                    Note = $"{Note} và {other.Note}";
                }
                Items.AddRange(other.Items);
            }
        }
    }
}
