namespace Shaballa
{
    public class ThucPhamBUS : BUS_layer<ThucPhamDAL>
    {
        private readonly DoUongDAL DoUongDAL = new();
        public IEnumerable<IThucPham> GetThucPham()
        {
            return [];
        }
        public IEnumerable<IMatHang> GetMatHang()
        {
            return DoUongDAL.GetDoUong();
        }
    }
}
