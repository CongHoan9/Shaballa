
namespace Shaballa
{
    public class ListGroupbleItem<T> : ListRemovableItem<T>, IRemove, ICombine where T : IUnique, IRemove, IGroup
    {
        public ListGroupbleItem() { }
        public ListGroupbleItem(IEnumerable<T> items)
        {
            AddRange(items);
        }
        public event Action<IRemove> SeftRemove;
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (Contains(item))
            {
                item.NhomChanged += OnItemNhomChanged;
            }
        }
        public virtual void OnItemNhomChanged(IGroup item)
        {
            if (item is T t)
            {
                item.NhomChanged -= OnItemNhomChanged;
                Remove(t);
            }
        }
        protected override void RemoveItem(int index)
        {
            if (this[index] is T item)
            {
                item.NhomChanged -= OnItemNhomChanged;
            }
            base.RemoveItem(index);
            if (Count == 0)
            {
                SeftRemove?.Invoke(this);
            }
        }
        protected override void ClearItems()
        {
            foreach (T t in this)
            {
                t.NhomChanged -= OnItemNhomChanged;
            }
            base.ClearItems();
            if (Count == 0)
            {
                SeftRemove?.Invoke(this);
            }
        }
        public void Gop(ICombine icombine)
        {
            if (icombine is ListGroupbleItem<T> other)
            {
                AddRange(other);
            }
        }
    }
}
