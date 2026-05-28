using System.Windows;
using System.Windows.Controls;
namespace Shaballa
{
    public class NoteButton : Button
    {
        public static readonly DependencyProperty NoteProperty = DependencyProperty.Register(nameof(Note), typeof(string), typeof(NoteButton), new(""));
        public string Note
        {
            get => (string)GetValue(NoteProperty);
            set => SetValue(NoteProperty, value);
        }
    }
}
