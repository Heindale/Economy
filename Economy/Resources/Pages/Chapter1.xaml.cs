﻿using System;
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