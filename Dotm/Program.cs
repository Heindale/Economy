using NPOI.XWPF.UserModel;

namespace Dotm
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			string path = "C:\\Users\\danil\\source\\repos\\Economy\\Dotm\\Maket.docx";

			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
			{
				XWPFDocument doc = new XWPFDocument(fs);

				ReplacePlaceholder(doc, "<Text>", "meth228");

				// Сброс указателя потока в начало, чтобы не происходило смещения
				//fs.Seek(0, SeekOrigin.Begin);
				doc.Write(fs);
			}
		}

		private static void ReplacePlaceholder(XWPFDocument document, string placeholder, string value)
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