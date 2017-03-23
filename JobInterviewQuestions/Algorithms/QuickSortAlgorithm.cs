using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class QuickSortAlgorithm
    {
        private readonly int[] _input = {99829, 12, 4300, 453, 67, 999, 1201, 53, 4310};
        private readonly int[] _expected = {12, 53, 67, 453, 999, 1201, 4300, 4310, 99829};

        private static int[] QuickSort(IReadOnlyCollection<int> array)
        {
            var maxIndex = array.Count - 1;
            return SortSlice(array.ToArray(), 0, maxIndex);
        }

        private static int[] SortSlice(int[] input, int startIndex, int endIndex)
        {
            var indexMovingRight = startIndex;
            var indexMovingLeft = endIndex;
            var middleValue = input[(startIndex + endIndex) / 2];

            while (indexMovingRight < indexMovingLeft)
            {
                while (input[indexMovingRight] < middleValue) indexMovingRight++;
                while (input[indexMovingLeft] > middleValue) indexMovingLeft--;

                var tmp = input[indexMovingRight];
                input[indexMovingRight] = input[indexMovingLeft];
                input[indexMovingLeft] = tmp;

                indexMovingRight++;
                indexMovingLeft--;
            }

            if (startIndex < indexMovingLeft) SortSlice(input, startIndex, indexMovingLeft);
            if (indexMovingRight < endIndex) SortSlice(input, indexMovingRight, endIndex);

            return input;
        }

        [Fact]
        public void ArrayValuesAreOrderedAscendingly()
        {
            var quickSort = QuickSort(_input);
            Assert.Equal(_expected, quickSort);
        }
    }
}