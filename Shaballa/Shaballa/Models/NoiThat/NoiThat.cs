namespace Shaballa
{
    public abstract class NoiThat(string id, string name, double x, double y) : StructbleItem<double>(id, x, y)
    {
        public virtual string Name
        {
            get => GetString(name, "Nội thất");
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
