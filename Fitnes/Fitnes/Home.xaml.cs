using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
       
        public Home()
        {
            InitializeComponent();
        
        }

        private void ToolBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void windowState(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void homeChecked(object sender, RoutedEventArgs e)
        {
            if(rbHome.IsChecked == true)
            {
                home.Visibility = Visibility.Visible;
                profile.Visibility = Visibility.Collapsed;
            }
        }

        private void profileChecked(object sender, RoutedEventArgs e)
        {
            if (rbProfile.IsChecked == true)
            {
                profile.Visibility = Visibility.Visible;
                home.Visibility = Visibility.Collapsed;
            }
           
        }
    }
}
