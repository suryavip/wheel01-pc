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

        double ffbMult = 1;
        double ffbLinearity = 1;
        readonly double maxFfbVoltage = 7.0;
        double lastFfbVoltageSent = 0;

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
            string[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.App("Port list updated!");
            Logger.App("Please wait until vJoy device initialized!");
        }

        private void LoadAllSettings()
        {
            Logger.App("Load settings...");

            wheel.hwValueOffset = Properties.Settings.Default.WheelHwValueOffset;
            wheel.hwOverRotationOffset = Properties.Settings.Default.WheelHwOverRotationOffset;
            wheel.flipDirection = Properties.Settings.Default.WheelFlipDirection;
            wheel.rotationRange = Properties.Settings.Default.WheelRotationRange;

            accelerator.startHwValue = Properties.Settings.Default.AccStartHwValue;
            accelerator.endHwValue = Properties.Settings.Default.AccEndHwValue;

            brake.startHwValue = Properties.Settings.Default.BrkStartHwValue;
            brake.endHwValue = Properties.Settings.Default.BrkEndHwValue;

            clutch.startHwValue = Properties.Settings.Default.CltStartHwValue;
            clutch.endHwValue = Properties.Settings.Default.CltEndHwValue;

            FfbMultSlider.Value = Properties.Settings.Default.FFBMultiplier;
            double slider = FfbMultSlider.Value;
            double realMult = slider / 10;
            ffbMult = realMult;

            FfbLinearitySlider.Value = Properties.Settings.Default.FFBLinearity;
            double ffbLinearitySlider = FfbLinearitySlider.Value;
            double realFfbLinearity = ffbLinearitySlider / 100;
            ffbLinearity = realFfbLinearity;
            FFBLinearityDisplayText.Text = ffbLinearity.ToString();
        }

        private void SaveAllSettings()
        {
            Properties.Settings.Default.WheelHwValueOffset = wheel.hwValueOffset;
            Properties.Settings.Default.WheelHwOverRotationOffset = wheel.hwOverRotationOffset;
            Properties.Settings.Default.WheelFlipDirection = wheel.flipDirection;
            Properties.Settings.Default.WheelRotationRange = wheel.rotationRange;

            Properties.Settings.Default.AccStartHwValue = accelerator.startHwValue;
            Properties.Settings.Default.AccEndHwValue = accelerator.endHwValue;

            Properties.Settings.Default.BrkStartHwValue = brake.startHwValue;
            Properties.Settings.Default.BrkEndHwValue = brake.endHwValue;

            Properties.Settings.Default.CltStartHwValue = clutch.startHwValue;
            Properties.Settings.Default.CltEndHwValue = clutch.endHwValue;

            Properties.Settings.Default.FFBMultiplier = FfbMultSlider.Value;

            Properties.Settings.Default.FFBLinearity = FfbLinearitySlider.Value;

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
                    SendFFBValue();
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
            int steeringAxisValue = wheel.CalculateAxisValue();
            SteeringAxisDisplayText.Text = steeringAxisValue.ToString();
            SteeringAxisDisplayBar.Value = steeringAxisValue;

            SteeringRangeDisplayText.Text = (wheel.rotationRange * 360) + "°";

            FFBValueDisplayText.Text = lastFfbVoltageSent.ToString();
            FFBValueDisplayBar.Value = (int)(lastFfbVoltageSent * 1000) + VJoyWrapper.maxFfbValue;

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
                OnCommandReceived(read);
            }
            catch (Exception ex)
            {
                Logger.App("Error on receiving data: " + ex.Message);
            }
        }

        private void OnCommandReceived(string value)
        {
            string[] splitted = value.Split(',');

            wheel.currentHwValue = int.Parse(splitted[0]);
            wheel.currentHwOverRotationValue = int.Parse(splitted[1]);

            accelerator.currentHwValue = int.Parse(splitted[2]);
            brake.currentHwValue = int.Parse(splitted[3]);
            clutch.currentHwValue = int.Parse(splitted[4]);

            SendValueToVJoy();

            SendFFBValue();
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

        private void SendFFBValue()
        {
            try
            {
                if (SerialPortController.IsOpen == false) return;

                lastFfbVoltageSent = CalculateFfbVoltage();
                string tosent = string.Format("{0:F2};", lastFfbVoltageSent).Replace(",", ".");
                SerialPortController.Write(tosent);
                Logger.Tx(tosent);
            }
            catch (Exception ex)
            {
                Logger.App("Error on sending data: " + ex.Message);
                Logger.App("Connection disrupted!");
            }
        }

        private double CalculateFfbVoltage()
        {
            double signalInDouble; // hold ffb signal between -1 to 1, where 0 is no ffb to any direction

            if (FidgetCheckBox.Checked)
            {
                double pedalSum = clutch.CalculateAxisValue() - accelerator.CalculateAxisValue();
                signalInDouble = pedalSum / Pedal.maxHwValue;
            }
            else
            {
                double signalFromGame = VJoyWrapper.CalculateFFB();
                signalFromGame *= ffbMult; // apply multiplier for signal from game
                signalInDouble = signalFromGame / VJoyWrapper.maxFfbValue;
            }

            // Adding soft lock force
            int steeringPosition = wheel.CalculateAxisValue();
            double normalizedThreshold = VJoyWrapper.softLockThreshold / (wheel.rotationRange / 5);
            
            if (steeringPosition < normalizedThreshold)
            {
                double progress = normalizedThreshold - steeringPosition;
                double percent = progress / normalizedThreshold;
                signalInDouble -= percent * 1.1;
            }
            double rightBumpThreshold = VJoyWrapper.maxAxisValue - normalizedThreshold;
            if (steeringPosition > rightBumpThreshold)
            {
                double progress = (rightBumpThreshold - steeringPosition) * -1;
                double percent = progress / normalizedThreshold;
                signalInDouble += percent * 1.1;
            }

            // clamp ffbOutput for soft lock pass
            if (signalInDouble > 1) signalInDouble = 1;
            if (signalInDouble < -1) signalInDouble = -1;

            // transform curve
            double transformer = Math.Pow(Math.Abs(signalInDouble), ffbLinearity);
            if (signalInDouble < 0) signalInDouble = transformer * -1;
            else signalInDouble = transformer;

            // clamp ffbOutput again
            if (signalInDouble > 1) signalInDouble = 1;
            if (signalInDouble < -1) signalInDouble = -1;

            // convert to voltage
            double inVoltage = signalInDouble * maxFfbVoltage;

            return inVoltage;
        }

        private void ResetZeroBtn_Click(object sender, EventArgs e)
        {
            wheel.hwValueOffset = wheel.currentHwValue;
            wheel.hwOverRotationOffset = wheel.currentHwOverRotationValue;
            Logger.App("Steering wheel offset: " + wheel.hwValueOffset);
            Logger.App("Steering wheel OR offset: " + wheel.hwOverRotationOffset);
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

        private void FfbMultSlider_Scroll(object sender, EventArgs e)
        {
            double slider = FfbMultSlider.Value;
            double realValue = slider / 10;

            ffbMult = realValue;
            SaveAllSettings();
        }

        private void FfbLinearitySlider_Scroll(object sender, EventArgs e)
        {
            double slider = FfbLinearitySlider.Value;
            ffbLinearity = slider / 100;
            FFBLinearityDisplayText.Text = ffbLinearity.ToString();
            SaveAllSettings();
        }
    }
}
