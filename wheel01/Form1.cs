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
        // Arduino to PC vars
        string lastSerialReceived = "";
        int encoderPosition = 0;

        // PC to game vars
        int steeringPosition = (VJoyWrapper.maxVJoy - VJoyWrapper.minVJoy) / 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.AddLine("Detecting ports...");
            String[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.AddLine("Port list updated!");
            Logger.AddLine("Please wait until vJoy device initialized!");
        }

        private void VJoyInitDelay_Tick(object sender, EventArgs e)
        {
            VJoyInitDelay.Enabled = false;
            VJoyWrapper.InitVJoy();
            VJoyWrapper.vJoy.SetAxis(steeringPosition, VJoyWrapper.vJoyId, HID_USAGES.HID_USAGE_X);
        }

        private void COMPortsRefreshButton_Click(object sender, EventArgs e)
        {
            Logger.AddLine("Refreshing ports...");
            String[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.AddLine("Port list updated!");
        }

        private void COMPortsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = COMPortsComboBox.SelectedItem.ToString();
            Logger.AddLine("Connecting to " + selected + "...");
            try
            {
                SerialPortController.Close();
            }
            catch (Exception ex)
            {
                Logger.AddLine("Error closing previous connection: " + ex.Message);
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
                    Logger.AddLine("Failed connecting to " + selected + ": " + ex.Message);
                }
                Logger.AddLine("Connected to " + selected + "!");
            }
        }

        private void DisplayUpdater_Tick(object sender, EventArgs e)
        {
            LogOutput.Text = Logger.allLogs;
            EncoderPositionDisplayText.Text = encoderPosition.ToString();
            EncoderPositionDisplayBar.Value = encoderPosition;
        }

        private void CopyLogToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Logger.allLogs);
        }

        private void SerialPortController_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string read = SerialPortController.ReadLine();
                if (read == null || read.Length == 0) return;
                if (read == lastSerialReceived) return;
                lastSerialReceived = read;

                if (read.StartsWith("E:"))
                {
                    OnCommandReceived(read.Substring(0, 1), read.Substring(2));
                }
            }
            catch (Exception ex)
            {
                Logger.AddLine("Error on receiving data: " + ex.Message);
            }
        }

        private void OnCommandReceived(string command, string value)
        {
            switch (command)
            {
                case "E":
                    int newEncoderPosition = int.Parse(value);
                    if (newEncoderPosition < 16 && encoderPosition > 4085)
                    {
                        // overlap
                        int plus = encoderPosition + (encoderPosition - 4095) + newEncoderPosition;

                    }
                    else if (newEncoderPosition > 4085 && encoderPosition < 16)
                    {
                        // underlap
                        int minus = encoderPosition + (encoderPosition - 4095) + newEncoderPosition;

                    }
                    else
                    {
                        // normal
                    }

                    encoderPosition = newEncoderPosition;
                    break;
            }
        }
    }
}
