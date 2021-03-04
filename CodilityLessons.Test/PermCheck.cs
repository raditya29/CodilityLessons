using System.Linq;
using Xunit;

namespace Xtremax.Test
{
    public class PermCheck
    {
        public static PermCheck Instance { get; } = new PermCheck();

        private PermCheck() { }

        public int Solution(int[] A)
        {
            int N = A.Length;
            var orderedArray = A.OrderBy(a => a);

            int i = 1;
            foreach (var element in orderedArray)
            {
                if (element != i)
                    return 0;

                i++;
            }

            return 1;
        }
    }

    public class PermCheckTest
    {
        [Theory]
        [InlineData(1, 4, 1, 3, 2)]
        [InlineData(0, 4, 1, 3)]
        public void PermCheck_Solution_Test(int expectedResult, params int[] array)
        {
            // act
            var actualResult = PermCheck.Instance.Solution(array);
            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
