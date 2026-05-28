using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
namespace Shaballa
{
    public class ViewModel_Win_ChiTietDiemPhucVu(DiemPhucVu diemphucvu, string selectedtieuchi = "") : BindingTime()
    {
        public DiemPhucVu DiemPhucVu => diemphucvu;
        public static ObservableCollection<string> TieuChiSapXep => ["Không sắp xếp phụ", "Thời gian (Cao đến thấp)", "Thời gian (Thấp đến cao)", "Tổng tiền (Cao đến thấp)", "Tổng tiền (Thấp đến cao)"];
        public string SelectedTieuChi
        {
            get => GetString(selectedtieuchi, TieuChiSapXep[0]);
            set
            {
                if (selectedtieuchi != value)
                {
                    selectedtieuchi = value;
                    (string property, ListSortDirection? direction)? sortOption = SelectedTieuChi switch
                    {
                        var t when t == TieuChiSapXep[1] => ("Time", ListSortDirection.Descending),
                        var t when t == TieuChiSapXep[2] => ("Time", ListSortDirection.Ascending),
                        var t when t == TieuChiSapXep[3] => ("Items.TongTien", ListSortDirection.Descending),
                        var t when t == TieuChiSapXep[4] => ("Items.TongTien", ListSortDirection.Ascending),
                        _ => null
                    };
                    DiemPhucVu.DonHangs.CollectionView.SortDescriptions.Clear();
                    if (sortOption is not null)
                    {
                        DiemPhucVu.DonHangs.Sort(sortOption.Value.property, sortOption.Value.direction.Value);
                    }
                }
            }
        }
        public string GhiChu { get; set; }
        public ICommand CmdChangeTrangThai => new RunCommand(param =>
        {
            if (param is TrangThai trangthai)
            {
                DiemPhucVu.TrangThai = trangthai;
            }
        });
        public ICommand CmdTaoDonHang => new RunCommand(_ =>
        {
            if (DiemPhucVu.TrangThai == TrangThai.Trong)
            {
                Win_TaoDonHang win = new((chitiets, note) =>
                {
                    DiemPhucVu.DonHangs.AddItem(DiemPhucVu, chitiets, note);
                });
                win.ShowDialog();
                DiemPhucVu.DonHangs.Sort("Time", ListSortDirection.Descending);
            }
            else
            {
                MessageBox.Show($"Không thể thêm đơn hàng khi trạng thái bàn là: {DiemPhucVu.TrangThai}");
            }
        });
    }
}
