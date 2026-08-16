using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wheel01
{
    public partial class Form1 : Form
    {
        readonly Wheel wheel = new Wheel();
        readonly Pedal accelerator = new Pedal();
        readonly Pedal brake = new Pedal();
        readonly Pedal clutch = new Pedal();
        readonly SerialCom serialCom = new SerialCom();

        bool flipFfbVoltage = false;
        double lastFfbVoltageSent = 0;

        double[] ffbMapKeys;
        double[] ffbMapValues;

        // Add this inside your Form class
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowTheme(FfbValueDisplayBar.Handle, "", "");
            SetWindowTheme(SteeringAxisDisplayBar.Handle, "", "");
            SetWindowTheme(AcceleratorAxisDisplayBar.Handle, "", "");
            SetWindowTheme(BrakeAxisDisplayBar.Handle, "", "");
            SetWindowTheme(ClutchAxisDisplayBar.Handle, "", "");

            LoadAllSettings();

            Logger.App("Detecting ports...");
            string[] ports = SerialPort.GetPortNames();
            COMPortsComboBox.DataSource = ports;
            Logger.App("Port list updated!");
        }

        private void LoadAllSettings()
        {
            Logger.App("Load settings...");

            wheel.hwValueOffset = Properties.Settings.Default.WheelHwValueOffset;
            wheel.hwOverRotationOffset = Properties.Settings.Default.WheelHwOverRotationOffset;
            wheel.flipDirection = Properties.Settings.Default.WheelFlipDirection;
            wheel.rotationRange = Properties.Settings.Default.WheelRotationRange;
            SteeringRangeSlider.Value = (int)(wheel.rotationRange * 2);

            accelerator.startHwValue = Properties.Settings.Default.AccStartHwValue;
            accelerator.endHwValue = Properties.Settings.Default.AccEndHwValue;
            AccMinSlider.Value = accelerator.startHwValue;
            AccMaxSlider.Value = accelerator.endHwValue;

            brake.startHwValue = Properties.Settings.Default.BrkStartHwValue;
            brake.endHwValue = Properties.Settings.Default.BrkEndHwValue;
            BrkMinSlider.Value = brake.startHwValue;
            BrkMaxSlider.Value = brake.endHwValue;

            BrkLinearitySlider.Value = Properties.Settings.Default.BrkLinearity;
            double brkLinearitySlider = BrkLinearitySlider.Value;
            double realBrkLinearity = brkLinearitySlider / 100;
            brake.linearity = realBrkLinearity;
            BrkLinearityDisplayText.Text = brake.linearity.ToString();

            clutch.startHwValue = Properties.Settings.Default.CltStartHwValue;
            clutch.endHwValue = Properties.Settings.Default.CltEndHwValue;
            CltMinSlider.Value = clutch.startHwValue;
            CltMaxSlider.Value = clutch.endHwValue;

            flipFfbVoltage = Properties.Settings.Default.FFBFlipVout;

            try
            {
                FfbMap.Text = Properties.Settings.Default.FFBMap;
                ApplyFfbMap();
            }
            catch {
                Logger.App("Failed to load FFB map. Revert to default safe value.");
                FfbMap.Text = "0 0\n10000 1";
                ApplyFfbMap();
            }
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
            Properties.Settings.Default.BrkLinearity = BrkLinearitySlider.Value;

            Properties.Settings.Default.CltStartHwValue = clutch.startHwValue;
            Properties.Settings.Default.CltEndHwValue = clutch.endHwValue;

            Properties.Settings.Default.FFBFlipVout = flipFfbVoltage;

            Properties.Settings.Default.FFBMap = FfbMap.Text;

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
            string selected = COMPortsComboBox.SelectedItem.ToString();
            serialCom.Connect(selected, () =>
            {
                SendFFBValue();
            }, (read) =>
            {
                OnCommandReceived(read);
            });
        }

        private void DisplayUpdater_Tick(object sender, EventArgs e)
        {
            int steeringAxisValue = wheel.CalculateAxisValue();
            SteeringAxisDisplayText.Text = steeringAxisValue.ToString();
            SteeringAxisDisplayBar.Value = steeringAxisValue;

            SteeringRangeDisplayText.Text = (wheel.rotationRange * 360) + "°";

            FfbValueDisplayText.Text = lastFfbVoltageSent.ToString();
            FfbValueDisplayBar.Value = (int)(lastFfbVoltageSent * 1000) + ((FfbValueDisplayBar.Maximum - FfbValueDisplayBar.Minimum) / 2);

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
            VJoyWrapper.state.AxisX = wheel.CalculateAxisValue();
            VJoyWrapper.state.AxisXRot = accelerator.CalculateAxisValue();
            VJoyWrapper.state.AxisYRot = brake.CalculateAxisValue();
            VJoyWrapper.state.AxisZRot = clutch.CalculateAxisValue();
            VJoyWrapper.UpdateState();
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
            lastFfbVoltageSent = CalculateFfbVoltage();
            string tosent = string.Format("{0:F2};", lastFfbVoltageSent).Replace(",", ".");
            serialCom.Send(tosent, () =>
            {
                OnCommandReceived(string.Format(
                    "{0},{1},{2},{3},{4}",
                    wheel.currentHwValue,
                    wheel.currentHwOverRotationValue,
                    accelerator.startHwValue,
                    brake.startHwValue,
                    clutch.startHwValue
                ));
            });
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

            // convert to voltage
            int absolute = (int)Math.Abs(signalInDouble * VJoyWrapper.maxFfbValue);
            double inVoltage = MultiMap.Get(absolute, ffbMapKeys, ffbMapValues);

            // flip to original direction if needed
            if (signalInDouble < 0) inVoltage *= -1;

            // flip voltage if settings said flip
            if (flipFfbVoltage) inVoltage *= -1;

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

        private void FlipFfbButton_Click(object sender, EventArgs e)
        {
            flipFfbVoltage = !flipFfbVoltage;
            Logger.App("Flip FFB Vout: " + flipFfbVoltage);
            SaveAllSettings();
        }

        private void BrkLinearitySlider_Scroll(object sender, EventArgs e)
        {
            double slider = BrkLinearitySlider.Value;
            brake.linearity = slider / 100;
            BrkLinearityDisplayText.Text = brake.linearity.ToString();
            SaveAllSettings();
        }

        private void ApplyFfbMap()
        {
            Dictionary<int, double> ffbMap = ParseMap(FfbMap.Text);
            ffbMapKeys = ffbMap.Keys.Select(k => (double)k).ToArray();
            ffbMapValues = ffbMap.Values.ToArray();
        }

        private void ApplyFfbMapButton_Click(object sender, EventArgs e)
        {
            Logger.App("Applying map...");
            try
            {
                ApplyFfbMap();
                SaveAllSettings();
                Logger.App("Map applied!");
            }
            catch (Exception ex)
            {
                Logger.App(string.Format("Failed to apply map: {0}", ex.Message));
            }
        }

        private Dictionary<int, double> ParseMap(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var result = new Dictionary<int, double>();

            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2) throw new FormatException($"Invalid line: '{line}'. Expected '<key> <value>'.");

                int key;
                double value;

                if (!int.TryParse(parts[0], out key)) throw new FormatException($"Invalid key '{parts[0]}' in line: '{line}'.");
                if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out value)) throw new FormatException($"Invalid value '{parts[1]}' in line: '{line}'.");
                if (result.ContainsKey(key)) throw new FormatException($"Duplicate key '{key}'.");

                result.Add(key, value);
            }

            if (!result.ContainsKey(0)) throw new FormatException("Required key '0' is missing.");
            if (!result.ContainsKey(10000)) throw new FormatException("Required key '10000' is missing.");

            return result;
        }
    }
}
