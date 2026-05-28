using System.Windows.Controls;
using System.Windows.Input;
namespace Shaballa
{
    public partial class Page_QuanLyOrder : Page
    {
        public Page_QuanLyOrder()
        {
            InitializeComponent();
            DataContext = new ViewModel_Page_QuanLyOrder();
        }
        public override string ToString()
        {
            return "Quản lý đơn hàng";
        }
    }
}
