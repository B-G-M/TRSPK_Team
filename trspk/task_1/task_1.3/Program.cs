using System;


namespace task1_3
{
	class Program
	{
		static void Main(string[] args)
		{
			Node test = new Node();
			test.create_Tree(test);
			Console.WriteLine("j= " + Node.j);
			Console.WriteLine(test.print_Tree(test)); 
		}
	}
}
