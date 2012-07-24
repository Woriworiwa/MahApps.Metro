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

        AdornerLayer l, overlayAdonerLayer = null;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DockPanel overlayContainer = new DockPanel();
            overlayContainer.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            overlayContainer.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            overlayContainer.Background = new SolidColorBrush(Color.FromArgb(100, 0,0,0));            
            overlayContainer.Width = app.ActualWidth;
            overlayContainer.Height = app.ActualHeight;
            overlayContainer.LastChildFill = false;

            var player = new Player();
            player.Width = 300;
            player.Height = 50;
            player.SetValue(DockPanel.DockProperty, Dock.Bottom);
            player.NextClick += new EventHandler(player_NextClick);
            player.StopClick += new EventHandler(player_StopClick);
            overlayContainer.Children.Add(player);

            UIElementAdorner overlayAdorner = new UIElementAdorner(overlayContainer, app);
            overlayAdonerLayer = AdornerLayer.GetAdornerLayer(app);
            overlayAdonerLayer.Add(overlayAdorner);            


            StackPanel sp = new StackPanel();            
            sp.Margin = new Thickness(0, nav.ActualHeight + 5, 0, 0);
            sp.Width = nav.ActualWidth;

            var tb = CreateNavHelp();

            Polygon poly = CreateTriangle();

            sp.Children.Add(poly);
            sp.Children.Add(tb);


            UIElementAdorner d = new UIElementAdorner(sp, nav);
            l = AdornerLayer.GetAdornerLayer(nav);
            l.Add(d);

           
        }

        private static TextBlock CreateNavHelp()
        {
            var tb = new TextBlock();
            tb.Text = "Navigate between Triggers, Logs and the home screen.";
            tb.Padding = new Thickness(5);
            tb.TextWrapping = TextWrapping.WrapWithOverflow;
            tb.Foreground = Brushes.White;
            tb.Background = new SolidColorBrush(Color.FromRgb(0, 107, 194));
            tb.FontSize = 14;
            return tb;
        }

        private static TextBlock CreateServerHelp()
        {
            var tb = new TextBlock();
            tb.Text = "Server status and information.";
            tb.Padding = new Thickness(5);
            tb.TextWrapping = TextWrapping.WrapWithOverflow;
            tb.Foreground = Brushes.White;
            tb.Background = new SolidColorBrush(Color.FromRgb(0, 107, 194));
            tb.FontSize = 14;
            return tb;
        }

        private static Polygon CreateTriangle()
        {
            Polygon poly = new Polygon();
            poly.Points = new PointCollection() { new Point(1, 0), new Point(2, 1), new Point(0, 1) };
            poly.Fill = new SolidColorBrush(Color.FromRgb(0, 107, 194));
            poly.Stretch = Stretch.Fill;
            poly.Width = 15;
            poly.Height = 15;
            return poly;
        }

        void player_NextClick(object sender, EventArgs e)
        {
            try { l.Remove((l.GetAdorners(nav))[0]); }
            catch { }


            StackPanel sp = new StackPanel();
            sp.Margin = new Thickness(0, server.ActualHeight + 5, 0, 0);
            sp.Width = nav.ActualWidth;

            var tb = CreateServerHelp();

            Polygon poly = CreateTriangle();

            sp.Children.Add(poly);
            sp.Children.Add(tb);

            UIElementAdorner d = new UIElementAdorner(sp, server);
            l = AdornerLayer.GetAdornerLayer(nav);
            l.Add(d);
        }

        void player_StopClick(object sender, EventArgs e)
        {
            try { overlayAdonerLayer.Remove((overlayAdonerLayer.GetAdorners(app))[0]); }
            catch { }

            try { l.Remove((l.GetAdorners(nav))[0]); }
            catch { }

            try { l.Remove((l.GetAdorners(server))[0]); }
            catch { }
        }
    }
}
