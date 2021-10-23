using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
	class ReadBD
	{

		public static List<string[]> ClientList()
		{
			var cList = new List<string[]>();
			var sw = new StreamReader("clients.txt");
			
			string str;
			string[] strArr = new string[5];

			int i = 0;
			while ((str = sw.ReadLine()) != null)
			{
				if (str == "")
				{
					cList.Add(strArr);
					strArr = new string[5];
					i = 0;
					continue;
				}
				strArr[i] = str;
				i++;
			}
			cList.Add(strArr);
			sw.Close();

			return cList;
		}

		public static List<string[]> ProductList()
		{
			var pList = new List<string[]>();
			var sw = new StreamReader("product.txt");

			string str;
			string[] strArr = new string[6];

			int i = 0;
			while ((str = sw.ReadLine()) != null)
			{
				if (str == "")
				{
					pList.Add(strArr);
					strArr = new string[6];
					i = 0;
					continue;
				}
				strArr[i] = str;
				i++;
			}
			pList.Add(strArr);
			sw.Close();

			return pList;
		}
	}
}



