namespace Shaballa
{

    public class ChiTietDonHang<T> : ChiTiet<T> where T : IThucPham
    {
        public override decimal DonGia => GetDecimal(Item.Gia * Quantity, 0);
        public ChiTietDonHang(string id, T item, int quantity = 1) : base(id)
        {
            Item = item;
            Quantity = quantity;
        }
        private T _Item;
        public override T Item
        { 
            get => _Item;
            set
            {
                if (!value.Check(_Item))
                {
                    if (_Item is T olditem)
                    {
                        olditem.GiaChanged -= NotifyChanged;
                    }
                    _Item = value;
                    if (_Item is T newitem)
                    {
                        newitem.GiaChanged += NotifyChanged;
                    }
                    NotifyChanged();
                    NotifyItemChanged(Item);
                }
            }
        }
        private int _Quantity = 0;
        public override int Quantity
        {
            get => GetInt(_Quantity, 0);
            set
            {
                if (Quantity != value)
                {
                    _Quantity = value;
                    if (_Quantity == 0)
                    {
                        NotifyRemove();
                    }
                    else
                    {
                        NotifyChanged();
                        NotifyQuantityChanged();
                    }
                }
            }
        }
        public override bool Check(IUnique item)
        {
            return item is ChiTietDonHang<T> other && (other.ID == ID || other.Item.Check(Item));
        }
        public override void Gop(ICombine icombine)
        {
            if (icombine is ChiTietDonHang<T> chitiet)
            {
                Quantity += chitiet.Quantity;
            }
        }
        public void NotifyChanged()
        {
            OnPropertyChanged(nameof(DonGia));
        }
    }
}
