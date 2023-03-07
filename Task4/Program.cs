using System;
using System.Xml.Linq;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ФИО контакта");
            string FIO = $"Person name=“{Console.ReadLine()}“";

            Console.WriteLine("Введите название улицы");
            string street = Console.ReadLine();

            Console.WriteLine("Введите номер дома");
            string houseNumber = $"_{Console.ReadLine()}";

            Console.WriteLine("Введите номер квартиры");
            string flatNumber = $"_{Console.ReadLine()}";

            Console.WriteLine("Введите номер мобильного телефона");
            string mobilePhone = $"_{Console.ReadLine()}";

            Console.WriteLine("Введите номер домашнего телефона");
            string flatPhone = $"_{Console.ReadLine()}";

            XDocument Contacts = new XDocument();

            XElement People = new XElement("Person");
            XAttribute PersonName = new XAttribute("name", FIO);
            People.Add(PersonName);

                XElement Adress = new XElement("Adress");
                People.Add(Adress);
                    XElement Street = new XElement("Street", street);
                    XElement HouseNumber = new XElement("HouseNumber", houseNumber);
                    XElement FlatNumber = new XElement("FlatNumber", flatNumber);
                    Adress.Add(Street);
                    Adress.Add(HouseNumber);
                    Adress.Add(FlatNumber);

                XElement Phones = new XElement("Phones");
                    People.Add(Phones);
                    XElement MobilePhone = new XElement("MobilePhone", mobilePhone);
                    XElement FlatPhone = new XElement("FlatPhone", flatPhone);
                    Phones.Add(MobilePhone);
                    Phones.Add(FlatPhone);

            Contacts.Add(People);
            Contacts.Save("Contats.xml");
            Console.WriteLine("Данные сохранены");
        }
    }
}
