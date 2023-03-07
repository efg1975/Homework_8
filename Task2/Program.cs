using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using Newtonsoft.Json;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите операцию:\n" +
                "1 - добавление нового абонента\n" +
                "2 - просмотр списка всех абонентов\n" +
                "3 - поиск абонента по номеру телефона\n" +
                "0 - для выхода из программы");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: break;
                case 1:
                    InputSubscriber();
                    break;
                case 2:
                    GetDictionaryFromFile();
                    Print();
                    break;
                case 3:
                    GetDictionaryFromFile();
                    GetSubscriberByNumberPhone();
                    break;
            }
        }
        static Dictionary<int, string> phoneBook = new();
        static string path = @"phoneBook.json";

        public static void InputSubscriber()//добавление нового абонента
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                phoneBook = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);
            }
            else
            {
            }
            while (true)
            {
                Console.WriteLine("Введите ФИО нового абонента");
                string FIO = Console.ReadLine();

                Console.WriteLine("Введите номер нового абонента");
                int numberPhone = Convert.ToInt32(Console.ReadLine());

                phoneBook.Add(numberPhone, FIO);
                string json = JsonConvert.SerializeObject(phoneBook);
                File.WriteAllText(path, json);

                Console.WriteLine("\nПродолжить ввод?\n1 - да\nпробел - выход");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (key == ' ')
                {
                    break;
                }

                if (key == '1')
                {
                    continue;
                }
                else break;
            }
        }

        public static void Print()//вывод полного списка абонентов
        {
            foreach (var item in phoneBook)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }

        public static void GetSubscriberByNumberPhone()//поиск абонента по номеру телефона
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Введите номер телефона абонента");
                int findSubscriber = Convert.ToInt32(Console.ReadLine());

                if (phoneBook.TryGetValue(findSubscriber, out string result))
                {
                    Console.WriteLine($"Номер телефона {findSubscriber} принадлежит абоненту: {result}");
                }
                else
                {
                    Console.WriteLine($"В телефонной книге абонент с номером телефона {findSubscriber} отсутствует");
                }
            }
            else
            {
                return;
            }
        }

        public static void GetDictionaryFromFile()//чтение телефонной книги из файла в Dictionary
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                phoneBook = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);
            }
            else
            {
                Console.WriteLine("Телефонная книга еще не создана. Создайте ее.");
            }

        }
    }
}
            
    
    

    
    

