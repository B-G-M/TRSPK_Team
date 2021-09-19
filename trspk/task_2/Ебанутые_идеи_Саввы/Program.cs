using System;

namespace task2_2
{
	class LongNumber
	{
		public LongNumber()
		{
		}
		public LongNumber(LongNumber longNumber)
		{
			this.number = longNumber.number;
		}

		private string number;

		public string Number
		{
			get { return number; }
			set { number = value; }
		}

		public static LongNumber operator +(LongNumber number1, LongNumber number2)
		{
			//Реализовать сложение отрицательного с положительным !!!

			LongNumber sum = new();
			int temp1 = 0,
				temp2 = 0,
				num1_lenght = number1.number.Length,
				num2_lenght = number2.number.Length;

			if (num1_lenght > num2_lenght)
			{
				sum.number = number1.number;
				number1.number = number2.number;
				number2.number = sum.number;
				sum.number = "";
			}

			for (; num1_lenght > 0; num1_lenght--, num2_lenght--)// пизда+говно+моча (1 символ проебали мейби)
			{
				temp1 += Convert.ToInt32(number1.number[num1_lenght]);
				temp2 += Convert.ToInt32(number2.number[num2_lenght]);

				if (temp1 + temp2 < 9)
				{
					sum.number = sum.number.Insert(0, Convert.ToString(temp1 + temp2));
					continue;
				}
				temp1 += temp2;
				temp1 %= 10;
				temp2 = 1;
				sum.number = sum.number.Insert(0, Convert.ToString(temp1));
				temp1 = 0;
			}

			for (; 0 < num2_lenght; num2_lenght--)
			{
				temp2 += Convert.ToInt32(number2.number[num2_lenght]);
				sum.number = sum.number.Insert(0, Convert.ToString(temp2));
			}

			if (number1.number[0] == '-' && number2.number[0] == '-')
			{
				sum.number = sum.number.Insert(0, Convert.ToString('-'));
			}
			return sum;
		}
		public static LongNumber operator -(LongNumber number1, LongNumber number2)
		{
			LongNumber sum = new();
			int temp1 = 0,
				temp2 = 0,
				num1_lenght = number1.number.Length,
				num2_lenght = number2.number.Length,
				i = num1_lenght < num2_lenght ? num1_lenght : num2_lenght;

			for (; i > 0; i--)
			{
				temp1 = Convert.ToInt32(number1.number[num1_lenght]);
				temp2 = Convert.ToInt32(number2.number[num2_lenght]);

				if (temp1 - temp2 > 0)
				{
					sum.number = sum.number.Insert(0, Convert.ToString(temp1 - temp2));
					num1_lenght--;
					num2_lenght--;
					continue;
				}
				Give_ten(ref number1, i);
				temp1 += 10;
				temp1 -= temp2;
				sum.number = sum.number.Insert(0, Convert.ToString(temp1));

				num1_lenght--;
				num2_lenght--;
			}
			return sum;
		}
		public static bool operator <(LongNumber number1, LongNumber number2)
		{
			bool da = true;
			int temp1,
				temp2;

			if (number1.number.Length < number2.number.Length)
			{
				da = false;
				return da;
			}
			else if (number1.number.Length > number2.number.Length)
			{
				return da;
			}
			for (int i = 0; i < number1.number.Length; i++)
			{
				temp1 = Convert.ToInt32(number1.number[i]);
				temp2 = Convert.ToInt32(number2.number[i]);

				if (temp1 < temp2)
				{
					da = false;
					return da;
				}
			}
			return da;
		}
		public static bool operator >(LongNumber number1, LongNumber number2)
		{
			bool da = true;


			return da;
		}
		private static void Give_ten(ref LongNumber number, int i)
		{
			char[] arr = number.number.ToCharArray();
			int k = i - 1,
				temp;
			while (true)
			{
				if (arr[k] != '0')
				{
					temp = Convert.ToInt32(arr[k]);
					temp--;
					arr[k] = Convert.ToChar(temp);
					k++;
					break;
				}
				k--;
			}
			while (k != i - 1)//возможно нужны скобки
			{
				temp = 9;
				arr[k] = Convert.ToChar(temp);
				k++;
			}
			number.number = Convert.ToString(arr);
		}

	}


	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
