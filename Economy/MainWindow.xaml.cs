﻿using DocumentFormat.OpenXml.Packaging;
using Economy.Resources.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Economy
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public int MyProperty { get; set; }

		public MainWindow()
		{
			InitializeComponent();
		}

		private void GenerateDocxButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Chapter1_Click(object sender, RoutedEventArgs e)
		{
			CurrentPage.Navigate(new Chapter1());
		}

		private void Chapter2_Click(object sender, RoutedEventArgs e)
		{
			CurrentPage.Navigate(new Chapter2());
		}
	}
}