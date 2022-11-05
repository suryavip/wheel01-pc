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
        const int maxEncoderValue = 4095;
        const int minEncoderValue = 0;
        const int encoderValueRange = maxEncoderValue - minEncoderValue + 1;
        const int midEncoderValue = encoderValueRange / 2;
        const int encoderBottomRange = minEncoderValue + 64;
        const int encoderTopRange = maxEncoderValue - 64;

        int encoderValue = midEncoderValue;
        int encoderOverRotation = 0;

        // PC to game vars
        int steeringPosition = VJoyWrapper.midValue;

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

        private void COMPortsComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                }
                catch (Exception ex)
                {
                    Logger.App("Failed connecting to " + selected + ": " + ex.Message);
                }
                SerialPortController.Write("C:");
                Logger.Tx("C:");
                Logger.App("Connected to " + selected + "!");
            }
        }

        private void DisplayUpdater_Tick(object sender, EventArgs e)
        {
            EncoderPositionDisplayText.Text = encoderValue.ToString();
            EncoderPositionDisplayBar.Value = encoderValue;

            EncoderMultRotPositionDisplayText.Text = ((encoderValueRange * encoderOverRotation) + encoderValue).ToString();


            RxLogOutput.Text = Logger.rxLog;
            TxLogOutput.Text = Logger.txLog;

            SteeringRangeDisplayText.Text = (SteeringRangeSlider.Value * 180) + "°";

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
                string read = SerialPortController.ReadLine();
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
                    int newEncoderPosition = int.Parse(value);

                    if (newEncoderPosition < encoderBottomRange && encoderValue > encoderTopRange)
                    {
                        // overlap
                        encoderOverRotation++;
                    }
                    else if (newEncoderPosition > encoderTopRange && encoderValue < encoderBottomRange)
                    {
                        // underlap
                        encoderOverRotation--;
                    }

                    encoderValue = newEncoderPosition;
                    
                    break;
            }
        }
    }
}
