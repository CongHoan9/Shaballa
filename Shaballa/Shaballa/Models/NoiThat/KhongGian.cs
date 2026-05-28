namespace Shaballa
{
    public class KhongGian : RemovableItem
    {
        private int _Number = 0;
        public int Number
        {
            get => GetInt(_Number, 0);
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }
        public ListRemovableItem<NoiThat> NoiThats { get; }
        public KhongGian(string id, int number, ListRemovableItem<NoiThat> noithats) : base(id)
        {
            Number = number;
            NoiThats = noithats;
        }
    }
}
