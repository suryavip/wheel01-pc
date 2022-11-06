using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Encoder
    {
        public const int maxValue = 4095;
        public const int minValue = 0;
        public const int valueRange = maxValue - minValue + 1;
        public const int bottomRangeThreshold = minValue + 64;
        public const int topRangeThreshold = maxValue - 64;

        public static int currentValue = 0;
        public static int currentOverRotation = 0;

        public static void UpdateValue(int newValue)
        {
            if (newValue < bottomRangeThreshold && currentValue > topRangeThreshold)
            {
                // overlap
                currentOverRotation++;
            }
            else if (newValue > topRangeThreshold && currentValue < bottomRangeThreshold)
            {
                // underlap
                currentOverRotation--;
            }

            currentValue = newValue;
        }

        public static int CurrentMultiRotationValue()
        {
            return (valueRange * currentOverRotation) + currentValue;
        }
    }
}
