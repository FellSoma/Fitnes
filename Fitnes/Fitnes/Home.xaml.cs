using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {

        public Home(ref Entities.User authUser)
        {
            InitializeComponent();

            switch (authUser.Role)
            {
                case "Администратор       ":
                    {
                        DataGridUsers.ItemsSource = App.DataBase.Users.ToList();
                    }
                    break;
                case "Тренер":
                    {
                        rbUsers.Visibility = Visibility.Collapsed;
                        rbPoints.Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Пользователь":
                    {
                        rbUsers.Visibility = Visibility.Collapsed;
                        rbPoints.Visibility = Visibility.Collapsed;
                        rbFaqs.Visibility = Visibility.Collapsed;
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
            if (rbHome.IsChecked == true)
            {
                home.Visibility = Visibility.Visible;
                profile.Visibility = Visibility.Collapsed;
                faqsTabcontrol.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility = Visibility.Collapsed;

            }
        }

        private void profileChecked(object sender, RoutedEventArgs e)
        {
            if (rbProfile.IsChecked == true)
            {
                profile.Visibility = Visibility.Visible;
                home.Visibility = Visibility.Collapsed;
                usersTabControl.Visibility = Visibility.Collapsed;
                pointTabControl.Visibility = Visibility.Collapsed;
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
                pointTabControl.Visibility = Visibility.Collapsed;
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

        private void addNewProfile(object sender, RoutedEventArgs e)
        {

            if (loginNewProfile.Text == "" || passNewProfile.Text == "" || roleNewProfile.Text == "")
            {
                errorBlock.Text = "Не заполнены Логин, Пароль, Роль";
            }
            else
            {
                Entities.User user = new Entities.User()
                {
                    Name = nameNewProfile.Text,
                    Email = emailNewProfile.Text,
                    Login = loginNewProfile.Text,
                    Password = passNewProfile.Text,
                    Role = roleNewProfile.Text
                };
                Entities.User authUser1 = null;
                using (Entities.FitnessDBEntities context = new Entities.FitnessDBEntities())
                {
                    authUser1 = context.Users.Where(b => b.Login == loginNewProfile.Text || b.Email == emailNewProfile.Text).FirstOrDefault();
                    if (authUser1 != null)
                    {
                        errorBlock.Foreground = Brushes.Red;
                        errorBlock.Text = "Такой пользователь уже существует";
                        return;
                    }

                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        errorBlock.Foreground = Brushes.Green;
                        errorBlock.Text = "Пользователь создан";
                    }
                    catch (Exception ex)
                    {
                        errorBlock.Text = ex.Message.ToString();
                    }
                }
            }
        }

        private void restock(object sender, RoutedEventArgs e)
        {
            DataGridUsers.ItemsSource = App.DataBase.Users.ToList();
        }

        private void deleteUser(object sender, RoutedEventArgs e)
        {
            var rowselected = DataGridUsers.SelectedItem as Entities.User;

            if (rowselected == null)
            {
                MessageBox.Show("Не выбрана ни одна строка для удаления!");
                return;
            }
            try
            {
                App.DataBase.Users.Remove(rowselected);
                App.DataBase.SaveChanges();
                DataGridUsers.ItemsSource = App.DataBase.Users.ToList();
            }
            catch (Exception ex)
            {
                errorBlock.Text = ex.Message.ToString();
            }
        }

        private void editUser(object sender, RoutedEventArgs e)
        {
            editUsers.Visibility = Visibility.Visible;
            usersTabControl.SelectedIndex = 2;
            var currenttrow = DataGridUsers.SelectedItem as Entities.User;
            if (currenttrow == null)
            {
                MessageBox.Show("Не выбрана ни одна строка для редактирования!");
                return;
            }
            nameEditProfile.Text = currenttrow.Name;
            emailEditProfile.Text = currenttrow.Email;
            loginEditProfile.Text = currenttrow.Login;
            passEditProfile.Text = currenttrow.Password;
            roleEditProfile.Text = currenttrow.Role;
        }

        private void editProfile(object sender, RoutedEventArgs e)
        {
            var currenttrow = DataGridUsers.SelectedItem as Entities.User;
            if (loginEditProfile.Text == "" || passEditProfile.Text == "" || roleEditProfile.Text == "")
            {
                errorBlock2.Text = "Не заполнены Логин, Пароль, Роль";
            }
            else
            {

                try
                {
                    (from p in App.DataBase.Users
                     where p.id_User == currenttrow.id_User
                     select p).ToList().ForEach(x => x.Name = nameEditProfile.Text);

                    (from p in App.DataBase.Users
                     where p.id_User == currenttrow.id_User
                     select p).ToList().ForEach(x => x.Email = emailEditProfile.Text);

                    (from p in App.DataBase.Users
                     where p.id_User == currenttrow.id_User
                     select p).ToList().ForEach(x => x.Login = loginEditProfile.Text);

                    (from p in App.DataBase.Users
                     where p.id_User == currenttrow.id_User
                     select p).ToList().ForEach(x => x.Password = passEditProfile.Text);

                    (from p in App.DataBase.Users
                     where p.id_User == currenttrow.id_User
                     select p).ToList().ForEach(x => x.Role = roleEditProfile.Text);


                    App.DataBase.SaveChanges();
                    errorBlock2.Foreground = Brushes.Green;
                    errorBlock2.Text = "Пользователь изменён";
                }
                catch (Exception ex)
                {
                    errorBlock2.Foreground = Brushes.Red;
                    errorBlock2.Text = ex.Message.ToString();
                }

            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            usersTabControl.SelectedIndex = 1;
            editUsers.Visibility = Visibility.Collapsed;
        }
    }
}
