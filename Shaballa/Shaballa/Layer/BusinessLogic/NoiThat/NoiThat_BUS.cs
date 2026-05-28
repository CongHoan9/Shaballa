namespace Shaballa
{
    public class NoiThat_BUS : BUS_layer<NoiThat_DAL>
    {
        private static readonly NoiThat_BUS _Instance = new();
        public static NoiThat_BUS Instance => _Instance;
        public ListRemovableItem<NoiThat> NoiThats { get; }
        public NoiThat_BUS()
        {
            NoiThats = new(GetNoiThat());
        }
        public IEnumerable<NoiThat> GetNoiThat(string id = null, string name = null, string idkhonggian = null)
        {
            return DAL.GetNoiThat(id, name, idkhonggian);
        }
    }
}
