namespace Shaballa
{
    public class Topping(string id, string name, decimal gia, TrangThaiMatHang trangthaimathang, TrangThaiNguyenLieu trangthainguyenlieu, int nguongtoithieu, string donvi, string note = "", byte[] image = null) : ThucPham(id, name, gia, note, image), INguyenLieu, IMatHang
    {
        public int NguongToiThieu
        {
            get => GetInt(nguongtoithieu, 0);
            set
            {
                if (nguongtoithieu != value)
                {
                    nguongtoithieu = value;
                    OnPropertyChanged(nameof(NguongToiThieu));
                }
            }
        }
        public string DonVi
        {
            get => GetString(donvi, "");
            set
            {
                if (donvi != value)
                {
                    donvi = value;
                    OnPropertyChanged(nameof(DonVi));
                }
            }
        }
        public TrangThaiMatHang TrangThaiMatHang
        {
            get => trangthaimathang;
            set
            {
                if (trangthaimathang != value)
                {
                    trangthaimathang = value;
                    OnPropertyChanged(nameof(TrangThaiMatHang));
                }
            }
        }
        public TrangThaiNguyenLieu TrangThaiNguyenLieu
        {
            get => trangthainguyenlieu;
            set
            {
                if (trangthainguyenlieu != value)
                {
                    trangthainguyenlieu = value;
                    OnPropertyChanged(nameof(TrangThaiNguyenLieu));
                }
            }
        }
        public int TonKho => GetInt(GetTonKho(), 0);
        public int GetTonKho()
        {
            return 0;
        }
        public void ThongBao()
        {

        }
    }
}
