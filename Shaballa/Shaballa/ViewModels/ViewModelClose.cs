using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ViewModelClose : Binding
    {
        public ICommand CmdColse { get; }
        public ViewModelClose()
        {
            CmdColse = new RunCommand<Window>(Close);
        }
        protected virtual void Close(Window close)
        {
            close.Close();
        }
    }
}
