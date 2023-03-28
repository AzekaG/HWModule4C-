using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*Пользователь вводит словами цифру от 0 до 9. Прило-
жение должно перевести слово в цифру. Например, если
пользователь ввёл five, приложение должно вывести на
экран 5.*/

namespace Task2
{
    internal class Program
    {
        class Input
        {
            public int KeyValue { get; set; } 
        }
        class Vocabulary : Input
        {
            string[] vocabulary = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            public void getVocabulary() 
            {
                Console.Write(KeyValue + " : ");
                Console.WriteLine(vocabulary[KeyValue]); }
             }
      
      
        static void Main(string[] args)
        {
            Vocabulary vocabulary = new Vocabulary();
            Console.WriteLine("Enter a value from 0 to 9");
            do
            {

                vocabulary.KeyValue = int.Parse(Console.ReadLine());
                if (vocabulary.KeyValue < 0 || vocabulary.KeyValue > 9) Console.WriteLine("Incorrect Value , try again");             
            }while(vocabulary.KeyValue < 0 || vocabulary.KeyValue > 9);
            vocabulary.getVocabulary();
        }

    }
}
