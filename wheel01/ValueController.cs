using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Wheel
    {
        public const int maxHwValue = 4095;
        public const int minHwValue = 0;
        public const int hwValueRange = maxHwValue - minHwValue + 1;

        public int currentHwValue = 0;
        public bool flipDirection = true;
        public double rotationRange = 3;

        public int CalculateAxisValue()
        {
            double fullRange = hwValueRange * rotationRange;
            double mult = VJoyWrapper.axisValueRange / fullRange;
            double beforeOffset = currentHwValue * mult;
            double afterOffset = beforeOffset + VJoyWrapper.midAxisValue;

            // clamping
            if (afterOffset > VJoyWrapper.maxAxisValue) afterOffset = VJoyWrapper.maxAxisValue;
            if (afterOffset < VJoyWrapper.minAxisValue) afterOffset = VJoyWrapper.minAxisValue;

            // apply flip
            if (flipDirection)
            {
                afterOffset /= -1;
                afterOffset += VJoyWrapper.maxAxisValue;
            }

            return (int)afterOffset;
        }
    }

    internal class Pedal
    {
        public const int maxHwValue = 4095;
        public const int minHwValue = 0;
        public const int hwValueRange = maxHwValue - minHwValue + 1;

        public int currentHwValue = 0;
        public int startHwValue = minHwValue;
        public int endHwValue = maxHwValue;

        public int CalculateAxisValue()
        {
            // clamping start and end value
            if (startHwValue < minHwValue) startHwValue = minHwValue;
            if (endHwValue > maxHwValue) endHwValue = maxHwValue;

            // make sure start and end make sense
            if (endHwValue < startHwValue) endHwValue = startHwValue;

            // clamping calibrated value
            double calibratedHwValue = currentHwValue - startHwValue;
            if (calibratedHwValue < 0) calibratedHwValue = 0;
            double maxAllowedCalibratedHwValue = endHwValue - startHwValue;
            if (calibratedHwValue > maxAllowedCalibratedHwValue) calibratedHwValue = maxAllowedCalibratedHwValue;

            // converting to axis scale
            double percentage = calibratedHwValue / maxAllowedCalibratedHwValue;
            double toAxis = VJoyWrapper.maxAxisValue * percentage;

            return (int)toAxis;
        }
    }
}
