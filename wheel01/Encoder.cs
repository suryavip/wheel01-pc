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

        public static int beforeOffsetValue = 0;

        public static int currentValue => beforeOffsetValue - offsetToZero;

        public static int offsetToZero = 0;

        public static void SetAsZero()
        {
            offsetToZero = beforeOffsetValue;
        }
    }
}
