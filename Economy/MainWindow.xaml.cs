using Economy.Resources.Pages;
using Economy.Resources.Windows;
using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;
using Xceed.Words.NET;

namespace Economy
{
    public partial class MainWindow : Window
    {
        private List<TextBoxData> textBoxDataList = new List<TextBoxData>();
        private List<TextBoxDataWord> textBoxDataListWord = new List<TextBoxDataWord>();

        public MainWindow()
        {
            InitializeComponent();
            this.devInfo = new DevInfo();   
            this.title = new Title(this);
            this.page1 = new Chapter1();
            this.page2 = new Chapter2();
            this.page3 = new Chapter3();
            this.page4 = new Chapter4();
            this.page5 = new Chapter5();

        }

        public DocX document { get; set; }
        public int MyProperty { get; set; }
        public DevInfo devInfo { get; set; }
        public Title title { get; set; }
        public Chapter1 page1 { get; set; }
        public Chapter2 page2 { get; set; }
        public Chapter3 page3 { get; set; }
        public Chapter4 page4 { get; set; }
        public Chapter5 page5 { get; set; }
        public string LastLoadFile;

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

        private void ReplacePlaceholderVersionSecond(DocX document, List<TextBoxDataWord> textBoxDataListWords)
        {
            int i = 0;
            foreach (var paragraph in document.Paragraphs)
            {
                if (textBoxDataListWords.Count > i) 
                { 
                    if (paragraph.Text.Contains($"<{textBoxDataListWords[i].placeholder}>"))
                    {
                        paragraph.ReplaceText($"<{textBoxDataListWords[i].placeholder}>", textBoxDataListWords[i].value);
                        i++;
                    }
                }
            }
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
            SetText(page4.Page4);
        }
        private void ChangePage5()
        {
            SetText(page5.Page5);
        }
        public void Title_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.title);
            UnsetButtonMarks();
            SetButtonMark(Title);
            
        }

        public void Chapter1_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.page1);
            UnsetButtonMarks();
            SetButtonMark(Chapter1);
        }

        public void Chapter2_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.page2);
            UnsetButtonMarks();
            SetButtonMark(Chapter2);
        }

        public void Chapter3_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.page3);
            UnsetButtonMarks();
            SetButtonMark(Chapter3);
        }

        public void Chapter4_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.page4);
            UnsetButtonMarks();
            SetButtonMark(Chapter4);
        }
        public void Chapter5_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.page5);
            UnsetButtonMarks();
            SetButtonMark(Chapter5);
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void FindVisualChildrenVersionSecond(DependencyObject depObj)
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    var textboxdatawords = new TextBoxDataWord();
                    if (child != null && child is TextBox)
                    {
                        TextBox textBox = (TextBox)child;
                        if (textBox.Name != "") { 
                            textboxdatawords.placeholder = textBox.Name;
                            textboxdatawords.value = textBox.Text;
                            textBoxDataListWord.Add(textboxdatawords);
                        }
                    } else if (child != null && child is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)child;
                        if (comboBox.Name != "")
                        {
                            textboxdatawords.placeholder = comboBox.Name;
                            textboxdatawords.value = comboBox.Text;
                            textBoxDataListWord.Add(textboxdatawords);
                        }
                    }
                    if (VisualTreeHelper.GetChildrenCount(child) != 0 && (child is Grid || child is StackPanel || child is Border)) 
                    { 
                        FindVisualChildrenVersionSecond(child);
                    }
                }
            }
        }

        private async void GenerateDocxButton_Click(object sender, RoutedEventArgs e)
        {
            this.document = DocX.Load("TemplateVersionSecond.docx");
            SaveFileDialog folderBrowser = new SaveFileDialog();
            folderBrowser.Filter = "Word documents (*.docx)|*.docx";
            if (folderBrowser.ShowDialog() == true)
            {
                textBoxDataListWord.Clear();
                ChangePage1();
                ChangePage2();
                ChangePage3();
                ChangePage4();
                ChangePage5();
                ReplacePlaceholderVersionSecond(document, textBoxDataListWord);
                try
                {
                    this.document.SaveAs(folderBrowser.FileName);
                    MessageBox.Show("DOCX файл успешно сгенерирован!");
                }
                catch
                {
                    MessageBox.Show("Возможно у вас открыт документ. Проверьте ни открыт ли у вас сохраняемый документ и закройте его.");
                }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.Filter = "XML files (*.xml)|*.xml";
            if (folderBrowser.ShowDialog() == true)
            {
                LastLoadFile = folderBrowser.FileName;
                LoadDataAllPage();
            }
        }

        private void LoadDataAllPage()
        {
            LoadDataOfPage(page1.Page1, 1);
            LoadDataOfPage(page2.Page2, 2);
            LoadDataOfPage(page3.Page3, 3);
            LoadDataOfPage(page4.Page4, 4);
            LoadDataOfPage(page5.Page5, 5);
        }

        private void LoadDataOfPage(Grid xamlpage, byte t)
        {

            // Создайте сериализатор XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<TextBoxData>));

            // Десериализуйте коллекцию из файла
            using (TextReader reader = new StreamReader(LastLoadFile))
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

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                //MaxButImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/max.png"));
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                //MaxButImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/win.png"));
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveAllPage();
        }

        private void SaveAllPage()
        {
            SaveFileDialog folderBrowser = new SaveFileDialog();
            folderBrowser.Filter = "XML files (*.xml)|*.xml";
            if (folderBrowser.ShowDialog() == true)
            {
                string path = folderBrowser.FileName;
                textBoxDataList.Clear();
                SavePage(page1.Page1);
                SavePage(page2.Page2);
                SavePage(page3.Page3);
                SavePage(page4.Page4);
                SavePage(page5.Page5);
                SaveFile(path);
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        private void SaveFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TextBoxData>));

            // Сериализуйте коллекцию и сохраните в файл
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, textBoxDataList);
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

        private void SetText(DependencyObject xamlpage)
        {
            FindVisualChildrenVersionSecond(xamlpage);
            //foreach (var textBox in FindVisualChildren<TextBox>(xamlpage))
            //{
            //    ReplacePlaceholder(document, $"<{textBox.Name}>", textBox.Text);
            //}
            //foreach (var comboBox in FindVisualChildren<ComboBox>(xamlpage))
            //{
            //    ReplacePlaceholder(document, $"<{comboBox.Name}>", comboBox.Text);
            //}
        }

        private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            App.Current.MainWindow.DragMove();
        }

        private void DevInfo_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(this.devInfo);

        }

        private void UnsetButtonMarks()
        {
            Brush Brushie = new SolidColorBrush(Color.FromArgb(255, 227, 233, 255));
            Title.Background = Brushie;
            Chapter1.Background = Brushie;
            Chapter2.Background = Brushie;
            Chapter3.Background = Brushie;
            Chapter4.Background = Brushie;
            Chapter5.Background = Brushie;
        }
        private void SetButtonMark(Button button)
        {
            Brush Brushie = new SolidColorBrush(Color.FromArgb(255, 239, 218, 255));
            button.Background = Brushie;
        }
    }

    [Serializable]
    public class TextBoxData
    {
        public string Text { get; set; }
        public string TextBoxName { get; set; }
        public string Type { get; set; }
    }
    public class TextBoxDataWord
    {
        public string placeholder { get; set; }
        public string value { get; set; }
    }
}