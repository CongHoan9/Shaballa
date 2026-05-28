namespace Shaballa
{
    public class LichBUS : BUS_layer<LichDAL>
    {
        private static readonly LichBUS _Instance = new();
        public static LichBUS Instance => _Instance;

        private ListRemovableItem<Lich> _Lichs = [];
        public ListRemovableItem<Lich> Lichs
        {
            get => _Lichs;
            set
            {
                if (_Lichs != value)
                {
                    _Lichs = value;
                    OnPropertyChanged(nameof(Lichs));
                }
            }
        }
        public LichBUS()
        {
            Lichs = new(GetLichLam(isWeek: false));
        }
        public Lich CreateLichLam(string idaccount, RoleOnCaLam role, DateTime time, CaLam calam)
        {
            if (CheckString(idaccount) && calam != CaLam.None && role != RoleOnCaLam.None)
            {
                return DAL.CreateLichLam(idaccount, role, time, calam);
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Lich> GetLichLam(string id = null, DateTime? time = null, CaLam calam = CaLam.None, string key = null, bool isWeek = true)
        {
            return DAL.GetLichLam(id, time, calam, key, isWeek);
        }
    }
}
