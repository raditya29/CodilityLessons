using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Xtremax.Test
{
    public class TapeEquilibrium
    {
        public static TapeEquilibrium Instance { get; } = new TapeEquilibrium();

        private TapeEquilibrium() { }

        public int Solution(int[] A)
        {
            int N = A.Length;
            long sumLeft = A[0];

            long sumRight = 0;
            for (int i = 1; i < N; i++)
                sumRight += A[i];

            long minimalDifference = Math.Abs(sumLeft - sumRight);

            for (int P = 1; P < N; P++)
            {
                if (Math.Abs(sumLeft - sumRight) < minimalDifference)
                    minimalDifference = Math.Abs(sumLeft - sumRight);

                sumLeft += A[P];
                sumRight -= A[P];
            }

            return (int)minimalDifference;
        }
    }

    public class TapeEquilibriumTest
    {
        [Theory]
        [InlineData(2000, -1000, 1000)]
        [InlineData(0, -1000, -1000)]
        [InlineData(1, 3, 1, 2, 4, 3)]
        [InlineData(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        public void Solution_Valid(int expectedResult, params int[] array)
        {
            // act
            var actualResult = TapeEquilibrium.Instance.Solution(array);

            //
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
