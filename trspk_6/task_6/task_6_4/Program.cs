using System;

namespace task_6_4
{
	class Program
	{
		enum Colors { Yellow = 1, Green = 2, Red = 4, Blue = 8 };

		[Flags] 
		enum ColorsFlag 
		{ Red = 4, 
		  Green = 2,
		  Blue = 8, 
		  Yellow = 1,
		 // Orange = 5
		}
		
		static void Main(string[] args)
		{
			var str = (Colors.Yellow | Colors.Red).ToString();
			var str1 = (ColorsFlag.Yellow | ColorsFlag.Red).ToString();
            Console.WriteLine(str);
            Console.WriteLine(str1);
			ColorsFlag colors = (ColorsFlag)Enum.Parse(typeof(ColorsFlag), str1, ignoreCase: true);
            Console.WriteLine(colors);

            //Console.WriteLine((ColorsFlag)Enum.Parse(typeof(ColorsFlag), "Orange"));
           // Console.WriteLine((ColorsFlag)Enum.Parse(typeof(ColorsFlag), "Yellow,Red"));
		}
	}
}
