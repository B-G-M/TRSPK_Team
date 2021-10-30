using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	public class Client
	{

		private string fName;
		public string FullName
		{
			get => fName;
			set => fName = value;
		}

		private string typeC;
		public string TypeContribution
		{
			get => typeC;
			set => typeC = value;
		}

		private double sum;
		public double Sum
		{
			get => sum;
			set => sum = value;
		}

		private DateTime date;
		public DateTime Date
		{
			get => date;
			set => date = value;
		}

		private int term;
		public int Term
		{
			get => term;
			set => term = value;
		}

		public static List<Client> GetClient(List<string[]> cList)
		{
			var clients = new List<Client>();
			Client client = new();
			int pos;
			foreach (var str in cList)
			{
				client.FullName = str[0];
				pos = str[1].IndexOf("= ");
				client.typeC = str[1].Substring(pos + 2);
				pos = str[2].IndexOf("= ");
				client.Sum = double.Parse(str[2].Substring(pos + 2));
				pos = str[3].IndexOf("= ");
				client.Date = DateTime.Parse(str[3].Substring(pos + 2));
				pos = str[4].IndexOf("= ");
				client.Term = int.Parse(str[4].Substring(pos + 2));

				clients.Add(client);
				client = new();
			}

			return clients;
		}
	}
}
