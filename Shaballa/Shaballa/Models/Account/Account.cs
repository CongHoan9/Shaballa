namespace Shaballa
{
    public class Account(string id, string name, string phone, string address, string note = "", byte[] image = null) : ContentbleItem(id, name, note, image)
    {
        public virtual string Phone
        {
            get => GetString(phone, "Chưa cập nhật");
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public virtual string Address
        {
            get => GetString(address, "Chưa cập nhật");
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}
