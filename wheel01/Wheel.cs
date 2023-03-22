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

        public int hwValueOffset = 0;
        public int hwOverRotationOffset = 0;
        public int currentHwValue = 0;
        public int currentHwOverRotationValue = 0;
        public bool flipDirection = true;
        public double rotationRange = 3;

        public int CurrentHwMultiRotationValue()
        {
            return ((maxHwValue + 1) * (currentHwOverRotationValue - hwOverRotationOffset)) + (currentHwValue - hwValueOffset);
        }

        public int CalculateAxisValue()
        {
            double fullRange = hwValueRange * rotationRange;
            double mult = VJoyWrapper.axisValueRange / fullRange;

            double multipliedToVJoyScale = CurrentHwMultiRotationValue() * mult;
            double centeredOnVJoyScale = multipliedToVJoyScale + VJoyWrapper.midAxisValue;

            // clamping
            if (centeredOnVJoyScale > VJoyWrapper.maxAxisValue) centeredOnVJoyScale = VJoyWrapper.maxAxisValue;
            if (centeredOnVJoyScale < VJoyWrapper.minAxisValue) centeredOnVJoyScale = VJoyWrapper.minAxisValue;

            // apply flip
            if (flipDirection)
            {
                centeredOnVJoyScale /= -1;
                centeredOnVJoyScale += VJoyWrapper.maxAxisValue;
            }

            return (int)centeredOnVJoyScale;
        }
    }
}
