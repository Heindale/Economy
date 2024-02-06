using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace Economy.Resources.UserControls
{
    /// <summary>
    /// Interaction logic for HintTextBox.xaml
    /// </summary>
    public partial class HintTextBox : UserControl
    {
        
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(HintTextBox));

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
       
        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public double FontSizeText
        {
            get { return textBox.FontSize; }
            set 
            { 
                textBox.FontSize = value;
                        
            }
        }

        public double FontSizeHint
        {
            get { return hintTextBlock.FontSize; }
            set
            {
                hintTextBlock.FontSize = value;
            }
        }

        public System.Windows.VerticalAlignment VerticalContentAligment
        {
            get { return textBox.VerticalContentAlignment; }
            set
            {
                textBox.VerticalContentAlignment = value;
            }
        }

        public System.Windows.TextAlignment TextAlignment
        {
            get { return textBox.TextAlignment; }
            set
            {
                textBox.TextAlignment = value;
            }
        }

        public System.Windows.TextAlignment HintAlignment
        {
            get { return hintTextBlock.TextAlignment; }
            set
            {
                hintTextBlock.TextAlignment = value;
            }
        }



        public TextWrapping TextWrapping
        {
            get { return textBox.TextWrapping; }
            set
            {
                textBox.TextWrapping = value;
                if (value == TextWrapping.Wrap) { 
                    this.Right.Visibility = Visibility.Visible;
                    this.Left.Visibility = Visibility.Visible;
                    this.Top.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Right.Visibility = Visibility.Hidden;
                    this.Left.Visibility = Visibility.Hidden;
                    this.Top.Visibility = Visibility.Hidden;
                }
        }
        }

        public HintTextBox()
        {
            InitializeComponent();
            hintTextBlock.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Hidden;
            textBox.TextChanged += TextBox_TextChanged;
        }

      

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            hintTextBlock.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}

