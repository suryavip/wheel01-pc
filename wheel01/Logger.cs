using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Logger
    {
        public static String appLog = "";
        public static String rxLog = "";
        public static String txLog = "";

        public static void App(string log)
        {
            appLog = "- " + log + Environment.NewLine + appLog;
            Console.WriteLine(log);
        }

        public static void Rx(string log)
        {
            rxLog = log + Environment.NewLine + rxLog;
        }

        public static void Tx(string log)
        {
            txLog = log + Environment.NewLine + txLog;
        }
    }
}
