using System;
using System.Collections.Generic;

namespace task_6_2
{

    public class ValidateInt32Attribute
    {
        private int minValue;
        private int maxValue;
        private int zeroEnabled;

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public int ZeroEnabled
        {
            get { return zeroEnabled; }
            set { zeroEnabled = value; }
        }
    }

    //класс исключения
    public class InvalidValueException
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public static List<int> list = new List<int>() { 4, 20, 0 }; //список ограничений
        int nowValue;
        public int NowValue { get { return nowValue; } set { nowValue = value; } }

        private int numberMistake;
        public int NumberMistake { get { return numberMistake; } set { numberMistake = value; } }

        List<string> mistake = new List<string>() {
	        "ниже минимума", 
	        "выше максимума",
	        "не должно быть = 0"};

        public void Show()
        {
            Console.WriteLine("В значении " + Name + ": " + NowValue + " ошибка: " + mistake[numberMistake]);
        }
    }

    public static class Int32Validate
    {
        public static void Validate1(ValidateInt32Attribute obj)
        {
            //проверка на ограничения
            if (obj.MinValue <= InvalidValueException.list[0])
            {
                InvalidValueException mis = new InvalidValueException() { Name = "MinValue", NowValue = obj.MinValue, NumberMistake = 0 };
                mis.Show();
            }

            if (obj.MaxValue >= InvalidValueException.list[1])
            {
                InvalidValueException mis = new InvalidValueException() { Name = "MaxValue", NowValue = obj.MaxValue, NumberMistake = 1 };
                mis.Show();
            }

            if (obj.ZeroEnabled == InvalidValueException.list[2])
            {
                InvalidValueException mis = new InvalidValueException() { Name = "ZeroEnabled", NowValue = obj.ZeroEnabled, NumberMistake = 2 };
                mis.Show();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ValidateInt32Attribute v = new ValidateInt32Attribute() { MinValue = 5, MaxValue = 25, ZeroEnabled = 50 };
            Int32Validate.Validate1(v);
        }
    }
}
