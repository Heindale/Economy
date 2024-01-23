using System.Windows;
using System.Windows.Controls;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static System.Net.Mime.MediaTypeNames;

namespace Economy
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GenerateDocxButton_Click(object sender, RoutedEventArgs e)
		{
			// Замените этот код на соответствующую логику вашего приложения

			Formatting titleFormat = new Formatting
			{
				Size = 16D,
				Bold = true,
				Spacing = 1.5
			};

			Formatting textFormat = new Formatting
			{
				Size = 14D,
				Spacing = 1.5
			};

			// Создание нового документа
			using (DocX doc = DocX.Create("GeneratedDocument.docx"))
			{
				// Добавление параграфа в документ
				Paragraph paragraph = doc.InsertParagraph();

				// Заполнение данных из текстового поля
				string userData = UserDataTextBox.Text;
				paragraph.Append(userData).Font("Arial").FontSize(12).Bold();

				// Сохранение документа
				doc.Save();
			}

			MessageBox.Show("DOCX файл успешно сгенерирован!");
		}
	}
}