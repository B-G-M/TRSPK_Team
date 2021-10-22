using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Product
	{
		private string kindC;
		public string KindContribution
		{
			get => kindC;
			set => kindC = value;
		}

		private double percent;
		public double Percent
		{
			get => percent;
			set => percent = value;
		}

		private bool term;
		public bool Term
		{
			get => term;
			set => term = value;
		}

		private int capital;
		public int Capital
		{
			get => capital;
			set => capital = value;
		}

		private bool close;
		public bool Close
		{
			get => close;
			set => close = value;
		}

		private bool prolong;
		public bool Prolong
		{
			get => prolong;
			set => prolong = value;
		}

		public static List<Product> GetProducts(List<string[]>pList)
		{
			var products = new List<Product>();
			Product product = new();
			int pos;
			foreach (var str in pList)
			{
				product.KindContribution = str[0];
				pos = str[1].IndexOf("= ");
				product.Percent = double.Parse(str[1].Substring(pos + 2));
				pos = str[2].IndexOf("= ");
				product.Term = bool.Parse(str[2].Substring(pos + 2));
				pos = str[3].IndexOf("= ");
				product.capital = int.Parse(str[3].Substring(pos + 2));
				pos = str[4].IndexOf("= ");
				product.Close = bool.Parse(str[4].Substring(pos + 2));
				pos = str[5].IndexOf("= ");
				product.Prolong = bool.Parse(str[5].Substring(pos + 2));

				products.Add(product);
				product = new();
			}
			
			return products;
		}
	}
}
