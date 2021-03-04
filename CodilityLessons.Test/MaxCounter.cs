using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// you are given N counters, initially set to 0, and you have two possible operations on them:
    ///     increase(X) − counter X is increased by 1, 
    ///     max counter − all counters are set to the maximum value of any counter.
    ///     
    /// A non-empty array A of M integers is given. This array represents consecutive operations:
    ///     if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
    ///     if A[K] = N + 1 then operation K is max counter.
    /// </summary>
    public class MaxCounter
    {
        public static MaxCounter Instance { get; } = new MaxCounter();

        private MaxCounter() { }

        public int[] Solution(int N, params int[] A)
        {
            int condition = N + 1;
            int currentMax = 0;
            int lastUpdate = 0;
            int[] countersArray = new int[N];

            for (int iii = 0; iii < A.Length; iii++)
            {
                int currentValue = A[iii];
                if (currentValue == condition)
                {
                    lastUpdate = currentMax;
                }
                else
                {
                    int position = currentValue - 1;
                    if (countersArray[position] < lastUpdate)
                        countersArray[position] = lastUpdate + 1;
                    else
                        countersArray[position]++;

                    if (countersArray[position] > currentMax)
                    {
                        currentMax = countersArray[position];
                    }
                }

            }

            for (int iii = 0; iii < N; iii++)
            {
                if (countersArray[iii] < lastUpdate)
                    countersArray[iii] = lastUpdate;
            }

            return countersArray;
        }
    }

    public class MaxCounterTest
    {
        [Theory]
        [InlineData(5, 3, 4, 4, 6, 1, 4, 4)]
        public void OptimumMaxCounter_Validated(int n, params int[] a)
        {
            // act
            var actualResult = MaxCounter.Instance.Solution(n, a);
            var expectedResult = new int[] { 3, 2, 2, 4, 2 };

            // assert
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i]);
            }

        }
    }
}
