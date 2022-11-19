using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Logger
    {
        const int lengthLimit = 500;

        public static String appLog = "";
        public static String rxLog = "";
        public static String txLog = "";

        public static void App(string log)
        {
            appLog = "- " + log + Environment.NewLine + appLog;
            if (appLog.Length > lengthLimit)
            {
                appLog = appLog.Substring(0, lengthLimit);
            }

            Console.WriteLine(log);
        }

        public static void Rx(string log)
        {
            rxLog = log + Environment.NewLine + rxLog;
            if (rxLog.Length > lengthLimit)
            {
                rxLog = rxLog.Substring(0, lengthLimit);
            }
        }

        public static void Tx(string log)
        {
            txLog = log + Environment.NewLine + txLog;
            if (txLog.Length > lengthLimit)
            {
                txLog = txLog.Substring(0, lengthLimit);
            }
        }
    }
}
