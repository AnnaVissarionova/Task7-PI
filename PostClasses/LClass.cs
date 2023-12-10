using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PostClasses
{
    public class LClass
    {
        ///

        /// <summary>
        /// Главная функция, проверяет, является ли заданная eval'ом функция линейной
        /// </summary>
        /// <param name="eval"> Eval заданной функции </param>
        /// 
        public static bool Check(int[] eval)
        {
            Debug.Assert((int) Math.Ceiling(Math.Log2(eval.Length)) == (int) Math.Floor(Math.Log2(eval.Length))); 
            var count = (int) Math.Log2(eval.Length);
            int[] coef = new int[count + 1];
            coef[0] = eval[0];
            for(var i = 1; i <= count; i++)
            {
                coef[count - i + 1] = coef[0] ^ eval[(int) Math.Pow(2, i-1)];
            }
            return ArrEquals(FindEval(coef, count), eval);
    
        }


       
        /// <summary>
        /// Функция, находящая eval по заданному массиву коэффициентов a0, a1 ... am и количеству переменных m
        /// </summary>
        /// <param name="coef"> массив коэффициентов в АНФ </param>
        /// <param name="count"> количество переменных функции</param>
        /// 
        static int[] FindEval(int[] coef, int count) 
        {
            Debug.Assert((coef.Length > 1) && (count > 0) && (coef.Length == count + 1));
            var num = 0;
            var i = 0;
            int[] res = new int[(int) Math.Pow(2, count)];
            while (num < (int) Math.Pow(2, count))
            {
                var binNum = ToBinary(num, count);
                res[i] = coef[0];
                for(var j = 1; j <= count; j++)
                {
                    res[i] = res[i] ^ (coef[j] * binNum[j-1]);
                }
                i++;
                num++;
            }
            return res;
        }


        /// <summary>
        /// Функция, представляющая заданное число в двоичной СИ ( в виде массива цифр 1 и 0)
        /// </summary>
        /// <param name="num"> число, которое необходимо представить в двоичной системе </param>
        /// <param name="count"> количество разрядов для представления </param>
        /// 
        static int[] ToBinary(int num, int count)
        {
            Debug.Assert((num >= 0) && (count > 0) && (num < (int)Math.Pow(2, count)));
            var i = 0;
            int[] res = FillZero(count);
            while (num > 0)
            {
                res[count - i -1] = num % 2;
                i++;
                num = num / 2;
            }
            return res;
        }

        /// <summary>
        /// Функция, заполняющая массив нулями
        /// </summary>
        /// <param name="count"> размер массива </param>
        /// 
        static int[] FillZero(int count)
        {
            Debug.Assert(count > 0);
            var res = new int[count];
            for (var i = 0; i < count; i++)
            {
                res[i] = 0;
            }
            return res;
        }

        /// <summary>
        /// Функция, проверяющая массивы на равенство
        /// </summary>
        /// <param name="a"> первый массив </param>
        /// <param name="b"> второй массив </param>
        /// 
        static bool ArrEquals(int[] a, int[] b)
        {
            Debug.Assert((a.Length == b.Length) && (a.Length > 0));
            var res = true;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}
