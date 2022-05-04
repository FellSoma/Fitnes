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
using System.Windows.Shapes;

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для OutTimer.xaml
    /// </summary>
    public partial class OutTimer : Window
    {
        public OutTimer()
        {
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            SiningMenu w = new SiningMenu();
            w.Show();
            this.Close();
        }
    }
}
