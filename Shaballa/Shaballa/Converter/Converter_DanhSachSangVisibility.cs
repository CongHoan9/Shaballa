using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;

namespace Shaballa
{
    class Converter_DanhSachSangVisibility : MarkupExtension, IValueConverter
    {
        private static Converter_DanhSachSangVisibility _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_DanhSachSangVisibility();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ICollection collection && collection.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
