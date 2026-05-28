using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
namespace Shaballa
{
    public class ListBinding<T> : ObservableCollection<T>
    {
        public ListBinding() : base() { }
        public ListBinding(IEnumerable<T> items) : base(items) { }
        public virtual ICollectionView CollectionView => CollectionViewSource.GetDefaultView(this); 
        private readonly Dictionary<string, ListSortDirection> SortStates = [];
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T t in items)
            {
                Add(t);
            }
        }
        public virtual void Sort(string property, ListSortDirection? input = null)
        {
            property = property.Trim();
            CollectionView.SortDescriptions.Clear();
            if (!input.HasValue && SortStates.TryGetValue(property, out ListSortDirection state))
            {
                input = state == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            ListSortDirection direction = input ?? ListSortDirection.Descending;
            SortStates[property] = direction;
            CollectionView.SortDescriptions.Add(new SortDescription(property, direction));
            CollectionView.Refresh();
        }
        public virtual string GetString(string input, string output = "Unknown") => Binding.GetString(input, output);
        public virtual double GetDouble(double input, double min = double.MinValue, double max = double.MaxValue) => Binding.GetDouble(input, min, max);
        public virtual int GetInt(int input, int min = int.MinValue, int max = int.MaxValue) => Binding.GetInt(input, min, max);
        public override string ToString()
        {
            return $"{string.Join(", ", Items)}";
        }
    }
}
