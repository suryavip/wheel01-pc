using ScpPad2vJoy.vJ;
using ScpPad2vJoy.vJ.FFB.Effect;
using ScpPad2vJoy.vJ.FFB.Effect.Periodic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using vJoyInterfaceWrap;

namespace wheel01
{
    internal class VJoyFfbHandler
    {
        public enum DeviceState
        {
            Deactivated,
            AwaitingDeactivation,
            Active
        }

        public const int ERROR_SUCCESS = 0;
        public const byte MAX_BLOCKS = 255; // (2^7) - 1; //7bits for EBI

        public static object vibThreadSentry = new object();
        public static volatile bool HaltVibThread = false;
        public static System.Threading.Thread eTh = null;

        public static volatile DeviceState DeviceActive = DeviceState.Deactivated;
        public static Dictionary<byte, BaseEffectBlock> EffectBlocks = new Dictionary<byte, BaseEffectBlock>();
        public static bool[] LoadedBlocks = new bool[MAX_BLOCKS];
        public static volatile bool DevicePaused = false;
        public static volatile float DeviceGain = 1.0F;

        public static void AddBlock(byte index, BaseEffectBlock anObj)
        {
            if (EffectBlocks.ContainsKey(1))
            {
                Logger.App("HACK, EFFECT OVERWRITTEN");
                EffectBlocks.Remove(1);
            }
            LoadedBlocks[index] = true;
            EffectBlocks.Add(index, anObj);
        }

        public static void RemoveBlock(byte index)
        {
            if (EffectBlocks.ContainsKey((byte)index))
            {
                EffectBlocks.Remove((byte)index);
            }
            LoadedBlocks[index] = false;
        }

        public static void ClearBlocks()
        {
            EffectBlocks.Clear();
            LoadedBlocks = new bool[MAX_BLOCKS];
            LoadedBlocks[0] = true; // Never use 0 as it is for failed allocations
        }

        public static byte NextKey()
        {
            Logger.App("Hack, Setting Block to 1");
            return 1;
            //byte newKey = 0;
            //for (byte i = 1; i < MAX_BLOCKS; i++)
            //{
            //    if (!LoadedBlocks[i])
            //    {
            //        newKey = i;
            //        break;
            //    }
            //}
            //return newKey;
        }

