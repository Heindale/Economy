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
	/// Логика взаимодействия для Chapter1.xaml
	/// </summary>
	public partial class Chapter1 : Page
	{
		public List<string> Table11Cell1 { get; set; }

		public Chapter1()
		{
			InitializeComponent();
		}

		private void Sum_Click(object sender, RoutedEventArgs e)
		{
			var childrenOfTable11 = Table11.Children.OfType<TextBox>().Where(tb => string.IsNullOrEmpty(tb.Text));
			//var table11Cell1 = Table11.
			foreach (var item in childrenOfTable11)
			{
				item.Focus();
			}
			if (Table11.Children.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text)))
			{
				MessageBox.Show("Пожалуйста, заполните поля!");
			}
		}
	}
}