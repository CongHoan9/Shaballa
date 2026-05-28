using System.Collections;
using System.Collections.Specialized;
namespace Shaballa
{
    public class ListOrderItems : QuanLyDonHangBan
    {
        public ListOrderItems()
        {
            NoiThat_BUS.Instance.NoiThats.CollectionChanged += CauTrucs_CollectionChanged;
            foreach (var diemphucvu in NoiThat_BUS.Instance.NoiThats.OfType<DiemPhucVu>())
            {
                AddDiemPhucVu(diemphucvu);
            }
        }
        private void AddDiemPhucVu(DiemPhucVu diemphucvu)
        {
            diemphucvu.DonHangs.CollectionChanged += DonHangs_CollectionChanged;
            AddRange(diemphucvu.DonHangs);
        }
        private void RemoveDiemPhucVu(DiemPhucVu diemphucvu)
        {
            diemphucvu.DonHangs.CollectionChanged -= DonHangs_CollectionChanged;
            foreach (DonHangBan donhang in diemphucvu.DonHangs)
            {
                Remove(donhang);
            }
        }
        private void CauTrucs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems is IList listAdd)
            {
                foreach (DiemPhucVu diemphucvu in listAdd)
                {
                    AddDiemPhucVu(diemphucvu);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems is IList listRemove)
            {
                foreach (DiemPhucVu diemphucvu in listRemove)
                {
                    RemoveDiemPhucVu(diemphucvu);
                }
            }
        }
        private void DonHangs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems is IList listAdd)
            {
                AddRange(listAdd.OfType<DonHangBan>());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems is IList listRemove)
            {
                foreach (DonHangBan donhangban in listRemove)
                {
                    Remove(donhangban);
                }
            }
        }
    }
}
