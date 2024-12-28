using System;
using System.IO.Ports;

namespace wheel01
{
    internal class SerialCom
    {
        private SerialPort serialPort;
        private bool caughtError;
        private Action<string> _onDataReceived;
        private Action _onConnect;
        private string _portName;

        public void Connect(string portName, Action onConnect, Action<string> onDataReceived)
        {
            Logger.App(string.Format("Connecting to {0}...", portName));

            try
            {
                _onConnect = onConnect;
                _onDataReceived = onDataReceived;
                _portName = portName;

                serialPort = new SerialPort();
                serialPort.BaudRate = 115200;
                serialPort.PortName = portName;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.ReadTimeout = 300;
                serialPort.WriteTimeout = 300;
                serialPort.WriteBufferSize = 256;
                serialPort.ReadBufferSize = 256;
                serialPort.ReceivedBytesThreshold = 1;
                serialPort.RtsEnable = true;
                serialPort.DtrEnable = true;
                serialPort.DataReceived += DataReceived;
                serialPort.Open();

                Logger.App(string.Format("Connected to {0}!", portName));

                onConnect();
            }
            catch (Exception ex)
            {
                Logger.App(string.Format("Failed connecting to {0}: {1}", portName, ex.Message));
            }
        }

        public void Send(string tosent, Action onError)
        {
            if (caughtError)
            {
                Logger.App("Serial Send is blocked due to error on last try!");
                caughtError = false;
                serialPort.Dispose();
                return;
            }

            if (serialPort.IsOpen == false)
            {
                return;
            }

            try
            {
                serialPort.Write(tosent);
                Logger.Tx(tosent);
            }
            catch (Exception ex)
            {
                Logger.App(string.Format("Error on sending data: {0}", ex.Message));
                caughtError = true;
                onError();
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string read = serialPort.ReadTo(";");
                if (read == null || read.Length == 0) return;
                Logger.Rx(read);
                _onDataReceived(read);
            }
            catch (Exception ex)
            {
                Logger.App(string.Format("Error on receiving data: {0}", ex.Message));
            }
        }
    }
}
