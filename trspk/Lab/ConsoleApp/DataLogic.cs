using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
	class DataLogic
	{
		public DataLogic()
		{
			products = Product.GetProducts(DataLogic.ProductList());
			clients = Client.GetClient(DataLogic.ClientList());
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

		public static List<string[]> ClientList()
		{
			var cList = new List<string[]>();
			var sw = new StreamReader("clients.txt");
			
			string str;
			string[] strArr = new string[5];

			int i = 0;
			while ((str = sw.ReadLine()) != null)
			{
				if (str == "")
				{
					cList.Add(strArr);
					strArr = new string[5];
					i = 0;
					continue;
				}
				strArr[i] = str;
				i++;
			}
			cList.Add(strArr);
			sw.Close();

			return cList;
		}

		public static List<string[]> ProductList()
		{
			var pList = new List<string[]>();
			var sw = new StreamReader("product.txt");

			string str;
			string[] strArr = new string[6];

			int i = 0;
			while ((str = sw.ReadLine()) != null)
			{
				if (str == "")
				{
					pList.Add(strArr);
					strArr = new string[6];
					i = 0;
					continue;
				}
				strArr[i] = str;
				i++;
			}
			pList.Add(strArr);
			sw.Close();

			return pList;
		}

		public void AddClient(Client client)
		{
			//Client client = new Client();
			//string str;
			//Console.WriteLine("Введите данные клиента:\n ФИО: ");
			//str = Convert.ToString(Console.ReadLine());
			//client.FullName = str;
			//Console.WriteLine("Тип вклада: ");
			//str = Convert.ToString(Console.ReadLine());
			//client.TypeContribution = str;
			//Console.WriteLine("Сумма вклада: ");
			//str = Convert.ToString(Console.ReadLine());
			//client.Sum = double.Parse(str);
			//Console.WriteLine("Дата вклада: ");
			//str = Convert.ToString(Console.ReadLine());
			//client.Date = DateTime.Parse(str);
			//Console.WriteLine("Срок вклада: ");
			//str = Convert.ToString(Console.ReadLine());
			//client.Term = int.Parse(str);
			clients.Add(client);
			this.UpdBase();
		}
		public void UpdBase()
		{
			File.Exists("clients.txt");
			string path = "clients.txt";
			int i = 0;
			File.WriteAllText(path, String.Empty);
			foreach (var client in clients)
			{
				if (i != 0)
				{
					File.AppendAllText(path, "\n");
				}
				File.AppendAllText(path, client.FullName + '\n');
				File.AppendAllText(path, "Тип вклада = " + client.TypeContribution + '\n');
				File.AppendAllText(path, "Сумма = " + client.Sum + '\n');
				File.AppendAllText(path, "Дата = " + client.Date + '\n');
				File.AppendAllText(path, "Срок = " + client.Term + '\n');
				i++;
			}
		}

		public void ShowClients()
		{
			int k = 0;
			foreach (var client in clients)
			{
				DateTime date = client.Date;
				Console.WriteLine("Клиент №{0}:\n" +
				                  "Имя: " + client.FullName + '\n' +
				                  "Тип вклада: " + client.TypeContribution + '\n' +
				                  "Сумма вклада: " + client.Sum + '\n' +
				                  "Дата вклада: " + date.ToShortDateString() + '\n' +
				                  "Срок вклада: " + client.Term + '\n', k);
				k++;
			}
		}


	}
}



