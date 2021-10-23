using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Logic logic = new Logic();
			int num = -1;
			while (num != 0)
			{
				Console.WriteLine("\n Меню:");
				Console.WriteLine("0. Выход из программы.");
				Console.WriteLine("1. Обновить данные из БД.");
				Console.WriteLine("2. Подсчитать сумму денег, необходимую банку для выплаты по срочным вкладам в указанный месяц");
				Console.WriteLine("3. Подсчитать объемы вкладов в среднем помесячно");
				Console.WriteLine("4. Подсчитать доходность каждого продукта с учетом капитализации");
				Console.WriteLine("5. Показать всю БД клиентов.");
				Console.WriteLine("6. Показать информацию о клиенте.");
				Console.WriteLine("7. Добавить клиента. ");
				Console.WriteLine("8. Обновить БД.");
				num = int.Parse(Console.ReadLine());
				Console.Clear();
				switch (num)
				{
					case 1:
						logic = new();
						continue;
					
					case 2:
						Console.Write("Введите нужную дату в формате дд.мм.гггг: ");
						DateTime date = DateTime.Parse(Console.ReadLine());
						Console.Write("Нужно заплатить: ");
						Console.WriteLine(logic.NeedToPay(date));
						continue;
					
					case 3:
						double[] volume = logic.VolumeOfDeposits();
						for (int i = 0; i < 12; i++)
						{
							Console.WriteLine("{0}: {1} ",
								CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i+1),volume[i]);
						}
						continue;

					case 4:
						List<double> profit = logic.ProductsProfit();
						string str;
						for (int i = 0; i < profit.Count; i++)
						{
							Console.WriteLine("Клиент №"+ i + ": " + profit[i]);
						}
						continue;

					case 5:
						int k = 0;
						foreach (var client in logic.Clients)
						{
							Console.WriteLine("Клиент №{0}:\n" +
							                  "Имя: " + client.FullName + '\n' +
											  "Тип вклада: " + client.TypeContribution + '\n' +
							                  "Сумма вклада: " + client.Sum + '\n' +
											  "Дата вклада: " + client.Date + '\n' +
											  "Срок вклада: " + client.Term +'\n', k);
							k++;
						}
						continue;

					case 6:
						k = 0;
						Console.Write("Введите номер клиента: ");
						int number;
						number = int.Parse(Console.ReadLine());
						foreach (var client in logic.Clients)
						{
							if (k == number)
							{
								Console.WriteLine("Клиент №{0}:\n" +
								                  "Имя: " + client.FullName + '\n' +
												  "Тип вклада: " + client.TypeContribution + '\n' +
								                  "Сумма вклада: " + client.Sum + '\n' +
								                  "Дата вклада: " + client.Date + '\n' +
								                  "Срок вклада: " + client.Term + '\n', k);
								break;
							}
							k++;
						}
						continue;

					case 7: 
						logic.AddClient();
						continue;
					case 8:
						logic.UpdBase();
						continue;
					default:
						continue;


				}

			}
		}
	}
}
