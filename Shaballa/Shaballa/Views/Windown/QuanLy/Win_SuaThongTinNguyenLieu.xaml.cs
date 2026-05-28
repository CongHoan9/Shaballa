using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
namespace Shaballa
{
    /// <summary>
    /// Interaction logic for Win_SuaThongTinNguyenLieu.xaml
    /// </summary>
    public partial class Win_SuaThongTinNguyenLieu : Window
    {
        public Win_SuaThongTinNguyenLieu(NguyenLieu nguyenlieu)
        {
            InitializeComponent();
            DataContext = new V1(nguyenlieu);
        }
    }
    public class V1(NguyenLieu nguyenLieu) : Binding
    {
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public int ntt { get; set; }
        public string donvi { get; set; }
        public ICommand CmdLuu => new RunCommand(param =>
        {
            if (param is Window window)
            {
                nguyenLieu.Name = Ten;
                nguyenLieu.Gia = Gia;
                nguyenLieu.NguongToiThieu = ntt;
                nguyenLieu.DonVi = donvi;
                window.Close();
            }
        });
    }
}
