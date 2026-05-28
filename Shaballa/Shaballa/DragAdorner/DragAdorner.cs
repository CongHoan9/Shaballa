using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Shaballa
{
    public class DragAdorner : Adorner
    {
        private readonly VisualBrush _Brush;
        private readonly double _Width;
        private readonly double _Height;
        public Point Offset { get; set; }
        public DragAdorner(UIElement adornedElement, UIElement visual, Point offset) : base(adornedElement)
        {
            _Brush = new VisualBrush(visual);
            _Width = visual.RenderSize.Width;
            _Height = visual.RenderSize.Height;
            Offset = offset;
            IsHitTestVisible = false;
        }

        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    drawingContext.DrawRectangle(_Brush, null, new Rect(Offset, new Size(_Width, _Height)));
        //}
    }

}
