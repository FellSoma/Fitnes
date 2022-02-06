using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для RegMenu.xaml
    /// </summary>
    public partial class RegMenu : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int sec = 0;
        public RegMenu()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(5);


        }
        int trys = 0;
        string name;
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

            if (passwordBx2.Password.Length > 0)
            {
                WaterMark1.Visibility = Visibility.Collapsed;
                //passwordBx.IsSelectionActive
            }
            else
            {
                WaterMark1.Visibility = Visibility.Visible;

            }
        }

        private void emptyMethod(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void entrance(object sender, RoutedEventArgs e)
        {
            Window g = new SiningMenu();
            g.Show();
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

        private void regisry(object sender, RoutedEventArgs e)
        {
            Boolean check = false;
            check = checkCapcha(check);
        }

        public bool checkCapcha(Boolean check)
        {
            caphaName();
            if (Capcha.Text == name)
            {
                CapchaImage.Source.ToString();
                return true;
            }
            else
            {
                ErrorBlock.Text = "Капчи не совподают \n возможно вы робот";
                newImage();
                trys++;
                if (trys == 5)
                {
                    timer.Start();
                    regButton.IsEnabled = false;
                    timer.Tick += timer_Tick;

                    ErrorBlock.Text = "Вы ввели слишком много правельных капч \nповторите попытку через 5 секунд";
                }
            }
            return false;
        }


        public void timer_Tick(object sender, EventArgs e)
        {
            regButton.IsEnabled = true;
            trys = 0;
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
    }
}
