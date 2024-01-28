using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Economy.Resources.Pages;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
		public DocX document { get; set; }
		public Chapter1 page1 { get; set; }
		public Chapter2 page2 { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			this.page1 = new Chapter1();
			this.page2 = new Chapter2();
			this.document = DocX.Load("TemplateVersionSecond.docx");
		}
        private void SetText(DependencyObject xamlpage)
        {
            foreach (var textBox in FindVisualChildren<TextBox>(xamlpage))
            {
                ReplacePlaceholder(document, $"<{textBox.Name}>", textBox.Text);
            }

        }


        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        private void GenerateDocxButton_Click(object sender, RoutedEventArgs e)
		{
            OpenFolderDialog folderBrowser = new OpenFolderDialog();
            string path = "";
            ChangePage1();
            ChangePage2();
            ChangePage3();
            ChangePage4();

            if (folderBrowser.ShowDialog() ==  true)
            {
                path = folderBrowser.FolderName;
            }
            this.document.SaveAs($"{path}\\Документ");

			MessageBox.Show("DOCX файл успешно сгенерирован!");
		}

        private void ChangePage1()
        {

        }

        private void ChangePage2()
		{
            SetText(page2.Page2);
        }

        private void ChangePage3()
        {

        }

        private void ChangePage4()
        {

        }

        private void Chapter1_Click(object sender, RoutedEventArgs e)
		{
			CurrentPage.Navigate(this.page1);
		}
        private void Chapter2_Click(object sender, RoutedEventArgs e)
		{
			CurrentPage.Navigate(this.page2);
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