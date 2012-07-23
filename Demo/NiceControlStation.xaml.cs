﻿using System;
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
    }
}
