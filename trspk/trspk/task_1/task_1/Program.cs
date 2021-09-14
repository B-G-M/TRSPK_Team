using System;

namespace task1_1
{

	class Program
	{
		static void Main(string[] args)
		{
			StringList str = new StringList();
			str.Insert("test 1");
			str.Insert("test 2");
			str.Insert("test 3");
			str.Insert("test 4");
			str.Search("test 2");
			str.Show();
			str.Update(2, "test 3#");
			Console.WriteLine("GetAt: " + str.GetAt(2)); 
			str.Delete(50);
			Console.WriteLine("GetAt: " + str.GetAt(2));
			str.Show();
		}
	}
}
 