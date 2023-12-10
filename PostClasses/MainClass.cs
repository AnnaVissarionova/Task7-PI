using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PostClasses
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            var arr = ParseEval("01001101");

            var blng = new bool[] { PClass.CheckP0(arr), PClass.CheckP1(arr), LClass.Check(arr), SClass.Check(arr), MClass.Check(arr) };
            PrintTable(blng);

            /* Console.WriteLine("Enter the eval of function (e for exit):");
             var inputStr = Console.ReadLine();
             while (inputStr != "e")
             {

                 while (!(CheckEval(inputStr)))
                 {
                     Console.WriteLine();
                     Console.WriteLine("Try input again:");
                     inputStr = Console.ReadLine();

                 }

                 var arr = ParseEval(inputStr);

                 var blng = new bool[] { PClass.CheckP0(arr), PClass.CheckP1(arr), LClass.Check(arr), SClass.Check(arr), MClass.Check(arr) };
                 PrintTable(blng);
                 Console.WriteLine();
                 Console.WriteLine("Enter the eval of function (e for exit):");
                 inputStr = Console.ReadLine();
             }
             if (inputStr.Equals("e"))
             {
                 Environment.Exit(0);
             }*/
        }

        

        /// <summary>
        /// Функция, проверяющая корректность введенного eval
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        static bool CheckEval(string eval)
        {
            Console.WriteLine();
            if (Regex.IsMatch(eval, @"[^01]"))
            {
                Console.WriteLine("Invalid characters.");
                return false;
            }
            
            if (((int) Math.Floor(Math.Log2(eval.Length)) != (int) Math.Ceiling(Math.Log2(eval.Length))) || (eval.Length < 2))
            {
                Console.WriteLine("Wrong length of eval.");
                return false;
            }
            if(eval.Length > 1024)
            {
                Console.WriteLine($"{(int)Math.Log2(eval.Length)} params are too much, but i'll do my best (=^..^=) .");
                Console.WriteLine();
            }
            return true;
        }

        /// <summary>
        /// Функция, преобразующая eval из строки в массив чисел
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        public static int[] ParseEval(string eval)
        {
            var res = new int[eval.Length];
            for (var i = 0; i < eval.Length; i++)
            {
                res[i] = int.Parse(""+eval[i]);
            }
            return res;
        }

        /// <summary>
        /// Функция, выводящая таблицу классов Поста
        /// </summary>
        /// <param name="blng"> </param>
        static void PrintTable(bool[] blng) 
        {
            var names = new string[] { "P0", "P1", "L", "S", "M" };

            Console.WriteLine("----------------------------");
            Console.WriteLine(String.Format("|{0,12}  |  {1,7}  |", "Class name", "Belongs"));
            Console.WriteLine("----------------------------");
            for(var i = 0; i < 5; i++)
            {
                Console.WriteLine(String.Format("|      {0,-2}      |     {1,1}     |", names[i], blng[i] ? "+" : "-"));
                Console.WriteLine("----------------------------");
            }
        }
    }
}
