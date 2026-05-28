using System.Collections;
using System.Collections.Specialized;
using System.Windows.Data;

namespace Shaballa
{
    public class OrderManager : CompositeCollection
    {
        private readonly ListRemovableItem<NoiThat> CauTrucs;
        private readonly Dictionary<DiemPhucVu, CollectionContainer> ContainerMap = [];
        public OrderManager(ListRemovableItem<NoiThat> cautrucs)
        {
            CauTrucs = cautrucs;
            CauTrucs.CollectionChanged += CauTrucs_CollectionChanged;
            foreach (DiemPhucVu diemphucvu in cautrucs.OfType<DiemPhucVu>())
            {
                AddDiemPhucVu(diemphucvu);
            }
        }
        private void CauTrucs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems is IList listnew)
            {
                foreach (DiemPhucVu phucvu in listnew.OfType<DiemPhucVu>())
                {
                    AddDiemPhucVu(phucvu);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems is IList listold)
            {
                foreach (DiemPhucVu phucvu in listold.OfType<DiemPhucVu>())
                {
                    RemoveDiemPhucVu(phucvu);
                }
            }
        }
        private void AddDiemPhucVu(DiemPhucVu phucvu)
        {
            if (!ContainerMap.ContainsKey(phucvu))
            {
                var container = new CollectionContainer { Collection = phucvu.DonHangs };
                ContainerMap[phucvu] = container;
                Add(container);

            }
        }
        private void RemoveDiemPhucVu(DiemPhucVu dpv)
        {
            if (ContainerMap.TryGetValue(dpv, out CollectionContainer container))
            {
                Remove(container);
                ContainerMap.Remove(dpv);
            }
        }
    }
}
