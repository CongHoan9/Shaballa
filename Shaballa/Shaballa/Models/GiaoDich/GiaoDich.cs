using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public abstract class GiaoDich<T>(string id, DateTime time, ListCombinableItem<T> items, string note = null) : DragDropbleItem(id) where T : IUnique, ICombine, IRemove
    {
        public virtual string Note
        {
            get => GetString(note, "");
            set
            {
                note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        public DateTime Time => time;
        public virtual ListCombinableItem<T> Items => items;
        public override string ToString()
        {
            return $"{Items}";
        }
    }
}
