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

        public static int currentValue = 0;
    }
}
