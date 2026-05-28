using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace Shaballa
{
    public class ListDragDropItem<T> : ListRemovableItem<T> where T : IUnique, IRemove, IDragDrop 
    {
        private readonly ListBinding<T> DefaultItems;
        public ListDragDropItem(ListBinding<T> items)
        {
            DefaultItems = items;
            DefaultItems.CollectionChanged += Items_CollectionChanged;
            foreach (T item in DefaultItems)
            {
                AddItem(item);
            }
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems is IList listAdd)
            {
                foreach (T item in listAdd)
                {
                    AddItem(item);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems is IList listRemove)
            {
                foreach (T item in listRemove)
                {
                    RemoveItem(item);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (e.OldItems is IList oldList)
                {
                    foreach (T item in oldList)
                    {
                        RemoveItem(item);
                    }
                }
                if (e.NewItems is IList newList)
                {
                    foreach (T item in newList)
                    {
                        AddItem(item);
                    }
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                foreach (T item in this.ToList())
                {
                    RemoveItem(item);
                }
                Clear();
            }
        }
        private void AddItem(T item)
        {
            item.OnDrag += Item_OnDrag;
            item.OnDrop += Item_OnDrop;
            Console.WriteLine($"Đăng ký cho {item}");
        }
        private void RemoveItem(T item)
        {
            item.OnDrag -= Item_OnDrag;
            item.OnDrop -= Item_OnDrop;
        }
        private void Item_OnDrag(IDragDrop dragdrop)
        {
            if (dragdrop is T item && !Contains(item))
            {
                Add(item);
            }
        }
        private void Item_OnDrop(IDragDrop dragdrop)
        {
            if (dragdrop is T item && Contains(item))
            {
                Remove(item);
            }
        }
    }
}
