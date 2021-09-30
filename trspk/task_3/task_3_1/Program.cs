using System;

namespace task_3_1
{
	class Program
	{
		static void Main(string[] args)
		{
			int a, b, up, down;
			a = Convert.ToInt32(Console.ReadLine()); // кол-во измерений (cтолбцов)
			b = Convert.ToInt32(Console.ReadLine()); // кол-во измерений (строк)
			Console.WriteLine("Введите нижнюю границу: ");
			down = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите верхнюю границу: ");
			up = Convert.ToInt32(Console.ReadLine());
			
			if (down > up)
			{
				Console.WriteLine("Нижняя граница больше верхней ");
				int temp = 0;
				temp = down;
				down = up;
				up = temp;
			}

			int[,] myArr = new int[a, b];
			Random random = new Random();

			for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
					myArr[i, j] = random.Next(down, up);
                }
            }

			Console.WriteLine("Кол-во столбцов: " + a);
			Console.WriteLine("Кол-во строк: " + b);
			Console.WriteLine("Нижняя граница: " + down);
			Console.WriteLine("Верхняя граница: " + up);


            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
					Console.Write(myArr[i, j] + "\t") ;
                }
				Console.WriteLine();
            }
		}
	}
}
