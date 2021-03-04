using System.Linq;
using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
    /// A could be unsorted.
    /// </summary>
    public class SmallestNotIncludedInteger
    {
        public static SmallestNotIncludedInteger Instance { get; } = new SmallestNotIncludedInteger();

        private SmallestNotIncludedInteger() { }

        public int Solution(int[] array)
        {
            var temp = array.Where(e => e > 0).Distinct().OrderBy(e => e)
                        .Select((element, index) => new { Element = element, Number = index + 1 });
            if (!temp.Any())
                return 1;

            var smallest = temp.FirstOrDefault(p => p.Element > p.Number)?.Number; ;

            return smallest ?? temp.Last().Element + 1;
        }
    }

    public class SmallestNotIncludedIntegerTest
    {
        [Theory]
        [InlineData(1, -1, -3)]
        [InlineData(5, 1, 3, 6, 4, 1, 2)]
        [InlineData(6, 5, 4, 3, 2, 1)]
        public void Smallest_Integer_Greater_Than_Zero_Not_Included_In_Array(int expectedResult, params int[] arrayValues)
        {
            // act
            var actualResult = SmallestNotIncludedInteger.Instance.Solution(arrayValues);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
