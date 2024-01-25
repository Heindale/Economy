using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economy.Resources.Models
{
	public class Table11
	{
		private int sum;

		public byte NecessaryFinancing { get; set; }
		public byte PersonalInterest { get; set; }
		public int NumberOfInternetRequests { get; set; }
		public byte DemandForTheProduct { get; set; }
		public int Sum { get => sum; set => sum = NecessaryFinancing + PersonalInterest + DemandForTheProduct; }
	}
}