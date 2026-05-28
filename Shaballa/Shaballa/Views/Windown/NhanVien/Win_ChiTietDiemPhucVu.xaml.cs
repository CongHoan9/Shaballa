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
    /// Interaction logic for Win_ChiTietDiemPhucVu.xaml
    /// </summary>
    public partial class Win_ChiTietDiemPhucVu : Window
    {
        public Win_ChiTietDiemPhucVu(DiemPhucVu diemphucvu)
        {
            InitializeComponent();
            Console.WriteLine("Đã mở giao diện quản lý điểm phục vụ");
            DataContext = new ViewModel_Win_ChiTietDiemPhucVu(diemphucvu);
        }
    }
}
