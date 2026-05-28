using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Shaballa
{
    public interface IDragDrop
    {
        public event Action<IDragDrop> OnDrag;
        public event Action<IDragDrop> OnDrop;
        public Visibility Visibility { get; set; }
        public void Drag();
        public void Drop(IDragDrop dragdrop); 
    }
    public abstract class DragDropbleItem(string id) : CombinableItem(id), IDragDrop
    {

        public event Action<IDragDrop> OnDrag;
        public event Action<IDragDrop> OnDrop;
        private Visibility _Visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get => _Visibility;
            set
            {
                _Visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }
        public virtual void Drop(IDragDrop dragdrop)
        {
            if (dragdrop is DragDropbleItem item)
            {
                Gop(item);
                item.NotifyRemove();
                OnDrop?.Invoke(this);
                Visibility = Visibility.Visible;
            }
        }
        public void Drag()
        {
            Visibility = Visibility.Collapsed;
            OnDrag?.Invoke(this);
        }
    }
}
