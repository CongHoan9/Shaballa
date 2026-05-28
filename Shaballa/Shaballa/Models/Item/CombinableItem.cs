namespace Shaballa
{
    public interface ICombine
    {
        public void Gop(ICombine icombine);
    }
    public abstract class CombinableItem(string id) : RemovableItem(id), ICombine
    {
        public abstract void Gop(ICombine icombine);
    }
}
