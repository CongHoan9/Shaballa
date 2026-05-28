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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shaballa
{
    /// <summary>
    /// Interaction logic for Page_QuanLyKhongGian.xaml
    /// </summary>
    public partial class Page_QuanLyKhongGian : Page
    {
        public Page_QuanLyKhongGian()
        {
            InitializeComponent();
            DataContext = new ViewModel_Page_QuanLyKhongGian();
        }
    }
}
