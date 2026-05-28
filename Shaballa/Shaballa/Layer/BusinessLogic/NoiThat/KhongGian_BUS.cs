namespace Shaballa
{
    public class KhongGian_BUS : BUS_layer<KhongGian_DAL>
    {
        private static readonly KhongGian_BUS _Instance = new();
        public static KhongGian_BUS Instance => _Instance;
        public ListRemovableItem<KhongGian> KhongGians { get; }
        public KhongGian_BUS()
        {
            KhongGians = new(GetKhongGians());
        }
        public IEnumerable<KhongGian> GetKhongGians(string id = null, int? number = null)
        {
            return DAL.GetKhongGian(id, number);
        }
    }
}
