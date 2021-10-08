using System;
using System.Diagnostics;


namespace Task4
{
    class Program
    {
        delegate void SortDelegate(NumberArray number);
        class NumberArray
        {
            public NumberArray()
            {
                Random rd = new();
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = rd.Next(-100,100);
                }
            }
            public NumberArray(NumberArray numberArray)
            {
                numbers = numberArray.numbers;
            }
         
            int[] numbers = new int[20];


            public int[] Numbers
            {
                get
                {
                    return numbers;
                }
                set
                {
                    numbers = value;
                }

            }
            public int this[int index]
            {
                get
                {
                    return numbers[index];
                }
                set
                {
                    numbers[index] = value;
                }

            }
            public static void PrintArr(NumberArray number)
            {
                int[] printy = number.Numbers;
                for (int i = 0; i < printy.Length; i++)
                {
                    Console.WriteLine(printy[i] + "   ");
                }
            }

            public void DelegateSort(SortDelegate sortDelegate)
            {   
                if (sortDelegate != null)
                {
                    sortDelegate(this);
                }
            }   

            public static void Sort1(NumberArray number) //bubblesort 
            {
                Stopwatch sw = new();
                sw.Start();
                int[] arr = number.Numbers;

                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            int t = arr[i];
                            arr[i] = arr[j];
                            arr[j] = t;
                        }
                    }
                }
                number.Numbers = arr;
                sw.Stop();
                Console.WriteLine("Время выполнения пузырьковой сортировки (мс) : " + sw.ElapsedTicks);
            }
            public static void Sort2(NumberArray number)//InsertionSort
            {
                Stopwatch sw = new();
                sw.Start();
                int[] arr = number.Numbers;
                for (int i = 1; i < arr.Length; i++)
                {
                    int curr = arr[i];
                    int j = i;
                    while (j > 0 && curr < arr[j - 1])
                    {
                        arr[j] = arr[j - 1];
                        j--;
                    }
                    arr[j] = curr;
                }
                number.Numbers = arr;
                sw.Stop();
                Console.WriteLine("Время выполнения сортировки вставками (мс) : " + sw.ElapsedTicks);
            }
        }

        static void Main(string[] args)
        {
            int b;
            NumberArray a = new NumberArray();
            SortDelegate sortD1 = new(NumberArray.Sort1);
            SortDelegate sortD2 = new(NumberArray.Sort2);
            Console.Write("1 - пузырьковая сортировка, 2 - сортировка вставками: ");
            b = Int32.Parse(Console.ReadLine());
            if(b == 1)
            {
                sortD1(a);
                Console.WriteLine("Пузырьковая сортировка : ");
            }
            else if(b == 2)
            {
                sortD2(a);
                Console.WriteLine("Cортировка вставками : ");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. ");
            }
            NumberArray.PrintArr(a);
            Console.ReadKey();
        }
    }


}