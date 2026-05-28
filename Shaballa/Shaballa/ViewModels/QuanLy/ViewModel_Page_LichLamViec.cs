using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Page_LichLamViec : Binding
    {
        public static ListRemovableItem<Lich> Lichs => LichBUS.Instance.Lichs;
        public ICommand CmdThemLichLam { get; }
        public static void ThemLichLam()
        {
            Win_ThemLichLam win = new(Lichs.Add);
            Console.WriteLine(Lichs.Count);
            win.ShowDialog();
        }
        public ViewModel_Page_LichLamViec()
        {
            CmdThemLichLam = new RunCommand(_ => ThemLichLam());
        }
    }
}
