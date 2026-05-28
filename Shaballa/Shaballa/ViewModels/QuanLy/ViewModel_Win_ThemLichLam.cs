using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Win_ThemLichLam : ViewModelClose
    {
        public static ListRemovableItem<Account> Accounts => Account_BUS.Instance.Accounts;
        private readonly LichBUS LichBUS = new();
        private readonly Action<Lich> OnCreate;
        public static ObservableCollection<string> Calams => [ "Ca sáng", "Ca chiều", "Ca tối" ];
        private string _CaLamSelected = Calams[0];
        public string CaLamSelected
        {
            get => GetString(_CaLamSelected, Calams[0]);
            set
            {
                if (_CaLamSelected != value && Calams.Contains(value))
                {
                    _CaLamSelected = value;
                }
            }
        }
        private Account _AccountSelected = Accounts[0];
        public Account AccountSelected
        { 
            get => _AccountSelected ?? Accounts[0];
            set
            {
                if (_AccountSelected != value)
                {
                    _AccountSelected = value;
                }
            }
        }
        public static ObservableCollection<string> VaiTros => [ "Trưởng ca", "Pha chế", "Phục vụ", "Tiếp tân"];
        private string _VaiTroSelected = VaiTros[0];
        public string VaiTroSelected
        {
            get => GetString(_VaiTroSelected, Calams[0]);
            set
            {
                if (_VaiTroSelected != value && VaiTros.Contains(value))
                {
                    _VaiTroSelected = value;
                }
            }
        }
        private DateTime _Time = DateTime.Today;
        public DateTime Time
        {
            get => _Time;
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                }
            }
        }
        public ICommand CmdLuu { get; }
        public ViewModel_Win_ThemLichLam(Action<Lich> oncreate) : base()
        {
            OnCreate = oncreate;
            CmdLuu = new RunCommand(Luu);
        }
        public void Luu(object param)
        {
            Console.WriteLine(Time);
            if (param is Window windown && LichBUS.CreateLichLam(AccountSelected.ID, LichLamNhanVien.ConverterStringToVaiTro(VaiTroSelected), Time, Lich.ConverterStringToCa(CaLamSelected)) is Lich lich)
            {
                OnCreate(lich);
                windown.DialogResult = true;
                windown.Close();
            }
        }
    }
}
