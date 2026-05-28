using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Win_TaoDonHang : Binding
    {
        private readonly ThucPhamBUS BUS = new();
        private readonly Action<QuanLyChiTietDonHangBan, string> OnSave;
        public ListRemovableItem<IMatHang> MatHangs { get; } = [];
        public QuanLyChiTietDonHangBan ChiTiets { get; } = [];
        private string _Note = "";
        public string Note
        {
            get => GetString(_Note, "");
            set
            {
                if (_Note != value)
                {
                    _Note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }
        public ICommand CmdTaoChiTiet { get; }
        public ICommand CmdHuy { get; }
        public ICommand CmdLuu { get; }
        private void Close(Window close)
        {
            close.Close();
        }
        public ViewModel_Win_TaoDonHang(Action<QuanLyChiTietDonHangBan, string> onsave)
        {
            Console.WriteLine("Đã mở giao diện tạo đơn hàng");
            OnSave = onsave;
            CmdTaoChiTiet = new RunCommand(TaoChiTiet);
            CmdHuy = new RunCommand<Window>(Close);
            MatHangs = new(BUS.GetMatHang());
            CmdLuu = new RunCommand(Luu);
        }
        public void Luu(object param)
        {
            if (param is Window window && ChiTiets.Count > 0)
            {
                if (ChiTiets.Count > 0)
                {
                    Console.WriteLine("Tạo đơn hàng thành công");
                    OnSave(ChiTiets, Note);
                    window.DialogResult = true;
                    window.Close();
                }
                else
                {
                    Console.WriteLine("Không có chi tiết đơn hàng!");
                }
            }
            else
            {
                Console.WriteLine("Thêm đơn hàng thất bại!");
            }
        }
        public void TaoChiTiet(object param)
        {
            if (param is IMatHang mathang)
            {
                Console.WriteLine($"Đã thêm: {mathang} vào đơn hàng");
                ChiTiets.AddItem(mathang, 1);
            }
        }
    }
}
