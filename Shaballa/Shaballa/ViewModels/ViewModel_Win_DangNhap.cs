using System.Windows;
using System.Windows.Input;
namespace Shaballa
{
    public class ViewModel_Win_DangNhap : Binding
    {
        public static List<string> AccountTypes => [ "Nhân viên", "Quản lý" ];
        public string SelectedAccountType { get; set; } = AccountTypes[0];
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public ICommand CmdDangNhap => new RunCommand<Window>(DangNhap);
        private void DangNhap(Window close)
        {
            Window open = SelectedAccountType switch
            {
                "Nhân viên" => new Win_NhanVien(new("AC003", "Trịnh Trần Phương Tuấn", "0123456789", "Bến Tre")),
                "Quản lý" => new Win_QuanLy(new("QL001", "Hoàng Công Hoàn", "0904249730", "Lạng Sơn")),
                _ => throw new Exception("Không xác định!"),
            };
            open.Show();
            close.Close();
        }
    }
}
