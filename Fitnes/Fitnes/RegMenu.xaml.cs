using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
        ApplicationContext db;
        public RegMenu()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(5);
            db = new ApplicationContext();

            newImage();

           
           
        }
        int trys = 0;
        string name;
        bool check=false;
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
        private User _currentUser = new User();
        public void regisry()
        {
            if(Email.Text !="" && Login.Text != "" && passwordBx.Password.Length != 0 && passwordBx2.Password.Length != 0)
            {
                if(check==true && level >0)
                {
                    Entities.User user = new Entities.User()
                    {
                        Email = Email.Text,
                        Login = Login.Text,
                        Password = passwordBx.Password,
                        Role = "Пользователь"
                    };
                    Entities.User authUser = null;
                    using (Entities.FitnessDBEntities1 context = new Entities.FitnessDBEntities1())
                    {
                        authUser = context.Users.Where(b => b.Login == Login.Text || b.Email == Email.Text).FirstOrDefault();
                        if (authUser != null)
                        {
                            ErrorBlock.Text = "Такой пользователь уже существует";
                            return;
                        }
                        try
                        {
                             context.Users.Add(user);
                             context.SaveChanges();
                             ErrorBlock.Text="Пользователь создан";
                        }
                        catch (Exception ex)
                        {
                            ErrorBlock.Text=ex.Message.ToString();
                        }
                        // Пользователь создан 
                    }
                }
                else
                emailCheck();
            }
            else
            {
                ErrorBlock.Text = "Заполните поля данных";
            }
        }

        public void emailCheck()
        {
            if(Email.Text.Length>5 && Email.Text.Contains("@")&&Email.Text.Contains("."))
            {
                passwordLenght();
            }    
            else {
                ErrorBlock.Text = "Email введён некоректно проверте\nуказаны ли все знаки @ , . ";
            }
            
        }
        public void passwordLenght()
        {
            if(passwordBx.Password.Length >=6 && passwordBx2.Password.Length >= 6)
            {
                someChar();
            }
            else
            {
                ErrorBlock.Text = "пароль дожнен быть не меннее 6 символов";
            }
        }

        public void someChar()
        {
           if(( passwordBx.Password.Contains("@") && passwordBx2.Password.Contains("@")) || (passwordBx.Password.Contains("!") && 
                passwordBx2.Password.Contains("!")) || (passwordBx.Password.Contains("%") && passwordBx2.Password.Contains("%")))
           {
                level++;
                charLowwerUp();
           }
           else
           {
                charLowwerUp();
           }
        }
        public void charLowwerUp()
        {
            int j = 0;
            string password = passwordBx.Password;
            foreach (var item in password)
            {
                if(item.ToString()==item.ToString().ToUpper())
                {
                    j++;
                }
            }
            if (j == password.Length)
            {
                level++;
                recurringChar();
            }
            else recurringChar();
        }

        public void recurringChar()
        {
            int j = 0;
            string password = passwordBx.Password;
            for (int i = 0; i < password.Length-1; i++)
            {
                if(password[i]==password[++i])
                {
                    j++;
                }
            }
            if (j >=3)
            {
                passwordGemeni();
            }
            else
            {
                level++;
                passwordGemeni();
            }
        }

        public void passwordGemeni()
        {
            if (passwordBx.Password==passwordBx2.Password)
            {
                check = true;
                check = checkCapcha(check);
                if(check)
                {
                    passwordRateing();
                }
            }
            else
            {
                ErrorBlock.Text = "пароли не совбадают";
            }
        }
        int level = 0;
        //dadadadad
        public void passwordRateing()
        {
            switch (level)
            {
                case 0:
                    {
                        ErrorBlock.Text = "Используйте специальные символы\n@,%,! ";
                        passwordRate.Text = "Плохой паролль";
                        passwordRate.Foreground = Brushes.Red;
                    }
                    break;
                case 1:
                    {
                        passwordRate.Text = "Средний паролль";
                        ErrorBlock.Foreground = Brushes.Green;
                        passwordRate.Foreground = Brushes.Orange;
                        regisry();
                    }
                    break;
                case 2:
                    {
                        passwordRate.Text = "Хороший паролль";
                        passwordRate.Foreground = Brushes.Green;
                        ErrorBlock.Foreground = Brushes.Green;
                        regisry();
                    }
                    break;
            }
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



        private void passwordRateing(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {

        }

        private void regisryClick(object sender, RoutedEventArgs e)
        {
            ErrorBlock.Foreground = Brushes.DarkRed;
            check = false;
            regisry();
        }
    }
}
