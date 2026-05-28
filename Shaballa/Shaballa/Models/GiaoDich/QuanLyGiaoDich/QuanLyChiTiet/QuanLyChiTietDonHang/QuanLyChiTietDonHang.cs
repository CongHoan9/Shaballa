using System.Security.Cryptography;

namespace Shaballa
{
    public abstract class QuanLyChiTietDonHang<T> : QuanLyIDGiaoDich<ChiTietDonHang<T>> where T : IThucPham
    {
        private static int _Id = 0;
        public QuanLyChiTietDonHang() : base() { }
        public QuanLyChiTietDonHang(IEnumerable<ChiTietDonHang<T>> items)
        {
            AddRange(items);
        }
        protected override string GenerateNewId()
        {
            return $"CT{++_Id:D3}";
        }
        public void AddItem(T item, int quantity)
        {
            Add(new(GenerateNewId(), item, quantity));
        }
        public decimal TongTien => Items.Sum(i => i.DonGia);
        protected override void InsertItem(int index, ChiTietDonHang<T> item)
        {
            base.InsertItem(index, item);
            if (Contains(item))
            {
                item.ItemChanged += ItemChanged;
                item.QuantityChanged += TongTienChanged;
                ItemChanged(item.Item);
            }
        }
        protected override void RemoveItem(int index)
        {
            if (this[index] is ChiTietDonHang<T> item)
            {
                item.ItemChanged -= ItemChanged;
                item.QuantityChanged -= TongTienChanged;
            }
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.ItemChanged -= ItemChanged;
                item.QuantityChanged -= TongTienChanged;
            }
            base.ClearItems();
        }
        public abstract void ItemChanged(T t);
        public virtual void TongTienChanged()
        {
            OnPropertyChanged(nameof(TongTien));
        }
        public override void SetRemove(IRemove item)
        {
            base.SetRemove(item);
            TongTienChanged();
        }
    }
}
