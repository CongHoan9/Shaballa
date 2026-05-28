namespace Shaballa
{
    public abstract class QuanLyIDGiaoDich<T> : ListCombinableItem<T> where T : IUnique, ICombine, IRemove
    {
        protected abstract string GenerateNewId();
    }
}
