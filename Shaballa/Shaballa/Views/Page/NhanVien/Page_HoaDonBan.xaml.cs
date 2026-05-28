using System.Windows;
using System.Windows.Controls;
namespace Shaballa
{
    public partial class Page_HoaDonBan : Page
    {
        public Page_HoaDonBan()
        {
            InitializeComponent();
            DataContext = new ViewModel_Page_HoaDonBan();
        }
        public override string ToString()
        {
            return "Quản lý hóa đơn bán";
        }
    }
}
