using System;

namespace task_5_5
{
	class Program
	{
		static void Main(string[] args)
		{
			bool check = false;
			DateTime start = DateTime.Now;
			string hW1 = "Hello World!";
			string hW2 = hW1;
			for (int i = 0; i < 100000; i++)
			{
				check = hW1 == hW2;
			}
			DateTime end = DateTime.Now;
			Console.WriteLine("Time '==': {0}\n", end - start);

			start = DateTime.Now;
			hW1 = "Hello World!";
			hW2 = string.Intern(hW1);
			for (int i = 0; i < 100000; i++)
			{
				check = hW1 == hW2;
			}
			end = DateTime.Now;
			Console.WriteLine("Time 'Intern': {0}\n", end - start);
		}
	}
}
