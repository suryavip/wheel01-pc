﻿namespace wheel01
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
            this.label1 = new System.Windows.Forms.Label();
            this.COMPortsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EncoderMultRotPositionDisplayText = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.EncoderPositionDisplayText = new System.Windows.Forms.Label();
            this.EncoderPositionDisplayBar = new System.Windows.Forms.ProgressBar();
            this.label13 = new System.Windows.Forms.Label();
            this.TxLogOutput = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RxLogOutput = new System.Windows.Forms.RichTextBox();
            this.COMPortsRefreshButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SteeringRangeDisplayText = new System.Windows.Forms.Label();
            this.SteeringRangeSlider = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.FlipSteeringButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar7 = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.progressBar8 = new System.Windows.Forms.ProgressBar();
            this.SteeringAxisDisplayText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SteeringAxisDisplayBar = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.SerialPortController = new System.IO.Ports.SerialPort(this.components);
            this.VJoyInitDelay = new System.Windows.Forms.Timer(this.components);
            this.DisplayUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CopyLogToClipboardButton = new System.Windows.Forms.Button();
            this.LogOutput = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SteeringRangeSlider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // COMPortsComboBox
            // 
            this.COMPortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMPortsComboBox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMPortsComboBox.FormattingEnabled = true;
            this.COMPortsComboBox.ItemHeight = 15;
            this.COMPortsComboBox.Location = new System.Drawing.Point(130, 23);
            this.COMPortsComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.COMPortsComboBox.Name = "COMPortsComboBox";
            this.COMPortsComboBox.Size = new System.Drawing.Size(170, 23);
            this.COMPortsComboBox.TabIndex = 1;
            this.COMPortsComboBox.SelectedIndexChanged += new System.EventHandler(this.COMPortsComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EncoderMultRotPositionDisplayText);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.EncoderPositionDisplayText);
            this.groupBox1.Controls.Add(this.EncoderPositionDisplayBar);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.COMPortsRefreshButton);
            this.groupBox1.Controls.Add(this.COMPortsComboBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // EncoderMultRotPositionDisplayText
            // 
            this.EncoderMultRotPositionDisplayText.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncoderMultRotPositionDisplayText.Location = new System.Drawing.Point(220, 120);
            this.EncoderMultRotPositionDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EncoderMultRotPositionDisplayText.Name = "EncoderMultRotPositionDisplayText";
            this.EncoderMultRotPositionDisplayText.Size = new System.Drawing.Size(119, 30);
            this.EncoderMultRotPositionDisplayText.TabIndex = 21;
            this.EncoderMultRotPositionDisplayText.Text = "-";
            this.EncoderMultRotPositionDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(10, 120);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(200, 30);
            this.label17.TabIndex = 19;
            this.label17.Text = "Encoder Multi Rotation Position:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EncoderPositionDisplayText
            // 
            this.EncoderPositionDisplayText.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncoderPositionDisplayText.Location = new System.Drawing.Point(220, 60);
            this.EncoderPositionDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EncoderPositionDisplayText.Name = "EncoderPositionDisplayText";
            this.EncoderPositionDisplayText.Size = new System.Drawing.Size(119, 30);
            this.EncoderPositionDisplayText.TabIndex = 18;
            this.EncoderPositionDisplayText.Text = "-";
            this.EncoderPositionDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EncoderPositionDisplayBar
            // 
            this.EncoderPositionDisplayBar.Location = new System.Drawing.Point(10, 90);
            this.EncoderPositionDisplayBar.Maximum = 4095;
            this.EncoderPositionDisplayBar.Name = "EncoderPositionDisplayBar";
            this.EncoderPositionDisplayBar.Size = new System.Drawing.Size(330, 20);
            this.EncoderPositionDisplayBar.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 60);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 30);
            this.label13.TabIndex = 16;
            this.label13.Text = "Encoder Position:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxLogOutput
            // 
            this.TxLogOutput.BackColor = System.Drawing.SystemColors.Window;
            this.TxLogOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxLogOutput.Location = new System.Drawing.Point(180, 50);
            this.TxLogOutput.Name = "TxLogOutput";
            this.TxLogOutput.ReadOnly = true;
            this.TxLogOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.TxLogOutput.Size = new System.Drawing.Size(160, 90);
            this.TxLogOutput.TabIndex = 7;
            this.TxLogOutput.Text = "";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "PC to Arduino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Arduino to PC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RxLogOutput
            // 
            this.RxLogOutput.BackColor = System.Drawing.SystemColors.Window;
            this.RxLogOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RxLogOutput.Location = new System.Drawing.Point(10, 50);
            this.RxLogOutput.Name = "RxLogOutput";
            this.RxLogOutput.ReadOnly = true;
            this.RxLogOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RxLogOutput.Size = new System.Drawing.Size(160, 90);
            this.RxLogOutput.TabIndex = 4;
            this.RxLogOutput.Text = "";
            // 
            // COMPortsRefreshButton
            // 
            this.COMPortsRefreshButton.BackgroundImage = global::wheel01.Properties.Resources.arrows_rotate_11;
            this.COMPortsRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.COMPortsRefreshButton.Location = new System.Drawing.Point(310, 20);
            this.COMPortsRefreshButton.Name = "COMPortsRefreshButton";
            this.COMPortsRefreshButton.Size = new System.Drawing.Size(30, 30);
            this.COMPortsRefreshButton.TabIndex = 3;
            this.COMPortsRefreshButton.UseVisualStyleBackColor = true;
            this.COMPortsRefreshButton.Click += new System.EventHandler(this.COMPortsRefreshButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SteeringRangeDisplayText);
            this.groupBox2.Controls.Add(this.SteeringRangeSlider);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.FlipSteeringButton);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.progressBar7);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.progressBar8);
            this.groupBox2.Controls.Add(this.SteeringAxisDisplayText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SteeringAxisDisplayBar);
            this.groupBox2.Location = new System.Drawing.Point(370, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 230);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steering";
            // 
            // SteeringRangeDisplayText
            // 
            this.SteeringRangeDisplayText.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteeringRangeDisplayText.Location = new System.Drawing.Point(110, 90);
            this.SteeringRangeDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SteeringRangeDisplayText.Name = "SteeringRangeDisplayText";
            this.SteeringRangeDisplayText.Size = new System.Drawing.Size(100, 30);
            this.SteeringRangeDisplayText.TabIndex = 26;
            this.SteeringRangeDisplayText.Text = "-";
            this.SteeringRangeDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SteeringRangeSlider
            // 
            this.SteeringRangeSlider.AutoSize = false;
            this.SteeringRangeSlider.Location = new System.Drawing.Point(10, 120);
            this.SteeringRangeSlider.Maximum = 4;
            this.SteeringRangeSlider.Minimum = 1;
            this.SteeringRangeSlider.Name = "SteeringRangeSlider";
            this.SteeringRangeSlider.Size = new System.Drawing.Size(200, 40);
            this.SteeringRangeSlider.TabIndex = 25;
            this.SteeringRangeSlider.Value = 3;
            this.SteeringRangeSlider.Scroll += new System.EventHandler(this.SteeringRangeSlider_Scroll);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 30);
            this.label12.TabIndex = 24;
            this.label12.Text = "Steering Range:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlipSteeringButton
            // 
            this.FlipSteeringButton.BackgroundImage = global::wheel01.Properties.Resources.left_right;
            this.FlipSteeringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FlipSteeringButton.Location = new System.Drawing.Point(180, 20);
            this.FlipSteeringButton.Name = "FlipSteeringButton";
            this.FlipSteeringButton.Size = new System.Drawing.Size(30, 30);
            this.FlipSteeringButton.TabIndex = 22;
            this.FlipSteeringButton.UseVisualStyleBackColor = true;
            this.FlipSteeringButton.Click += new System.EventHandler(this.FlipSteeringButton_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(110, 170);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 30);
            this.label14.TabIndex = 21;
            this.label14.Text = "-";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar7
            // 
            this.progressBar7.Location = new System.Drawing.Point(110, 200);
            this.progressBar7.Maximum = 10000;
            this.progressBar7.Name = "progressBar7";
            this.progressBar7.Size = new System.Drawing.Size(100, 20);
            this.progressBar7.Step = 1;
            this.progressBar7.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 170);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 30);
            this.label15.TabIndex = 19;
            this.label15.Text = "FFB Value:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar8
            // 
            this.progressBar8.Location = new System.Drawing.Point(10, 200);
            this.progressBar8.Maximum = 10000;
            this.progressBar8.Name = "progressBar8";
            this.progressBar8.Size = new System.Drawing.Size(100, 20);
            this.progressBar8.Step = 1;
            this.progressBar8.TabIndex = 18;
            // 
            // SteeringAxisDisplayText
            // 
            this.SteeringAxisDisplayText.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SteeringAxisDisplayText.Location = new System.Drawing.Point(110, 20);
            this.SteeringAxisDisplayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SteeringAxisDisplayText.Name = "SteeringAxisDisplayText";
            this.SteeringAxisDisplayText.Size = new System.Drawing.Size(60, 30);
            this.SteeringAxisDisplayText.TabIndex = 14;
            this.SteeringAxisDisplayText.Text = "-";
            this.SteeringAxisDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Steering Axis:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SteeringAxisDisplayBar
            // 
            this.SteeringAxisDisplayBar.Location = new System.Drawing.Point(10, 60);
            this.SteeringAxisDisplayBar.Maximum = 32767;
            this.SteeringAxisDisplayBar.Name = "SteeringAxisDisplayBar";
            this.SteeringAxisDisplayBar.Size = new System.Drawing.Size(200, 20);
            this.SteeringAxisDisplayBar.Step = 1;
            this.SteeringAxisDisplayBar.TabIndex = 0;
            this.SteeringAxisDisplayBar.Value = 16383;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(110, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 30);
            this.label11.TabIndex = 17;
            this.label11.Text = "-";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(110, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 30);
            this.label10.TabIndex = 16;
            this.label10.Text = "-";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(110, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "-";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(10, 170);
            this.progressBar5.Maximum = 32767;
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(200, 20);
            this.progressBar5.Step = 1;
            this.progressBar5.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "Clutch:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(10, 110);
            this.progressBar4.Maximum = 32767;
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(200, 20);
            this.progressBar4.Step = 1;
            this.progressBar4.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "Brake:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(10, 50);
            this.progressBar3.Maximum = 32767;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(200, 20);
            this.progressBar3.Step = 1;
            this.progressBar3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "Throttle:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialPortController
            // 
            this.SerialPortController.ReceivedBytesThreshold = 16;
            this.SerialPortController.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPortController_DataReceived);
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
            this.groupBox3.Controls.Add(this.CopyLogToClipboardButton);
            this.groupBox3.Controls.Add(this.LogOutput);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.RxLogOutput);
            this.groupBox3.Controls.Add(this.TxLogOutput);
            this.groupBox3.Location = new System.Drawing.Point(10, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 270);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // CopyLogToClipboardButton
            // 
            this.CopyLogToClipboardButton.BackgroundImage = global::wheel01.Properties.Resources.copy;
            this.CopyLogToClipboardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CopyLogToClipboardButton.Location = new System.Drawing.Point(310, 230);
            this.CopyLogToClipboardButton.Name = "CopyLogToClipboardButton";
            this.CopyLogToClipboardButton.Size = new System.Drawing.Size(30, 30);
            this.CopyLogToClipboardButton.TabIndex = 6;
            this.CopyLogToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyLogToClipboardButton.Click += new System.EventHandler(this.CopyLogToClipboardButton_Click);
            // 
            // LogOutput
            // 
            this.LogOutput.BackColor = System.Drawing.SystemColors.Window;
            this.LogOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogOutput.HideSelection = false;
            this.LogOutput.Location = new System.Drawing.Point(10, 150);
            this.LogOutput.Name = "LogOutput";
            this.LogOutput.ReadOnly = true;
            this.LogOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LogOutput.Size = new System.Drawing.Size(290, 110);
            this.LogOutput.TabIndex = 5;
            this.LogOutput.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.progressBar3);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.progressBar4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.progressBar5);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(370, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 200);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pedals";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Wheel 01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SteeringRangeSlider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox COMPortsComboBox;
        private System.Windows.Forms.Button COMPortsRefreshButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TxLogOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RxLogOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar SteeringAxisDisplayBar;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label SteeringAxisDisplayText;
        private System.Windows.Forms.Label EncoderPositionDisplayText;
        private System.Windows.Forms.ProgressBar EncoderPositionDisplayBar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar progressBar7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar progressBar8;
        private System.IO.Ports.SerialPort SerialPortController;
        private System.Windows.Forms.Timer VJoyInitDelay;
        private System.Windows.Forms.Button FlipSteeringButton;
        private System.Windows.Forms.Timer DisplayUpdater;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox LogOutput;
        private System.Windows.Forms.Button CopyLogToClipboardButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label SteeringRangeDisplayText;
        private System.Windows.Forms.TrackBar SteeringRangeSlider;
        private System.Windows.Forms.Label EncoderMultRotPositionDisplayText;
        private System.Windows.Forms.Label label17;
    }
}

