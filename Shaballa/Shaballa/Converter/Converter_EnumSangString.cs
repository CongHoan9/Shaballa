using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
namespace Shaballa
{
    public class Converter_EnumSangString : MarkupExtension, IValueConverter
    {
        private static Converter_EnumSangString _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_EnumSangString();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                TrangThaiNguyenLieu.TonKho => "Còn hàng",
                TrangThaiNguyenLieu.HuyNhap => "Hủy Nhập",
                TrangThaiNguyenLieu.HetHang => "Hết hàng",
                TrangThaiNguyenLieu.None => "Chưa cập nhật",
                _ => DependencyProperty.UnsetValue,
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
