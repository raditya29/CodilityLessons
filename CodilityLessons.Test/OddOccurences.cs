using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xtremax.Test
{
    public class OddOccurences
    {
        public static OddOccurences Instance { get; } = new OddOccurences();

        private OddOccurences() { }

        public int Solution(int[] A)
        {
            Dictionary<int, int> elementCount = new Dictionary<int, int>();

            foreach (var element in A)
            {
                if (elementCount.ContainsKey(element))
                    elementCount[element]++;
                else
                    elementCount.Add(element, 1);
            }

            return elementCount.First(pair => (pair.Value % 2) != 0).Key;
        }
    }

    public class OddOccurencesTest
    {
        [Theory]
        [InlineData(7, 9, 3, 9, 3, 9, 7, 9)]
        public void OddOccurences_Valid(int expectedResult, params int[] array)
        {
            // act
            var actualResult = OddOccurences.Instance.Solution(array);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
