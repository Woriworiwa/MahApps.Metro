using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Shapes;

namespace Demo
{
    public class Bubble : Adorner
    {
        // Be sure to call the base class constructor.
        public Bubble(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);
            
            //Point relativePoint = this.AdornedElement.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0));
            adornedElementRect.Location = new Point(adornedElementRect.Location.X, adornedElementRect.Location.Y + adornedElementRect.Height + 10);            

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Color.FromRgb(0, 107,194));            
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);                    
            
            drawingContext.DrawRoundedRectangle(renderBrush, null, adornedElementRect, 0.0, 0.0);

            

            //drawingContext.DrawImage()
            //drawingContext.DrawGeometry()
            var text = new FormattedText("Navigate between Triggers, Logs and the home screen.", CultureInfo.InvariantCulture, System.Windows.FlowDirection.LeftToRight, new Typeface("Segoe UI"), 16, Brushes.White);
            drawingContext.DrawText(text, new Point(adornedElementRect.Location.X, adornedElementRect.Location.Y));


        }
    }
}
