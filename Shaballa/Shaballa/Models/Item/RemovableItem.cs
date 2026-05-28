
using System.Windows.Input;

namespace Shaballa
{
    public interface IRemove
    {
        public event Action<IRemove> SeftRemove;
    }
    public abstract class RemovableItem : UnquebleItem, IRemove
    {
        public event Action<IRemove> SeftRemove;
        public void NotifyRemove()
        {
            SeftRemove?.Invoke(this);
        }
        public ICommand CmdRemove { get; }
        public RemovableItem(string id) : base(id)
        {
            CmdRemove = new RunCommand(_ => NotifyRemove());
        }
    }
}
