namespace Shaballa
{
    public class BuocThucHien(string id, int thutu, string mota) : CombinableItem(id)
    {
        public int ThuTu
        {
            get => GetInt(thutu, 1);
            set
            {
                thutu = value;
                OnPropertyChanged(nameof(ThuTu));
            }
        }
        public string MoTa
        {
            get => GetString(mota, "");
            set
            {
                mota = value;
                OnPropertyChanged(nameof(MoTa));
            }
        }
        public override bool Check(IUnique item)
        {
            return item is BuocThucHien other && other != this && (other.ID == ID || other.ThuTu == ThuTu);
        }
        public override void Gop(ICombine icombine)
        {
            if (icombine is BuocThucHien other)
            {
                MoTa += $"Sau đó, {other.MoTa}";
            }
        }
    }
}
