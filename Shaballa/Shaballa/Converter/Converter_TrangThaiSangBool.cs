using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Shaballa
{
    public class Converter_TrangThaiSangBool : MarkupExtension, IValueConverter
    {
        private static Converter_TrangThaiSangBool _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_TrangThaiSangBool();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return System.Convert.ToInt32(value) == System.Convert.ToInt32(parameter);
            }
            catch
            {
                return false;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b && parameter != null)
            {
                return System.Convert.ToInt32(parameter);
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
