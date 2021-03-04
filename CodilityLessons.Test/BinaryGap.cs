using System;
using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// A binary gap within a positive integer N is any maximal sequence of consecutive zeros 
    /// that is surrounded by ones at both ends in the binary representation of N
    /// </summary>
    public class BinaryGap
    {
        public static BinaryGap Instance { get; } = new BinaryGap();

        private BinaryGap() { }

        public int Solution(int N)
        {
            var binaryArray = Convert.ToString(N, 2);
            int maxGapCount = 0;
            int gapCount = 0;
            for (int i = 0; i < binaryArray.Length; i++)
            {
                if (i == binaryArray.Length - 1 && binaryArray[i] == '0') // we are at the last element and is '0'. so the count is not valid
                    continue;
                else if (binaryArray[i] == '0') // never a leading zero
                    gapCount++;
                else // meaning we found '1'
                {
                    if (gapCount > maxGapCount) maxGapCount = gapCount;

                    gapCount = 0;
                }
            }

            return maxGapCount;
        }
    }

    public class BinaryGapTest
    {


        [Theory]
        [InlineData(9, 2)]
        [InlineData(529, 4)]
        [InlineData(20, 1)]
        [InlineData(15, 0)]
        [InlineData(32, 0)]
        [InlineData(1041, 5)]
        [InlineData(561892, 3)]
        public void BinaryGap_Valid(int value, int expectedResult)
        {
            // act
            var actualResult = BinaryGap.Instance.Solution(value);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
