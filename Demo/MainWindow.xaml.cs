using System;
using System.Collections.Generic;
using System.Linq;
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
using MahApps.Metro.Controls;
using System.Globalization;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var v = this.menu.Visibility;
            if (v == System.Windows.Visibility.Collapsed)
            {
                this.menu.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.menu.Visibility = System.Windows.Visibility.Collapsed;                
            }
            
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                //do work when tab is changed
                tabHidden.SelectedIndex = (e.Source as TabControl).SelectedIndex;
            }
        }

        private void AddTab_Click(object sender, RoutedEventArgs e)
        {
            var newTab = new TabItem();
            newTab.Header = ((sender as Button).Content as string).Replace("\n", " ");
            newTab.SetResourceReference(StyleProperty, "TabControl");            
            tabShown.Items.Add(newTab);
        }

        private void LeftTabs1_Click(object sender, RoutedEventArgs e)
        {
            //((sender as Button).Parent as Border).BorderThickness = new Thickness(0,0,1,0);
            //(leftTabs2_button.Parent as Border).BorderThickness = new Thickness(1, 0, 1, 1);
            //(leftTabs3_button.Parent as Border).BorderThickness = new Thickness(1, 0, 0, 1);

            ((sender as Button).Parent as Border).Background = new SolidColorBrush(Color.FromRgb(241, 243, 245));
            (leftTabs2_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            (leftTabs3_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            tools_variables.Visibility = System.Windows.Visibility.Hidden;
            tools_events_order.Visibility = System.Windows.Visibility.Hidden;

            //left_tabs.SelectedIndex = 0;
        }
        private void LeftTabs2_Click(object sender, RoutedEventArgs e)
        {

            //((sender as Button).Parent as Border).BorderThickness = new Thickness(1, 0, 1, 0);
            //(LeftTabs1_button.Parent as Border).BorderThickness = new Thickness(0, 0, 1, 1);
            //(leftTabs3_button.Parent as Border).BorderThickness = new Thickness(1, 0, 0, 1);

            ((sender as Button).Parent as Border).Background = new SolidColorBrush(Color.FromRgb(241, 243, 245));
            (LeftTabs1_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            (leftTabs3_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            tools_variables.Visibility = System.Windows.Visibility.Visible;
            tools_events_order.Visibility = System.Windows.Visibility.Hidden;

            //left_tabs.SelectedIndex = 1;
        }
        private void LeftTabs3_Click(object sender, RoutedEventArgs e)
        {
            
            //((sender as Button).Parent as Border).BorderThickness = new Thickness(1, 0, 0, 0);
            //(LeftTabs1_button.Parent as Border).BorderThickness = new Thickness(0, 0, 1, 1);
            //(leftTabs2_button.Parent as Border).BorderThickness = new Thickness(1, 0, 1, 1);

            ((sender as Button).Parent as Border).Background = new SolidColorBrush(Color.FromRgb(241, 243, 245));
            (LeftTabs1_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            (leftTabs2_button.Parent as Border).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            tools_variables.Visibility = System.Windows.Visibility.Hidden;
            tools_events_order.Visibility = System.Windows.Visibility.Visible;

            //left_tabs.SelectedIndex = 2;
        }

    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return (double)value / 3 ;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return (double)value * 3;
        }
    }
}
