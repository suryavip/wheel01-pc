using System;

namespace wheel01
{
    internal class MultiMap
    {
        public static double Get(double x, double[] input, double[] output)
        {
            if (input.Length != output.Length || input.Length < 2)
                throw new ArgumentException("Arrays must have the same length and at least 2 points.");

            if (x <= input[0])
                return output[0];

            if (x >= input[input.Length - 1])
                return output[output.Length - 1];

            int i = Array.BinarySearch(input, x);

            if (i >= 0)
                return output[i];

            i = ~i; // first element greater than x

            double x0 = input[i - 1];
            double x1 = input[i];
            double y0 = output[i - 1];
            double y1 = output[i];

            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
        }
    }
}
