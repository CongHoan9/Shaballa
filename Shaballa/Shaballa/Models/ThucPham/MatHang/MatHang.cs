
namespace Shaballa
{
    public enum TrangThaiMatHang
    {
        None,
        Dangban,
        Ngungban,
    }
    public interface IMatHang : IThucPham
    {
        public TrangThaiMatHang TrangThaiMatHang { get; set; }
    }
    public abstract class MatHang : ThucPham, IGroup, IMatHang
    {
        public event Action<IGroup> NhomChanged;
        public MatHang(string id, string name, decimal gia, TrangThaiMatHang trangthaimathang, string nhom, string note = "", byte[] image = null) : base(id, name, gia, note, image)
        {
            TrangThaiMatHang = trangthaimathang;
            Nhom = nhom;
        }
        private TrangThaiMatHang _TrangThaiMatHang = TrangThaiMatHang.Dangban;
        public virtual TrangThaiMatHang TrangThaiMatHang
        { 
            get => _TrangThaiMatHang; 
            set
            {
                if (_TrangThaiMatHang != value)
                {
                    _TrangThaiMatHang = value;
                    OnPropertyChanged(nameof(TrangThaiMatHang));
                }
            }
        }
        private string _Nhom;
        public virtual string Nhom
        {
            get => GetString(_Nhom, "Khác");
            set
            {
                if (_Nhom != value)
                {
                    _Nhom = value;
                    NhomChanged?.Invoke(this);
                    OnPropertyChanged(nameof(Nhom));
                }
            }
        }
        public abstract ListCombinableItem<BuocThucHien> GetCongThuc();
    }
}
