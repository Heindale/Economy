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
using Xceed.Words.NET;

namespace Economy.Resources.Pages
{
	/// <summary>
	/// Логика взаимодействия для Chapter1.xaml
	/// </summary>
	public partial class Chapter1 : Page
	{
		public Chapter1()
		{
			InitializeComponent();
		}

		private void Sum_Click(object sender, RoutedEventArgs e)
		{
			Table11Cell16.Text = ComboBoxSum(Table11Cell12.Text, Table11Cell13.Text, Table11Cell15.Text);
			Table11Cell26.Text = ComboBoxSum(Table11Cell22.Text, Table11Cell23.Text, Table11Cell25.Text);
			Table11Cell36.Text = ComboBoxSum(Table11Cell32.Text, Table11Cell33.Text, Table11Cell35.Text);
			Table11Cell46.Text = ComboBoxSum(Table11Cell42.Text, Table11Cell43.Text, Table11Cell45.Text);
			Table11Cell56.Text = ComboBoxSum(Table11Cell52.Text, Table11Cell53.Text, Table11Cell55.Text);
			Table11Cell66.Text = ComboBoxSum(Table11Cell62.Text, Table11Cell63.Text, Table11Cell65.Text);
			Table11Cell76.Text = ComboBoxSum(Table11Cell72.Text, Table11Cell73.Text, Table11Cell75.Text);
			Table11Cell86.Text = ComboBoxSum(Table11Cell82.Text, Table11Cell83.Text, Table11Cell85.Text);
			Table11Cell96.Text = ComboBoxSum(Table11Cell92.Text, Table11Cell93.Text, Table11Cell95.Text);
			Table11Cell106.Text = ComboBoxSum(Table11Cell102.Text, Table11Cell103.Text, Table11Cell105.Text);
			Table11Cell116.Text = ComboBoxSum(Table11Cell112.Text, Table11Cell113.Text, Table11Cell115.Text);
			Table11Cell126.Text = ComboBoxSum(Table11Cell122.Text, Table11Cell123.Text, Table11Cell125.Text);
			Table11Cell136.Text = ComboBoxSum(Table11Cell132.Text, Table11Cell133.Text, Table11Cell135.Text);
			Table11Cell146.Text = ComboBoxSum(Table11Cell142.Text, Table11Cell143.Text, Table11Cell145.Text);
			Table11Cell156.Text = ComboBoxSum(Table11Cell152.Text, Table11Cell153.Text, Table11Cell155.Text);
			Table11Cell166.Text = ComboBoxSum(Table11Cell162.Text, Table11Cell163.Text, Table11Cell165.Text);
			Table11Cell176.Text = ComboBoxSum(Table11Cell172.Text, Table11Cell173.Text, Table11Cell175.Text);
			Table11Cell186.Text = ComboBoxSum(Table11Cell182.Text, Table11Cell183.Text, Table11Cell185.Text);

			var emptyTextBoxesOfTable11 = Table11.Children.OfType<TextBox>().Where(tb => string.IsNullOrEmpty(tb.Text));
			var notEmptyTextBoxesOfTable11 = Table11.Children.OfType<TextBox>().Where(tb => !string.IsNullOrEmpty(tb.Text));
			foreach (var item in notEmptyTextBoxesOfTable11)
			{
				item.Background = Brushes.White;
			}
			var emptyComboBoxesOfTable11 = Table11.Children.OfType<ComboBox>().Where(cb => string.IsNullOrEmpty(cb.Text));
			var notEmptyComboBoxesOfTable11 = Table11.Children.OfType<ComboBox>().Where(cb => !string.IsNullOrEmpty(cb.Text));
			foreach (var item in notEmptyComboBoxesOfTable11)
			{
				item.Background = Brushes.White;
			}
			var comboBoxesOfTable11 = Table11.Children.OfType<ComboBox>();

			if (Table11.Children.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text))
				|| Table11.Children.OfType<ComboBox>().Any(cb => string.IsNullOrEmpty(cb.Text)))
			{
				foreach (var item in emptyTextBoxesOfTable11)
				{
					item.Background = Brushes.Red;
					item.Focus();
				}
				foreach (var item in emptyComboBoxesOfTable11)
				{
					item.Focus();
				}
				MessageBox.Show("Пожалуйста, заполните все поля!");
			}
		}

		private string ComboBoxSum(string a, string b, string c)
		{
			if (!(string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || string.IsNullOrEmpty(c)))
			{
				return (Convert.ToInt32(a) + Convert.ToInt32(b) + Convert.ToInt32(c)).ToString();
			}
			return "";
		}
	}
}