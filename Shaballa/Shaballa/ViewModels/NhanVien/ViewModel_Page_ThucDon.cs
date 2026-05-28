namespace Shaballa
{
    public class ViewModel_Page_ThucDon(GroupManager<DoUong> douongs, GroupManager<DoAn> doans, ListRemovableItem<Topping> toppings) : Binding
    {
        public GroupManager<DoUong> DoUongs => douongs;
        public GroupManager<DoAn> DoAns => doans;
        public ListRemovableItem<Topping> Toppings => toppings;
    }
}
