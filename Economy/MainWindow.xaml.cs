﻿using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static System.Net.Mime.MediaTypeNames;

namespace Economy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
    public class MyObject //better to choose an appropriate name
    {
        string id;
        DateTime date;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    /*public ObservableCollection<MyObject> MyList
	{

	}*/
    public partial class MainWindow : Window
	{
		private readonly ViewModel viewModel;
		public MainWindow()
		{
			InitializeComponent();
			/*Binding binding = new Binding();
			binding.ElementName = "myTextBox";
			binding.Path = new PropertyPath("ModelName");
			Table.SetBinding(UidProperty, binding);*/
			this.viewModel = new ViewModel
			{
				DataGridItems = new List<DataGridItems>()
				{
					new DataGridItems
					{
						Name = "dwqd",
						Value = "1"
					},
                    new DataGridItems
                    {
                        Name = "gg",
                        Value = "3"
                    }
                }
			};
			this.DataContext = this.viewModel;
			/*myTextBox.SetBinding(, binding);*/
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

            //using (var document = DocX.Load("D:\\Projects\\Economy\\Economy\\bin\\Debug\\net8.0-windows\\GeneratedDocument.docx"))
            //{
            //    Paragraph paragraph = document.InsertParagraph();
            //    string userData = "Это гг";
            //    paragraph.Append(userData).Font("Arial").FontSize(12).Bold();
            //    ReplacePlaceholder(document, "<FirstName>", "John");
            //    ReplacePlaceholder(document, "<LastName>", "Doe");
            //    ReplacePlaceholder(document, "<DateOfBirth>", "01/01/1990");
            //    document.SaveAs("NewCopy.docx");
            //}

            // Создание нового документа
            using (DocX doc = DocX.Create("GeneratedDocument.docx"))
			{
				// Добавление параграфа в документ
				Paragraph paragraph = doc.InsertParagraph();
				Table table = doc.AddTable(Table.Items.Count, Table.Columns.Count);
				table.Design = TableDesign.TableGrid;
                for (int i = 0; i < Table.Items.Count-1; i++)
				{
                    MessageBox.Show(Convert.ToString(this.viewModel.DataGridItems.ToArray()[i].Name));
                    MessageBox.Show(Convert.ToString(this.viewModel.DataGridItems.ToArray()[i].Value));
                    table.Rows[i].Cells[0].Paragraphs[0].Append(Convert.ToString(this.viewModel.DataGridItems.ToArray()[i].Name));
                    table.Rows[i].Cells[1].Paragraphs[0].Append(Convert.ToString(this.viewModel.DataGridItems.ToArray()[i].Value));
                    /*for (int j = 0; j < Table.Columns.Count; j++)
					{
                        *//*DataGridItems dataGridItems = Table.SelectedValue as DataGridItems;*/
                    /*table.Rows[i].Cells[j] = */
                    /*DataGridItems dataGridItems = Table.SelectedCells as DataGridItems;

                    var dataGridCellInfo = new DataGridCellInfo(Table.Items[i], Table.Columns[j]);*/
                    /*MessageBox.Show(Convert.ToString(Table.Columns[j].GetCellContent(Table.Items[i])));*//*

                }*/
                }
				/*foreach (DataGridCellInfo cellinfo in Table.SelectedCells)
                {
					MessageBox.Show(Convert.ToString(cellinfo.Column.GetCellContent(cellinfo.Item))); 
                }*/
				/*table = Table.DataContext;*/
				// Заполнение данных из текстового поля
				string userData = UserDataTextBox.Text;
				paragraph.Append(userData).Font("Arial").FontSize(12).Bold();
                doc.InsertParagraph().InsertTableAfterSelf(table);
                // Сохранение документа
                doc.Save();
			}

			MessageBox.Show("DOCX файл успешно сгенерирован!");
		}
        private static void ReplacePlaceholder(DocX document, string placeholder, string value)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                if (paragraph.Text.Contains(placeholder))
                {
                    paragraph.ReplaceText(placeholder, value);
                }
            }
        }
    }
}