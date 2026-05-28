using System.Windows.Input;
namespace Shaballa
{
    public class DonHangBan : DonHang<IMatHang>
    {
        private readonly HoaDon_BUS BUS = new();
        public DiemPhucVu DiemPhucVu { get; }
        public ICommand CmdXuatHoaDon { get; }
        public DonHangBan(DiemPhucVu diemphucvu, string id, DateTime time, QuanLyChiTietDonHangBan items, string note = null) : base(id, time, items, note)
        {
            DiemPhucVu = diemphucvu;
            if (DiemPhucVu == null)
            {
                Console.WriteLine(123);
            }
            CmdXuatHoaDon = new RunCommand(_ => XuatHoaDon());
        }
        public override void XuatHoaDon()
        {
            if (ViewModel_Win_NhanVien.Account is Account account)
            {
                if (BUS.CreateHoaDonBan(account.ID, DiemPhucVu.ID, "Chuyển khoản", Items, "") is HoaDonBan newhoadon)
                {
                    HoaDon_BUS.Instance.HoaDonBans.Add(newhoadon);
                    NotifyRemove();
                }
                else
                {
                    Console.WriteLine("Không trả về đơn hàng");
                }
            }
        }
    }
}
