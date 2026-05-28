using System.Numerics;
namespace Shaballa
{
    public interface IStruct<T> where T : INumber<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
    }
    public abstract class StructbleItem<T>(string id, T x, T y) : RemovableItem(id) where T : INumber<T>
    {
        public virtual T X
        {
            get => x;
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }
        public virtual T Y
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }
        public override bool Check(IUnique item)
        {
            return item is StructbleItem<T> other && other.GetType() == GetType() && other.X == X && other.Y == Y;
        }
    }
}
