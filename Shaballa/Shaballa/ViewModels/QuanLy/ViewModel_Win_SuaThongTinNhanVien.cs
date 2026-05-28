using System.Windows.Input;
using System.Windows;

namespace Shaballa.ViewModels.QuanLy
{
    class ViewModel_Win_SuaThongTinNhanVien : ViewModelClose
    {
        private readonly Account_BUS AccountBUS = new();
        private Account Account { get; }
        private string _TenNhanVien = "";
        public string TenNhanVien
        {
            get => GetString(_TenNhanVien, "");
            set
            {
                if (_TenNhanVien != value)
                {
                    _TenNhanVien = value;
                    OnPropertyChanged(nameof(IsCanLuu));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private string _MatKhau = "";
        public string MatKhau
        {
            get => GetString(_MatKhau, "");
            set
            {
                if (_MatKhau != value)
                {
                    _MatKhau = value;
                    OnPropertyChanged(nameof(IsCanLuu));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private string _SoDienThoai = "";
        public string SoDienThoai
        {
            get => GetString(_SoDienThoai, "");
            set
            {
                if (_SoDienThoai != value)
                {
                    _SoDienThoai = value;
                    OnPropertyChanged(nameof(IsCanLuu));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private string _DiaChi = "";
        public string DiaChi
        {
            get => GetString(_DiaChi, "");
            set
            {
                if (_DiaChi != value)
                {
                    _DiaChi = value;
                    OnPropertyChanged(nameof(IsCanLuu));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private string TenNV => TenNhanVien.Replace("Nhập tên nhân viên", "").Trim();
        private string MKNV => MatKhau.Replace("Nhập mật khẩu", "").Trim();
        private string Sdt => SoDienThoai.Replace("Nhập số điện thoại", "").Trim();
        private string Dc => DiaChi.Replace("Nhập địa chỉ", "").Trim();
        public string ThongTin
        {
            get
            {
                string thongtin = "";
                if (!string.IsNullOrEmpty(TenNV))
                {
                    thongtin += $"Tên nhân viên: {TenNhanVien}";
                }
                if (!string.IsNullOrEmpty(MKNV))
                {
                    thongtin += $"\nMật khẩu: {MKNV}";
                }
                if (!string.IsNullOrEmpty(Sdt))
                {
                    thongtin += $"\nSố điện thoại: {SoDienThoai}";
                }
                if (!string.IsNullOrEmpty(Dc))
                {
                    thongtin += $"\nĐịa chỉ nhà: {DiaChi}";
                }
                return GetString(thongtin, "Chi tiết tài khoản...");
            }
        }
        public bool IsCanLuu
        {
            get
            {
                return !string.IsNullOrEmpty(TenNV)
                    && !string.IsNullOrEmpty(MKNV)
                    && !string.IsNullOrEmpty(Sdt)
                    && !string.IsNullOrEmpty(Dc);
            }
        }
        public ICommand CmdLuu { get; }
        public ViewModel_Win_SuaThongTinNhanVien(Account account)
        {
            Account = account;
            CmdLuu = new RunCommand(Luu);
        }
        public void Luu(object param)
        {
            if (param is Window window)
            {
                Account.Name = TenNV;
                Account.Phone = Sdt;
                Account.Address = Dc;
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
