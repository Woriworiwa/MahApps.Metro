using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
	/// <summary>
	/// Interaction logic for BarButton.xaml
	/// </summary>
	public partial class BarButton : UserControl
	{
		public BarButton()
		{
			this.InitializeComponent();
            this.MetroText = "Hello"; 
		}        

        public static readonly DependencyProperty MetroImageSourceProperty =
            DependencyProperty.Register("MetroImageSource", typeof(Visual), typeof(BarButton), new PropertyMetadata(default(Visual)));

        public Visual MetroImageSource
        {           
            get { return (Visual)GetValue(MetroImageSourceProperty); }
            set { SetValue(MetroImageSourceProperty, value); }
        }



        public string MetroText
        {
            get { return (string)GetValue(MetroTextProperty); }
            set { SetValue(MetroTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MetroText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetroTextProperty =
            DependencyProperty.Register("MetroText", typeof(string), typeof(BarButton), new PropertyMetadata("Text"));

        
	}
}