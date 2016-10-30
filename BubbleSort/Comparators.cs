using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class CompareSum : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                throw new ArgumentException($"{nameof(x)} must be not null and not empty");
            if (y == null || y.Length == 0)
                throw new ArgumentException($"{nameof(y)} must be not null and not empty");
            
            if (x.Sum() > y.Sum())
                return 1;
            if (x.Sum() < y.Sum())
                return -1;
            return 0;
        }
    }

    public class CompareMax : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                throw new ArgumentException($"{nameof(x)} must be not null and not empty");
            if (y == null || y.Length == 0)
                throw new ArgumentException($"{nameof(y)} must be not null and not empty");

            if (x.Max() > y.Max()) return 1;
            if (x.Max() < y.Max()) return -1;
            return 0;
        }
    }

    public class CompareMin : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                throw new ArgumentException($"{nameof(x)} must be not null and not empty");
            if (y == null || y.Length == 0)
                throw new ArgumentException($"{nameof(y)} must be not null and not empty");

            if (x.Min() > y.Min()) return 1;
            if (x.Min() < y.Min()) return -1;
            return 0;
        }
    }
}
