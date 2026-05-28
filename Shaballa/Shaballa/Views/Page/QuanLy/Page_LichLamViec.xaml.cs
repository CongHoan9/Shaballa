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
    /// Interaction logic for Page_LichLamViec.xaml
    /// </summary>
    public partial class Page_LichLamViec : Page
    {
        public Page_LichLamViec()
        {
            InitializeComponent();
            DataContext = new ViewModel_Page_LichLamViec();
        }
    }
}
