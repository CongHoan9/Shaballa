using System.Windows;
namespace Shaballa
{
    public partial class Win_NhanVien : Window
    {
        public Win_NhanVien(Account account)
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_NhanVien(account);
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Console.WriteLine($"Đăng nhập vào lúc: {DateTime.Now}");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Console.WriteLine($"Đăng xuất vào lúc: {DateTime.Now}");
        }
    }
}
