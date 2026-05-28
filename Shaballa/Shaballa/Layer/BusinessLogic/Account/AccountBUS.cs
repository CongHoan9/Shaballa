namespace Shaballa
{
    public class Account_BUS : BUS_layer<Account_DAL>
    {
        private static readonly Account_BUS _Instance = new();
        public static Account_BUS Instance => _Instance;

        public ListRemovableItem<Account> Accounts { get; }
        public Account_BUS()
        {
            Accounts = new(GetAccount());
        }
        public Account CreateAccount(string name, string matkhau, string number, string address, string role = null)
        {
            if (CheckString(name) && CheckString(matkhau) && CheckString(number) && CheckString(address))
            {
                return DAL.CreateAccount(name, matkhau, number, address, role);
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Account> GetAccount()
        {
            return DAL.GetAccount();
        }
    }
}
