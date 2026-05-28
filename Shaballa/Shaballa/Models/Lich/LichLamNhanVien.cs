namespace Shaballa
{
    public enum RoleOnCaLam
    {
        TruongCa,
        PhaChe,
        PhucVu,
        LeTan,
        None,
    }
    public class LichLamNhanVien : RemovableItem
    {
        public event Action<RoleOnCaLam, RoleOnCaLam> NewOldRoleChanged;
        private RoleOnCaLam _VaiTro = RoleOnCaLam.TruongCa;
        public RoleOnCaLam VaiTro
        {
            get => _VaiTro;
            set
            {
                if (_VaiTro != value)
                {
                    NewOldRoleChanged?.Invoke(value, _VaiTro);
                    _VaiTro = value;
                    OnPropertyChanged(nameof(VaiTro));
                }
            }
        }
        public Account Account { get; }
        public LichLamNhanVien(Account account, RoleOnCaLam vaitro) : base(account.ID)
        {
            Account = account;
            VaiTro = vaitro;
        }
        public override bool Check(IUnique item)
        {
            return item is LichLamNhanVien other && !ReferenceEquals(other, this) && (other.ID == ID || other.Account.Check(Account));
        }
        public static string ConverterVaiTroToString(RoleOnCaLam role)
        {
            return role switch
            {
                RoleOnCaLam.TruongCa => "Trưởng ca",
                RoleOnCaLam.PhaChe => "Pha chế",
                RoleOnCaLam.PhucVu => "Phục vụ",
                RoleOnCaLam.LeTan => "Tiếp tân",
                _ => null,
            };
        }
        public static RoleOnCaLam ConverterStringToVaiTro(string role)
        {
            return role switch
            {
                "Trưởng ca" => RoleOnCaLam.TruongCa,
                "Pha chế" => RoleOnCaLam.PhaChe,
                "Phục vụ" => RoleOnCaLam.PhucVu,
                "Tiếp tân" => RoleOnCaLam.LeTan,
                _ => RoleOnCaLam.None,
            };
        }
    }
}
