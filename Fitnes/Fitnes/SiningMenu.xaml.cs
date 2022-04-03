using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для SiningMenu.xaml
    /// </summary>
    public partial class SiningMenu : Window
    {


        public SiningMenu()
        {
            InitializeComponent();
            TestDataGrid.ItemsSource = App.DataBase.Users.ToList();

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Window g = new SiningMenu();
            g.Show();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void PasswordBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void onPasswordChenged(object sender, RoutedEventArgs e)
        {
            if (passwordBx.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
                //passwordBx.IsSelectionActive
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;

            }
        }

        private void emptyMethod(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void entrance(object sender, RoutedEventArgs e)
        {
            Entities.User authUser = null;
            using (Entities.FitnessDBEntities context = new Entities.FitnessDBEntities())
            {
                authUser = context.Users.Where(b => b.Login == Login.Text && b.Password == passwordBx.Password).FirstOrDefault();
            }
            if (authUser != null)
            {

                Window g = new Home();
                g.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void windowState(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Loading(object sender, RoutedEventArgs e)
        {
            Window g = new RegMenu();
            g.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
