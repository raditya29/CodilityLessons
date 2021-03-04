using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K
    /// { i : A ≤ i ≤ B, i mod K = 0 }
    /// For example, for A = 6, B = 11 and K = 2, your function should return 3, 
    /// because there are three numbers divisible by 2 within the range[6..11], namely 6, 8 and 10.
    /// </summary>
    public class CountDiv
    {
        public static CountDiv Instance { get; } = new CountDiv();

        private CountDiv() { }

        public int Solution(int A, int B, int K)
        {
            int modulusOfA = A % K;
            int firstDivisableNumber;
            if (modulusOfA == 0)
                firstDivisableNumber = A;
            else
                firstDivisableNumber = ((A / K) + 1) * K;

            if (firstDivisableNumber > B)
                return 0;

            return ((B - firstDivisableNumber) / K) + 1; // + 1 because we also count the firstDivisableNumber
        }
    }

    public class CountDivTest
    {
        [Theory]
        [InlineData(6, 11, 2, 3)]
        [InlineData(11, 345, 17, 20)]
        [InlineData(0, 1, 11, 1)]
        [InlineData(10, 10, 5, 1)]
        public void CountDiv_Valid(int a, int b, int k, int expectedResult)
        {
            // act
            var actualResult = CountDiv.Instance.Solution(a, b, k);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
