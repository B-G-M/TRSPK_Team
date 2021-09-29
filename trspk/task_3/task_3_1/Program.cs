using System;

namespace task_3_1
{
	class Program
	{
		static void Main(string[] args)
		{
			int a, up, down;
			a = Convert.ToInt32(Console.ReadLine()); // кол-во измерений
			up = Convert.ToInt32(Console.ReadLine());
			down = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Кол-во измерений: " + a);
			Console.WriteLine("Верхняя граница: " + up);
			Console.WriteLine("Нижняя граница: " + down);
		}
	}
}
