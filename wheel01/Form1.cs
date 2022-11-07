﻿using System;
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
        int steeringRotationRange = 3;
        int steeringPosition = VJoyWrapper.midValue;
        bool steeringFlipped = false;

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
            EncoderPositionDisplayText.Text = Encoder.currentValue.ToString();
            EncoderPositionDisplayBar.Value = Encoder.currentValue;

            EncoderMultRotPositionDisplayText.Text = Encoder.CurrentMultiRotationValue().ToString();

            RxLogOutput.Text = Logger.rxLog;
            TxLogOutput.Text = Logger.txLog;

            SteeringAxisDisplayText.Text = steeringPosition.ToString();
            SteeringAxisDisplayBar.Value = steeringPosition;

            SteeringRangeDisplayText.Text = (steeringRotationRange * 360) + "°";

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
                    Encoder.UpdateValue(int.Parse(value));
                    CalculateSteeringPosition();
                    break;
            }
        }

        private void SteeringRangeSlider_Scroll(object sender, EventArgs e)
        {
            steeringRotationRange = SteeringRangeSlider.Value;
            CalculateSteeringPosition();
        }

        private void CalculateSteeringPosition()
        {
            double fullRange = Encoder.valueRange * steeringRotationRange;
            double mult = VJoyWrapper.valueRange / fullRange;
            double beforeOffset = Encoder.CurrentMultiRotationValue() * mult;
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
    }
}
