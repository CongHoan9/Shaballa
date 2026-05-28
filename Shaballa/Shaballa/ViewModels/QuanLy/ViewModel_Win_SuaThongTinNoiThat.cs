using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Win_SuaThongTinNoiThat : ViewModelClose
    {
        public BanGhe BanGhe { get; }
        private string _Name = "";
        public string Name
        {
            get => GetString(_Name, "");
            set
            {
                if (_Name != value)
                {    
                    _Name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private double _X = 0;
        public double X
        {
            get => GetDouble(_X, 0);
            set
            {
                if (_X != value)
                {
                    _X = value;
                    OnPropertyChanged(nameof(X));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        private double _Y = 0;
        public double Y
        {
            get => GetDouble(_Y, 0);
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    OnPropertyChanged(nameof(Y));
                    OnPropertyChanged(nameof(ThongTin));
                }
            }
        }
        public string ThongTin
        {
            get
            {
                string thongtin = "";
                if (!string.IsNullOrEmpty(Name))
                {
                    thongtin += $"Tên bàn: {Name}";
                }
                if (X != BanGhe.X)
                {
                    thongtin += $"\nTọa độ X: {X}";
                }
                if (Y != BanGhe.Y)
                {
                    thongtin += $"\nTọa độ Y: {Y}";
                }
                return GetString(thongtin, "Chi tiết sau thay đổi...");
            }
        }
        public ICommand CmdLuu { get; }
        public ICommand CmdChangeTrangThai => new RunCommand(param =>
        {
            if (param is TrangThai trangthai)
            {
                BanGhe.TrangThai = trangthai;
            }
        });
        public ViewModel_Win_SuaThongTinNoiThat(BanGhe banghe) : base()
        {
            BanGhe = banghe;
            CmdLuu = new RunCommand(Luu);
        }
        public void Luu(object param)
        {
            if (param is Window window)
            {
                BanGhe.Name = Name;
                BanGhe.X = X;
                BanGhe.Y = Y;
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
