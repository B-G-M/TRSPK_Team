using System;
using System.Threading;
using System.Globalization;

namespace task_5_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture =
				CultureInfo.CreateSpecificCulture("ru-RU");
			Console.WriteLine("DATE: " + DateTime.Now);
			Console.WriteLine("-5 - INT\t" + int.Parse("-5"));
			Console.WriteLine("2,5 - DOUBLE\t" + double.Parse("2,5") + '\n');

			Thread.CurrentThread.CurrentCulture =
				CultureInfo.CreateSpecificCulture("tr-TR");
			Console.WriteLine("DATE: " + DateTime.Now);
			Console.WriteLine("-5 - INT\t" + int.Parse("-5"));
			Console.WriteLine("2,5 - DOUBLE\t" + double.Parse("2,5") + '\n');

			Thread.CurrentThread.CurrentCulture =
				CultureInfo.CreateSpecificCulture("eu-ES");
			Console.WriteLine("DATE: " + DateTime.Now);
			Console.WriteLine("5 - INT\t" + int.Parse("−5"));
			Console.WriteLine("2.5 - DOUBLE\t" + double.Parse("2.5") + '\n');

			Thread.CurrentThread.CurrentCulture =
				CultureInfo.CreateSpecificCulture("ti-ET");
			Console.WriteLine("DATE: " + DateTime.Now);
			Console.WriteLine("-5 - INT\t" + int.Parse("-5"));
			Console.WriteLine("2.5 - DOUBLE\t" + double.Parse("2.5") + '\n');
		}
	}
}
