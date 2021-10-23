using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{


	class Logic
	{
		public Logic()
		{
			products = Product.GetProducts(ReadBD.ProductList());
			clients = Client.GetClient(ReadBD.ClientList());
		}

		private List<Product> products;

		public List<Product> Products
		{
			get => products;
		}

		private List<Client> clients;

		public List<Client> Clients
		{
			get => clients;
		}

		public double NeedToPay(DateTime date)
		{
			double needPay = 0;

			foreach (var client in clients)
			{
				foreach (var product in products)
				{
					if (client.Date.AddMonths(client.Term) < date)
					{
						continue;
					}
					if (product.KindContribution == client.TypeContribution || product.Capital == 0)
					{
						needPay += client.Sum * product.Percent / 100 / 12;
						break;
					}
				}
			}
			return needPay;
		}

		public double[] VolumeOfDeposits()
		{
			int count = 0;
			double[] apm = new double[12];
			int[] countDep = new int[12];
			for (int i = 0; i < 12; i++)
			{
				foreach (var client in clients)
				{
					if (client.Date.Month == i+1)
					{
						apm[i] += client.Sum;
						countDep[i]++;
					}

				}
			}

			for (int i = 0; i < 12; i++)
			{
				apm[i] /= countDep[i];
			}
			
			return apm;
		}

		public List<double> ProductsProfit()
		{
			List<double> profit = new();
			double temp;
			foreach (var client in clients)
			{
				foreach (var product in products)
				{
					if (product.KindContribution == client.TypeContribution)
					{
						if (product.Capital == 0)
						{
							profit.Add(client.Sum + 
							           (client.Sum * product.Percent / 12 * client.Term));
							continue;
						}
						profit.Add(client.Sum * Math.Pow((1 + product.Percent 
							* client.Term * 30 / 365 / 100), client.Term/ (12/product.Capital)));

					}
				}
			}
			return profit;
		}

		public void AddClient()
		{
			Client client = new Client();
			string str;
			Console.WriteLine("Введите данные клиента:\n ФИО: ");
			str =Convert.ToString(Console.Read());
			client.FullName = str;
			Console.WriteLine("Тип вклада: ");
			str = Convert.ToString(Console.Read());
			client.TypeContribution = str;
			Console.WriteLine("Сумма вклада: ");
			str = Convert.ToString(Console.Read());
			client.Sum = double.Parse(str);
			Console.WriteLine("Дата вклада: ");
			client.Date = DateTime.Parse(str);
			Console.WriteLine("Срок вклада: ");
			client.Term = int.Parse(str);
			
			clients.Add(client);
		}

		public void UpdBase()
		{
			File.Exists("clients.txt");
			string path = "clients.txt";
			bool boo = false;
			File.WriteAllText(path,String.Empty);
			foreach (var client in clients)
			{
				File.AppendAllText(path, client.FullName +'\n');
				File.AppendAllText(path, "Тип вклада = " + client.TypeContribution+'\n');
				File.AppendAllText(path, "Сумма = " + client.Sum+'\n');
				File.AppendAllText(path, "Дата = " + client.Date+'\n');
				File.AppendAllText(path, "Срок = " + client.Term+'\n');
				File.AppendAllText(path, "\n");
			}
		}
	}
}
