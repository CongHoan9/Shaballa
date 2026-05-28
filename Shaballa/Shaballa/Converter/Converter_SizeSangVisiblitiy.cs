//ScrollBarVisibilitys
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Shaballa
{
    public class Converter_SizeSangVisiblitiy : MarkupExtension, IValueConverter
    {
        private static Converter_SizeSangVisiblitiy _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_SizeSangVisiblitiy();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double size && double.TryParse($"{parameter}", out double responsive))
            {
                return size < responsive ? ScrollBarVisibility.Auto : ScrollBarVisibility.Disabled;
            }
            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
