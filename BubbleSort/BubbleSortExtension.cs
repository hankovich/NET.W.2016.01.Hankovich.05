using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public enum SortComparators
    {
        LineSum,
        LineMax,
        LineMin
    }

    public static class BubbleSortExtension
    {
        /// <summary>
        /// Bubble sorting of jagged int array
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparator"></param>
        /// <param name="byIncrease">true, if you wan't increase sort Ex. (2, 1, 3, 5, 4)->(1, 2, 3, 4, 5). false, otherwise</param>
        /// <exception cref="ArgumentException">
        /// 1. array is null
        /// 2. array is empty
        /// 3. at least one of the array's strings is null
        /// 4. at least one of the array's strings is empty
        /// </exception>
        public static void BubbleSort(this int[][] array, SortComparators comparator = SortComparators.LineSum, bool byIncrease = true)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"{nameof(array)} must be not null and not empty");

            int expectedComparationResult = byIncrease ? 1 : -1;

            Comparer<int[]> comparer = null;
            switch (comparator)
            {
                case SortComparators.LineSum:
                    comparer = new CompareSum();
                    break;
                case SortComparators.LineMax:
                    comparer = new CompareMax();
                    break;
                case SortComparators.LineMin:
                    comparer = new CompareMin();
                    break;
                default:
                    comparer = new CompareSum();
                    break;
            }

            bool isChanged = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                //isChanged = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) == expectedComparationResult)
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