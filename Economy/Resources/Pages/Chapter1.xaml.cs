using Economy.Resources.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Economy.Resources.Pages
{
	/// <summary>
	/// Логика взаимодействия для Chapter1.xaml
	/// </summary>
	public partial class Chapter1 : Page
	{
		public ObservableCollection<Table11> DataCollection { get; set; }

		public Chapter1()
		{
			InitializeComponent();

			DataCollection = new ObservableCollection<Table11>()
			{
				new Table11
				{
					DemandForTheProduct = 1,
					NecessaryFinancing = 1,
					NumberOfInternetRequests = 1,
					PersonalInterest = 1
				}
			};
		}
	}
}