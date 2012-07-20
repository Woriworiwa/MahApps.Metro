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
                positionAnimation.To = (double)(solutions.SelectedIndex * (10 + 35) + (10 + 35/2 - 9) );
                positionAnimation.Duration = TimeSpan.FromMilliseconds(150);
                solution_pointer.BeginAnimation(Canvas.TopProperty, positionAnimation);
            }

            triggers_tab.SelectedIndex = solutions.SelectedIndex;
                //solution_pointer.SetValue(Canvas.TopProperty, (double)(solutions.SelectedIndex * 55));
        }
    }
}
