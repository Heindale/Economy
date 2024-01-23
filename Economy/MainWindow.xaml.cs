using System.Windows;
using Xceed.Document.NET;
using Xceed.Words.NET;

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
				// Добавление таблицы
				Table table = doc.AddTable(5, 3);

				// Заголовки столбцов
				table.Rows[0].Cells[0].Paragraphs.First().Append("Имя");
				table.Rows[0].Cells[1].Paragraphs.First().Append("Возраст");
				table.Rows[0].Cells[2].Paragraphs.First().Append("Город");

				// Добавление данных в ячейки
				table.Rows[1].Cells[0].Paragraphs.First().Append("Александр");
				table.Rows[1].Cells[1].Paragraphs.First().Append("25");
				table.Rows[1].Cells[2].Paragraphs.First().Append("Москва");

				table.Rows[2].Cells[0].Paragraphs.First().Append("Елена");
				table.Rows[2].Cells[1].Paragraphs.First().Append("30");
				table.Rows[2].Cells[2].Paragraphs.First().Append("Санкт-Петербург");

				table.Rows[3].Cells[0].Paragraphs.First().Append("Иван");
				table.Rows[3].Cells[1].Paragraphs.First().Append("22");
				table.Rows[3].Cells[2].Paragraphs.First().Append("Новосибирск");

				table.Rows[4].Cells[0].Paragraphs.First().Append("Ольга");
				table.Rows[4].Cells[1].Paragraphs.First().Append("28");
				table.Rows[4].Cells[2].Paragraphs.First().Append("Киев");

				// Добавление таблицы в документ
				doc.InsertTable(table);

				// Добавление параграфа в документ
				Paragraph paragraph = doc.InsertParagraph();

				// Заполнение данных из текстового поля
				string userData = UserDataTextBox.Text;
				paragraph.Append(userData).Font("Times New Roman").FontSize(12);

				// Сохранение документа
				doc.Save();
			}

			MessageBox.Show("DOCX файл успешно сгенерирован!");
		}
	}
}