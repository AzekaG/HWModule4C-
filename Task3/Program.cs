using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
/*Создайте класс «Заграничный паспорт». Вам необходимо
хранить информацию о номере паспорта, ФИО владельца,
дате выдачи и т.д. Предусмотреть механизмы для инициа-
лизации полей класса. Если значение для инициализации
неверное, генерируйте исключение.*/


namespace Task3
{
    internal class Program
    {



        class Passport
        {
            string numberPassport;
            string name;
            string secondName;
            public DateTime DateOfIssue { get; set; }

            public void SetInfo()
            {
                int temp = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Enter a number of Passport 'A'  - 'Z' , '0' - '9'   ");
                        numberPassport = Console.ReadLine();
                        foreach (var letter in numberPassport)
                            if ((letter > 'Z' || letter < 'A') && (letter < '0' || letter > '9')) throw new ArgumentOutOfRangeException();

                        Console.WriteLine("Enter a Name : ");
                        name = Console.ReadLine();
                        foreach (var letter in name)
                            if ((letter > 'Z' || letter < 'A') && (letter < 'a' || letter > 'z')) throw new ArgumentOutOfRangeException();

                        Console.WriteLine("Enter a Second Name : ");
                        secondName = Console.ReadLine();
                        foreach (var letter in secondName)
                            if ((letter > 'Z' || letter < 'A') && (letter < 'a' || letter > 'z')) throw new ArgumentOutOfRangeException();


                        Console.WriteLine("Enter a date of issue : dd.mm.yyyy");
                        DateOfIssue = DateTime.Parse(Console.ReadLine());
                        temp++;
                    }
                    catch (Exception ex) { Console.WriteLine("Incorrect data , try again"); temp = 0; };
                } while (temp == 0);

            }

           


          public  void OutputInfo()
            {
                Console.WriteLine("Name : " + name);
                Console.WriteLine("Second Name : " + secondName);
                Console.WriteLine("Number : " + numberPassport);
                Console.WriteLine("Date of issue : " + DateOfIssue.ToLongDateString());
            }

        }
        static void Main(string[] args)
        {
            Passport passport = new Passport();
            Console.WriteLine("Enter a data");
            passport.SetInfo();
            passport.OutputInfo();
        
        }
    }
}
