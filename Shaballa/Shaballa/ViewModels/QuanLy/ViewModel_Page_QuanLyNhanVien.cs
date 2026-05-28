using Shaballa.ViewModels.QuanLy;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModel_Page_QuanLyNhanVien : Binding
    {
        public static ListRemovableItem<Account> Accounts => Account_BUS.Instance.Accounts;
        public ICommand CmdThemNhanVien { get; }
        public ViewModel_Page_QuanLyNhanVien()
        {
            CmdThemNhanVien = new RunCommand(_ => ThemNhanVien());
            CmdEdit = new RunCommand(Edit);
        }
        public static void ThemNhanVien()
        {
            Win_ThemNhanVien win = new(Accounts.Add);
            win.ShowDialog();
        }
        public ICommand CmdEdit { get; }
        public void Edit(object param)
        {
            if (param is Account account)
            {
                new Win_ChiTietTaiKhoan(account).ShowDialog();
            }
        }
    }
}
