using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Shaballa
{
    public partial class App : Application
    {
        public static DispatcherTimer Timer = new();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Timer.Start();
            Console.OutputEncoding = Encoding.UTF8; 
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("vi-VN");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage("vi-VN")));
            Console.WriteLine($"Phần mềm bắt đầu lúc: {DateTime.Now}");
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Console.WriteLine($"Phần mềm kết thúc lúc: {DateTime.Now}");
        }
    }
}
