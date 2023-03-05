using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vJoyInterfaceWrap;

namespace wheel01
{
    public partial class Form1 : Form
    {
        readonly Wheel wheel = new Wheel();
        readonly Pedal accelerator = new Pedal();
        readonly Pedal brake = new Pedal();
        readonly Pedal clutch = new Pedal();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllSettings();

            SteeringRangeSlider.Value = (int)(wheel.rotationRange * 2);

            AccMinSlider.Value = accelerator.startHwValue;
            AccMaxSlider.Value = accelerator.endHwValue;

            BrkMinSlider.Value = brake.startHwValue;
            BrkMaxSlider.Value = brake.endHwValue;

            CltMinSlider.Value = clutch.startHwValue;
            CltMaxSlider.Value = clutch.endHwValue;

            Logger.App("Detecting ports...");
            String[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.App("Port list updated!");
            Logger.App("Please wait until vJoy device initialized!");
        }

        private void LoadAllSettings()
        {
            Logger.App("Load settings...");

            wheel.hwValueOffset = Properties.Settings.Default.WheelHwValueOffset;
            wheel.flipDirection = Properties.Settings.Default.WheelFlipDirection;
            wheel.rotationRange = Properties.Settings.Default.WheelRotationRange;

            accelerator.startHwValue = Properties.Settings.Default.AccStartHwValue;
            accelerator.endHwValue = Properties.Settings.Default.AccEndHwValue;

            brake.startHwValue = Properties.Settings.Default.BrkStartHwValue;
            brake.endHwValue = Properties.Settings.Default.BrkEndHwValue;

            clutch.startHwValue = Properties.Settings.Default.CltStartHwValue;
            clutch.endHwValue = Properties.Settings.Default.CltEndHwValue;
        }

        private void SaveAllSettings()
        {
            Properties.Settings.Default.WheelHwValueOffset = wheel.hwValueOffset;
            Properties.Settings.Default.WheelFlipDirection = wheel.flipDirection;
            Properties.Settings.Default.WheelRotationRange = wheel.rotationRange;

            Properties.Settings.Default.AccStartHwValue = accelerator.startHwValue;
            Properties.Settings.Default.AccEndHwValue = accelerator.endHwValue;

            Properties.Settings.Default.BrkStartHwValue = brake.startHwValue;
            Properties.Settings.Default.BrkEndHwValue = brake.endHwValue;

            Properties.Settings.Default.CltStartHwValue = clutch.startHwValue;
            Properties.Settings.Default.CltEndHwValue = clutch.endHwValue;

            Properties.Settings.Default.Save();
        }

        private void VJoyInitDelay_Tick(object sender, EventArgs e)
        {
            VJoyInitDelay.Enabled = false;
            VJoyWrapper.Init();
            SendValueToVJoy();
        }

        private void COMPortsRefreshButton_Click(object sender, EventArgs e)
        {
            Logger.App("Refreshing ports...");
            String[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.App("Port list updated!");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            string selected = COMPortsComboBox.SelectedItem.ToString();
            Logger.App("Connecting to " + selected + "...");
            try
            {
                FFBValueSender.Enabled = false;
                SerialPortController.Close();
            }
            catch (Exception ex)
            {
                Logger.App("Error closing previous connection: " + ex.Message);
            }
            finally
            {
                try
                {
                    SerialPortController.PortName = selected;
                    SerialPortController.Open();
                    FFBValueSender.Enabled = true;
                }
                catch (Exception ex)
                {
                    Logger.App("Failed connecting to " + selected + ": " + ex.Message);
                }

                Logger.App("Connected to " + selected + "!");
            }
        }

        private void DisplayUpdater_Tick(object sender, EventArgs e)
        {
            RxLogOutput.Text = Logger.rxLog;
            TxLogOutput.Text = Logger.txLog;

            int steeringAxisValue = wheel.CalculateAxisValue();
            SteeringAxisDisplayText.Text = steeringAxisValue.ToString();
            SteeringAxisDisplayBar.Value = steeringAxisValue;

            SteeringRangeDisplayText.Text = (wheel.rotationRange * 360) + "°";

            FFBValueDisplayText.Text = VJoyWrapper.ffbValue.ToString();
            FFBValueDisplayBar.Value = VJoyWrapper.ffbValue + VJoyWrapper.maxFfbValue;

            int accAxisValue = accelerator.CalculateAxisValue();
            AcceleratorAxisDisplayText.Text = accAxisValue.ToString();
            AcceleratorAxisDisplayBar.Value = accAxisValue;

            int brkAxisValue = brake.CalculateAxisValue();
            BrakeAxisDisplayText.Text = brkAxisValue.ToString();
            BrakeAxisDisplayBar.Value = brkAxisValue;

            int cltAxisValue = clutch.CalculateAxisValue();
            ClutchAxisDisplayText.Text = cltAxisValue.ToString();
            ClutchAxisDisplayBar.Value = cltAxisValue;

            LogOutput.Text = Logger.appLog;
        }

        private void CopyLogToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Logger.appLog);
        }

