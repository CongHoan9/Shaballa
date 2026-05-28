using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Shaballa
{
    public class Converter_TrangThaiSangMau : MarkupExtension, IValueConverter
    {
        private static Converter_TrangThaiSangMau _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_TrangThaiSangMau();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrangThai trangThai)
            {
                return trangThai switch
                {
                    TrangThai.Trong => new SolidColorBrush(Color.FromRgb(34, 197, 94)),
                    TrangThai.DaDay => new(Color.FromRgb(239, 68, 68)),
                    TrangThai.BaoTri => new(Color.FromRgb(107, 114, 128)),
                    _ => new(Color.FromRgb(190, 133, 80)),
                };
            }
            return new SolidColorBrush(Color.FromRgb(190, 133, 80));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class Converter_TrangThaiSangMauVien : MarkupExtension, IValueConverter
    {
        private static Converter_TrangThaiSangMauVien _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_TrangThaiSangMauVien();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrangThai trangThai)
            {
                return trangThai switch
                {
                    
                    TrangThai.Trong => new SolidColorBrush(Color.FromRgb(22, 163, 74)),
                    TrangThai.DaDay => new(Color.FromRgb(217, 119, 6)),
                    TrangThai.BaoTri => new(Color.FromRgb(40, 49, 63)),
                    _ => new(Color.FromRgb(149, 110, 84)),
                };
            }
            return new SolidColorBrush(Color.FromRgb(149, 110, 84));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
