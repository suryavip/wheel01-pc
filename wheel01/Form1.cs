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
        double steeringRotationRange = 3;
        int steeringPosition = VJoyWrapper.midValue;
        bool steeringFlipped = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.App("Detecting ports...");
            String[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.App("Port list updated!");
            Logger.App("Please wait until vJoy device initialized!");
        }

        private void VJoyInitDelay_Tick(object sender, EventArgs e)
        {
            VJoyInitDelay.Enabled = false;
            VJoyWrapper.Init();
            VJoyWrapper.SetAxis(steeringPosition, HID_USAGES.HID_USAGE_X);
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
            ConnectedSerialPort.Text = SerialPortController.IsOpen ? SerialPortController.PortName : "-";

            EncoderMultRotPositionDisplayText.Text = Encoder.currentValue.ToString();

            RxLogOutput.Text = Logger.rxLog;
            TxLogOutput.Text = Logger.txLog;

            SteeringAxisDisplayText.Text = steeringPosition.ToString();
            SteeringAxisDisplayBar.Value = steeringPosition;

            SteeringRangeDisplayText.Text = (steeringRotationRange * 360) + "°";

            FFBValueDisplayText.Text = VJoyWrapper.ffbValue.ToString();
            FFBValueDisplayBar.Value = VJoyWrapper.ffbValue + 10000;

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
                    Encoder.currentValue = int.Parse(value);
                    CalculateSteeringPosition();
                    break;
            }
        }

        private void SteeringRangeSlider_Scroll(object sender, EventArgs e)
        {
            steeringRotationRange = (double)SteeringRangeSlider.Value / 2;
            Logger.App("Set steering range: " + steeringRotationRange);
            CalculateSteeringPosition();
        }

        private void CalculateSteeringPosition()
        {
            double fullRange = Encoder.valueRange * steeringRotationRange;
            double mult = VJoyWrapper.valueRange / fullRange;
            double beforeOffset = Encoder.currentValue * mult;
            double afterOffset = beforeOffset + VJoyWrapper.midValue;

            if (afterOffset > VJoyWrapper.maxValue)
            {
                afterOffset = VJoyWrapper.maxValue;
            }

            if (afterOffset < VJoyWrapper.minValue)
            {
                afterOffset = VJoyWrapper.minValue;
            }

            if (steeringFlipped)
            {
                afterOffset /= -1;
                afterOffset += VJoyWrapper.maxValue;
            }

            steeringPosition = (int)afterOffset;

            VJoyWrapper.SetAxis(steeringPosition, HID_USAGES.HID_USAGE_X);
        }

        private void FlipSteeringButton_Click(object sender, EventArgs e)
        {
            steeringFlipped = !steeringFlipped;
            Logger.App("Flip steering wheel: " + steeringFlipped);
            CalculateSteeringPosition();
        }

        private void FFBValueSender_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SerialPortController.IsOpen == false) return;

                int val = VJoyWrapper.ffbValue;

                if (steeringPosition <= 10)
                {
                    val = -3000;
                }
                if (steeringPosition >= VJoyWrapper.maxValue - 10)
                {
                    val = 3000;
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
            try
            {
                if (SerialPortController.IsOpen == false) return;

                string tosent = "C:;";

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
    }
}
