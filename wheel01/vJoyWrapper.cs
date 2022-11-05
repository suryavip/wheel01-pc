using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vJoyInterfaceWrap;

namespace wheel01
{
    internal class VJoyWrapper
    {
        public const uint vJoyId = 1;

        public const int maxVJoy = 32767;
        public const int minVJoy = 0;

        static public vJoy vJoy;

        static FFBPType fFBPType;
        static vJoy.FFB_EFF_CONSTANT constantEffect;
        static public int ffbValue = 0;

        static public void InitVJoy()
        {
            Logger.AddLine("Initializing vJoy device...");

            vJoy = new vJoy();

            Logger.AddLine("Vendor: " + vJoy.GetvJoyManufacturerString());
            Logger.AddLine("Product: " + vJoy.GetvJoyProductString());
            Logger.AddLine("Version Number: " + vJoy.GetvJoySerialNumberString());

            VjdStat status = vJoy.GetVJDStatus(vJoyId);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    break;
                case VjdStat.VJD_STAT_FREE:
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Logger.AddLine("Device is already owned by another feeder.");
                    return;
                case VjdStat.VJD_STAT_MISS:
                    Logger.AddLine("Device is not installed or disabled.");
                    return;
                default:
                    Logger.AddLine("Device general error.");
                    return;
            }
            if (!vJoy.AcquireVJD(vJoyId))
            {
                Logger.AddLine("Failed to acquire device.");
                return;
            }

            Logger.AddLine(String.Format("Acquired: vJoy device number {0}", vJoyId));
            Logger.AddLine(String.Format("FFB is {0}", Convert.ToString(vJoy.IsDeviceFfb(vJoyId))));

            vJoy.ResetVJD(vJoyId);

            vJoy.FfbRegisterGenCB(OnEffectObj, null);
        }

        /// <summary>
        /// Will forward FFB value and save it to <c>ffbValue</c>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userData"></param>
        static void OnEffectObj(IntPtr data, object userData)
        {
            vJoy.Ffb_h_Type(data, ref fFBPType);

            switch (fFBPType)
            {
                case FFBPType.PT_CONSTREP:
                    vJoy.Ffb_h_Eff_Constant(data, ref constantEffect);
                    ffbValue = constantEffect.Magnitude;
                    break;
                default:
                    // Console.WriteLine(fFBPType);
                    break;
            }
        }
    }
}
