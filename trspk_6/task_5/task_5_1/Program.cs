using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int a = 21;
        //количество знаков в числовом значении
        string result = String.Format("Decimal: {0:d}", a);
        Console.WriteLine(result);

        string result1 = String.Format("Decimal: {0:d3}", a);
        Console.WriteLine(result1);

        double b = 21.032002;
        //количество разрядов после запятой
        string result2 = String.Format("Fixed-point: {0:f3}", b);
        Console.WriteLine(result2);

        //количество десятичных цифр после запятой, но с экспонентой
        string result3 = String.Format("Exponential: {0:e3}", b);
        Console.WriteLine(result3);

        //более компактное представление
        string result4 = String.Format("General: {0:g3}", b);
        Console.WriteLine(result4);

        //также количество разрядов после запятой
        string result5 = String.Format("Numeric: {0:n3}", b);
        Console.WriteLine(result5);

        double c = 0.21;
        //преобразует в проценты
        string result6 = String.Format("Percent: {0:p}", c);
        Console.WriteLine(result6);

        //преобразует числовое значение в текст и обратно без потерь, выводит то же самое число
        string result7 = String.Format("Round-trip: {0:r}", b);
        Console.WriteLine(result7);

        //шестнадцатеричный формат числа
        string result8 = String.Format("Hexadecimal: {0:x}", a);
        Console.WriteLine(result8);

        //добавляется обозначение денежного знака (в зависимости от культуры компьютера)
        string result9 = String.Format("Currency: {0:c}", b);
        Console.WriteLine(result9);

        //нестандартное форматирование разбиение числа на триады
        Console.WriteLine("Выделение тысяч: {0:#0####,###.#######}", b);

        //несандартное форматирование - вывод процентов
        Console.WriteLine("Проценты: {0:####%###.######%}", b);

        //нестандартное форматирование (конкретно тут округляет до одного знака после запятой)
        Console.WriteLine("Изменение формата: {0:0.#;(0.0);0.00000}", b);

        Console.WriteLine("Вывод даты от пользователя");

        Console.WriteLine("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите месяц: ");
        int month = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите день: ");
        int day = int.Parse(Console.ReadLine());

        DateTime myDate = new DateTime(year, month, day);
        Console.WriteLine("Дата в длинной форме: {0:D}", myDate);
        Console.WriteLine("Месяц и день: {0:M}", myDate);
        Console.WriteLine("Месяц и год: {0:Y}", myDate);
    }
}
