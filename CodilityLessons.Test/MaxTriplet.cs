using System;
using System.Collections.Generic;
using System.Text;

namespace Xtremax.Test
{
    public class MaxTriplet
    {
        public static MaxTriplet Instance { get; } = new MaxTriplet();

        private MaxTriplet() { }

        public int Solution(int[] A)
        {
            int maxTriplet = int.MinValue;
            for (int i = 0; i < A.Length - 2; i++)
            {
                for (int j = i + 1; j < A.Length - 1; j++)
                {
                    for (int k = j + 1; k < A.Length; k++)
                    {
                        int currentTriplet = A[i] * A[j] * A[k];
                        if (currentTriplet > maxTriplet)
                            maxTriplet = currentTriplet;
                    }
                }
            }

            return maxTriplet;
        }
    }
}
