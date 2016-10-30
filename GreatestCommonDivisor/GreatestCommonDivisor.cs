﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    public static class GreatestCommonDivisor
    {
        #region EuclideanAlgorithm
        
        /// <summary>
        /// Find greatest common divisor with help of Euclidean Method
        /// </summary>
        /// <param name="ts">Out variable for time</param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int? EuclideanAlgorithm(out TimeSpan ts, int? a, int? b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (!a.HasValue || !b.HasValue || (a == 0 && b == 0))
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                return null;
            }

            a = AbsForNullableInt(a);
            b = AbsForNullableInt(b);

            while (b != 0)
                b = a%(a = b);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            return a;
        }

        //public static int? EuclideanAlgorithm(int? a, int? b, int? c, int? d, int? e, int? f, int? g, int? h, int? i, int? j, int? k, int? l, int? m, int? n, int? o, int? p, int? q, int? r, int? s, int? t, int? u, int? v, int? w, int? x, int? y, int? z)
        //just a joke

        /// <summary>
        /// Find greatest common divisor with help of Euclidean Method
        /// </summary>
        /// <param name="ts">Out variable for time</param>
        /// <param name="arrayValue"></param>
        /// <exception cref="ArgumentException">
        /// 1. If at least one of the operands is equal int.MinValue
        /// 2. If <paramref name="arrayValue"/> is null
        /// 3. If number of operands in <paramref name="arrayValue"/> is below 2</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int? EuclideanAlgorithm(out TimeSpan ts, params int?[] arrayValue)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan temp;
            int? tempValue = Induction(out temp, true, arrayValue);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            return tempValue;
        }

        #endregion

        #region BinaryAlgorithm

        /// <summary>
        /// Find greatest common divisor with help of Binary Method
        /// </summary>
        /// <param name="ts">Out variable for time</param>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <exception cref="ArgumentException">If at least one of the operands is equal int.MinValue</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int? BinaryAlgorithm(out TimeSpan ts, int? a, int? b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (!a.HasValue || !b.HasValue || (a == 0 && b == 0))
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                return null;
            }

            a = AbsForNullableInt(a);
            b = AbsForNullableInt(b);

            int shift;

            if (a == 0)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                return b;
            }
            if (b == 0)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
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
                    int? t = b;
                    b = a;
                    a = t;
                }
                b = b - a;
            } while (b != 0);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            return a << shift;
        }

        /// <summary>
        /// Find greatest common divisor with help of Binary Method
        /// </summary>
        /// <param name="ts">Out variable for time</param>
        /// <param name="arrayValue"></param>
        /// <exception cref="ArgumentException">
        /// 1. If at least one of the operands is equal int.MinValue
        /// 2. If <paramref name="arrayValue"/> is null
        /// 3. If number of operands in <paramref name="arrayValue"/> is below 2</exception>
        /// <returns>Greatest common divisor or null if GCD is undefined</returns>
        public static int? BinaryAlgorithm(out TimeSpan ts, params int?[] arrayValue)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan temp;
            int? tempValue = Induction(out temp, false, arrayValue);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            return tempValue;
        }

        #endregion

        #region private methods
        
        /// <summary>
        /// Find absolute value for int?. Value must inhare (int.MinValue, int.MaxValue]
        /// </summary>
        /// <param name="value">Operand to find absolute value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Absolute value of <paramref name="value"/>If operand is equal int.MinValue</returns>
        private static int? AbsForNullableInt(int? value)
        {
            if (value == int.MinValue)
                throw new ArgumentException($"{nameof(value)} must be greater than int.MinValue");
            return (value >= 0) ? value : -value;
        }


        private static int? Induction(out TimeSpan ts, bool euclidean, params int?[] arrayValue)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan temp;

            if (arrayValue == null)
                throw new ArgumentException($"{nameof(arrayValue)} must be not null");
            if (arrayValue.Length < 2)
                throw new ArgumentException($"{nameof(arrayValue)} must contain at least two arguements");

            int?[] array = arrayValue.Distinct().ToArray();

            if (array.Length == 1)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = 0;
            }

            int? tempValue = euclidean ? EuclideanAlgorithm(out temp, array[0], array[1]) : BinaryAlgorithm(out temp, array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                if (tempValue == null)
                {
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    return tempValue;
                }
                tempValue = euclidean ? EuclideanAlgorithm(out temp, tempValue, array[i]) : BinaryAlgorithm(out temp, tempValue, array[i]);
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            return tempValue;
        }
        #endregion
    }
}