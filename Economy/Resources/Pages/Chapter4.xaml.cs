using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Economy.Resources.Pages
{
    /// <summary>
    /// Логика взаимодействия для Chapter4.xaml
    /// </summary>
    public partial class Chapter4 : Page
    {
        public Chapter4()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://wordstat.yandex.ru/") { UseShellExecute = true });
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://navigator.smbn.ru/realty/13") { UseShellExecute = true });
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://corpmsp.ru/infrastruktura-podderzhki/imushchestvennaya-infrastruktura/") { UseShellExecute = true });
        }
    }
}
