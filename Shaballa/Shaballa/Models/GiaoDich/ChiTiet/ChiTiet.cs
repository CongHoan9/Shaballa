using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public interface IChiTiet<T>
    {
        public event Action QuantityChanged;
        public event Action<T> ItemChanged;
        public decimal DonGia { get; }
        public T Item { get; set; }
        public int Quantity { get; set; }
        public void NotifyQuantityChanged();
        public void NotifyItemChanged(T t);
    }
    public abstract class ChiTiet<T>(string id) : DragDropbleItem(id), IChiTiet<T> 
    {
        public event Action QuantityChanged;
        public event Action<T> ItemChanged;
        public abstract decimal DonGia { get; }
        public abstract T Item { get; set; }
        public abstract int Quantity { get; set; }
        public override void Gop(ICombine icombine)
        {
            if (icombine is ChiTiet<T> chitiet)
            {
                Quantity += chitiet.Quantity;
            }
        }
        public void Fun(IDragDrop dragdrop)
        {
            if (dragdrop is ChiTiet<T> chitiet)
            {
                Gop(chitiet);
            }
        }
        public void NotifyItemChanged(T t)
        {
            ItemChanged?.Invoke(t);
            OnPropertyChanged(nameof(Item));
        }
        public void NotifyQuantityChanged()
        {
            QuantityChanged?.Invoke();
            OnPropertyChanged(nameof(Quantity));
        }
    }
}
