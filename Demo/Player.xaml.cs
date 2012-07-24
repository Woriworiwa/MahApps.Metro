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

namespace Demo
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        public delegate void NextClickHandler(object sender, EventArgs e);
        public event EventHandler NextClick;
        public event EventHandler StopClick;

        public event EventHandler OkClick;
        private void Rectangle_MouseDown(object sender, RoutedEventArgs e)
        {
            if (NextClick != null)
                NextClick(this, e);
        }

        private void Stop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (StopClick != null)
                StopClick(this, e);
        }
    }
}
