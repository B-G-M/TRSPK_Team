using System;
using System.IO;

namespace task_3
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] board = new int[10,10];
			int col,
				row,
				perimeter = 0;
			string line;
			bool aCounted = false;
			StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\INPUT.txt");
			line = sr.ReadLine();
			Console.WriteLine(line);
			line = sr.ReadLine();
			while (line != null)
			{
				row = line[0] - '0';
				col = line[2] - '0';
				board[row, col] = 1;
				Console.WriteLine(line);
				line = sr.ReadLine();
			}
			sr.Close();

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (board[i, j] == 1)
					{
						if (board[i - 1, j] == 0){perimeter++;}

						if (board[i + 1, j] == 0){perimeter++;}

						if (board[i, j - 1] == 0){perimeter++;}

						if (board[i, j + 1] == 0){perimeter++;}
					}

				}
				aCounted = false;
			}

			Console.WriteLine();
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Console.Write(board[i, j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine('\n' + "Периметр = " + perimeter);

			StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\OUTPUT.txt");
			sw.WriteLine(perimeter);
			sw.Close();
		}
	}
}
