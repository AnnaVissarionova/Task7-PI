using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostClasses
{
    public class PClass
    {
        /// <summary>
        /// Функция, проверяет, является ли заданная eval'ом сохраняющей ноль
        /// </summary>
        /// <param name="eval"> Eval заданной функции </param>
        /// <returns></returns>
        public static bool CheckP0(int[] eval) {
            return eval[0] == 0;
        }

        /// <summary>
        /// Функция, проверяет, является ли заданная eval'ом сохраняющей единицу
        /// </summary>
        /// <param name="eval">Eval заданной функции</param>
        /// <returns></returns>
        public static bool CheckP1(int[] eval)
        {
            return eval[eval.Length - 1] == 1;
        }
    }
}
