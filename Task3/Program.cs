using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRead();
            Input();
        }
        static HashSet<int> listNumbers = new();
        static string path = @"Numbers.json";

        public static void Input()//добавление числа в коллекцию
        {
            char key;
            do
            {
                Console.WriteLine("Введите число:");
                int userNumber = int.Parse(Console.ReadLine());

                bool num = listNumbers.Contains(userNumber);

                if (num == true)
                {
                    Console.WriteLine($"Число {userNumber} уже присутствует в коллекции");
                }
                else
                {
                    listNumbers.Add(userNumber);
                    Console.WriteLine($"Число {userNumber} добавлено в коллекцию\n");
                    File.WriteAllText(path, JsonConvert.SerializeObject(listNumbers));
                }

                Console.WriteLine("Продолжить ввод чисел?\n" +
                    "да    - д\n" +
                    "выход - любая клавиша");
                key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д');
        }
        
        public static void FileRead()//восстановление существующей коллекции из файла
        {
            if(File.Exists(path))
            {
            string json = File.ReadAllText(path);
            listNumbers = JsonConvert.DeserializeObject<HashSet<int>>(json); 
            }
            else
            {
                return;
            }
            
        }
    }
}