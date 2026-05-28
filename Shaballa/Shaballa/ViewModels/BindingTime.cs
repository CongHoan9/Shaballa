namespace Shaballa
{
    public abstract class BindingTime : ViewModelClose
    {
        public virtual DateTime Time => DateTime.Now;
        public BindingTime() : base()
        {
            App.Timer.Tick += (_, _) => OnPropertyChanged(nameof(Time));
        }
    }
}
