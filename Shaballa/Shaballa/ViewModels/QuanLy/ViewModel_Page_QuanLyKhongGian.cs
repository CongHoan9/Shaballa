using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Page_QuanLyKhongGian : Binding
    {
        public static ListRemovableItem<KhongGian> KhongGians => KhongGian_BUS.Instance.KhongGians;
        public static ListRemovableItem<NoiThat> NoiThats => NoiThat_BUS.Instance.NoiThats;
        private int _Trang = 0;
        public int Trang
        {
            get => GetInt(_Trang, 0);
            set
            {
                if (_Trang != value)
                {
                    _Trang = value;
                    OnPropertyChanged(nameof(Trang));
                    Console.WriteLine(Trang);
                    Console.WriteLine(KhongGians.Sum(k => k.NoiThats.Count));
                }
            }
        }
        public ICommand CmdEdit { get; }
        public ICommand CmdTabChanged { get; }
        private void SetTab(object param)
        {
            if (int.TryParse($"{param}", out int value))
            {
                Trang += value;
            }
        }
        public ViewModel_Page_QuanLyKhongGian()
        {
            CmdEdit = new RunCommand(Edit);
            CmdTabChanged = new RunCommand(SetTab);
        }
        public void Edit(object param)
        {
            if (param is BanGhe banghe)
            {
                new Win_SuaThongTinNoiThat(banghe).ShowDialog();
            }
        }
    }
}
