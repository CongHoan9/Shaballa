
namespace Shaballa
{
    public class ListRemovableItem<T> : ListBinding<T> where T : IUnique, IRemove
    {
        public ListRemovableItem() : base() { }
        public ListRemovableItem(IEnumerable<T> items) : base(items)
        {
            AddRange(items);
        }
        protected override void InsertItem(int index, T item)
        {
            if (CheckKhongTrung(item))
            {
                base.InsertItem(index, item);
                item.SeftRemove += SetRemove;
            }
        }
        protected override void RemoveItem(int index)
        {
            if (this[index] is T item)
            {
                item.SeftRemove -= SetRemove;
            }
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.SeftRemove -= SetRemove;
            }
            base.ClearItems();
        }
        public virtual void SetRemove(IRemove item)
        {
            if (item is T t)
            {
                Remove(t);
            }
        }
        protected virtual bool CheckKhongTrung(T item)
        {
            return !this.Any(i => i.Check(item)) && !Contains(item);
        }
    }
}
