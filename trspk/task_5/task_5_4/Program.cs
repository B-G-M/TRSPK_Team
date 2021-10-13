using System;
using System.Text;

namespace task_5_4
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime start = DateTime.Now;
			StringBuilder sbHello = new("Hello");
			StringBuilder sbWorld = new("World!");
			StringBuilder sbHW = new();
			sbHW.Append(sbHello);
			sbHW.Append(sbWorld);
			DateTime end = DateTime.Now;
			Console.WriteLine("\nSbHW: {0}", sbHW);
			Console.WriteLine("Time Sb: {0}\n", end - start);

			start = DateTime.Now;
			string strHello = "Hello";
			string strWorld = "World!";
			string strHW = strHello + strWorld;
			end = DateTime.Now;
			Console.WriteLine("StrHW: {0}", strHW);
			Console.WriteLine("Time Str: {0}\n", end - start);

			start = DateTime.Now;
			StringBuilder sbFor = new();
			for (int i = 0; i < 100000; i++)
			{
				sbFor.Append(i);
			}
			end = DateTime.Now;
			//Console.WriteLine("SbFor: {0}", sbFor);
			Console.WriteLine("Time SbFor: {0}\n", end - start);

			start = DateTime.Now;
			string strFor = "";
			for (int i = 0; i < 100000; i++)
			{
				strFor += i;
			}
			end = DateTime.Now;
			//Console.WriteLine("Str: {0}", strFor);
			Console.WriteLine("Time StrFor: {0}\n", end - start);
		}
	}
}
