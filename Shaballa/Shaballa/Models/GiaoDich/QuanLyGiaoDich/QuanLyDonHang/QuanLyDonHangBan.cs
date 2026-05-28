namespace Shaballa
{
    public class QuanLyDonHangBan : QuanLyIDGiaoDich<DonHang<IMatHang>>
    {
        private static int _Id = 0;
        public void AddItem(DiemPhucVu diemphucvu, QuanLyChiTietDonHangBan chitiets, string note = null)
        {
           Add(new DonHangBan(diemphucvu, GenerateNewId(), DateTime.Now, chitiets, note));
        }
        protected override string GenerateNewId()
        {
            return $"DH{++_Id:D3}";
        }
    }
}
