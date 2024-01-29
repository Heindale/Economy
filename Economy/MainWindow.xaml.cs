using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Economy.Resources.Pages;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Serialization;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Economy
{

    [Serializable]
    public class TextBoxData
    {
        public string TextBoxName { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<TextBoxData> textBoxDataList = new List<TextBoxData>();
        public int MyProperty { get; set; }
        public DocX document { get; set; }
        public Chapter1 page1 { get; set; }
        public Chapter2 page2 { get; set; }
        public Chapter3 page3 { get; set; }
        public Chapter4 page4 { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.page1 = new Chapter1();
            this.page2 = new Chapter2();
            this.page3 = new Chapter3();
            this.page4 = new Chapter4();
            this.document = DocX.Load("TemplateVersionSecond.docx");
        }
        private void SetText(DependencyObject xamlpage)
        {
            foreach (var textBox in FindVisualChildren<TextBox>(xamlpage))
            {
                ReplacePlaceholder(document, $"<{textBox.Name}>", textBox.Text);
            }
            foreach (var comboBox in FindVisualChildren<ComboBox>(xamlpage))
            {
                ReplacePlaceholder(document, $"<{comboBox.Name}>", comboBox.Text);
            }

        }
        private void SavePage(DependencyObject xamlpage)
        {
            foreach (var textBox in FindVisualChildren<TextBox>(xamlpage))
            {
                var textBoxData = new TextBoxData
                {
                    TextBoxName = textBox.Name,
                    Text = textBox.Text,
                    Type = textBox.GetType().Name
                };
                textBoxDataList.Add(textBoxData);
            }
            foreach (var textBox in FindVisualChildren<ComboBox>(xamlpage))
            {
                var textBoxData = new TextBoxData
                {
                    TextBoxName = textBox.Name,
                    Text = textBox.Text,
                    Type = textBox.GetType().Name
                };
                textBoxDataList.Add(textBoxData);
            }
        }
        private void SaveFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TextBoxData>));

            // Сериализуйте коллекцию и сохраните в файл
            using (TextWriter writer = new StreamWriter("textBoxDataList.xml"))
            {
                serializer.Serialize(writer, textBoxDataList);
            }
        }
        private void LoadDataOfPage(Grid xamlpage, byte t)
        {
            // Проверка наличия файла
            if (File.Exists("textBoxDataList.xml"))
            {
                // Создайте сериализатор XML
                XmlSerializer serializer = new XmlSerializer(typeof(List<TextBoxData>));

                // Десериализуйте коллекцию из файла
                using (TextReader reader = new StreamReader("textBoxDataList.xml"))
                {
                    textBoxDataList = ((List<TextBoxData>)serializer.Deserialize(reader));
                }
                var filteredList = textBoxDataList.Where(data => data.TextBoxName.Contains($"T{t}")).ToList();
                // Проход по коллекции и установка текста в соответствующие TextBox
                foreach (var textBoxData in filteredList)
                {
                    if (textBoxData.Type == typeof(TextBox).Name)
                    {
                        TextBox textBox = (TextBox)xamlpage.FindName(textBoxData.TextBoxName);

                        if (textBox != null)
                        {
                            textBox.Text = textBoxData.Text;
                        }
                    }
                    else
                    {

                        ComboBox textBox = (ComboBox)xamlpage.FindName(textBoxData.TextBoxName);

                        if (textBox != null)
                        {
                            textBox.Text = textBoxData.Text;
                        }

                    }
                }
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

                if (folderBrowser.ShowDialog() == true)
                {
                    path = folderBrowser.FolderName;
                }
                this.document.SaveAs($"{path}\\Документ");

                MessageBox.Show("DOCX файл успешно сгенерирован!");
            }

            private void ChangePage1()
            {
                SetText(page1.Page1);
            }

            private void ChangePage2()
            {
                SetText(page2.Page2);
            }

            private void ChangePage3()
            {
                SetText(page3.Page3);
            }

            private void ChangePage4()
            {

            }
            private void SaveAllPage()
            {
                textBoxDataList.Clear();
                File.Delete("textBoxDataList.xml");
                SavePage(page1.Page1);
                SavePage(page2.Page2);
                SavePage(page3.Page3);
                SavePage(page4.Page4);
                SaveFile();
                MessageBox.Show("Файл успешно сохранен!");
            }
            private void LoadDataAllPage()
            {
                LoadDataOfPage(page1.Page1, 1);
                LoadDataOfPage(page2.Page2, 2);
                LoadDataOfPage(page3.Page3, 3);
                LoadDataOfPage(page4.Page4, 4);
            }
            private void Chapter1_Click(object sender, RoutedEventArgs e)
            {
                CurrentPage.Navigate(this.page1);
            }
            private void Chapter2_Click(object sender, RoutedEventArgs e)
            {
                CurrentPage.Navigate(this.page2);
            }
            private void Chapter3_Click(object sender, RoutedEventArgs e)
            {
                CurrentPage.Navigate(this.page3);
            }
            private void Chapter4_Click(object sender, RoutedEventArgs e)
            {
                CurrentPage.Navigate(this.page4);
            }
            private void Save_Click(object sender, RoutedEventArgs e)
            {
                SaveAllPage();
            }
            private void Load_Click(object sender, RoutedEventArgs e)
            {
                LoadDataAllPage();
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