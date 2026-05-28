namespace Shaballa
{
    public class DoUongBUS : BUS_layer<DoUongDAL>
    {
        private static readonly DoUongBUS _Instance = new();
        public static DoUongBUS Instance => _Instance;
        public IEnumerable<DoUong> GetDoUong(string id = null, string name = null, string group = null, decimal? price = null, string key = null)
        {
            return DAL.GetDoUong(id, name, group, price, key);
        }
    }
}
