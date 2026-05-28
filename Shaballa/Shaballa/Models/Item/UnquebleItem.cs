using System.Xml;

namespace Shaballa
{
    public interface IUnique
    {
        public string ID { get; }
        public bool Check(IUnique item);
    }
    public abstract class UnquebleItem(string id) : Binding, IUnique
    {
        public virtual string ID => GetString(id, "Lỗi");
        public virtual bool Check(IUnique item)
        {
            return item is UnquebleItem other && other.GetType() == GetType() && other.ID == ID;
        }
    }
}
