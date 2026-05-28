using System.Windows;
namespace Shaballa
{
    /// <summary>
    /// Interaction logic for Win_TaoDonHang.xaml
    /// </summary>
    public partial class Win_TaoDonHang : Window
    {
        public Win_TaoDonHang(Action<QuanLyChiTietDonHangBan, string> onsave)
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_TaoDonHang(onsave);
        }
    }
}
