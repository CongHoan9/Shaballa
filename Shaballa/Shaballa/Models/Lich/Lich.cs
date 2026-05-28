namespace Shaballa
{
    public enum CaLam
    {
        Toi = 0,
        Chieu = 1,
        Sang = 2,
        None = -1,
    }
    public class Lich(string id, DateTime time, CaLam calam, ListLichLamNhanVien accounts) : StructbleItem<int>(id, ThuVN(time), (int)calam)
    {
        public CaLam CaLam
        {
            get => calam;
            set
            {
                if (calam != value)
                {
                    calam = value;
                    OnPropertyChanged(nameof(CaLam));
                }
            }
        }
        public DateTime Time
        {
            get => time;
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged(nameof(CaLam));
                }
            }
        }
        public ListLichLamNhanVien Accounts => accounts;
        private static int ThuVN(DateTime d)
        {
            return d.DayOfWeek switch
            {
                DayOfWeek.Sunday => 6,
                DayOfWeek.Monday => 0,
                DayOfWeek.Tuesday => 1,
                DayOfWeek.Wednesday => 2,
                DayOfWeek.Thursday => 3,
                DayOfWeek.Friday => 4,
                DayOfWeek.Saturday => 5,
                _ => 0
            };
        }
        public static string ConverterCaToString(CaLam calam)
        {
            return calam switch
            {
                CaLam.Toi => "Tối",
                CaLam.Chieu => "Chiều",
                CaLam.Sang => "Sáng",
                _ => null
            };
        }
        public static CaLam ConverterStringToCa(string calam)
        {
            return calam switch
            {
                "Tối" => CaLam.Toi,
                "Ca tối" => CaLam.Toi,
                "Chiều" => CaLam.Chieu,
                "Ca chiều" => CaLam.Chieu,
                "Sáng" => CaLam.Sang,
                "Ca sáng" => CaLam.Sang,
                _ => CaLam.None,
            };
        }
    }
}
