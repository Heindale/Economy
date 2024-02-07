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

namespace Economy.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoadWindowVerisonSecond.xaml
    /// </summary>
    public partial class LoadWindowVerisonSecond : Window
    {
        public LoadWindowVerisonSecond()
        {
            InitializeComponent();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
