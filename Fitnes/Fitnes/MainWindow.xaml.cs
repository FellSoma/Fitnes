using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        int sec = 0;



        void timer_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 1)
            {
                if (sec >= 2)
                {
                    if (sec >= 3)
                    {
                        FirstLogo.Visibility = Visibility.Visible;
                        SecondLogo.Visibility = Visibility.Collapsed;
                        FinishLogo.Visibility = Visibility.Collapsed;
                        if (sec >= 4)
                        {
                            sec = 0;
                            timer.Stop();
                            Window g = new SiningMenu();
                            g.Show();
                            this.Close();
                        }
                        return;
                    }
                    FirstLogo.Visibility = Visibility.Collapsed;
                    SecondLogo.Visibility = Visibility.Collapsed;
                    FinishLogo.Visibility = Visibility.Visible;
                    return;
                }
                FirstLogo.Visibility = Visibility.Collapsed;
                SecondLogo.Visibility = Visibility.Visible;
                FinishLogo.Visibility = Visibility.Collapsed;
                return;
            }

        }
    }
}
