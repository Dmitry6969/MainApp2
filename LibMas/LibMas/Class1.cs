using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;


namespace LibMas
{
    public class ClassMas
    {
        public static void InflateMas(int i, int max, out int[] mas)//функция заполнения массива числами
        {
            mas = new int[i];
            Random rnd = new Random();

            for (int j = 0; j < i; j++)
            {
                mas[j] = rnd.Next(1,max);
            }
        }

        public static void ClearMas(int[] mas, out int[] masc)//фунция очистки массива
        {
            int i = mas.Length;
            masc = new int[i];

            for (int j = 0; j < i; j++)
            {
                masc[j] = 0;
            }
        }

        
    }
}
