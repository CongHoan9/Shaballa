namespace Shaballa
{
    public class GroupManager<T> where T : IUnique, IRemove, IGroup
    {
        public ListCombinableItem<MenubleItem<T>> Items { get; } = [];
        public void AddItem(T item)
        {
            if (Items.FirstOrDefault(g => g.Nhom == item.Nhom) is MenubleItem<T> group)
            {
                group.Items.Add(item);
                item.NhomChanged += OnItemNhomChanged;
            }
        }
        private void OnItemNhomChanged(IGroup item)
        {
            if (item is T t)
            {
                AddItem(t);
            }
        }
    }
}
