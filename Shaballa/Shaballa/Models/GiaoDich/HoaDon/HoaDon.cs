namespace Shaballa
{
    public abstract class HoaDon(string id, string idaccount, DateTime time, QuanLyChiTietHoaDon items, string note = null) : GiaoDich<ChiTietHoaDon>(id, time, items, note)
    {
        public virtual string IDAccount => GetString(idaccount);
        public virtual decimal TongTien => Items.Sum(i => i.DonGia);
        public override string ToString()
        {
            return $"{Items}";
        }
        public override void Gop(ICombine icombine)
        {
            if (icombine is HoaDon other && other != this)
            {
                Items.AddRange(other.Items);
            }
        }
    }
}
