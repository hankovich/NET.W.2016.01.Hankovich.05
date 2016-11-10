using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleSort;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace BubbleSort.Tests
{
    class ByMaxInc : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            if (a.Max() > b.Max())
                return 1;
            if (a.Max() < b.Max())
                return -1;
            return 0;
        }
    }
    class ByMaxDec : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            if (a.Max() > b.Max())
                return -1;
            if (a.Max() < b.Max())
                return 1;
            return 0;
        }
    }
    class ByMinInc : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            if (a.Min() > b.Min())
                return 1;
            if (a.Min() < b.Min())
                return -1;
            return 0;
        }
    }
    class ByMinDec : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            if (a.Min() > b.Min())
                return -1;
            if (a.Min() < b.Min())
                return 1;
            return 0;
        }
    }

    [TestFixture]
    public class BubbleSortExtensionTests
    {
        #region increase sort tests
        [Test]
        public void BubbleSortIncrease_Array_IncreaseSortedArrayByMax()
        {
            int[][] array = new int[3][];

            array[0] = new[] {int.MinValue, int.MaxValue, 0, 2};
            array[1] = new[] {4};
            array[2] = new[] {0, -1, 3};

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new[] {0, -1, 3};
            expectedArray[1] = new[] {4};
            expectedArray[2] = new[] {int.MinValue, int.MaxValue, 0, 2};

            Debug.WriteLine(array.ToString());
            array.BubbleSort(new ByMaxInc());
            CollectionAssert.AreEqual(array, expectedArray);
        }

        [Test]
        public void BubbleSortIncrease_Array_IncreaseSortedArrayByMin()
        {
            int[][] array = new int[3][];

            array[0] = new[] {int.MinValue, int.MaxValue, 0, 2};
            array[1] = new[] {4};
            array[2] = new[] {0, -1, 3};

            int[][] expectedArray = new int[3][];

            expectedArray[0] = new[] {int.MinValue, int.MaxValue, 0, 2};
            expectedArray[1] = new[] {0, -1, 3};
            expectedArray[2] = new[] {4};

            Debug.WriteLine(array.ToString());
            array.BubbleSort(new ByMinInc());
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion

        #region decrease sort tests
        [Test]
        public void BubbleSortDecrease_Array_DecreaseSortedArrayByMax()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];
            expectedArray[2] = new[] { 0, -1, 3 };
            expectedArray[1] = new[] { 4 };
            expectedArray[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };

            Debug.WriteLine(array.ToString());
            array.BubbleSort(new ByMaxDec());
            CollectionAssert.AreEqual(array, expectedArray);
        }

        [Test]
        public void BubbleSortDecrease_Array_DecreaseSortedArrayByMin()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];

            expectedArray[2] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            expectedArray[1] = new[] { 0, -1, 3 };
            expectedArray[0] = new[] { 4 };

            Debug.WriteLine(array.ToString());
            array.BubbleSort(new ByMinDec());
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion

        BubbleSortExtension.SortingDelegate sortingDelegate;

        #region delegate increase sort tests
        [Test]
        public void BubbleSortDelegateIncrease_Array_IncreaseSortedArrayByMax()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new[] { 0, -1, 3 };
            expectedArray[1] = new[] { 4 };
            expectedArray[2] = new[] { int.MinValue, int.MaxValue, 0, 2 };

            Debug.WriteLine(array.ToString());
            sortingDelegate = new ByMaxInc().Compare;
            array.BubbleSort(sortingDelegate);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        [Test]
        public void BubbleSortDelegateIncrease_Array_IncreaseSortedArrayByMin()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];

            expectedArray[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            expectedArray[1] = new[] { 0, -1, 3 };
            expectedArray[2] = new[] { 4 };

            sortingDelegate = new ByMinInc().Compare;
            Debug.WriteLine(array.ToString());
            array.BubbleSort(sortingDelegate);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion

        #region delegate decrease sort tests
        [Test]
        public void BubbleSortDelegateDecrease_Array_DecreaseSortedArrayByMax()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];
            expectedArray[2] = new[] { 0, -1, 3 };
            expectedArray[1] = new[] { 4 };
            expectedArray[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };

            Debug.WriteLine(array.ToString());
            sortingDelegate = new ByMaxDec().Compare;
            array.BubbleSort(sortingDelegate);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        [Test]
        public void BubbleSortDelegateDecrease_Array_DecreaseSortedArrayByMin()
        {
            int[][] array = new int[3][];

            array[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            array[1] = new[] { 4 };
            array[2] = new[] { 0, -1, 3 };

            int[][] expectedArray = new int[3][];

            expectedArray[2] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            expectedArray[1] = new[] { 0, -1, 3 };
            expectedArray[0] = new[] { 4 };

            sortingDelegate = new ByMinDec().Compare;
            Debug.WriteLine(array.ToString());
            array.BubbleSort(sortingDelegate);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion
    }
}
