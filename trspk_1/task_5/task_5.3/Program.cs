using System;

namespace Task_5_3
{
    internal class Program
    {
        class Test
        {
            string s = "";
            public int i = 0;
            
            public Test(string n, int k)
            {
                Console.WriteLine("Вызван конструктор");
                s = n;
                i = k;
            }
            public void print(int i)
            {
                Console.WriteLine("Вызвана функция");
            }
            ~Test()
            {
                Console.WriteLine("Вызван финализатор");
            }
        }

        static void Main(string[] args)
        {
            string n = "Alan";
            int k = 10;

            for (int i = 0; i < 1000000; i++)
            {
                Test test = new Test(n, k);
                GC.Collect();
            }
        }
    }
}