using System;
using System.Text;
using System.IO;

namespace _5_3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите исходный текст : ");
            string str = Console.ReadLine();
            
            Encoding eUTF8 = Encoding.UTF8;
            Byte[] arr = eUTF8.GetBytes(str);

            Encoding eUTF32 = Encoding.UTF32;
            Byte[] arr1 = eUTF32.GetBytes(str);

            Encoding ascii = Encoding.ASCII;
            Byte[] arr2 = ascii.GetBytes(str);

            string path = @"C:\Users\user\Desktop\1.txt";
            
            using (StreamWriter fl = new StreamWriter(path))
            {
                Console.WriteLine("Исходный текст : ");
                fl.WriteLine(str);

                fl.Write("UTF-8 : ");
                foreach (Byte b in arr)
                {
                    fl.Write("[{0}]", b);
                }
                fl.WriteLine("\n");

                fl.Write("UTF-32 : ");
                foreach (Byte b in arr1)
                {
                    fl.Write("[{0}]", b);
                }
                fl.WriteLine("\n");

                fl.Write("ASCII : ");
                foreach (Byte b in arr2)
                {
                    fl.Write("[{0}]", b);
                }
                fl.WriteLine("\n");
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string filestr;
                while ((filestr = reader.ReadLine()) != null)
                {
                    Console.WriteLine(filestr);
                }
            }
        }
    }
}