using System;


namespace task1_3
{
	class Program
	{
		static void Main(string[] args)
		{
			Node test = new Node();
			test.Create_Tree(test);
			Console.WriteLine(test.Сreate_string (test)); 
		}
	}
}
