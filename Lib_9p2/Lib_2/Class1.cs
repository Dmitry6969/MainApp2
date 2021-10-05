using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_2
{
    public class Class2
    {
        public static int YmnozhMas(int[] mas)//функция умножения всех элементов массива
        {
            int i = mas.Length;
            int proizv = 1;
            for (int j = 0;j < i;j++)
            {
                proizv *= mas[j];
            }

            return proizv;
        }
    }
}
