using System;
using System.IO.Ports;
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

        double ffbMult = 1;
        double ffbLinearity = 1;
        double ffbLinearityMix = 1;
        double maxFfbVoltage = 9.0;
        bool flipFfbVoltage = false;
        double lastFfbVoltageSent = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllSettings();

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

            FfbMultSlider.Value = Properties.Settings.Default.FFBMultiplier;
            double slider = FfbMultSlider.Value;
            double realMult = slider / 10;
            ffbMult = realMult;

            FfbLinearitySlider.Value = Properties.Settings.Default.FFBLinearity;
            double ffbLinearitySlider = FfbLinearitySlider.Value;
            double realFfbLinearity = ffbLinearitySlider / 100;
            ffbLinearity = realFfbLinearity;
            FFBLinearityDisplayText.Text = ffbLinearity.ToString();

            FfbLinearityMixSlider.Value = Properties.Settings.Default.FFBLinearityMix;
            double ffbLinearityMixSlider = FfbLinearityMixSlider.Value;
            double realFfbLinearityMix = ffbLinearityMixSlider / 100;
            ffbLinearityMix = realFfbLinearityMix;
            FFBLinearityMixDisplayText.Text = ffbLinearityMix.ToString();

            flipFfbVoltage = Properties.Settings.Default.FFBFlipVout;

            maxFfbVoltage = Properties.Settings.Default.FFBMaxVout;
            MaxVoutSlider.Value = (int)(maxFfbVoltage * 10);
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

            Properties.Settings.Default.FFBMultiplier = FfbMultSlider.Value;

            Properties.Settings.Default.FFBLinearity = FfbLinearitySlider.Value;
            Properties.Settings.Default.FFBLinearityMix = FfbLinearityMixSlider.Value;

            Properties.Settings.Default.FFBFlipVout = flipFfbVoltage;

            Properties.Settings.Default.FFBMaxVout = maxFfbVoltage;

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
            VJoyWrapper.state.AxisY = accelerator.CalculateAxisValue();
            VJoyWrapper.state.AxisZ = brake.CalculateAxisValue();
            VJoyWrapper.state.AxisXRot = clutch.CalculateAxisValue();
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
            double transformer = (Math.Pow(Math.Abs(signalInDouble), ffbLinearity) * ffbLinearityMix) + (Math.Abs(signalInDouble) * (1 - ffbLinearityMix));
            if (signalInDouble < 0) signalInDouble = transformer * -1;
            else signalInDouble = transformer;

            // clamp ffbOutput again
            if (signalInDouble > 1) signalInDouble = 1;
            if (signalInDouble < -1) signalInDouble = -1;

            // convert to voltage
            double inVoltage = signalInDouble * maxFfbVoltage;

            // flip voltage if needed
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

        private void FlipFfbButton_Click(object sender, EventArgs e)
        {
            flipFfbVoltage = !flipFfbVoltage;
            Logger.App("Flip FFB Vout: " + flipFfbVoltage);
            SaveAllSettings();
        }

        private void MaxVoutSlider_Scroll(object sender, EventArgs e)
        {
            double slider = MaxVoutSlider.Value;
            maxFfbVoltage = slider / 10;
            Logger.App("Max Vout: " + maxFfbVoltage);
            SaveAllSettings();
        }

        private void BrkLinearitySlider_Scroll(object sender, EventArgs e)
        {
            double slider = BrkLinearitySlider.Value;
            brake.linearity = slider / 100;
            BrkLinearityDisplayText.Text = brake.linearity.ToString();
            SaveAllSettings();
        }

        private void FfbLinearityMixSlider_Scroll(object sender, EventArgs e)
        {
            double slider = FfbLinearityMixSlider.Value;
            ffbLinearityMix = slider / 100;
            FFBLinearityMixDisplayText.Text = ffbLinearityMix.ToString();
            SaveAllSettings();
        }
    }
}
