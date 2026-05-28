using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Shaballa
{
    public class ViewModel_Page_QuanLyOrder(int trang = 0, double sizewidth = 700, double sizeheight = 1000) : Binding
    {
        public static ListOrderItems DonHangs => [];
        public static ListRemovableItem<NoiThat> NoiThats => NoiThat_BUS.Instance.NoiThats;
        public int Trang
        {
            get => GetInt(trang, 0);
            set
            {
                trang = value;
                OnPropertyChanged(nameof(Trang));
            }
        }
        public double SizeWidth
        {
            get => sizewidth;
            set
            {
                sizewidth = value;
                OnPropertyChanged(nameof(SizeWidth));
            }
        }
        public double SizeHeight
        {
            get => sizeheight;
            set
            {
                sizeheight = value;
                OnPropertyChanged(nameof(SizeHeight));
            }
        }
        public ICommand CmdBackTab => new RunCommand(_ => Trang--);
        public ICommand CmdNextTab => new RunCommand(_ => Trang++);
    }
}
