using System.Windows.Input;
namespace Shaballa
{
    public class DonHangNhap(string id, DateTime time, QuanLyChiTietDonHangNhap items, string note = null) : DonHang<INguyenLieu>(id, time, items, note)
    {
        public ICommand CmdXoaDonHang => new RunCommand(_ => NotifyRemove());
        public ICommand CmdXuatHoaDon => new RunCommand(_ => XuatHoaDon());
        public override void XuatHoaDon()
        {
            if (ViewModel_Win_NhanVien.Account is Account account)
            {
                _ = new HoaDonNhap("BA", account.ID, DateTime.Now, new(Items.Select(i => { return new ChiTietHoaDon(i.ID, i.Item.Name, i.Quantity, 10000); })), Note);
            }
        }
    }
}
