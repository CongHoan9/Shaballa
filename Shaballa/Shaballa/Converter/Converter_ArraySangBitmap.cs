using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Shaballa
{
    public class Converter_ArraySangBitmap : MarkupExtension, IValueConverter
    {
        private static Converter_ArraySangBitmap _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new Converter_ArraySangBitmap();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[,] input)
            {
                try
                {
                    byte[] byteArray = new byte[input.GetLength(0) * input.GetLength(1)];
                    int index = 0;
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        for (int j = 0; j < input.GetLength(1); j++)
                        {
                            byteArray[index++] = input[i, j];
                        }
                    }
                    using MemoryStream stream = new(byteArray);
                    BitmapImage image = new();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                    image.Freeze();
                    return image;
                }
                catch
                {
                    return null;
                }
            }
            return new Random().Next(0,3) switch
            {
                0 => "Assets/TraChanh.jpg",
                1 => "Assets/KhoGa.jpg",
                _ => "Assets/QuatLacSua.jpg"
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
