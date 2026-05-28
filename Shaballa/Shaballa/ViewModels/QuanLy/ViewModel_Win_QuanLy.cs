using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Win_QuanLy : BindingTime
    {
        public static Account Account { get; set; }
        private readonly Page_QuanLyNhanVien Page_QuanLyNhanVien = new();
        private readonly Page_LichLamViec Page_LichLamViec = new();
        private readonly Page_QuanLyKhongGian Page_QuanLyKhongGian = new();
        private readonly Page_NguyenLieu Page_NguyenLieu = new();
        private Page _PageOnShow;
        public Page PageOnShow
        {
            get => _PageOnShow ?? Page_QuanLyNhanVien;
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
        public ICommand CmdShowPage { get; }
        public ViewModel_Win_QuanLy(Account account) : base()
        {
            Account = account;
            CmdShowPage = new RunCommand(ShowPage);
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
                "1" => Page_QuanLyNhanVien,
                "2" => Page_LichLamViec,
                "3" => Page_NguyenLieu,
                "4" => Page_QuanLyKhongGian,
                _ => Page_QuanLyNhanVien,
            };
        }
    }
}
