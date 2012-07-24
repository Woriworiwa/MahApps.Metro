using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Collections;

namespace Demo
{
    public class UIElementAdorner : Adorner
    {
        private UIElement child;
        public UIElementAdorner(UIElement element, UIElement adornedElement)
            : base(adornedElement)
        {
            this.child = element;
            base.AddLogicalChild(element);
            base.AddVisualChild(element);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Int32 VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(Int32 index)
        {
            return this.child;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add(this.child);
                return (IEnumerator)list.GetEnumerator();
            }
        }
    }
}