        /// <summary>
        /// Will forward FFB value and save it to <c>ffbValue</c>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userData"></param>
        public static void OnEffectObj(IntPtr data, object userData)
        {
            FFBPType fFBPType = (FFBPType)0;
            int effectBlockIndex = -1;

            VJoyWrapper.device.Ffb_h_Type(data, ref fFBPType);
            VJoyWrapper.device.Ffb_h_EBI(data, ref effectBlockIndex);

            switch (fFBPType)
            {
                case FFBPType.PT_EFFREP:
                    vJoy.FFB_EFF_REPORT effectParam = new vJoy.FFB_EFF_REPORT();
                    if (VJoyWrapper.device.Ffb_h_Eff_Report(data, ref effectParam) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Effect Param");
                        return;
                    }
                    EffectBlocks[(byte)effectBlockIndex].ffbHeader = effectParam;
                    break;

                case FFBPType.PT_ENVREP:
                    vJoy.FFB_EFF_ENVLP envEffect = new vJoy.FFB_EFF_ENVLP();
                    if (VJoyWrapper.device.Ffb_h_Eff_Envlp(data, ref envEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Envelope Effect");
                        return;
                    }
                    EffectBlocks[(byte)effectBlockIndex].SecondaryEffectData(envEffect);
                    break;

                case FFBPType.PT_CONDREP:
                    vJoy.FFB_EFF_COND condEffect = new vJoy.FFB_EFF_COND();
                    if (VJoyWrapper.device.Ffb_h_Eff_Cond(data, ref condEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Conditional Effect");
                        return;
                    }
                    break;

                case FFBPType.PT_PRIDREP:
                    vJoy.FFB_EFF_PERIOD perEffect = new vJoy.FFB_EFF_PERIOD();
                    if (VJoyWrapper.device.Ffb_h_Eff_Period(data, ref perEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Periodic Effect");
                        return;
                    }
                    EffectBlocks[(byte)effectBlockIndex].PrimaryEffectData(perEffect);
                    break;

                case FFBPType.PT_CONSTREP:
                    vJoy.FFB_EFF_CONSTANT constEffect = new vJoy.FFB_EFF_CONSTANT();
                    if (VJoyWrapper.device.Ffb_h_Eff_Constant(data, ref constEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Constant Effect");
                        return;
                    }
                    EffectBlocks[(byte)effectBlockIndex].PrimaryEffectData(constEffect);
                    break;

                case FFBPType.PT_RAMPREP:
                    vJoy.FFB_EFF_RAMP rampEffect = new vJoy.FFB_EFF_RAMP();
                    if (VJoyWrapper.device.Ffb_h_Eff_Ramp(data, ref rampEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Ramp Effect");
                        return;
                    }
                    EffectBlocks[(byte)effectBlockIndex].PrimaryEffectData(rampEffect);
                    break;

                case FFBPType.PT_EFOPREP:
                    vJoy.FFB_EFF_OP effect_OP = new vJoy.FFB_EFF_OP();
                    if (VJoyWrapper.device.Ffb_h_EffOp(data, ref effect_OP) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Effect OP");
                        return;
                    }
                    switch (effect_OP.EffectOp)
                    {
                        case FFBOP.EFF_START:
                            lock (vibThreadSentry)
                            {
                                Logger.App("Effect OP: Start");
                                EffectBlocks[(byte)effectBlockIndex].Start(effect_OP.LoopCount);
                            }
                            break;
                        case FFBOP.EFF_STOP:
                            lock (vibThreadSentry)
                            {
                                Logger.App("Effect OP: Stop");
                                EffectBlocks[(byte)effectBlockIndex].Stop();
                            }
                            break;
                        default:
                            Logger.App("Effect OP: Unkown command");
                            break;
                    }
                    break;

                case FFBPType.PT_BLKFRREP:
                    Logger.App("Free Block");
                    lock (vibThreadSentry)
                    {
                        RemoveBlock((byte)effectBlockIndex);
                    }
                    break;

                case FFBPType.PT_CTRLREP:
                    FFB_CTRL control = (FFB_CTRL)0;
                    if (VJoyWrapper.device.Ffb_h_DevCtrl(data, ref control) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Dev Control");
                        return;
                    }
                    //byte[] rawP2 = new byte[0];
                    //int len2 = 0;
                    //uint transfertype2 = 0;
                    //joystick.Ffb_h_Packet(data, ref transfertype2, ref len2, ref rawP2);
                    //Trace.WriteLine(String.Format("DevControlThing : {0}", BitConverter.ToUInt16(rawP2, len2 - 2)));
                    switch (control)
                    {
                        case FFB_CTRL.CTRL_ENACT:
                            Logger.App("Enable all actuators (Not Supported)");
                            break;
                        case FFB_CTRL.CTRL_DISACT:
                            Logger.App("Disable all actuators (Not Supported)");
                            break;
                        case FFB_CTRL.CTRL_STOPALL:
                            Logger.App("Stop All Effects");
                            //Set All To Zero + Pause
                            foreach (BaseEffectBlock peffect in EffectBlocks.Values)
                            {
                                peffect.Stop();
                            }
                            break;
                        case FFB_CTRL.CTRL_DEVRST:
                            Logger.App("Reset Device");
                            lock (vibThreadSentry)
                            {
                                ClearBlocks();
                                DevicePaused = false;
                            }
                            break;
                        case FFB_CTRL.CTRL_DEVPAUSE:
                            Logger.App("Pause all effects");
                            foreach (BaseEffectBlock peffect in EffectBlocks.Values)
                            {
                                peffect.DevPause();
                            }
                            DevicePaused = true;
                            break;
                        case FFB_CTRL.CTRL_DEVCONT:
                            Logger.App("Resume all effects paused by DevPause");
                            foreach (BaseEffectBlock peffect in EffectBlocks.Values)
                            {
                                peffect.DevPause();
                            }
                            DevicePaused = false;
                            break;
                        default:
                            Logger.App("Unkown Command");
                            break;
                    }
                    break;

                case FFBPType.PT_GAINREP:
                    byte gain = 1;
                    if (VJoyWrapper.device.Ffb_h_DevGain(data, ref gain) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read Dev Gain Command");
                        return;
                    }
                    Logger.App(String.Format("Gain Set : {0}", gain));
                    DeviceGain = (float)gain / vJoyConstants.EFFECT_MAX_GAIN;
                    break;

                case FFBPType.PT_NEWEFREP:
                    FFBEType nextEffect = (FFBEType)0;
                    if (VJoyWrapper.device.Ffb_h_EffNew(data, ref nextEffect) != ERROR_SUCCESS)
                    {
                        Logger.App("Error: Unable read new effect");
                        return;
                    }
                    Logger.App(string.Format("Incomming Effect : {0}", nextEffect.ToString()));
                    //Add + Load Block
                    //Use effecct type as an index
                    byte free_ebi = NextKey();
                    if (free_ebi != 0)
                    {
                        BaseEffectBlock newBlock;
                        switch (nextEffect)
                        {
                            //ET_NONE
                            case FFBEType.ET_CONST:
                                newBlock = new ConstEffectBlock();
                                break;
                            case FFBEType.ET_RAMP:
                                newBlock = new RampEffectBlock();
                                break;
                            case FFBEType.ET_SQR:
                                newBlock = new SquareEffectBlock();
                                break;
                            case FFBEType.ET_SINE:
                                newBlock = new SineEffectBlock();
                                break;
                            case FFBEType.ET_TRNGL:
                                newBlock = new TrangleEffectBlock();
                                break;
                            case FFBEType.ET_STUP:
                                newBlock = new SawUpEffectBlock();
                                break;
                            case FFBEType.ET_STDN:
                                newBlock = new SawDownEffectBlock();
                                break;
                            default:
                                Logger.App(String.Format("Unhandled future Eff: {0}", nextEffect));
                                newBlock = new NullEffectBlock();
                                break;
                        }
                        if (newBlock != null)
                        {
                            newBlock.m_effectType = nextEffect;
                            //TODO, If Blockload support arrives
                            //Do AddBlock/ebi selection @ Blockload
                            lock (vibThreadSentry)
                            {
                                AddBlock(free_ebi, newBlock);
                            }
                        }
                    }
                    break;

                default:
                    Logger.App(String.Format("Unhandled Eff: {0}", fFBPType));
                    break;
            }
        }

        public static void Start()
        {
            Logger.App("Starting thread...");
            HaltVibThread = false;
            eTh = new System.Threading.Thread(EffectThread);
            eTh.Start();
            DeviceActive = DeviceState.Active;
            Logger.App("Thread started");
        }

        public static void Stop()
        {
            Logger.App("Deactivating device...");
            DeviceActive = DeviceState.AwaitingDeactivation;
            HaltVibThread = true;
            eTh.Join();
            Logger.App("Device deactivated");
        }

        private static void EffectThread()
        {
            while (HaltVibThread == false)
            {
                if (DeviceActive == DeviceState.Deactivated || DeactivateIfNeeded((uint)1))
                {
                    //Don't send VibCommands to from
                    //inactive devices
                    continue;
                }

                EffectReturnValue VibValues = new EffectReturnValue(0, 0);
                if (!DevicePaused)
                {
                    List<BaseEffectBlock> EffectsCopy = new List<BaseEffectBlock>();
                    lock (vibThreadSentry)
                    {
                        foreach (BaseEffectBlock eff in EffectBlocks.Values)
                        {
                            EffectsCopy.Add(eff);
                        }
                    }
                    //Appy Gain before or after summation?
                    foreach (BaseEffectBlock eff in EffectsCopy)
                    {
                        if (eff.isPaused)
                        {
                            continue;
                        }
                        VibValues += eff.Effect();
                    }
                }

                VibValues.MotorLeft = (VibValues.MotorLeft * DeviceGain);
                VibValues.MotorRight = (VibValues.MotorRight * DeviceGain);
                VJoyWrapper.ffbValue = (int)VibValues.MotorLeft;
            }
            System.Threading.Thread.Sleep(5);

            DeactivateIfNeeded((uint)1);
        }

        private static bool DeactivateIfNeeded(uint id)
        {
            if (DeviceActive == DeviceState.AwaitingDeactivation)
            {
                DeviceActive = DeviceState.Deactivated;
                //Send Zero Vibration
                //To stop left over effect
                VJoyWrapper.ffbValue = 0;
                //if (VibrationCommand != null)
                //{
                //    VibrationCommand(id, new EffectReturnValue(0, 0));
                    return true;
                //}
            }
            return false;
        }
    }
}
