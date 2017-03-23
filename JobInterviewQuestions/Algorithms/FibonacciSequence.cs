using System.Collections.Generic;
using Xunit;

namespace Algorithms
{
    public class FibonacciSequence
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {0, 0};
            yield return new object[] {1, 1};
            yield return new object[] {2, 1};
            yield return new object[] {3, 2};
            yield return new object[] {4, 3};
            yield return new object[] {5, 5};
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void FibonacciValues(int value, int expected)
        {
            Assert.Equal(expected, Fibonacci(value));
        }

        private static int Fibonacci(int value)
        {
            switch (value)
            {
                case 0:
                    return 0;
                case 1:
                case 2:
                    return 1;
                default:
                    return Fibonacci(value - 2) + Fibonacci(value - 1);
            }
        }
    }
}