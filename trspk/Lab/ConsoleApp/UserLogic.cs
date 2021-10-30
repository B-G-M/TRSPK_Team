using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp
{
	public class UserLogic
	{
		static void Main(string[] args)
		{
			BusinessLogic logic = new BusinessLogic();
			int num = -1;
			while (num != 0)
			{
				Console.WriteLine("\n Меню:");
				Console.WriteLine("0. Выход из программы.");
				Console.WriteLine("1. Подсчитать сумму денег, необходимую банку для выплаты по срочным вкладам в указанный месяц");
				Console.WriteLine("2. Подсчитать объемы вкладов в среднем помесячно");
				Console.WriteLine("3. Подсчитать доходность каждого продукта с учетом капитализации");
				Console.WriteLine("4. Показать всю БД клиентов.");
				Console.WriteLine("5. Показать информацию о клиенте.");
				Console.WriteLine("6. Добавить клиента. ");
				num = int.Parse(Console.ReadLine());
				Console.Clear();
				switch (num)
				{
					case 1:
						Console.Write("Введите нужную дату в формате дд.мм.гггг: ");
						DateTime date = DateTime.Parse(Console.ReadLine());
						Console.Write("Нужно заплатить: ");
						Console.WriteLine(logic.NeedToPay(date));
						continue;
					
					case 2:
						double[] volume = logic.VolumeOfDeposits();
						for (int i = 0; i < 12; i++)
						{
							if (!double.IsNaN(volume[i]))
							{

								Console.WriteLine("{0}: {1} ",
								CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1), volume[i]);
								continue;
								
							}
							Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1)
												+ ": нет выплат в данном месяце \n");
						}
						continue;

					case 3:
						List<double> profit = logic.ProductsProfit();
						string str;
						for (int i = 0; i < profit.Count; i++)
						{
							Console.WriteLine("Клиент №"+ i + ": " + profit[i]);
						}
						continue;

					case 4:
						logic.ShowClients();
						continue;

					case 5:
						
						int k = 0;
						Console.Write("Введите номер клиента: ");
						int number;
						number = int.Parse(Console.ReadLine());
						foreach (var client in logic.Clients)
						{
							if (k == number)
							{
								Console.WriteLine("Клиент №{0}:\n" +
								                  "Фио: " + client.FullName + '\n' +
												  "Тип вклада: " + client.TypeContribution + '\n' +
								                  "Сумма вклада: " + client.Sum + '\n' +
								                  "Дата вклада: " + client.Date + '\n' +
								                  "Срок вклада: " + client.Term + '\n', k);
								break;
							}
							k++;
						}
						continue;

					case 6:
					{
						Client client = new Client();

						Console.WriteLine("Введите данные клиента:\n ФИО: ");
						str = Convert.ToString(Console.ReadLine());
						client.FullName = str;
						Console.WriteLine("Тип вклада: ");
						str = Convert.ToString(Console.ReadLine());
						client.TypeContribution = str;
						Console.WriteLine("Сумма вклада: ");
						str = Convert.ToString(Console.ReadLine());
						client.Sum = double.Parse(str);
						Console.WriteLine("Дата вклада: ");
						str = Convert.ToString(Console.ReadLine());
						client.Date = DateTime.Parse(str);
						Console.WriteLine("Срок вклада: ");
						str = Convert.ToString(Console.ReadLine());
						client.Term = int.Parse(str);

						logic.AddClient(client);
						continue;
					}
					default:
						continue;


				}

			}
		}
	}
}
