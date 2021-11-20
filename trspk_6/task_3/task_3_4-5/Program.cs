using System;
//params нужен для того, чтобы метод Sum работал при любом количестве параметров, и мы каждый раз не добавляли руками новые 
class Program
{
    public static void Swap(ref int a, int b)
    {
        int a;
        a = b;
        b = a;
    }

    static int Sum(params int[] parameters)
    {
        int result = 0;
        for (int i = 0; i < parameters.Length; i++)
        {
            result += parameters[i];
        }
        return result;
    }
    static void Main(string[] args)
    {
        int a = 222;
        int b = 444;

        Swap(ref a, ref b);
        Console.WriteLine(a, b);

        int result = Sum(2, 6, 4, -7, 8, 4, 6, 8, 9, 5);
        Console.WriteLine(result);
    }
}
