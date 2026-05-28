namespace Shaballa
{
    public class QuanLyChiTietDonHangNhap : QuanLyChiTietDonHang<INguyenLieu>
    {
        public ListCombinableItem<ChiTietDonHang<INguyenLieu>> NguyenLieus => new(Items.Where(i => i.Item is NguyenLieu));
        public ListCombinableItem<ChiTietDonHang<INguyenLieu>> Toppings => new(Items.Where(i => i.Item is Topping));
        public override void ItemChanged(INguyenLieu mathang)
        {
            if (mathang is NguyenLieu)
            {
                OnPropertyChanged(nameof(NguyenLieus));
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
