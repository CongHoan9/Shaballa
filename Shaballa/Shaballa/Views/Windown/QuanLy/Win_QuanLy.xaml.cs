
using System.Windows;
namespace Shaballa
{
    /// <summary>
    /// Interaction logic for Win_QuanLy.xaml
    /// </summary>
    public partial class Win_QuanLy : Window
    {
        public Win_QuanLy(Account account)
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_QuanLy(account);
        }
    }
}
