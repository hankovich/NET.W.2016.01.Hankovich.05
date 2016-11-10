using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort.Tests
{
    public static class BubbleSortDelegateExtension
    {
        public delegate int SortingDelegate(int[] a, int[] b);

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
        public static void BubbleSort(this int[][] array, SortingDelegate comparator)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"{nameof(array)} must be not null and not empty");

            var isChanged = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                isChanged = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparator(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isChanged = true;
                    }
                }
                if (!isChanged)
                    return;
            }
        }

        public static void BubbleSort(this int[][] array, IComparer<int[]> comparator)
        {
            array.BubbleSort(comparator.Compare);
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        
    }
}
