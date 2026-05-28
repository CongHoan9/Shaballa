namespace Shaballa
{
    public class QuanLyChiTietDonHangBan : QuanLyChiTietDonHang<IMatHang>
    {
        public ListCombinableItem<ChiTietDonHang<IMatHang>> DoUongs => new(Items.Where(i => i.Item is DoUong));
        public ListCombinableItem<ChiTietDonHang<IMatHang>> DoAns => new(Items.Where(i => i.Item is DoAn));
        public ListCombinableItem<ChiTietDonHang<IMatHang>> Toppings => new(Items.Where(i => i.Item is Topping));
        public override void ItemChanged(IMatHang mathang)
        {
            if (mathang is DoUong)
            {
                OnPropertyChanged(nameof(DoUongs));
            }
            if (mathang is DoAn)
            {
                OnPropertyChanged(nameof(DoAns));
            }
            if (mathang is Topping)
            {
                OnPropertyChanged(nameof(Toppings));
            }
            TongTienChanged();
        }
        public override void SetRemove(IRemove item)
        {
            base.SetRemove(item);
            TongTienChanged();
        }
    }
}
