using System.Windows;

namespace Shaballa
{
    public interface IThucPham : IUnique, IRemove, IContent
    {
        public event Action GiaChanged;
        public decimal Gia { get; set; }
    }
    public abstract class ThucPham : ContentbleItem, IThucPham
    {
        public event Action GiaChanged;
        private decimal _Gia = 0;
        public virtual decimal Gia
        {
            get => GetDecimal(_Gia, 0);
            set
            {
                if (_Gia != value)
                {
                    _Gia = value;
                    GiaChanged?.Invoke();
                    OnPropertyChanged(nameof(Gia));
                }
            }
        }
        public ThucPham(string id, string name, decimal gia, string note = "", byte[] image = null) : base(id, name, note, image)
        {
            Gia = gia;
        }
    }
}
