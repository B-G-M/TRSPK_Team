using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_1
{
	class StringList
	{

		private string[] Str = new string[100];
		private int i = 0;

		public int Insert(string str) 
		{
			Str[i] = str;
			return i++;
		}
		public void Delete(int i)
		{
			if (Str.Length > i && Str[i] != null)
			{
				string[] newStr = new string[100];

				for (int j = 0; j < i; j++)
				{
					newStr[j] = Str[j];
				}

				for (int j = i + 1;Str[j] != null; j++)
				{
					newStr[j - 1] = Str[j];
				}
				Str = newStr;
				this.i--;
				Console.WriteLine("Delete: Строка удалена");
			}
			else
			{
				Console.WriteLine("Delete: Строки не сущетвует");
			}
			
		}
		public int Search(string str) 
		{
			for (int i = 0; Str[i] != null; i++)
			{
				if(Str[i] == str)
				{
					return i;
				}
			}
			return -1;
		}
		public void Update(int i, string str) 
		{
			if(Str.Length > i && Str[i] != null)
			{
				Str[i] = str;
			}
			else
			{
				Console.WriteLine("Update: Строки не сущетвует");
			}
		}
		public string GetAt(int i) 
		{
			if (Str.Length > i && Str[i] != null)
			{
				return Str[i];
			}
			return "Строки не сущетвует";
		}
		public void Show()
		{
			Console.WriteLine("================");
			for (int i = 0; Str[i] != null; i++)
			{
				Console.WriteLine(Str[i]);
			}
			Console.WriteLine("================");
		}
	}
}
