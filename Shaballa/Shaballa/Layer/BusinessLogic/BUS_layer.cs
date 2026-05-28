namespace Shaballa
{
    public abstract class BUS_layer<T> : Layer where T : new()
    {
        protected readonly T DAL = new();
    }
}
