namespace Shaballa
{
    public class QuanLyDonHangNhap : QuanLyIDGiaoDich<DonHang<INguyenLieu>>
    {
        private static int _Id = 0;
        public void AddItem(QuanLyChiTietDonHangNhap chitiets, string note = null)
        {
            Add(new DonHangNhap(GenerateNewId(), DateTime.Now, chitiets, note));
        }
        protected override string GenerateNewId()
        {
            return $"DH{++_Id:D3}";
        }
    }
}
