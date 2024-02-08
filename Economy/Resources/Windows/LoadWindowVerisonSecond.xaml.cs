using Microsoft.Win32;
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
		private MainWindow _mainWindow;

		public LoadWindowVerisonSecond(MainWindow mainWindow)
		{
			InitializeComponent();
			_mainWindow = mainWindow;
		}

		private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
		}

		public void IncrementValue(int value)
		{
			pbStatus.Value += value;
		}

		public void ProgressBarStartAsync(SaveFileDialog folderBrowser)
		{
			var thr = new Thread(ChangePages);
			thr.SetApartmentState(ApartmentState.STA);
			thr.IsBackground = true;
			thr.Start();

			_mainWindow.document.SaveAs(folderBrowser.FileName);
			MessageBox.Show("DOCX файл успешно сгенерирован!");
		}

		private void ChangePages()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				_mainWindow.ChangePage1();
				IncrementValue(20);
				_mainWindow.ChangePage2();
				IncrementValue(20);
				_mainWindow.ChangePage3();
				IncrementValue(20);
				_mainWindow.ChangePage4();
				IncrementValue(20);
				_mainWindow.ChangePage5();
				IncrementValue(20);
				Close();
			});
			System.Windows.Threading.Dispatcher.Run();
		}
	}
}