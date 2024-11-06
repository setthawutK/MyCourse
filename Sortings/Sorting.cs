using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public class Sorting { 
        private static bool lessThan(object a, object b)
        {
            return ((IComparable)a).CompareTo(b) < 0;
        }
        
        private static void swap(object[] d, int i, int j)
        {
            object t = d[i]; d[i] = d[j]; d[j] = t;
        }

        public static void selectionSort(object[] d)
        {
            for(int k = d.Length - 1; k > 0; k--)
            {
                int m = k;
                for (int j = 0; j < k; j++)
                    if ( lessThan(d[m], d[j])) m = j;
                swap(d, m, k);
            }
        }
        public static void bubbleSort(object[] d)
        {
            for (int k = d.Length; k > 1; k--)
                for (int j = 1; j < k; j++)
                    if (lessThan(d[j], d[k])) swap(d, j - 1, j);
        }
   
    }
}
