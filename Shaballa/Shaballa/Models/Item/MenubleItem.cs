using System.Windows.Controls;

namespace Shaballa
{
    public interface IGroup
    {
        public event Action<IGroup> NhomChanged;
        public string Nhom { get; set; }
    }
    public class MenubleItem<T> : CombinableItem, IGroup where T : IUnique, IRemove, IGroup
    {
        public event Action<IGroup> NhomChanged;
        public ListGroupbleItem<T> Items { get; }
        public MenubleItem(string id, string nhom, ListGroupbleItem<T> item) : base(id)
        {
            Nhom = nhom;
            Items = item;
        }
        private string _Nhom;
        public string Nhom 
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
        public override bool Check(IUnique item)
        {
            return base.Check(item) && item is MenubleItem<T> other && (other.ID == ID || other.Nhom == Nhom);
        }
        public override void Gop(ICombine icombine)
        {
            if (icombine is MenubleItem<T> other)
            {
                Items.AddRange(other.Items);
            }
        }
    }
}
