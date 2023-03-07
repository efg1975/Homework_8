using System;
using System.Collections.Generic;


namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            InputNumbers(list);
            Console.WriteLine("Первоначальный список:");
            PrintList(list);
            SortList(list);
            Console.WriteLine("Отсортированный список:");
            PrintList(list);
        }
        static List<int> list = new();

        public static List<int> InputNumbers(List<int> list)//создание списка чисел
        {
            Random random = new Random();
            for (int i = 0; i <= 100; i++)
            {
                list.Add(random.Next(101));
            }
            return list;
        }

        public static void PrintList(List<int> list)//вывод списка на консоль
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine("\n");
        }

        public static List<int> SortList(List<int> list)//удаление из списка указанных значений
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                while (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }
    }
}
