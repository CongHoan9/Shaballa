using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Shaballa
{
    public class ViewModel_Win_NhanVien : BindingTime
    {
        public static Account Account { get; set; }
        private readonly Page_QuanLyOrder Page_QuanLyOrder = new();
        private readonly Page_HoaDonBan Page_HoaDonBan = new();
        private readonly Page_ThucDon Page_ThucDon = new();
        private readonly Page_NguyenLieu Page_NguyenLieu = new();
        private Page _PageOnShow;
        public Page PageOnShow
        {
            get => _PageOnShow ?? Page_QuanLyOrder;
            set
            {
                if (_PageOnShow != value)
                {
                    _PageOnShow = value;
                    OnPropertyChanged(nameof(PageOnShow));
                    Console.WriteLine($"Đã chuyển sang trang {PageOnShow}");
                }
            }
        }
        public ICommand CmdShowManage { get; }
        public ICommand CmdShowPage { get; }
        public ViewModel_Win_NhanVien(Account account) : base()
        {
            Account = account;
            CmdShowPage = new RunCommand(ShowPage);
            CmdShowManage = new RunCommand(ShowWin_AccountManage);
        }
        private void ShowWin_AccountManage(object parameter)
        {
            Win_QuanLyTaiKhoanNhanVien accountmanage = new(Account);
            accountmanage.ShowDialog();
        }
        protected override void Close(Window close)
        {
            new Win_DangNhap().Show();
            base.Close(close);
        }
        public void ShowPage(object param)
        {
            PageOnShow = param switch
            {
                "0" => Page_ThucDon,
                "1" => Page_QuanLyOrder,
                "2" => Page_HoaDonBan,
                "3" => Page_NguyenLieu,
                _ => Page_QuanLyOrder,
            };
        }
    }
}
