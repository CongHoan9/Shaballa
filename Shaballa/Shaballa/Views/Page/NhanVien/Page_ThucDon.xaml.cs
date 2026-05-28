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
    /// Interaction logic for Page_ThucDon.xaml
    /// </summary>
    public partial class Page_ThucDon : Page
    {
        public Page_ThucDon()
        {
            InitializeComponent();
            GroupManager<DoUong> DoUongs = new();
            DoUong traChanh = new("1", "Trà chanh nhiệt đới", 15000, TrangThaiMatHang.Dangban, "Trà lạnh");
            DoUong traChanh2 = new("2", "Trà chanh machiato", 25000, TrangThaiMatHang.Dangban, "Trà lạnh");
            DoUong traQuat = new("4", "Kim quất nha đam", 15000, TrangThaiMatHang.Dangban, "Trà lạnh");
            DoUong traSua = new("2", "Trà sữa chân châu đường đen", 30000, TrangThaiMatHang.Dangban, "Trà sữa");
            DoUong quatSua = new("3", "Quất lắc sữa", 30000, TrangThaiMatHang.Dangban, "Trà lạnh");
            DoUong caPhe = new("3", "Cà phê", 20000, TrangThaiMatHang.Dangban, "Cà phê");
            DoUongs.Items.Add(new("NH001", "Trà lạnh", [traChanh, traChanh2, traQuat, quatSua]));
            DoUongs.Items.Add(new("NH002", "Trà Sữa", [traSua]));
            DoUongs.Items.Add(new("NH003", "Cà phê", [caPhe]));
            DoUongs.Items.Add(new("NH004", "Sữa chua", []));
            DoUongs.Items.Add(new("NH005", "Đồ đá xay", []));
            DoUongs.Items.Add(new("NH006", "Nước ép hoa quả", []));
            GroupManager<DoAn> DoAns = new();
            DoAn khoGa = new("1", "Khô gà", 25000, TrangThaiMatHang.Dangban, "Đồ ăn vặt");
            DoAn khoBo = new("2", "Khô bò", 25000, TrangThaiMatHang.Dangban, "Đồ ăn vặt");
            DoAn heoKho = new("3", "Heo khô cháy tỏi", 25000, TrangThaiMatHang.Dangban, "Đồ ăn vặt");
            DoAn xucXich = new("4", "Xúc xích", 10000, TrangThaiMatHang.Dangban, "Đồ chiên");
            DoAn caVien = new("5", "Cá viên", 25000, TrangThaiMatHang.Dangban, "Đồ chiên");
            DoAns.Items.Add(new("NH001", "Đồ ăn vặt", [khoGa, khoBo, heoKho]));
            DoAns.Items.Add(new("NH002", "Đồ chiên", [xucXich, caVien, heoKho]));
            DataContext = new ViewModel_Page_ThucDon(DoUongs, DoAns, []);
        }
        public override string ToString()
        {
            return $"Trang thực đơn";
        }
    }
}