        private void SerialPortController_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string read = SerialPortController.ReadTo(";");
                if (read == null || read.Length == 0) return;
                Logger.Rx(read);

                if (read.StartsWith("E:"))
                {
                    OnCommandReceived(read.Substring(0, 1), read.Substring(2));
                }
            }
            catch (Exception ex)
            {
                Logger.App("Error on receiving data: " + ex.Message);
            }
        }

        private void OnCommandReceived(string command, string value)
        {
            switch (command)
            {
                case "E":
                    String[] splitted = value.Split(',');
                    wheel.currentHwValue = int.Parse(splitted[0]);
                    accelerator.currentHwValue = int.Parse(splitted[1]);
                    brake.currentHwValue = int.Parse(splitted[2]);
                    clutch.currentHwValue = int.Parse(splitted[3]);
                    SendValueToVJoy();
                    break;
            }
        }

        private void SendValueToVJoy()
        {
            VJoyWrapper.SetAxis(wheel.CalculateAxisValue(), HID_USAGES.HID_USAGE_X);
            VJoyWrapper.SetAxis(accelerator.CalculateAxisValue(), HID_USAGES.HID_USAGE_Y);
            VJoyWrapper.SetAxis(brake.CalculateAxisValue(), HID_USAGES.HID_USAGE_Z);
            VJoyWrapper.SetAxis(clutch.CalculateAxisValue(), HID_USAGES.HID_USAGE_RX);
        }

        private void SteeringRangeSlider_Scroll(object sender, EventArgs e)
        {
            wheel.rotationRange = (double)SteeringRangeSlider.Value / 2;
            Logger.App("Set steering range: " + wheel.rotationRange);
            SaveAllSettings();
        }

        private void FlipSteeringButton_Click(object sender, EventArgs e)
        {
            wheel.flipDirection = !wheel.flipDirection;
            Logger.App("Flip steering wheel: " + wheel.flipDirection);
            SaveAllSettings();
        }

        private void FFBValueSender_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SerialPortController.IsOpen == false) return;

                int val = VJoyWrapper.ffbValue;

                int steeringPosition = wheel.CalculateAxisValue();
                double bumpThreshold = 500;
                if (steeringPosition < bumpThreshold)
                {
                    double progress = (bumpThreshold - steeringPosition);
                    double percent = progress / bumpThreshold;
                    double bumpForce = percent * VJoyWrapper.minFfbValue;
                    val = (int)bumpForce;
                }

                double rightBumpThreshold = VJoyWrapper.maxAxisValue - bumpThreshold;
                if (steeringPosition > rightBumpThreshold)
                {
                    double progress = (rightBumpThreshold - steeringPosition) * -1;
                    double percent = progress / bumpThreshold;
                    double bumpForce = percent * VJoyWrapper.maxFfbValue;
                    val = (int)bumpForce;
                }

                string tosent = "F:" + val + ";";

                SerialPortController.Write(tosent);
                Logger.Tx(tosent);
            }
            catch (Exception ex)
            {
                Logger.App("Error on sending data: " + ex.Message);
                Logger.App("Connection disrupted!");
                FFBValueSender.Enabled = false;
            }
        }

        private void ResetZeroBtn_Click(object sender, EventArgs e)
        {
            wheel.hwValueOffset = wheel.currentHwValue;
            Logger.App("Steering wheel offset: " + wheel.hwValueOffset);
            SaveAllSettings();
        }

        private void AccMinSlider_Scroll(object sender, EventArgs e)
        {
            accelerator.startHwValue = AccMinSlider.Value;
            SaveAllSettings();
        }

        private void AccMaxSlider_Scroll(object sender, EventArgs e)
        {
            accelerator.endHwValue = AccMaxSlider.Value;
            SaveAllSettings();
        }

        private void BrkMinSlider_Scroll(object sender, EventArgs e)
        {
            brake.startHwValue = BrkMinSlider.Value;
            SaveAllSettings();
        }

        private void BrkMaxSlider_Scroll(object sender, EventArgs e)
        {
            brake.endHwValue = BrkMaxSlider.Value;
            SaveAllSettings();
        }

        private void CltMinSlider_Scroll(object sender, EventArgs e)
        {
            clutch.startHwValue = CltMinSlider.Value;
            SaveAllSettings();
        }

        private void CltMaxSlider_Scroll(object sender, EventArgs e)
        {
            clutch.endHwValue = CltMaxSlider.Value;
            SaveAllSettings();
        }
    }
}
