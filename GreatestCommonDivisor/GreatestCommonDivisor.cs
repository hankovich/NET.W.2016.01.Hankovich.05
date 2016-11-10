using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    public static class GreatestCommonDivisor
    {
        private delegate int DelegateGcd(int a, int b);

        #region EuclideanAlgorithm

        /// <summary>
        /// Find greatest common divisor with help of Euclidean Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int EuclideanAlgorithm(out TimeSpan ts, int a, int b)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = EuclideanAlgorithmHelper(a, b);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        /// <summary>
        /// Find greatest common divisor for 3 numbers with help of Euclidean Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="c">Third operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int EuclideanAlgorithm(out TimeSpan ts, int a, int b, int c)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = EuclideanAlgorithmHelper(EuclideanAlgorithmHelper(a, b), c);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        //public static int EuclideanAlgorithm(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z)
        //just a joke

        /// <summary>
        /// Find greatest common divisor with help of Euclidean Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="arrayValue"></param>
        /// <exception cref="ArgumentException">
        /// 1. If at least one of the operands is equal int.MinValue
        /// 2. If <paramref name="arrayValue"/> is null
        /// 3. If number of operands in <paramref name="arrayValue"/> is below 2</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int EuclideanAlgorithm(out TimeSpan ts, params int[] arrayValue)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = Induction(EuclideanAlgorithmHelper, arrayValue);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        #endregion

        #region BinaryAlgorithm

        /// <summary>
        /// Find greatest common divisor with help of Binary Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int BinaryAlgorithm(out TimeSpan ts, int a, int b)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = BinaryAlgorithmHelper(a, b);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        /// <summary>
        /// Find greatest common divisor for three numbers with help of Binary Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="c">Third operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int BinaryAlgorithm(out TimeSpan ts, int a, int b, int c)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = BinaryAlgorithmHelper(BinaryAlgorithmHelper(a, b), c);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        /// <summary>
        /// Find greatest common divisor with help of Binary Method
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="arrayValue"></param>
        /// <exception cref="ArgumentException">
        /// 1. If at least one of the operands is equal int.MinValue
        /// 2. If <paramref name="arrayValue"/> is null
        /// 3. If number of operands in <paramref name="arrayValue"/> is below 2</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int BinaryAlgorithm(out TimeSpan ts, params int[] arrayValue)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int tempValue = Induction(BinaryAlgorithmHelper, arrayValue);

            watch.Stop();
            ts = watch.Elapsed;

            return tempValue;
        }

        #endregion

        #region private methods

        private static int Induction(DelegateGcd gdc, params int[] arrayValue)
        {
            if (arrayValue == null)
                throw new ArgumentException($"{nameof(arrayValue)} must be not null");
            if (arrayValue.Length < 2)
                throw new ArgumentException($"{nameof(arrayValue)} must contain at least two arguements");

            int tempValue = gdc(arrayValue[0], arrayValue[1]);
            for (int i = 2; i < arrayValue.Length; i++)
            {
                if (tempValue == 1)
                {
                    return tempValue;
                }
                tempValue = gdc(tempValue, arrayValue[i]);
            }

            return tempValue;
        }

        private static int EuclideanAlgorithmHelper(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                return 0;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
                b = a % (a = b);

            return a;
        }

        private static int BinaryAlgorithmHelper(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                return 0;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            int shift;

            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;

                if (a > b)
                {
                    int t = b;
                    b = a;
                    a = t;
                }
                b = b - a;
            } while (b != 0);

            return a << shift;
        }
        #endregion
    }
}