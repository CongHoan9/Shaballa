namespace Shaballa
{
    public enum TrangThaiNguyenLieu
    {
        None,
        HetHang,
        TonKho,
        HuyNhap,
    }
    public interface INguyenLieu : IThucPham
    {
        public TrangThaiNguyenLieu TrangThaiNguyenLieu { get; set; }
        public int NguongToiThieu { get; set; }
        public string DonVi { get; set; }
        public int TonKho { get; }
        public int GetTonKho();
        public void ThongBao();
    }
    public class NguyenLieu(string id, string name, decimal gia, TrangThaiNguyenLieu trangthainguyenlieu, int nguongtoithieu, string donvi, string note = "", byte[] image = null) : ThucPham(id, name, gia, note, image), INguyenLieu
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
            get => GetString(donvi, "").ToLower();
            set
            {
                if (donvi != value)
                {
                    donvi = value;
                    OnPropertyChanged(nameof(DonVi));
                }
            }
        }
        public int TonKho => GetInt(GetTonKho(), 0);
        public virtual TrangThaiNguyenLieu TrangThaiNguyenLieu
        {
            get => trangthainguyenlieu;
            set
            {
                if (trangthainguyenlieu != value)
                {
                    trangthainguyenlieu = value;
                    OnPropertyChanged(nameof(TrangThai));
                }
            }
        }
        public int GetTonKho()
        {
            return new Random().Next(0, 11);
        }
        public void ThongBao()
        {

        }
        public static TrangThaiNguyenLieu C(string s)
        {
            return s switch
            {
                "Tồn kho" => TrangThaiNguyenLieu.TonKho,
                "Hết hàng" => TrangThaiNguyenLieu.HetHang,
                "Hủy nhập" => TrangThaiNguyenLieu.HuyNhap,
                _ => TrangThaiNguyenLieu.None,
            };
        }
    }
}
