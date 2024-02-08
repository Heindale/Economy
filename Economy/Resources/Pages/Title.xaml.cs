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

namespace Economy.Resources.Pages
{
    /// <summary>
    /// Interaction logic for Title.xaml
    /// </summary>
    public partial class Title : Page
    {
        private MainWindow mainWindow;
        public Title(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
        }

        public void SetButtonMark()
        {       
            mainWindow.Title.Background = Brushes.White;
        }

        private void ToChapter1_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.CurrentPage.Navigate(mainWindow.page1);
            mainWindow.Chapter1_Click(sender, e);
        }

        private void ToChapter2_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.CurrentPage.Navigate(mainWindow.page2);
            mainWindow.Chapter2_Click(sender, e);
        }

        private void ToChapter3_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.CurrentPage.Navigate(mainWindow.page3);
            mainWindow.Chapter3_Click(sender, e);
        }

        private void ToChapter4_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.CurrentPage.Navigate(mainWindow.page4);
            mainWindow.Chapter4_Click(sender, e);
        }

        private void ToChapter5_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.CurrentPage.Navigate(mainWindow.page5);
            mainWindow.Chapter5_Click(sender, e);
        }
    }
}
