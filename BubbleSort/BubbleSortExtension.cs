using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public interface ICompare
    {
        int CompareTo(int[] a, int[] b);
    }

    public static class BubbleSortExtension
    {
        /// <summary>
        /// Bubble sorting of jagged int array
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparator"></param>
        /// <exception cref="ArgumentException">
        /// 1. array is null
        /// 2. array is empty
        /// 3. at least one of the array's strings is null
        /// 4. at least one of the array's strings is empty
        /// </exception>
        public static void BubbleSort(this int[][] array, ICompare comparator)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"{nameof(array)} must be not null and not empty");

            var isChanged = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                isChanged = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparator.CompareTo(array[j], array[j + 1]) > 0)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        isChanged = true;
                    }
                }
                if (!isChanged)
                    return;
            }
        } 
    }
}