using System;


namespace task_6_3
{
	class Program
	{
		enum DayOfWeek
        {
			Monday = 1,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
        }

		static void Main(string[] args)
		{
			DayOfWeek dayOfWeek;
            Console.WriteLine("Введите число от 1 до 7 : ");
			int value = Convert.ToInt32(Console.ReadLine());

			if (Enum.IsDefined(typeof(DayOfWeek), value))
			{
				dayOfWeek = (DayOfWeek)value;
            }
			else
            {
				throw new Exception("Некорректный ввод");
            }
            Console.WriteLine(dayOfWeek);
		}
	}
}
