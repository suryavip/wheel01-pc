using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
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
