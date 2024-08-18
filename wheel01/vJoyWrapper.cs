using System;
using vJoyInterfaceWrap;

namespace wheel01
{
    internal class VJoyWrapper
    {
        public const uint deviceId = 1;

        public const int maxAxisValue = 32767;
        public const int minAxisValue = 0;
        public const int axisValueRange = maxAxisValue - minAxisValue + 1;
        public const int midAxisValue = (axisValueRange / 2) - 1;

        public const int maxFfbValue = 10000;
        public const int minFfbValue = -10000;

        public const int softLockThreshold = 500;

        public static vJoy device;

        public static vJoy.JoystickState state;

        static FFBPType fFBPType;

        static FFBEType newEffectReport;
        static FFB_CTRL controlReport;
        static vJoy.FFB_EFF_OP operationReport;
        static vJoy.FFB_EFF_REPORT effectReport;
        static vJoy.FFB_EFF_COND conditionReport;
        static vJoy.FFB_EFF_CONSTANT constantReport;

        static DateTime lastEffect = DateTime.Now;

        public static void Init()
        {
            Logger.App("Initializing vJoy device...");

            device = new vJoy();

            Logger.App("Vendor: " + device.GetvJoyManufacturerString());
            Logger.App("Product: " + device.GetvJoyProductString());
            Logger.App("Version Number: " + device.GetvJoySerialNumberString());

            VjdStat status = device.GetVJDStatus(deviceId);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    break;
                case VjdStat.VJD_STAT_FREE:
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Logger.App("Device is already owned by another feeder.");
                    return;
                case VjdStat.VJD_STAT_MISS:
                    Logger.App("Device is not installed or disabled.");
                    return;
                default:
                    Logger.App("Device general error.");
                    return;
            }
            if (!device.AcquireVJD(deviceId))
            {
                Logger.App("Failed to acquire device.");
                return;
            }

            Logger.App(string.Format("Acquired: vJoy device number {0}", deviceId));
            Logger.App(string.Format("FFB is {0}", Convert.ToString(device.IsDeviceFfb(deviceId))));

            device.ResetVJD(deviceId);

            device.FfbRegisterGenCB(OnEffectObj, null);
        }

        public static void UpdateState()
        {
            device.UpdateVJD(deviceId, ref state);
        }

        /// <summary>
        /// Will forward FFB value and save it to <c>ffbValue</c>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userData"></param>
        static void OnEffectObj(IntPtr data, object userData)
        {
            device.Ffb_h_Type(data, ref fFBPType);

            int effectBlockIndex = -2;
            device.Ffb_h_EBI(data, ref effectBlockIndex);

            switch (fFBPType)
            {
                case FFBPType.PT_CONSTREP:
                    device.Ffb_h_Eff_Constant(data, ref constantReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}, {2}",
                    //    fFBPType,
                    //    effectBlockIndex,
                    //    constantReport.Magnitude
                    //));
                    break;

                case FFBPType.PT_NEWEFREP:
                    device.Ffb_h_EffNew(data, ref newEffectReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}",
                    //    fFBPType,
                    //    newEffectReport
                    //));
                    break;

                case FFBPType.PT_CTRLREP:
                    device.Ffb_h_DevCtrl(data, ref controlReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}",
                    //    fFBPType,
                    //    controlReport
                    //));
                    break;

                case FFBPType.PT_EFFREP:
                    device.Ffb_h_Eff_Report(data, ref effectReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}",
                    //    fFBPType,
                    //    effectBlockIndex,
                    //    effectReport.Gain,
                    //    effectReport.TrigerRpt,
                    //    effectReport.Direction,
                    //    effectReport.Duration,
                    //    effectReport.DirX,
                    //    effectReport.DirY,
                    //    effectReport.EffectType,
                    //    effectReport.Polar,
                    //    effectReport.SamplePrd,
                    //    effectReport.TrigerBtn,
                    //    effectReport.TrigerRpt
                    //));
                    break;

                case FFBPType.PT_EFOPREP:
                    device.Ffb_h_EffOp(data, ref operationReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}, {2}, {3}",
                    //    fFBPType,
                    //    effectBlockIndex,
                    //    operationReport.EffectOp,
                    //    operationReport.LoopCount
                    //));
                    break;

                case FFBPType.PT_CONDREP:
                    device.Ffb_h_Eff_Cond(data, ref conditionReport);
                    //Logger.App(string.Format(
                    //    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                    //    fFBPType,
                    //    effectBlockIndex,
                    //    conditionReport.CenterPointOffset,
                    //    conditionReport.PosCoeff,
                    //    conditionReport.NegCoeff,
                    //    conditionReport.PosSatur,
                    //    conditionReport.NegSatur,
                    //    conditionReport.DeadBand,
                    //    conditionReport.isY
                    //));
                    break;

                default:
                    //Logger.App(string.Format("Eff: {0} :{1}", fFBPType, effectBlockIndex));
                    break;
            }

            lastEffect = DateTime.Now;
        }

        public static double CalculateFFB()
        {
            var currentTime = DateTime.Now;
            var time = (currentTime - lastEffect).Duration().TotalMilliseconds;
            if (time > 500) return 0; // to make sure discard old effect that hasn't been cleared by game

            double ffbOutput = constantReport.Magnitude;
            return ffbOutput;
        }
    }
}
