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

		double NeedToPay()
		{
			double needPay = 0;

			foreach (var client in clients)
			{
				foreach (var product in products)
				{
					if (product.KindContribution == client.TypeContribution)
					{

					}
				}
				client.TypeContribution
			}
			return needPay;
		}
	}
}
