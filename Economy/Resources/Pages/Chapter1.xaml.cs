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
			T11Cell16.Text = ComboBoxSum(T11Cell12.Text, T11Cell13.Text, T11Cell15.Text);
			T11Cell26.Text = ComboBoxSum(T11Cell22.Text, T11Cell23.Text, T11Cell25.Text);
			T11Cell36.Text = ComboBoxSum(T11Cell32.Text, T11Cell33.Text, T11Cell35.Text);
			T11Cell46.Text = ComboBoxSum(T11Cell42.Text, T11Cell43.Text, T11Cell45.Text);
			T11Cell56.Text = ComboBoxSum(T11Cell52.Text, T11Cell53.Text, T11Cell55.Text);
			T11Cell66.Text = ComboBoxSum(T11Cell62.Text, T11Cell63.Text, T11Cell65.Text);
			T11Cell76.Text = ComboBoxSum(T11Cell72.Text, T11Cell73.Text, T11Cell75.Text);
			T11Cell86.Text = ComboBoxSum(T11Cell82.Text, T11Cell83.Text, T11Cell85.Text);
			T11Cell96.Text = ComboBoxSum(T11Cell92.Text, T11Cell93.Text, T11Cell95.Text);
			T11Cell106.Text = ComboBoxSum(T11Cell102.Text, T11Cell103.Text, T11Cell105.Text);
			T11Cell116.Text = ComboBoxSum(T11Cell112.Text, T11Cell113.Text, T11Cell115.Text);
			T11Cell126.Text = ComboBoxSum(T11Cell122.Text, T11Cell123.Text, T11Cell125.Text);
			T11Cell136.Text = ComboBoxSum(T11Cell132.Text, T11Cell133.Text, T11Cell135.Text);
			T11Cell146.Text = ComboBoxSum(T11Cell142.Text, T11Cell143.Text, T11Cell145.Text);
			T11Cell156.Text = ComboBoxSum(T11Cell152.Text, T11Cell153.Text, T11Cell155.Text);
			T11Cell166.Text = ComboBoxSum(T11Cell162.Text, T11Cell163.Text, T11Cell165.Text);
			T11Cell176.Text = ComboBoxSum(T11Cell172.Text, T11Cell173.Text, T11Cell175.Text);
			T11Cell186.Text = ComboBoxSum(T11Cell182.Text, T11Cell183.Text, T11Cell185.Text);

			var emptyTextBoxesOfT11 = Page1.Children.OfType<TextBox>().Where(tb => string.IsNullOrEmpty(tb.Text));
			var notEmptyTextBoxesOfT11 = Page1.Children.OfType<TextBox>().Where(tb => !string.IsNullOrEmpty(tb.Text));
			foreach (var item in notEmptyTextBoxesOfT11)
			{
				item.Background = Brushes.White;
			}
			var emptyComboBoxesOfT11 = Page1.Children.OfType<ComboBox>().Where(cb => string.IsNullOrEmpty(cb.Text));
			var notEmptyComboBoxesOfT11 = Page1.Children.OfType<ComboBox>().Where(cb => !string.IsNullOrEmpty(cb.Text));
			foreach (var item in notEmptyComboBoxesOfT11)
			{
				item.Background = Brushes.White;
			}
			var comboBoxesOfT11 = Page1.Children.OfType<ComboBox>();

			if (Page1.Children.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text))
				|| Page1.Children.OfType<ComboBox>().Any(cb => string.IsNullOrEmpty(cb.Text)))
			{
				foreach (var item in emptyTextBoxesOfT11)
				{
					item.Background = Brushes.Red;
					item.Focus();
				}
				foreach (var item in emptyComboBoxesOfT11)
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