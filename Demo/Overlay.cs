using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace Demo
{
    public class Overlay : Adorner
    {
        // Be sure to call the base class constructor.
        public Overlay(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);            

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);                        

            drawingContext.PushOpacity(0.5);
            drawingContext.DrawRectangle(Brushes.Gray, renderPen, adornedElementRect);
        }
    }
}
