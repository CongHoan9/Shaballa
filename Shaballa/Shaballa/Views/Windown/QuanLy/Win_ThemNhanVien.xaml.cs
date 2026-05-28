using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shaballa
{
    /// <summary>
    /// Interaction logic for Win_ThemNhanVien.xaml
    /// </summary>
    public partial class Win_ThemNhanVien : Window
    {
        public Win_ThemNhanVien(Action<Account> onSuccess)
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_ThemNhanVien(onSuccess);
        }
    }
}
