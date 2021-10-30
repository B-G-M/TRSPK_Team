using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	public class BusinessLogic
	{
		public BusinessLogic()
		{
			products = dataLogic.Products;
			clients = dataLogic.Clients;
		}

		private DataLogic dataLogic = new DataLogic();

		private List<Product> products;
		public List<Product> Products
		{
			get => products;
		}

		private List<Client> clients;
		public List<Client> Clients
		{
			get => clients;
			set
			{
				clients = value;
			}
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

		public void AddClient(Client client)
		{
			dataLogic.AddClient(client);
		}

		public void ShowClients()
		{
			dataLogic.ShowClients();
		}
	}
}
