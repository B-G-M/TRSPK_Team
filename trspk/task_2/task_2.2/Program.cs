using System;

namespace task2_2
{
	class LongNumber
	{
		public LongNumber()
		{
			number = "";
		}
		public LongNumber(int num)
		{
			number = Convert.ToString(num);
		}
		public LongNumber(LongNumber longNumber)
		{
			number = longNumber.number;
		}

		private static bool cycle = false;
		private string number;

		public string Number
		{
			get { return number; }
			set { number = value; }
		}

		public static string operator +(LongNumber number1, LongNumber number2)
		{
			LongNumber sum = new();

			if (!cycle)
			{
				cycle = true;
				if (number1.number[0] == '-' && number2.number[0] != '-')
				{
					sum.number = number1 - number2;
					sum.number = sum.number.Insert(0, Convert.ToString('-'));

					if (sum.number[0] == '-' && sum.number[1] == '-')
					{
						Two_minus_to_plus(ref sum);
					}
					return sum.number;
				}
				if (number1.number[0] != '-' && number2.number[0] == '-')
				{
					return number1 - number2;
				}
			}
			if (number1.number.Length > number2.number.Length)
			{
				Swap(ref number1, ref number2);
			}

			int temp1 = 0,
			temp2 = 0,
			num1_lenght = number1.number.Length,
			num2_lenght = number2.number.Length;

			for (; num1_lenght > 0;)
			{
				num1_lenght--;
				num2_lenght--;
				if (number1.number[num1_lenght] == '-' || number2.number[num2_lenght] == '-') { break; }

				temp1 += (number1.number[num1_lenght] - '0');
				temp2 += (number2.number[num2_lenght] - '0');

				if (temp1 + temp2 <= 9)
				{
					sum.number = sum.number.Insert(0, Convert.ToString(temp1 + temp2));
					temp1 = 0;
					temp2 = 0;
					continue;
				}
				temp1 += temp2;
				temp1 %= 10;
				temp2 = 1;
				sum.number = sum.number.Insert(0, Convert.ToString(temp1));
				temp1 = 0;
			}

			for (; 0 < num2_lenght;)
			{
				num2_lenght--;
				if (number2.number[num2_lenght] == '-') { break; }

				temp2 += (number2.number[num2_lenght] - '0');
				sum.number = sum.number.Insert(0, Convert.ToString(temp2));
			}

			if (number1.number[0] == '-' && number2.number[0] == '-')
			{
				sum.number = sum.number.Insert(0, Convert.ToString('-'));
			}
			cycle = false;
			return sum.number;
		}
		public static string operator -(LongNumber number1, LongNumber number2)
		{
			// Закоментируй код сука !!!!!!

			LongNumber sub = new();
			bool less = false;

			if (!cycle)
			{
				cycle = true;
				if (number1.number[0] == '-' && number2.number[0] != '-')
				{
					sub.number = number1 + number2;
					sub.number = sub.number.Insert(0, Convert.ToString('-'));
					return sub.number;
				}
				if (number1.number[0] != '-' && number2.number[0] == '-')
				{
					return number1 + number2;
				}
			}

			if (Mod(number1) < Mod(number2))
			{
				less = true;
				Swap(ref number1, ref number2);
			}

			int temp1,
				temp2,
				num1_lenght = number1.number.Length,
				num2_lenght = number2.number.Length,
				i = num1_lenght < num2_lenght ? num1_lenght : num2_lenght;

			for ( ;i > 0; i--)
			{
				num1_lenght--;
				num2_lenght--;
				if (number1.number[num1_lenght] == '-' || number2.number[num2_lenght] == '-') { break; }

				temp1 = (number1.number[num1_lenght] - '0');
				temp2 = (number2.number[num2_lenght] - '0');

				if ( temp1 - temp2 >= 0)
				{
					sub.number = sub.number.Insert(0, Convert.ToString(temp1 - temp2));
					continue;
				}
				Give_ten(ref number1, num1_lenght);
				temp1 += 10;
				temp1 -= temp2;
				sub.number = sub.number.Insert(0, Convert.ToString(temp1));
			}

			for (; 0 < num1_lenght;)
			{
				num1_lenght--;
				if (number1.number[num1_lenght] == '-') { break; };
				temp1 = (number1.number[num1_lenght] - '0');
				sub.number = sub.number.Insert(0, Convert.ToString(temp1));
			}

			if(less)
			{
				sub.number = sub.number.Insert(0, Convert.ToString('-'));
			}

			if (number1.number[0] == '-' && number2.number[0] == '-')
			{
				sub.number = sub.number.Insert(0, Convert.ToString('-'));
			}

			if (sub.number[0] == '-' && sub.number[1] == '-')
			{
				Two_minus_to_plus(ref sub);
			}
			cycle = false;
			return sub.number;
		}
		public static string operator *(LongNumber number1, LongNumber number2)
		{
			LongNumber mult = new();
			int lenght1 = number1.number.Length;
			int lenght2 = number2.number.Length;
			int temp1 = 0,
				temp2 = 0;
			if (number1.number[0] == '0' || number2.number[0] == '0')
			{
				mult.number = "0";
				return mult.number;
			}

			if (lenght1 > lenght2)
			{
				for (int i = number1.number.Length; i == 0; i--)
				{
					int k = i; int c = 0;
					for (int j = number2.number.Length; j == 0; j--) {
						temp1 = (number1.number[0] - '0') * (number2.number[0] - '0');
						temp1 = temp1 + c + number1.number[k];
						c = temp1 / 10;
						mult.number = temp1 % 10 + '0';
						k--;
					}
					if (c!=0) 
                    {
						mult.number = c + '0';
						k--;
                    }
				}
				return mult.number;
			}
        }
		public static string operator /(LongNumber number1, LongNumber number2)
		{
			LongNumber div = new();


			return div.number;
		}
		public static bool operator <(LongNumber number1, LongNumber number2)
		{
			bool da = true,
				positive = true;
			int i = 0,
				temp1,
				temp2;

			if (number1.number[0] == '-' && number2.number[0] != '-')
			{
				return da;
			}

			if (number2.number[0] == '-' && number1.number[0] != '-')
			{
				return !da;
			}

			if (number2.number[0] == '-' && number1.number[0] == '-')
			{
				positive = !positive;
				i++;
			}

			if (number1.number.Length < number2.number.Length)
			{
				if (positive)
				{
					return da;
				}
				return !da;
			}
			else if(number1.number.Length > number2.number.Length)
			{
				if (positive)
				{
					return !da;
				}
				return da;
			}

			for (	; i < number1.number.Length; i++)
			{
				temp1 = (number1.number[i] - '0');
				temp2 = (number2.number[i] - '0');

				if (temp1 < temp2)
				{
					if (positive)
					{
						return da;
					}
					return !da;
				}
			}
			return !da;
		}
		public static bool operator >(LongNumber number1, LongNumber number2)
		{
			return !(number1 < number2);
		}
		private static void Two_minus_to_plus(ref LongNumber number)
		{
			char[] arr = new char[number.number.Length - 2];
			for (int j = 2; j < number.number.Length; j++)
			{
				arr[j - 2] = number.number[j];
			}
			number.number = new string(arr);
			return;
		}
		private static void Give_ten(ref LongNumber number,int i)
		{
			char[] arr = number.number.ToCharArray();
			int k = i,
				temp;
			while (true)
			{
				k--;
				if (arr[k] != '0')
				{
					temp = (arr[k] - '0');
					temp--;
					arr[k] = Convert.ToChar('0' + temp);
					k++;
					break;
				}
			}
			while(k < i)
			{
				temp = 9;
				arr[k] = Convert.ToChar('0' + temp);
				k++;
			}
			number.number = new string(arr);
		}
		private static void Swap(ref LongNumber number1, ref LongNumber number2)
		{
			LongNumber temp = new();
			temp.number = number1.number;
			number1.number = number2.number;
			number2.number = temp.number;
			return;
		}
		private static LongNumber Mod (LongNumber number)
		{
			if (number.number[0] == '-')
			{
				LongNumber mod = new();
				char[] arr = new char[number.number.Length - 1];
				for (int i = 1; i < number.number.Length; i++)
				{
					arr[i - 1] = number.number[i];
				}
				mod.number = new string(arr);
				return mod;
			}
			return number;
		}


	}


	class Program
	{
		static void Main(string[] args)
		{
			int a = -2,
				b = -3;
			LongNumber a1 = new(a);
			LongNumber b1 = new(b);
			Console.WriteLine(a + " + " + b + " = " + (a + b) + '\n');
			Console.WriteLine("LongNumber = " + (a1 + b1));
		}
	}
}
