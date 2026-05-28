using System.Windows.Controls;
namespace Shaballa
{
    public partial class Page_NguyenLieu : Page
    {
        public Page_NguyenLieu()
        {
            InitializeComponent();
            DataContext = new ViewModel_Page_NguyenLieu(
            [
                new("NL001", "Nha đam", 5000, TrangThaiNguyenLieu.TonKho, 1, "Quả"),
                new("NL002", "Quả chanh", 5000, TrangThaiNguyenLieu.TonKho, 1, "Quả"),
                new("NL003", "Quả quất", 5000, TrangThaiNguyenLieu.HetHang, 1, "Quả"),
                new("NL004", "Lá bạc hà", 3000, TrangThaiNguyenLieu.TonKho, 1, "gam"),
                new("NL005", "Mật ong", 10000, TrangThaiNguyenLieu.TonKho, 1, "ml"),
                new("NL006", "Đường cát", 7000, TrangThaiNguyenLieu.TonKho, 1, "túi"),
                new("NL007", "Trà xanh", 4000, TrangThaiNguyenLieu.HetHang, 1, "gam"),
                new("NL008", "Trà đen", 4500, TrangThaiNguyenLieu.TonKho, 1, "túi"),
                new("NL009", "Sữa đặc", 8000, TrangThaiNguyenLieu.HetHang, 1, "hộp"),
                new("NL010", "Siro dâu", 6000, TrangThaiNguyenLieu.TonKho, 1, "ml"),
                new("NL011", "Thạch rau câu", 5000, TrangThaiNguyenLieu.HetHang, 1, "hộp"),
                new("NL012", "Trân châu đen", 6500, TrangThaiNguyenLieu.TonKho, 1, "hộp"),
                new("NL013", "Chanh leo", 7000, TrangThaiNguyenLieu.HetHang, 1, "Quả")
            ]);
        }
        public override string ToString()
        {
            return "Quản lý nguyên liệu";
        }
    }
}
