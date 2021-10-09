using System;

namespace task_3_1
{
	class Program
	{
		public class Array1 {
			static void Main(string[] args)
			{
				int up, down;
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
				Random random = new Random();
				int[] lengthsArray = new int[2] {1,5};
				int[] boundsArray = new int[2] {1,5};
				Array myArray = Array.CreateInstance(typeof(int), lengthsArray, boundsArray);
				for (int i = myArray.GetLowerBound(down); i <= myArray.GetUpperBound(up); i++)
				{
					for (int j = myArray.GetLowerBound(down); j <= myArray.GetUpperBound(up); j++)
					{
						


					}
				}

				Console.WriteLine("Нижняя граница: " + down);
				Console.WriteLine("Верхняя граница: " + up);	
				}
			}
	
	}
}
