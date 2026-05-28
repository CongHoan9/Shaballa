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
    /// Interaction logic for Win_ThemLichLam.xaml
    /// </summary>
    public partial class Win_ThemLichLam : Window
    {
        public Win_ThemLichLam(Action<Lich> oncreate)
        {
            InitializeComponent();
            DataContext = new ViewModel_Win_ThemLichLam(oncreate);
        }
    }
}
