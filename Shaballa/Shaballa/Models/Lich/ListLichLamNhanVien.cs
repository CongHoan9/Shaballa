using System.Windows.Media.Media3D;

namespace Shaballa
{
    public class ListLichLamNhanVien : ListRemovableItem<LichLamNhanVien>
    {
        public ListLichLamNhanVien() : base() { }
        public ListLichLamNhanVien(IEnumerable<LichLamNhanVien> items) : base(items)
        {
            AddRange(items);
        }
        protected override void InsertItem(int index, LichLamNhanVien item)
        {
            if (item.VaiTro == RoleOnCaLam.TruongCa && this.Any(nv => nv.VaiTro == RoleOnCaLam.TruongCa))
            {
                return;
            }
            base.InsertItem(index, item);
            if (Contains(item))
            {
                item.NewOldRoleChanged += Item_NewOldRoleChanged;
            }
        }
        private void Item_NewOldRoleChanged(RoleOnCaLam newRole, RoleOnCaLam oldRole)
        {
            if (newRole is RoleOnCaLam.TruongCa && this.FirstOrDefault(i => i.VaiTro == RoleOnCaLam.TruongCa) is LichLamNhanVien truongcaold)
            {
                truongcaold.VaiTro = oldRole;
            }
        }
    }
}
