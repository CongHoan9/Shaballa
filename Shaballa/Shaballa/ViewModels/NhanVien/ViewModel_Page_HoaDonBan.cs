using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Page_HoaDonBan : Binding
    {
        public static ListCombinableItem<HoaDonBan> HoaDonBans => HoaDon_BUS.Instance.HoaDonBans;
        public static List<string> ThanhToanTypes => ["Tất cả", "Tiền mặt", "Chuyển khoản"];
        public string SelectedThanhToanType { get; set; } = ThanhToanTypes[0];
        public ICommand CmdSort { get; }
        public ViewModel_Page_HoaDonBan()
        {
            CmdSort = new RunCommand(param => HoaDonBans.Sort($"{param}"));
        }
    }
}
