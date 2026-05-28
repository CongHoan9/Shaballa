using System.Windows;
namespace Shaballa
{
    public partial class Win_DangNhap : Window
    {
        public Win_DangNhap()
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_DangNhap();
        }
    }
}