namespace Shaballa
{
    public class Menu(GroupManager<DoUong> douongs, GroupManager<DoAn> doans, ListRemovableItem<Topping> toppings)
    {
        public GroupManager<DoUong> DoUongs => douongs;
        public GroupManager<DoAn> DoAns => doans;
        public ListRemovableItem<Topping> Toppings => toppings;
    }
}
