namespace Shaballa
{
    public class DoUong(string id, string name, decimal gia, TrangThaiMatHang trangthaimathang, string nhom, string note = "", byte[] image = null) : MatHang(id, name, gia, trangthaimathang, nhom, note, image)
    {
        public override ListCombinableItem<BuocThucHien> GetCongThuc()
        {
            return [];
        }
    }
}
