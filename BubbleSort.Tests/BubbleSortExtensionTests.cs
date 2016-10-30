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

namespace BubbleSort.Tests
{
    [TestFixture]
    public class BubbleSortExtensionTests
    {
        #region increase sort tests
        [Test]
        public void BubbleSortIncrease_Array_IncreaseSortedArrayBySum()
        {
            int[][] array = new int[3][];
            array[0] = new[] {0, -1, 3};
            array[1] = new[] {4};
            array[2] = new[] {int.MinValue, int.MaxValue, 0, 2};

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new[] {int.MinValue, int.MaxValue, 0, 2};
            expectedArray[1] = new[] {0, -1, 3};
            expectedArray[2] = new[] {4};

            array.BubbleSort();

            CollectionAssert.AreEqual(array, expectedArray);
        }

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
            array.BubbleSort(SortComparators.LineMax);
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
        
            expectedArray[0] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            expectedArray[1] = new[] {0, -1, 3};
            expectedArray[2] = new[] {4};

            Debug.WriteLine(array.ToString());
            array.BubbleSort(SortComparators.LineMin);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion

        #region decrease sort tests
        [Test]
        public void BubbleSortDecrease_Array_DecreaseSortedArrayBySum()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 0, -1, 3 };
            array[1] = new[] { 4 };
            array[2] = new[] { int.MinValue, int.MaxValue, 0, 2 };

            int[][] expectedArray = new int[3][];
            expectedArray[2] = new[] { int.MinValue, int.MaxValue, 0, 2 };
            expectedArray[1] = new[] { 0, -1, 3 };
            expectedArray[0] = new[] { 4 };

            array.BubbleSort(byIncrease: false);

            CollectionAssert.AreEqual(array, expectedArray);
        }

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
            array.BubbleSort(SortComparators.LineMax, false);
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
            array.BubbleSort(SortComparators.LineMin, false);
            CollectionAssert.AreEqual(array, expectedArray);
        }

        #endregion

        #region tests
        [Test]
        public void BubbleSortIncrease_Null_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), () => ((int[][])null).BubbleSort());
        }

        [Test]
        public void BubbleSortIncrease_Empty_ArgumentException()
        {
            int[][] array = new int[3][];

            Assert.Throws(typeof(ArgumentException), () => array.BubbleSort());
        }

        [Test]
        public void BubbleSortIncrease_NullString_ArgumentException()
        {
            int[][] array = new int[3][];
            array[0] = new[] {int.MaxValue };
            array[2] = new[] {int.MinValue};

            Assert.Throws(typeof(ArgumentException), () => array.BubbleSort());
        }

        [Test]
        public void BubbleSortIncrease_EmptyString_ArgumentException()
        {
            int[][] array = new int[3][];
            array[0] = new[] { int.MaxValue };
            array[1] = new int[0];
            array[2] = new[] { int.MinValue };

            Assert.Throws(typeof(ArgumentException), () => array.BubbleSort());
        }
        #endregion
    }
}
