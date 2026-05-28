using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
namespace Shaballa
{
    public class Converter_DataSangColor : MarkupExtension, IValueConverter
    {
        private static Converter_DataSangColor _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_DataSangColor();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                ListGroupbleItem<DoUong> => new(Color.FromRgb(99, 143, 72)),
                ListGroupbleItem<DoAn> => new(Color.FromRgb(239, 68, 68)),
                ListRemovableItem<Topping> => new(Color.FromRgb(59, 130, 246)),
                DoUong => new(Color.FromRgb(99, 143, 72)),
                DoAn => new(Color.FromRgb(239, 68, 68)),
                Topping => new(Color.FromRgb(59, 130, 246)),
                TrangThaiNguyenLieu.TonKho => new(Color.FromRgb(220, 252, 231)),
                TrangThaiNguyenLieu.HetHang => new(Color.FromRgb(254, 226, 226)),
                TrangThaiNguyenLieu.HuyNhap => new(Color.FromRgb(220, 220, 220)),
                TrangThai.Trong => new(Color.FromRgb(34, 197, 94)),
                TrangThai.DaDay => new(Color.FromRgb(239, 68, 68)),
                TrangThai.BaoTri => new(Color.FromRgb(107, 114, 128)),
                RoleOnCaLam.TruongCa => new(Color.FromRgb(251, 184, 31)),
                RoleOnCaLam.PhucVu => new(Color.FromRgb(99, 143, 72)),
                RoleOnCaLam.PhaChe => new(Color.FromRgb(255, 255, 255)),
                RoleOnCaLam.LeTan => new(Color.FromRgb(59, 130, 246)),
                _ => Brushes.Transparent,
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class Converter_DataSangColorBlur : MarkupExtension, IValueConverter
    {
        private static Converter_DataSangColorBlur _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_DataSangColorBlur();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                TrangThaiNguyenLieu.TonKho => new(Color.FromRgb(240, 253, 244)),
                TrangThaiNguyenLieu.HetHang => new(Color.FromRgb(255, 251, 235)),
                TrangThaiNguyenLieu.HuyNhap => new(Color.FromRgb(236, 236, 236)),
                TrangThai.Trong => new(Color.FromRgb(22, 101, 52)),
                TrangThai.DaDay => new(Color.FromRgb(153, 27, 27)),
                TrangThai.BaoTri => new(Color.FromRgb(40, 49, 63)),
                _ => Brushes.Transparent,
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class Converter_DataSangColorForeground : MarkupExtension, IValueConverter
    {
        private static Converter_DataSangColorForeground _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_DataSangColorForeground();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                TrangThaiNguyenLieu.TonKho => new(Color.FromRgb(22, 163, 74)),
                TrangThaiNguyenLieu.HetHang => new(Color.FromRgb(220, 38, 38)),
                TrangThaiNguyenLieu.HuyNhap => new(Color.FromRgb(96, 96, 96)),
                _ => Brushes.Transparent,
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
