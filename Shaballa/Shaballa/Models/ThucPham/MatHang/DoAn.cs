namespace Shaballa
{
    public class DoAn(string id, string name, decimal gia, TrangThaiMatHang trangthaimathang, string nhom, string note = "", byte[] image = null) : MatHang(id, name, gia, trangthaimathang, nhom, note, image)
    {
        public override ListCombinableItem<BuocThucHien> GetCongThuc()
        {
            return null;
        }
    }
}
