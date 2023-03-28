using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

/*Пользователь вводит в строку с клавиатуры логическое
выражение. Например, 3>2 или 7<3. Программа должна
посчитать результат введенного выражения и дать резуль-
тат true или false. В строке могут быть только целые числа
и операторы: <, >, <=, >=, ==, !=. Для обработки ошибок
ввода используйте механизм исключений.*/

namespace Task4
{

    class Calc
    {
        string task;
        public Calc(string task)
        {
            this.task = task;
        }
        bool Treatment()
        {
            int a = 0, b = 0;
            string c = "";
            int tempPow = 0;
            int count = 0;
            int tempCount;
            for (; count < task.Length - 1; count++)
            {
                if (task[0]<'0' && task[0]>'9') throw new OutOfMemoryException();
                if (task[count] >= '0' && task[count] <= '9') { a = a * ((int)Math.Pow(10, tempPow++)) + ((int)task[count] - 48); }
                else {  tempPow = 0; break; }
            }
            tempCount = count;
            for (; count < task.Length - 1; count++)
            {
                if ((task[tempCount] > 'A' && task[tempCount] < 'Z') || (task[tempCount] >'a' && task[tempCount] <'z')) throw new OutOfMemoryException();
                if (task[count] < '0' || task[count] > '9') { c += task[count]; }
                else {  tempPow = 0; break; }
            }
            for (; count < task.Length; count++)
            {
                if (task[count] >= '0' && task[count] <= '9') { b = b * ((int)Math.Pow(10, tempPow++)) + ((int)task[count] - 48); }
                else break;
            }
            switch (c) 
            {
                case "<": return a<b;
                case ">": return a>b;
                case "<=": return a<=b;
                case ">=": return a>=b;
                case "!=": return a != b;
                case "==": return a == b;
                
            }
            throw new OutOfMemoryException();
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                string str  = ("12>5");
                Console.WriteLine(str);
                Calc calc = new Calc(str);
                Console.WriteLine( calc.Treatment());
                Console.WriteLine("Enter a new task :   ");
                str = Console.ReadLine();
                Calc calcRes = new Calc(str);
                Console.WriteLine(calcRes.Treatment());
             
              
               

            }
        }
    }
}
