using System.Collections.Generic;
using Xunit;

namespace Algorithms
{
    public class FactorialAlgorithm
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {0, 1};
            yield return new object[] {1, 1};
            yield return new object[] {2, 2};
            yield return new object[] {3, 6};
            yield return new object[] {4, 24};
            yield return new object[] {5, 120};
            yield return new object[] {6, 720};
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void FactorialValues(int value, int expected)
        {
            Assert.Equal(expected, Factorial(value));
        }

        private static int Factorial(int value)
        {
            return value <= 1 ? 1 : value * Factorial(value - 1);
        }
    }
}