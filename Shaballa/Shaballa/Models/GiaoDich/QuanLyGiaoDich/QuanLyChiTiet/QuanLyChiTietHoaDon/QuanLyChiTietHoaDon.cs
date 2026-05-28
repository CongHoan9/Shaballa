namespace Shaballa
{
    public class QuanLyChiTietHoaDon : ListCombinableItem<ChiTietHoaDon>
    {
        public int Tong => this.Sum(i => i.Quantity);
        public QuanLyChiTietHoaDon() : base() { }
        public QuanLyChiTietHoaDon(IEnumerable<ChiTietHoaDon> items) : base(items) { }
    }
}
