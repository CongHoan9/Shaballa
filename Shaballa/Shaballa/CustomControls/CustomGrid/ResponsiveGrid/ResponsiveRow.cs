using System.Windows;
using System.Windows.Controls;
namespace Shaballa
{
    internal class ResponsiveRow : RowDefinition
    {
        protected double OldMin;
        protected double OldMax;
        protected GridLength OldSize;
        public static readonly DependencyProperty ResponsiveSizeProperty = DependencyProperty.Register(nameof(ResponsiveSize), typeof(double), typeof(ResponsiveRow), new(double.NaN));
        public static readonly DependencyProperty NewSizeProperty = DependencyProperty.Register(nameof(NewSize), typeof(GridLength), typeof(ResponsiveRow), new PropertyMetadata(new GridLength(1, GridUnitType.Star)));
        public double ResponsiveSize
        {
            get => (double)GetValue(ResponsiveSizeProperty);
            set => SetValue(ResponsiveSizeProperty, value);
        }
        public GridLength NewSize
        {
            get => (GridLength)GetValue(NewSizeProperty);
            set => SetValue(NewSizeProperty, value);
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            OldMin = MinHeight;
            OldMax = MaxHeight;
            OldSize = Height;
            Loaded += (_, _) =>
            {
                if (Parent is FrameworkElement grid)
                {
                    grid.SizeChanged += CheckToShow;
                }
            };
        }
        public void CheckToShow(object sender, SizeChangedEventArgs e)
        {
            double size = e.NewSize.Width;
            if (!double.IsNaN(size) && !double.IsNaN(ResponsiveSize))
            {
                if (size < ResponsiveSize)
                {
                    ClearValue(MinHeightProperty);
                    ClearValue(MaxHeightProperty);
                    Height = NewSize;
                }
                else
                {
                    MinHeight = OldMin;
                    MaxHeight = OldMax;
                    Height = OldSize;
                }
            }
        }
    }
}
