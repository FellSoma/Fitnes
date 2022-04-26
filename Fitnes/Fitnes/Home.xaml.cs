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
       
        public Home(ref string role)
        {
            InitializeComponent();

            switch (role)
            {
                case "Администратор       ":
                    {
                        MessageBox.Show("Привет владелец");
                    }
                    break;
                case "Тренер":
                    {
                      
                    }
                    break;
                case "Пользователь":
                    {
                        MessageBox.Show("Привет Раб");

                    }
                    break;
            }
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
                faqsTabcontrol.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility= Visibility.Collapsed;

            }
        }

        private void profileChecked(object sender, RoutedEventArgs e)
        {
            if (rbProfile.IsChecked == true)
            {
                profile.Visibility = Visibility.Visible;
                home.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility= Visibility.Collapsed;
                faqsTabcontrol.Visibility = Visibility.Collapsed;

            }

        }

        private void faqsChecked(object sender, RoutedEventArgs e)
        {
            if (rbFaqs.IsChecked == true)
            {
                profile.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                home.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility= Visibility.Collapsed;
                faqsTabcontrol.Visibility = Visibility.Visible;

            }
        }

        private void usersChecked(object sender, RoutedEventArgs e)
        {
            if (rbUsers.IsChecked == true)
            {
                profile.Visibility = Visibility.Collapsed;
                home.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Visible;
                pointTabControl.Visibility = Visibility.Collapsed;
                faqsTabcontrol.Visibility = Visibility.Collapsed;

            }
        }

        private void pointsChecked(object sender, RoutedEventArgs e)
        {
            if (rbPoints.IsChecked == true)
            {
                profile.Visibility = Visibility.Collapsed;
                home.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility = Visibility.Visible;
                faqsTabcontrol.Visibility = Visibility.Collapsed;

            }
        }
    }
}
