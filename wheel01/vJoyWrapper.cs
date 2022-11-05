﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vJoyInterfaceWrap;

namespace wheel01
{
    internal class VJoyWrapper
    {
        public const uint deviceId = 1;

        public const int maxValue = 32767;
        public const int minValue = 0;
        public const int valueRange = maxValue - minValue + 1;
        public const int midValue = valueRange / 2;

        static public vJoy device;

        static FFBPType fFBPType;
        static vJoy.FFB_EFF_CONSTANT constantEffect;
        static public int ffbValue = 0;

        static public void Init()
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

            Logger.App(String.Format("Acquired: vJoy device number {0}", deviceId));
            Logger.App(String.Format("FFB is {0}", Convert.ToString(device.IsDeviceFfb(deviceId))));

            device.ResetVJD(deviceId);

            device.FfbRegisterGenCB(OnEffectObj, null);
        }

        static public bool SetAxis(int value, HID_USAGES axis)
        {
            return device.SetAxis(value, deviceId, axis);
        }

        /// <summary>
        /// Will forward FFB value and save it to <c>ffbValue</c>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userData"></param>
        static void OnEffectObj(IntPtr data, object userData)
        {
            device.Ffb_h_Type(data, ref fFBPType);

            switch (fFBPType)
            {
                case FFBPType.PT_CONSTREP:
                    device.Ffb_h_Eff_Constant(data, ref constantEffect);
                    ffbValue = constantEffect.Magnitude;
                    break;
                default:
                    // Console.WriteLine(fFBPType);
                    break;
            }
        }
    }
}
