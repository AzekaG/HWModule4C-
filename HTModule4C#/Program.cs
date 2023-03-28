using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
/*Создайте приложение калькулятор для перевода числа
из одной системы исчисления в другую. Пользователь с 
помощью меню выбирает направление перевода. Например,
из десятичной в двоичную. После выбора направления,
пользователь вводит число в исходной системе исчисления.
Приложение должно перевести число в требуемую систему. 
Предусмотреть случай выхода за границы диапазона,
определяемого типом int, неправильный ввод.*/



namespace HTModule4C_
{
    internal class Program
    {

        class Convertation
        {
            public void Convert()

            {
                int choice;
                do
                {
                    Console.WriteLine("Make you'r choce : ");
                    Console.WriteLine("1 : bin To Hex");
                    Console.WriteLine("2 : bin to Dec");
                    Console.WriteLine("3 : Hex to Bin");
                    Console.WriteLine("4 : Hex to Dec");
                    Console.WriteLine("5 : Dec to Bin");
                    Console.WriteLine("6 : Dec to Hex");
                    choice = int.Parse(Console.ReadLine());
                  
                    switch (choice)
                    {
                        case 1:
                            {
                                Value<int> ValueObj = new BinaryValue();
                                Console.WriteLine("Enter a Binary value : ");
                                do {
                                    try
                                    {
                                        ValueObj.Val = int.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("format Exeption"); ValueObj.Val =0 ; 
                                        Console.WriteLine("Try again");
                                    }
                                    catch (OverflowException)
                                    {
                                        Console.WriteLine("Overflow exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                }
                                while(ValueObj.Val == 0);


                                IConvertToDecimal convertor = new IConvertToDecimal();
                                IConvertToHex convertor2 = new IConvertToHex();
                                Console.WriteLine(convertor2.ConvertToHex( convertor.ConvertToDecimal(ValueObj.Val)));
                               
                            }
                            break;
                        case 2:
                            {
                                Value<int> ValueObj = new BinaryValue();
                                Console.WriteLine("Enter a Binary value : ");
                                do
                                {
                                    try
                                    {
                                        ValueObj.Val = int.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("format Exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                    catch (OverflowException)
                                    {
                                        Console.WriteLine("Overflow exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                }
                                while (ValueObj.Val == 0);
                                IConvertToDecimal convertor = new IConvertToDecimal();
                                Console.WriteLine(convertor.ConvertToDecimal(ValueObj.Val));

                            }
                            break;
                        case 3:
                            {
                                Value<string> ValueObj = new HexValue();
                                Console.WriteLine("Enter a Hex value : ");
                                ValueObj.Val = Console.ReadLine();
                                Console.WriteLine(ValueObj.ConvertToBinary());

                            }
                            break;
                        case 4:
                            {
                                Value<string> ValueObj = new HexValue();
                                Console.WriteLine("Enter a Hex value : ");
                                ValueObj.Val = Console.ReadLine();
                               Console.WriteLine( ValueObj.ConvertToBinary());
                                
                            }
                            break;
                        case 5:
                            {
                                Value<int> ValueObj = new DecimalValue();
                                Console.WriteLine("Enter a Decimal value : ");
                               
                                do
                                {
                                    try
                                    {
                                        ValueObj.Val = checked(int.Parse(Console.ReadLine()));
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("format Exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                    catch (OverflowException)
                                    {
                                        Console.WriteLine("Overflow exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                }
                                while (ValueObj.Val == 0);


                                Console.WriteLine( ValueObj.ConvertToBinary());
                            }
                            break;
                        case 6:
                            {
                                Value<int> ValueObj = new DecimalValue();
                                Console.WriteLine("Enter a Decimal value : ");
                              
                                do
                                {
                                    try
                                    {
                                        ValueObj.Val = int.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("format Exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                    catch (OverflowException)
                                    {
                                        Console.WriteLine("Overflow exeption"); ValueObj.Val = 0;
                                        Console.WriteLine("Try again");
                                    }
                                }
                                while (ValueObj.Val == 0);
                                IConvertToHex convertor2 = new IConvertToHex();
                                Console.WriteLine(convertor2.ConvertToHex(ValueObj.Val));

                            }
                            break;
                    }
                } while (choice < 0 || choice > 6);
            }
           
        }

      
        class IConvertToHex
        {
            public  string ConvertToHex(int value)
            {
                int temp = value;
                string res = "";

                do
                {
                    if (temp % 16 < 10) {res += (temp % 16).ToString(); temp /= 16; }

                    if (temp % 16 == 10) { res += "A"; temp /= 16; }
                    if (temp % 16 == 11) {res += "B"; temp /= 16;}

                    if (temp % 16 == 12) {res += "C"; temp /= 16; }
            
                    if (temp % 16 == 13) { res += "D"; temp /= 16; }
                    if (temp % 16 == 14) { res += "E"; temp /= 16; }
                    if (temp % 16 == 15) { res += "F"; temp /= 16; }
                    if (temp % 16 >= 16) { res += ConvertToHex(temp/16); }
                } while (temp > 0);

                char[] sReverse = res.ToCharArray();
                Array.Reverse(sReverse);
                res = new string(sReverse);

                return res;
            } 
            
        }
        class IConvertToDecimal
        {
            public int ConvertToDecimal(int valueBin)
            {
                int temp = valueBin;
                int res = 0, count = 1;

                while (temp != 0)
                {
                    if (temp % 10 == 1)
                    {
                        res += count;
                    }
                    count *= 2;
                    temp /= 10;
                }
                return res;
            }

        }
    


      
        interface Value<T>          //суть в том , чтобы мы могли принимать любое число в любой системе и могли вывести 2-ное число
        {
            T Val { get; set; }
            int ConvertToBinary();
        }           

        class DecimalValue : Value<int>
        {
            public int Val { get; set; }
            public int ConvertToBinary()
            {
                int a = 0 , t=1;
                int temp = Val;
                while(temp>0)
                {
                    a += temp % 2*t;
                    temp /= 2;
                    t *= 10;
                }

                return a ;
            }

        }

        class HexValue : Value<string>
        {
           
            public string mainValue { get; set; }
            public string Val { get; set; }

            public int ConvertToDecimal()
            {
                int  tempS=0, tempKey=0, tempPow= Val.Length-1;
                for (int i = 0; i< Val.Length ; i++)
                {
                    switch (Val[i])
                    {
                        case 'A':
                            tempKey = 10; break;
                        case 'B':
                            tempKey = 11; break;
                        case 'C':
                            tempKey = 12; break;
                        case 'D':
                            tempKey = 13; break;
                        case 'E':
                            tempKey = 14; break;
                        case 'F':
                            tempKey = 15; break;
                        default: {
                                if (Val[i] <= '0' || Val[i] >= '9') { throw new ArgumentOutOfRangeException(); }

                                else tempKey = Val[i]-48; break; }
                   
                    }
                    Console.WriteLine(tempKey);
                    tempS += tempKey * (int)Math.Pow(16, tempPow--);
                    
                    Console.WriteLine(tempS);
                }
                
                return tempS;
            }

            public int ConvertToBinary()
            {
                Value<int> tempVal = new DecimalValue();
                tempVal.Val = ConvertToDecimal();
                return tempVal.ConvertToBinary();
            }

        }
        class BinaryValue : Value<int>
        {
            public int Val { get; set; }
            public int ConvertToBinary() { return Val; }

        }



        static void Main(string[] args)
        {
            Convertation convert = new Convertation();
            convert.Convert();

        }
    }
}
