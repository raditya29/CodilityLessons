using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Xtremax.Test
{
    /// <summary>
    /// An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, 
    /// and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] 
    /// (elements are shifted right by one index and 6 is moved to the first place).
    /// The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.
    /// </summary>
    public class CycleRotation
    {
        public static CycleRotation Instance { get; } = new CycleRotation();

        private CycleRotation() { }

        public int[] Solution(int[] A, int K)
        {
            if (A.Length == 0 || K == 0)
                return A;

            int[] rotatedArray = new int[A.Length];

            int shiftingNeeded = K % A.Length;
            for (int i = 0; i < A.Length; i++)
            {
                int shiftedIndex;
                if ((i + shiftingNeeded) < A.Length)
                    shiftedIndex = i + shiftingNeeded;
                else
                    shiftedIndex = i + shiftingNeeded - A.Length;

                rotatedArray[shiftedIndex] = A[i]; 
            }

            return rotatedArray;
        }
    }

    public class CycleRotationTest
    {
        [Theory]
        [ClassData(typeof(CycleRotationTestData))]
        public void CycleRotation_Valid(int[] originalArray, int k, int[] expectedRotatedArray)
        {
            // act
            var actualRotatedArray = CycleRotation.Instance.Solution(originalArray, k);

            // assert
            Assert.Equal(expectedRotatedArray, actualRotatedArray);
        }
    }

    internal class CycleRotationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new int[] { 3, 8, 9, 7, 6 }, 3, new int[] { 9, 7, 6, 3, 8 } };
            yield return new object[] { new int[] { 0, 0, 0 }, 1, new int[] { 0, 0, 0 } };
            yield return new object[] { new int[] { 1, 2, 3, 4 }, 4, new int[] { 1, 2, 3, 4 } };
            yield return new object[] { new int[] { }, 4, new int[] { } };
            yield return new object[] { new int[] { 9, 7, 5, 3 }, 0, new int[] { 9, 7, 5, 3 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
