using System.Windows.Input;
namespace Shaballa
{
    public enum TrangThai
    {
        Trong,
        DaDay,
        BaoTri,
    }
    public abstract class DiemPhucVu : NoiThat
    {
        public virtual QuanLyDonHangBan DonHangs { get; } = [];
        private TrangThai _TrangThai = TrangThai.Trong;
        public virtual TrangThai TrangThai
        { 
            get => _TrangThai;
            set
            {
                if (_TrangThai != value)
                {
                    _TrangThai = value;
                    OnPropertyChanged(nameof(TrangThai));
                }
            }
        }
        public virtual ICommand CmdOpenDiemPhucVu { get; }
        public DiemPhucVu(string id, string name, double x, double y, TrangThai trangthai = TrangThai.Trong) : base(id, name, x, y)
        {
            TrangThai = trangthai;
            CmdOpenDiemPhucVu = new RunCommand(_ => OpenDiemPhucVu());
        }
        public void OpenDiemPhucVu()
        {
            new Win_ChiTietDiemPhucVu(this).ShowDialog();
        }
    }
}
