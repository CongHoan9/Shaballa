using System.Collections.Specialized;

namespace Shaballa
{
    public class ListCombinableItem<T> : ListRemovableItem<T>, IList<T> where T : IUnique, ICombine, IRemove
    {
        public ListCombinableItem() : base() { }
        public ListCombinableItem(IEnumerable<T> items)
        {
            AddRange(items);
        }
        protected override void InsertItem(int index, T item)
        {
            IEnumerable<T> danhSachcangop = this.Where(ct => ct.Check(item));
            if (danhSachcangop.Any())
            {
                foreach (T t in danhSachcangop)
                {
                    t.Gop(item);
                }
            }
            else
            {
                base.InsertItem(index, item);
            }
        }
    }
}
