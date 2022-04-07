using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для SiningMenu.xaml
    /// </summary>
    public partial class SiningMenu : Window
    {


        DispatcherTimer timer = new DispatcherTimer();
        public SiningMenu()
        {
            InitializeComponent();
            spCapha.Visibility = Visibility.Hidden; 
            timer.Interval = TimeSpan.FromSeconds(5);
            TestDataGrid.ItemsSource = App.DataBase.Users.ToList();

        }
        string name;
        bool check = false;
        int trysCapcha = 0;
        int trys = 0;

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

        private void entrance()
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
                ErrorBlock.Text = "Пользователь не найден";
                spCapha.Visibility = Visibility.Visible;
                trys++;
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
        public bool checkCapcha(bool check)
        {
            caphaName();
            if (Capcha.Text == name)
            {
                CapchaImage.Source.ToString();
                return true;
            }
            else
            {
                ErrorBlock.Text = "Капчи не совподают \nвозможно вы робот";
                newImage();
                trysCapcha++;
                if (trysCapcha == 5)
                {
                    timer.Start();
                    singButton.IsEnabled = false;
                    timer.Tick += timer_Tick;

                    ErrorBlock.Text = "Вы ввели слишком много правельных капч \nповторите попытку через 5 секунд";
                }
            }
            return false;
        }


        public void timer_Tick(object sender, EventArgs e)
        {
            singButton.IsEnabled = true;
            trysCapcha = 0;
            timer.Stop();
        }

        public void newImage()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 3);
            string[] imgNames = new string[4]
            {
               "pack://application:,,,/Fitnes;component/Images/prabi.png",
               "pack://application:,,,/Fitnes;component/Images/forni.png",
               "pack://application:,,,/Fitnes;component/Images/pexpopti.png",
               "pack://application:,,,/Fitnes;component/Images/plings.png"
            };
            if (CapchaImage.Source.ToString() != imgNames[number])
            {
                name = imgNames[number];
                CapchaImage.Source = BitmapFrame.Create(new Uri(@imgNames[number]));
            }
            else
            {
                newImage();
            }
        }

        public void caphaName()
        {
            string s = CapchaImage.Source.ToString();
            char[] separators = new char[] { '{', ':', '/', ',', ';', '.', '}' };
            string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            name = subs[5];
            //5 элемен в масиве 

        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void test(object sender, RoutedEventArgs e)
        {
            someChar();
        }

        public void someChar()
        {
            if (Login.Text != "" && passwordBx.Password.Length != 0)
            { 
                if(trys<=0)
                {
                    entrance();
                }
                else
                {
                    check = true;
                    check = checkCapcha(check);
                    if (check)
                    {
                        entrance();
                    }
                }
            }
            else
            {
                ErrorBlock.Text = "Заполните поля данных";
            }
        }
    }
}
