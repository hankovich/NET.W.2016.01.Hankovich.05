using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace GreatestCommonDivisor.Tests
{
    [TestFixture]
    public class GreatestCommonDivisorTests
    {
        [TestCase(3, 0, 3)]
        [TestCase(4, 4, 0)]
        [TestCase(int.MaxValue >> 1, int.MaxValue - 1, int.MaxValue >> 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue + 1)]
        [TestCase(3, -3, 3)]
        [TestCase(5, -5, -10)]
        [TestCase(625, 6250, -625)]
        [Test]
        public void EuclideanAlgorithm_ab_gcdReturn(int expected, int a, int b)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclideanAlgorithm(out ts, a, b));
        }

        [TestCase(1, 6, 10, 15)]
        [TestCase(5, -5, 5, 10)]
        [TestCase(2, int.MinValue + 2, 2, int.MaxValue - 1)]
        [TestCase(20, 0, 0, 20)]
        [Test]
        public void EuclideanAlgorithm_abc_gcdReturn(int expected, int a, int b, int c)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclideanAlgorithm(out ts, a, b, c));
        }

        [TestCase(1, 6, 15, 10, 100)]
        [TestCase(2, 2, -4, 6, -8, 1024)]
        [Test]
        public void EuclideanAlgorithm_params_gcdReturn(int expected, params int[] arrayValue)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.EuclideanAlgorithm(out ts, arrayValue));
        }


        [TestCase(3, 0, 3)]
        [TestCase(4, 4, 0)]
        [TestCase(int.MaxValue >> 1, int.MaxValue - 1, int.MaxValue >> 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue + 1)]
        [TestCase(3, -3, 3)]
        [TestCase(5, -5, -10)]
        [TestCase(625, 6250, -625)]
        [Test]
        public void BinaryAlgorithm_ab_gcdReturn(int expected, int a, int b)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.BinaryAlgorithm(out ts, a, b));
        }

        [TestCase(1, 6, 10, 15)]
        [TestCase(5, -5, 5, 10)]
        [TestCase(2, int.MinValue + 2, 2, int.MaxValue - 1)]
        [Test]
        public void BinaryAlgorithm_abc_gcdReturn(int expected, int a, int b, int c)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.BinaryAlgorithm(out ts, a, b, c));
        }

        [TestCase(1, 6, 15, 10, 100)]
        [TestCase(2, 2, -4, 6, -8, 1024)]
        [Test]
        public void BinaryAlgorithm_params_gcdReturn(int expected, params int[] arrayValue)
        {
            TimeSpan ts;
            Assert.AreEqual(expected, GreatestCommonDivisor.BinaryAlgorithm(out ts, arrayValue));
        }
    }
}