using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// A small frog wants to get to the other side of the road. 
    /// The frog is currently located at position X and wants to get to a position greater than or equal to Y. 
    /// The small frog always jumps a fixed distance, D.
    /// 
    /// Count the minimal number of jumps that the small frog must perform to reach its target.
    /// 
    /// given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y
    /// </summary>
    public class FrogJump
    {
        public static FrogJump Instance { get; } = new FrogJump();

        private FrogJump() { }

        public int Solution(int X, int[] A)
        {
            int N = A.Length;
            Dictionary<int, bool> positionAppears = new Dictionary<int, bool>();
            for (int i = 1; i < X + 1; i++)
                positionAppears.Add(i, false);

            for (int i = 0; i < N; i++)
            {
                var inSecond = A[i];
                if (!positionAppears[inSecond])
                    positionAppears[inSecond] = true;

                if (positionAppears.All(p => p.Value))
                    return i;
            }

            return -1;
        }
    }

    public class FrogJumpTest
    {
        [Theory]
        [InlineData(6, 5, 1, 3, 1, 4, 2, 3, 5, 4)]
        public void FrogJump_Solution_Validate(int expectedResult, int x, params int[] array)
        {
            // act
            var actualResult = FrogJump.Instance.Solution(x, array);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
