using System;
using System.IO;

namespace task_4_5
{
	class Program
	{
		class KeyboardManager
		{
			public delegate void KeyPressed(char key);

			public event KeyPressed ThreeKeyPressed;
			public event KeyPressed FiveKeyPressed;
			public event KeyPressed DigitKeyPressed;
			public event KeyPressed AnyKeyPressed;

			public void Pressed(char key)
			{
				if (key == '3')
					ThreeKeyPressed(key);
				else if (key == '5')
					FiveKeyPressed(key);
				else if (key > 47 && key < 58)
					DigitKeyPressed(key);
				else
					AnyKeyPressed(key);
			}
		}
		class ThreeSubscriber
		{
			public void print(char key)
			{
				Console.WriteLine("Key = {0} (Three)", key);
			}
		}
		class FiveSubscriber
		{
			public void print(char key)
			{
				Console.WriteLine("Key = {0} (Five)", key);
			}
		}
		class DigitSubscriber
		{
			public void print(char key)
			{
				Console.WriteLine("Key = {0} (Digit)", key);
			}
		}
		class LogSubscriber
		{
			StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\log.txt");
			public void print(char key)
			{
				if (!File.Exists("C:\\Users\\User\\Desktop\\log.txt"))
				{
					File.Create("C:\\Users\\User\\Desktop\\log.txt");
				}
				if (key == '`' || key == 'ё')
				{
					sw.Close();
					return;
				}
				Console.WriteLine("Key = {0} (Log)", key);
				sw.Write(key);
			}
		}

		static void Main(string[] args)
		{
			KeyboardManager key = new();
			char readKey;

			ThreeSubscriber threeSubscriber = new();
			FiveSubscriber fiveSubscriber = new();
			DigitSubscriber digitSubscriber = new();
			LogSubscriber logSubscriber = new();

			key.ThreeKeyPressed += threeSubscriber.print;
			key.FiveKeyPressed += fiveSubscriber.print;
			key.DigitKeyPressed += digitSubscriber.print;
			key.AnyKeyPressed += logSubscriber.print;

			while (true)
			{
				readKey = Console.ReadKey(true).KeyChar;
				key.Pressed(readKey);
				if (readKey == '`' || readKey == 'ё')
					break;
			}
		}
	}
}
