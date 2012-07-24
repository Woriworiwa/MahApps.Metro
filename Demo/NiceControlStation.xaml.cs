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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Demo
{
    /// <summary>
    /// Interaction logic for NiceControlStation.xaml
    /// </summary>
    public partial class NiceControlStation
    {
        public NiceControlStation()
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (solution_pointer != null)
            {
                DoubleAnimation positionAnimation = new DoubleAnimation();
                positionAnimation.From = (double)solution_pointer.GetValue(Canvas.TopProperty);
                positionAnimation.To = (double)(solutions.SelectedIndex * (10 + 35) + (10 + 35 / 2 - 9));
                positionAnimation.Duration = TimeSpan.FromMilliseconds(150);
                solution_pointer.BeginAnimation(Canvas.TopProperty, positionAnimation);
            }

            try
            {
                triggers_tab.SelectedIndex = solutions.SelectedIndex;
            }
            catch (Exception)
            {

            }
            //solution_pointer.SetValue(Canvas.TopProperty, (double)(solutions.SelectedIndex * 55));
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            content_tab.SelectedIndex = 0;

            about_button.FontWeight = FontWeights.Bold;
            about_button.Foreground = Brushes.Black;

            triggers_button.FontWeight = FontWeights.Normal;
            triggers_button.Foreground = Brushes.Gray;

            logs_button.FontWeight = FontWeights.Normal;
            logs_button.Foreground = Brushes.Gray;
        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            content_tab.SelectedIndex = 1;
            about_button.FontWeight = FontWeights.Normal;
            about_button.Foreground = Brushes.Gray;

            triggers_button.FontWeight = FontWeights.Bold;
            triggers_button.Foreground = Brushes.Black;

            logs_button.FontWeight = FontWeights.Normal;
            logs_button.Foreground = Brushes.Gray;
        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            content_tab.SelectedIndex = 2;
            about_button.FontWeight = FontWeights.Normal;
            about_button.Foreground = Brushes.Gray;

            triggers_button.FontWeight = FontWeights.Normal;
            triggers_button.Foreground = Brushes.Gray;

            logs_button.FontWeight = FontWeights.Bold;
            logs_button.Foreground = Brushes.Black;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overlay ad = new Overlay(app);
            AdornerLayer adLayer = AdornerLayer.GetAdornerLayer(app);
            adLayer.Add(ad);

            //Bubble bubble = new Bubble(nav);
            //AdornerLayer bubbleLayer = AdornerLayer.GetAdornerLayer(nav);
            //bubbleLayer.Add(bubble);

            StackPanel sp = new StackPanel();            
            sp.Margin = new Thickness(0, nav.ActualHeight + 5, 0, 0);
            sp.Width = nav.ActualWidth;

            var tb = new TextBlock();
            tb.Text = "Navigate between Triggers, Logs and the home screen.";
            tb.Padding = new Thickness(5);
            tb.TextWrapping = TextWrapping.WrapWithOverflow;
            tb.Foreground = Brushes.White;
            tb.Background = new SolidColorBrush(Color.FromRgb(0, 107, 194));
            tb.FontSize = 14;

            Polygon poly = new Polygon();
            poly.Points = new PointCollection() { new Point(1, 0),new Point(2, 1), new Point(0, 1) };
            poly.Fill = new SolidColorBrush(Color.FromRgb(0, 107, 194));
            poly.Stretch = Stretch.Fill;
            poly.Width = 15;
            poly.Height = 15;

            sp.Children.Add(poly);
            sp.Children.Add(tb);


            UIElementAdorner d = new UIElementAdorner(sp, nav);
            AdornerLayer l = AdornerLayer.GetAdornerLayer(nav);
            l.Add(d);
        }
    }
}
