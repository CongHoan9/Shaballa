using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace Shaballa
{
    public class ViewModel_Page_NguyenLieu : Binding
    {
        public ListRemovableItem<NguyenLieu> NguyenLieus { get; }
        public static ObservableCollection<string> TieuChiSapXep => ["Không sắp xếp phụ", "Giá (cao đến thấp)", "Giá (thấp đến cao)", "Tồn kho (cao đến thấp)", "Tồn kho (thấp đến cao)"];
        private string _SelectedTieuChi = "TrangThaiNguyenLieu";
        public string SelectedTieuChi
        {
            get => GetString(_SelectedTieuChi, TieuChiSapXep[0]);
            set
            {
                if (_SelectedTieuChi != value)
                {
                    _SelectedTieuChi = value;
                    (string property, ListSortDirection? direction)? sortOption = SelectedTieuChi switch
                    {
                        var t when t == TieuChiSapXep[1] => ("Gia", ListSortDirection.Descending),
                        var t when t == TieuChiSapXep[2] => ("Gia", ListSortDirection.Ascending),
                        var t when t == TieuChiSapXep[3] => ("TonKho.TongTien", ListSortDirection.Descending),
                        var t when t == TieuChiSapXep[4] => ("TonKho.TongTien", ListSortDirection.Ascending),
                        _ => ("TrangThaiNguyenLieu", ListSortDirection.Descending)
                    };
                    NguyenLieus.CollectionView.SortDescriptions.Clear();
                    if (sortOption is not null)
                    {
                        NguyenLieus.Sort(sortOption.Value.property, sortOption.Value.direction.Value);
                    }
                }
            }
        }
        public static decimal I => new Random().Next(10, 20);
        public ICommand CmdSort => new RunCommand(param => NguyenLieus.Sort($"{param}"));
        public ViewModel_Page_NguyenLieu(ListRemovableItem<NguyenLieu> nguyenlieus, string selectedtieuchi = "")
        {
            NguyenLieus = nguyenlieus;
            SelectedTieuChi = selectedtieuchi;
        }
        public ICommand CmdEdit => new RunCommand(param =>
        {
            if (param is NguyenLieu nguyenLieu)
            {
                new Win_SuaThongTinNguyenLieu(nguyenLieu).ShowDialog();
            }
        });
    }
}
