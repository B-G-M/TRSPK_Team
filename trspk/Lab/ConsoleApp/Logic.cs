using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{


	class Logic
	{
		List<Product> products = Product.GetProducts(ReadBD.ProductList());
		List<Client> clients = Client.GetClient(ReadBD.ClientList());

		double NeedToPay(DateTime date)
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

		double[] VolumeOfDeposits()
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

		List<double> ProductsProfit()
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
							* client.Term * 30 / 365 / 100), product.Capital));

					}
				}
			}

			return profit;
		}

	}
}
