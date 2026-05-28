
using System.Windows;
using System.Windows.Input;

namespace Shaballa
{
    public class ChiTietHoaDon(string id, string item, int quantity, decimal dongia) : ChiTiet<string>(id)
    {
        public override decimal DonGia => GetDecimal(dongia, 0);
        public override int Quantity
        {
            get => GetInt(quantity, 0);
            set { /*Không thay đổi*/ }
        }
        public override string Item
        {
            get => GetString(item, "Không có dữ liệu");
            set { /*Không thay đổi*/ }
        }
        public override void Gop(ICombine icombine)
        {
            
        }
        public override string ToString()
        {
            return $"{Quantity}X {Item}";
        }
    }
}
