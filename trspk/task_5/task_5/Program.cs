using System;

namespace task_5
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите символ");
			string str1 = Console.ReadLine();
			char ch1 = Convert.ToChar(str1);
			Console.WriteLine(Char.GetUnicodeCategory(ch1));
		}
	}
}
