using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Win_ThemNhanVien : ViewModelClose
    {
        private readonly Account_BUS AccountBUS = new();
        private readonly Action<Account> OnCreate;
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
        public ViewModel_Win_ThemNhanVien(Action<Account> oncreate)
        {
            OnCreate = oncreate;
            CmdLuu = new RunCommand(Luu);
        }
        public void Luu(object param)
        {
            if (param is Window window && AccountBUS.CreateAccount(TenNV, MKNV, Sdt, Dc, "Nhân Viên") is Account account)
            {
                OnCreate(account);
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
