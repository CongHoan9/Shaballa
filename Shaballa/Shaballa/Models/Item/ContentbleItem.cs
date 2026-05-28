namespace Shaballa
{
    public interface IContent
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public  byte[] Image { get; set; }
    }
    public abstract class ContentbleItem(string id, string name, string note = "", byte[] image = null) : RemovableItem(id), IContent
    {
        public virtual string Name
        {
            get => GetString(name);
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public virtual byte[] Image
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }
        public string Note 
        { 
            get => GetString(note, "Không có bản ghi"); 
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }
        public override bool Check(IUnique item)
        {
            return base.Check(item) && item is ContentbleItem other && (other.ID == ID);
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
