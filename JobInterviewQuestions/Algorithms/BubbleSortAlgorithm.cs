using Xunit;

namespace Algorithms
{
    public class BubbleSortAlgorithm
    {
        private readonly int[] _input = {99827, 12, 453, 1201, 999, 4300, 23, 4323};
        private readonly int[] _expected = {12, 23, 453, 999, 1201, 4300, 4323, 99827};

        private static int[] BubbleSort(int[] input)
        {
            var numberOfIterations = input.Length - 1;

            for (var x = 0; x < numberOfIterations; x++)
            for (var i = 0; i < numberOfIterations; i++)
            {
                if (input[i] <= input[i + 1]) continue;

                var value = input[i];
                input[i] = input[i + 1];
                input[i + 1] = value;
            }

            return input;
        }

        [Fact]
        public void ArrayValuesAreOrderedAscendingly()
        {
            Assert.Equal(_expected, BubbleSort(_input));
        }
    }
}