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
	/// Interaction logic for triggerItem.xaml
	/// </summary>
	public partial class triggerItem : UserControl
	{
		public triggerItem()
		{
			this.InitializeComponent();
		}
		
		public string Status{
			get{
				return this.status.Text;
			}set{
				this.status.Text = value;
			}
		}

        public SolidColorBrush StatusBackground
        {
            set
            {
                this.Header.BorderBrush = value;
            }
        }

        public string triggerName
        {
            set { trigger_name.Text = value; }
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            header_command.Visibility = System.Windows.Visibility.Visible;
            Header.Padding = new Thickness(3);
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            header_command.Visibility = System.Windows.Visibility.Collapsed;
            Header.Padding = new Thickness(0);
        }
	}
}