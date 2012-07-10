using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
    public class MenuButton: Button
    {
        public MenuButton()
        {
            DefaultStyleKey = typeof(AppBarButton);
        }

        public static readonly DependencyProperty MetroImageSourceProperty =
            DependencyProperty.Register("MetroImageSource", typeof(Visual), typeof(AppBarButton), new PropertyMetadata(default(Visual)));

        public Visual MetroImageSource
        {
            get { return (Visual)GetValue(MetroImageSourceProperty); }
            set { SetValue(MetroImageSourceProperty, value); }
        }
    }
}
