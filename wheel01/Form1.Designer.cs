namespace wheel01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.COMPortsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.COMPortsRefreshButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FfbMultSlider = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResetZeroBtn = new System.Windows.Forms.Button();
            this.SteeringRangeDisplayText = new System.Windows.Forms.Label();
            this.SteeringRangeSlider = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.FlipSteeringButton = new System.Windows.Forms.Button();
            this.SteeringAxisDisplayText = new System.Windows.Forms.Label();
            this.SteeringAxisDisplayBar = new System.Windows.Forms.ProgressBar();
            this.FFBValueDisplayBar = new System.Windows.Forms.ProgressBar();
            this.FFBValueDisplayText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ClutchAxisDisplayText = new System.Windows.Forms.Label();
            this.BrakeAxisDisplayText = new System.Windows.Forms.Label();
            this.AcceleratorAxisDisplayText = new System.Windows.Forms.Label();
            this.ClutchAxisDisplayBar = new System.Windows.Forms.ProgressBar();
            this.BrakeAxisDisplayBar = new System.Windows.Forms.ProgressBar();
            this.AcceleratorAxisDisplayBar = new System.Windows.Forms.ProgressBar();
            this.SerialPortController = new System.IO.Ports.SerialPort(this.components);
            this.VJoyInitDelay = new System.Windows.Forms.Timer(this.components);
            this.DisplayUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FidgetCheckBox = new System.Windows.Forms.CheckBox();
            this.CopyLogToClipboardButton = new System.Windows.Forms.Button();
            this.LogOutput = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.AccMaxSlider = new System.Windows.Forms.TrackBar();
            this.AccMinSlider = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BrkMaxSlider = new System.Windows.Forms.TrackBar();
            this.BrkMinSlider = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.CltMaxSlider = new System.Windows.Forms.TrackBar();
            this.CltMinSlider = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FlipFfbButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxVoutSlider = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.FFBLinearityDisplayText = new System.Windows.Forms.Label();
            this.FfbLinearitySlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FfbMultSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SteeringRangeSlider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccMinSlider)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrkMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrkMinSlider)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CltMaxSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CltMinSlider)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVoutSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FfbLinearitySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // COMPortsComboBox
            // 
            this.COMPortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMPortsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COMPortsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMPortsComboBox.FormattingEnabled = true;
            this.COMPortsComboBox.ItemHeight = 16;
            this.COMPortsComboBox.Location = new System.Drawing.Point(8, 24);
            this.COMPortsComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.COMPortsComboBox.Name = "COMPortsComboBox";
            this.COMPortsComboBox.Size = new System.Drawing.Size(128, 24);
            this.COMPortsComboBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.COMPortsRefreshButton);
            this.groupBox1.Controls.Add(this.COMPortsComboBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackgroundImage = global::wheel01.Properties.Resources.plug;
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(176, 24);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(24, 24);
            this.ConnectButton.TabIndex = 22;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // COMPortsRefreshButton
            // 
            this.COMPortsRefreshButton.BackgroundImage = global::wheel01.Properties.Resources.arrows_rotate_11;
            this.COMPortsRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.COMPortsRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COMPortsRefreshButton.Location = new System.Drawing.Point(144, 24);
            this.COMPortsRefreshButton.Name = "COMPortsRefreshButton";
            this.COMPortsRefreshButton.Size = new System.Drawing.Size(24, 24);
            this.COMPortsRefreshButton.TabIndex = 3;
            this.COMPortsRefreshButton.UseVisualStyleBackColor = true;
            this.COMPortsRefreshButton.Click += new System.EventHandler(this.COMPortsRefreshButton_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(80, 48);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 24);
            this.label16.TabIndex = 44;
            this.label16.Text = "1x";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(152, 48);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 24);
            this.label14.TabIndex = 43;
            this.label14.Text = "2x";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 24);
            this.label9.TabIndex = 42;
            this.label9.Text = "0x";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FfbMultSlider
            // 
            this.FfbMultSlider.AutoSize = false;
            this.FfbMultSlider.LargeChange = 2;
            this.FfbMultSlider.Location = new System.Drawing.Point(8, 72);
            this.FfbMultSlider.Maximum = 20;
            this.FfbMultSlider.Name = "FfbMultSlider";
            this.FfbMultSlider.Size = new System.Drawing.Size(192, 32);
            this.FfbMultSlider.TabIndex = 41;
            this.FfbMultSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.FfbMultSlider.Value = 10;
            this.FfbMultSlider.Scroll += new System.EventHandler(this.FfbMultSlider_Scroll);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 24);
            this.label8.TabIndex = 40;
            this.label8.Text = "Game FFB Multiplier:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ResetZeroBtn);
            this.groupBox2.Controls.Add(this.SteeringRangeDisplayText);
            this.groupBox2.Controls.Add(this.SteeringRangeSlider);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.FlipSteeringButton);
            this.groupBox2.Controls.Add(this.SteeringAxisDisplayText);
            this.groupBox2.Controls.Add(this.SteeringAxisDisplayBar);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(440, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 184);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steering";
            // 
            // ResetZeroBtn
            // 
            this.ResetZeroBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ResetZeroBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetZeroBtn.Location = new System.Drawing.Point(144, 24);
            this.ResetZeroBtn.Name = "ResetZeroBtn";
            this.ResetZeroBtn.Size = new System.Drawing.Size(24, 24);
            this.ResetZeroBtn.TabIndex = 28;
            this.ResetZeroBtn.Text = "0";
            this.ResetZeroBtn.UseVisualStyleBackColor = true;
            this.ResetZeroBtn.Click += new System.EventHandler(this.ResetZeroBtn_Click);
            // 
            // SteeringRangeDisplayText
            // 
            this.SteeringRangeDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteeringRangeDisplayText.Location = new System.Drawing.Point(104, 88);
            this.SteeringRangeDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SteeringRangeDisplayText.Name = "SteeringRangeDisplayText";
            this.SteeringRangeDisplayText.Size = new System.Drawing.Size(96, 24);
            this.SteeringRangeDisplayText.TabIndex = 26;
            this.SteeringRangeDisplayText.Text = "-";
            this.SteeringRangeDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SteeringRangeSlider
            // 
            this.SteeringRangeSlider.AutoSize = false;
            this.SteeringRangeSlider.Location = new System.Drawing.Point(8, 112);
            this.SteeringRangeSlider.Minimum = 1;
            this.SteeringRangeSlider.Name = "SteeringRangeSlider";
            this.SteeringRangeSlider.Size = new System.Drawing.Size(192, 32);
            this.SteeringRangeSlider.TabIndex = 25;
            this.SteeringRangeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SteeringRangeSlider.Value = 6;
            this.SteeringRangeSlider.Scroll += new System.EventHandler(this.SteeringRangeSlider_Scroll);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 88);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Range:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlipSteeringButton
            // 
            this.FlipSteeringButton.BackgroundImage = global::wheel01.Properties.Resources.left_right;
            this.FlipSteeringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FlipSteeringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlipSteeringButton.Location = new System.Drawing.Point(176, 24);
            this.FlipSteeringButton.Name = "FlipSteeringButton";
            this.FlipSteeringButton.Size = new System.Drawing.Size(24, 24);
            this.FlipSteeringButton.TabIndex = 22;
            this.FlipSteeringButton.UseVisualStyleBackColor = true;
            this.FlipSteeringButton.Click += new System.EventHandler(this.FlipSteeringButton_Click);
            // 
            // SteeringAxisDisplayText
            // 
            this.SteeringAxisDisplayText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SteeringAxisDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteeringAxisDisplayText.Location = new System.Drawing.Point(8, 24);
            this.SteeringAxisDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SteeringAxisDisplayText.Name = "SteeringAxisDisplayText";
            this.SteeringAxisDisplayText.Size = new System.Drawing.Size(126, 24);
            this.SteeringAxisDisplayText.TabIndex = 14;
            this.SteeringAxisDisplayText.Text = "-";
            this.SteeringAxisDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SteeringAxisDisplayBar
            // 
            this.SteeringAxisDisplayBar.Location = new System.Drawing.Point(8, 56);
            this.SteeringAxisDisplayBar.Maximum = 32767;
            this.SteeringAxisDisplayBar.Name = "SteeringAxisDisplayBar";
            this.SteeringAxisDisplayBar.Size = new System.Drawing.Size(192, 16);
            this.SteeringAxisDisplayBar.Step = 1;
            this.SteeringAxisDisplayBar.TabIndex = 0;
            this.SteeringAxisDisplayBar.Value = 16383;
            // 
            // FFBValueDisplayBar
            // 
            this.FFBValueDisplayBar.Location = new System.Drawing.Point(8, 312);
            this.FFBValueDisplayBar.Maximum = 20000;
            this.FFBValueDisplayBar.Name = "FFBValueDisplayBar";
            this.FFBValueDisplayBar.Size = new System.Drawing.Size(192, 16);
            this.FFBValueDisplayBar.Step = 1;
            this.FFBValueDisplayBar.TabIndex = 27;
            this.FFBValueDisplayBar.Value = 10000;
            // 
            // FFBValueDisplayText
            // 
            this.FFBValueDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FFBValueDisplayText.Location = new System.Drawing.Point(104, 288);
            this.FFBValueDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FFBValueDisplayText.Name = "FFBValueDisplayText";
            this.FFBValueDisplayText.Size = new System.Drawing.Size(96, 24);
            this.FFBValueDisplayText.TabIndex = 21;
            this.FFBValueDisplayText.Text = "-";
            this.FFBValueDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 288);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 24);
            this.label15.TabIndex = 19;
            this.label15.Text = "Vout";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClutchAxisDisplayText
            // 
            this.ClutchAxisDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClutchAxisDisplayText.Location = new System.Drawing.Point(8, 24);
            this.ClutchAxisDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClutchAxisDisplayText.Name = "ClutchAxisDisplayText";
            this.ClutchAxisDisplayText.Size = new System.Drawing.Size(192, 24);
            this.ClutchAxisDisplayText.TabIndex = 17;
            this.ClutchAxisDisplayText.Text = "-";
            this.ClutchAxisDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrakeAxisDisplayText
            // 
            this.BrakeAxisDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrakeAxisDisplayText.Location = new System.Drawing.Point(8, 24);
            this.BrakeAxisDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BrakeAxisDisplayText.Name = "BrakeAxisDisplayText";
            this.BrakeAxisDisplayText.Size = new System.Drawing.Size(190, 24);
            this.BrakeAxisDisplayText.TabIndex = 16;
            this.BrakeAxisDisplayText.Text = "-";
            this.BrakeAxisDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AcceleratorAxisDisplayText
            // 
            this.AcceleratorAxisDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceleratorAxisDisplayText.Location = new System.Drawing.Point(8, 24);
            this.AcceleratorAxisDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AcceleratorAxisDisplayText.Name = "AcceleratorAxisDisplayText";
            this.AcceleratorAxisDisplayText.Size = new System.Drawing.Size(190, 24);
            this.AcceleratorAxisDisplayText.TabIndex = 15;
            this.AcceleratorAxisDisplayText.Text = "-";
            this.AcceleratorAxisDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ClutchAxisDisplayBar
            // 
            this.ClutchAxisDisplayBar.Location = new System.Drawing.Point(8, 48);
            this.ClutchAxisDisplayBar.Maximum = 32767;
            this.ClutchAxisDisplayBar.Name = "ClutchAxisDisplayBar";
            this.ClutchAxisDisplayBar.Size = new System.Drawing.Size(192, 16);
            this.ClutchAxisDisplayBar.Step = 1;
            this.ClutchAxisDisplayBar.TabIndex = 13;
            // 
            // BrakeAxisDisplayBar
            // 
            this.BrakeAxisDisplayBar.Location = new System.Drawing.Point(8, 48);
            this.BrakeAxisDisplayBar.Maximum = 32767;
            this.BrakeAxisDisplayBar.Name = "BrakeAxisDisplayBar";
            this.BrakeAxisDisplayBar.Size = new System.Drawing.Size(192, 16);
            this.BrakeAxisDisplayBar.Step = 1;
            this.BrakeAxisDisplayBar.TabIndex = 11;
            // 
            // AcceleratorAxisDisplayBar
            // 
            this.AcceleratorAxisDisplayBar.Location = new System.Drawing.Point(8, 48);
            this.AcceleratorAxisDisplayBar.Maximum = 32767;
            this.AcceleratorAxisDisplayBar.Name = "AcceleratorAxisDisplayBar";
            this.AcceleratorAxisDisplayBar.Size = new System.Drawing.Size(192, 16);
            this.AcceleratorAxisDisplayBar.Step = 1;
            this.AcceleratorAxisDisplayBar.TabIndex = 9;
            // 
            // SerialPortController
            // 
            this.SerialPortController.BaudRate = 115200;
            this.SerialPortController.DtrEnable = true;
            this.SerialPortController.ReadBufferSize = 1024;
            this.SerialPortController.ReceivedBytesThreshold = 4;
            this.SerialPortController.RtsEnable = true;
            this.SerialPortController.WriteBufferSize = 1024;
            // 
            // VJoyInitDelay
            // 
            this.VJoyInitDelay.Enabled = true;
            this.VJoyInitDelay.Interval = 1000;
            this.VJoyInitDelay.Tick += new System.EventHandler(this.VJoyInitDelay_Tick);
            // 
            // DisplayUpdater
            // 
            this.DisplayUpdater.Enabled = true;
            this.DisplayUpdater.Tick += new System.EventHandler(this.DisplayUpdater_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FidgetCheckBox);
            this.groupBox3.Controls.Add(this.CopyLogToClipboardButton);
            this.groupBox3.Controls.Add(this.LogOutput);
            this.groupBox3.Location = new System.Drawing.Point(8, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 312);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // FidgetCheckBox
            // 
            this.FidgetCheckBox.AutoSize = true;
            this.FidgetCheckBox.Location = new System.Drawing.Point(8, 280);
            this.FidgetCheckBox.Name = "FidgetCheckBox";
            this.FidgetCheckBox.Size = new System.Drawing.Size(102, 20);
            this.FidgetCheckBox.TabIndex = 7;
            this.FidgetCheckBox.Text = "Fidget mode";
            this.FidgetCheckBox.UseVisualStyleBackColor = true;
            // 
            // CopyLogToClipboardButton
            // 
            this.CopyLogToClipboardButton.BackgroundImage = global::wheel01.Properties.Resources.copy;
            this.CopyLogToClipboardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CopyLogToClipboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyLogToClipboardButton.Location = new System.Drawing.Point(176, 280);
            this.CopyLogToClipboardButton.Name = "CopyLogToClipboardButton";
            this.CopyLogToClipboardButton.Size = new System.Drawing.Size(24, 24);
            this.CopyLogToClipboardButton.TabIndex = 6;
            this.CopyLogToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyLogToClipboardButton.Click += new System.EventHandler(this.CopyLogToClipboardButton_Click);
            // 
            // LogOutput
            // 
            this.LogOutput.BackColor = System.Drawing.SystemColors.Window;
            this.LogOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogOutput.HideSelection = false;
            this.LogOutput.Location = new System.Drawing.Point(10, 20);
            this.LogOutput.Name = "LogOutput";
            this.LogOutput.ReadOnly = true;
            this.LogOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LogOutput.Size = new System.Drawing.Size(190, 252);
            this.LogOutput.TabIndex = 5;
            this.LogOutput.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.AccMaxSlider);
            this.groupBox5.Controls.Add(this.AccMinSlider);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.AcceleratorAxisDisplayBar);
            this.groupBox5.Controls.Add(this.AcceleratorAxisDisplayText);
            this.groupBox5.Location = new System.Drawing.Point(656, 8);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(208, 184);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Accelerator";
            // 
            // AccMaxSlider
            // 
            this.AccMaxSlider.AutoSize = false;
            this.AccMaxSlider.LargeChange = 1;
            this.AccMaxSlider.Location = new System.Drawing.Point(8, 144);
            this.AccMaxSlider.Maximum = 32767;
            this.AccMaxSlider.Name = "AccMaxSlider";
            this.AccMaxSlider.Size = new System.Drawing.Size(192, 32);
            this.AccMaxSlider.TabIndex = 27;
            this.AccMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AccMaxSlider.Value = 4095;
            this.AccMaxSlider.Scroll += new System.EventHandler(this.AccMaxSlider_Scroll);
            // 
            // AccMinSlider
            // 
            this.AccMinSlider.AutoSize = false;
            this.AccMinSlider.LargeChange = 1;
            this.AccMinSlider.Location = new System.Drawing.Point(8, 112);
            this.AccMinSlider.Maximum = 32767;
            this.AccMinSlider.Name = "AccMinSlider";
            this.AccMinSlider.Size = new System.Drawing.Size(192, 32);
            this.AccMinSlider.TabIndex = 25;
            this.AccMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AccMinSlider.Scroll += new System.EventHandler(this.AccMinSlider_Scroll);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = "Range:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BrkMaxSlider);
            this.groupBox6.Controls.Add(this.BrkMinSlider);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.BrakeAxisDisplayText);
            this.groupBox6.Controls.Add(this.BrakeAxisDisplayBar);
            this.groupBox6.Location = new System.Drawing.Point(440, 200);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(208, 184);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Brake";
            // 
            // BrkMaxSlider
            // 
            this.BrkMaxSlider.AutoSize = false;
            this.BrkMaxSlider.LargeChange = 1;
            this.BrkMaxSlider.Location = new System.Drawing.Point(8, 144);
            this.BrkMaxSlider.Maximum = 32767;
            this.BrkMaxSlider.Name = "BrkMaxSlider";
            this.BrkMaxSlider.Size = new System.Drawing.Size(192, 32);
            this.BrkMaxSlider.TabIndex = 27;
            this.BrkMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BrkMaxSlider.Value = 4095;
            this.BrkMaxSlider.Scroll += new System.EventHandler(this.BrkMaxSlider_Scroll);
            // 
            // BrkMinSlider
            // 
            this.BrkMinSlider.AutoSize = false;
            this.BrkMinSlider.LargeChange = 1;
            this.BrkMinSlider.Location = new System.Drawing.Point(8, 112);
            this.BrkMinSlider.Maximum = 32767;
            this.BrkMinSlider.Name = "BrkMinSlider";
            this.BrkMinSlider.Size = new System.Drawing.Size(192, 32);
            this.BrkMinSlider.TabIndex = 25;
            this.BrkMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BrkMinSlider.Scroll += new System.EventHandler(this.BrkMinSlider_Scroll);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 24);
            this.label11.TabIndex = 24;
            this.label11.Text = "Range:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.CltMaxSlider);
            this.groupBox7.Controls.Add(this.CltMinSlider);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.ClutchAxisDisplayBar);
            this.groupBox7.Controls.Add(this.ClutchAxisDisplayText);
            this.groupBox7.Location = new System.Drawing.Point(656, 200);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(208, 184);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Clutch";
            // 
            // CltMaxSlider
            // 
            this.CltMaxSlider.AutoSize = false;
            this.CltMaxSlider.LargeChange = 1;
            this.CltMaxSlider.Location = new System.Drawing.Point(8, 144);
            this.CltMaxSlider.Maximum = 32767;
            this.CltMaxSlider.Name = "CltMaxSlider";
            this.CltMaxSlider.Size = new System.Drawing.Size(192, 32);
            this.CltMaxSlider.TabIndex = 27;
            this.CltMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CltMaxSlider.Value = 4095;
            this.CltMaxSlider.Scroll += new System.EventHandler(this.CltMaxSlider_Scroll);
            // 
            // CltMinSlider
            // 
            this.CltMinSlider.AutoSize = false;
            this.CltMinSlider.LargeChange = 1;
            this.CltMinSlider.Location = new System.Drawing.Point(8, 112);
            this.CltMinSlider.Maximum = 32767;
            this.CltMinSlider.Name = "CltMinSlider";
            this.CltMinSlider.Size = new System.Drawing.Size(192, 32);
            this.CltMinSlider.TabIndex = 25;
            this.CltMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CltMinSlider.Scroll += new System.EventHandler(this.CltMinSlider_Scroll);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 80);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 24);
            this.label13.TabIndex = 24;
            this.label13.Text = "Range:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FlipFfbButton);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.MaxVoutSlider);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.FFBLinearityDisplayText);
            this.groupBox4.Controls.Add(this.FfbLinearitySlider);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.FFBValueDisplayBar);
            this.groupBox4.Controls.Add(this.FFBValueDisplayText);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.FfbMultSlider);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(224, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 376);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FFB";
            // 
            // FlipFfbButton
            // 
            this.FlipFfbButton.BackgroundImage = global::wheel01.Properties.Resources.left_right;
            this.FlipFfbButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FlipFfbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlipFfbButton.Location = new System.Drawing.Point(176, 192);
            this.FlipFfbButton.Name = "FlipFfbButton";
            this.FlipFfbButton.Size = new System.Drawing.Size(24, 24);
            this.FlipFfbButton.TabIndex = 52;
            this.FlipFfbButton.UseVisualStyleBackColor = true;
            this.FlipFfbButton.Click += new System.EventHandler(this.FlipFfbButton_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 51;
            this.label3.Text = "9V";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 216);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "0V";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaxVoutSlider
            // 
            this.MaxVoutSlider.AutoSize = false;
            this.MaxVoutSlider.LargeChange = 1;
            this.MaxVoutSlider.Location = new System.Drawing.Point(8, 240);
            this.MaxVoutSlider.Maximum = 90;
            this.MaxVoutSlider.Name = "MaxVoutSlider";
            this.MaxVoutSlider.Size = new System.Drawing.Size(192, 32);
            this.MaxVoutSlider.TabIndex = 49;
            this.MaxVoutSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.MaxVoutSlider.Value = 90;
            this.MaxVoutSlider.Scroll += new System.EventHandler(this.MaxVoutSlider_Scroll);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 192);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 24);
            this.label5.TabIndex = 48;
            this.label5.Text = "Max Vout:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FFBLinearityDisplayText
            // 
            this.FFBLinearityDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FFBLinearityDisplayText.Location = new System.Drawing.Point(104, 120);
            this.FFBLinearityDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FFBLinearityDisplayText.Name = "FFBLinearityDisplayText";
            this.FFBLinearityDisplayText.Size = new System.Drawing.Size(96, 24);
            this.FFBLinearityDisplayText.TabIndex = 47;
            this.FFBLinearityDisplayText.Text = "-";
            this.FFBLinearityDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FfbLinearitySlider
            // 
            this.FfbLinearitySlider.AutoSize = false;
            this.FfbLinearitySlider.LargeChange = 1;
            this.FfbLinearitySlider.Location = new System.Drawing.Point(8, 144);
            this.FfbLinearitySlider.Maximum = 100;
            this.FfbLinearitySlider.Minimum = 1;
            this.FfbLinearitySlider.Name = "FfbLinearitySlider";
            this.FfbLinearitySlider.Size = new System.Drawing.Size(192, 32);
            this.FfbLinearitySlider.TabIndex = 46;
            this.FfbLinearitySlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.FfbLinearitySlider.Value = 10;
            this.FfbLinearitySlider.Scroll += new System.EventHandler(this.FfbLinearitySlider_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 45;
            this.label1.Text = "Linearity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(872, 393);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Wheel 01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FfbMultSlider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SteeringRangeSlider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccMinSlider)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrkMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrkMinSlider)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CltMaxSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CltMinSlider)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaxVoutSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FfbLinearitySlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox COMPortsComboBox;
        private System.Windows.Forms.Button COMPortsRefreshButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar SteeringAxisDisplayBar;
        private System.Windows.Forms.ProgressBar ClutchAxisDisplayBar;
        private System.Windows.Forms.ProgressBar BrakeAxisDisplayBar;
        private System.Windows.Forms.ProgressBar AcceleratorAxisDisplayBar;
        private System.Windows.Forms.Label ClutchAxisDisplayText;
        private System.Windows.Forms.Label BrakeAxisDisplayText;
        private System.Windows.Forms.Label AcceleratorAxisDisplayText;
        private System.Windows.Forms.Label SteeringAxisDisplayText;
        private System.Windows.Forms.Label FFBValueDisplayText;
        private System.Windows.Forms.Label label15;
        private System.IO.Ports.SerialPort SerialPortController;
        private System.Windows.Forms.Timer VJoyInitDelay;
        private System.Windows.Forms.Button FlipSteeringButton;
        private System.Windows.Forms.Timer DisplayUpdater;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox LogOutput;
        private System.Windows.Forms.Button CopyLogToClipboardButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label SteeringRangeDisplayText;
        private System.Windows.Forms.TrackBar SteeringRangeSlider;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ProgressBar FFBValueDisplayBar;
        private System.Windows.Forms.Button ResetZeroBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar AccMinSlider;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar AccMaxSlider;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar BrkMaxSlider;
        private System.Windows.Forms.TrackBar BrkMinSlider;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TrackBar CltMaxSlider;
        private System.Windows.Forms.TrackBar CltMinSlider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar FfbMultSlider;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox FidgetCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar FfbLinearitySlider;
        private System.Windows.Forms.Label FFBLinearityDisplayText;
        private System.Windows.Forms.Button FlipFfbButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar MaxVoutSlider;
        private System.Windows.Forms.Label label5;
    }
}

