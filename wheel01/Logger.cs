using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Logger
    {
        static public String appLog = "";
        static public String rxLog = "";
        static public String txLog = "";

        static public void App(string log)
        {
            appLog = "- " + log + Environment.NewLine + appLog;
            Console.WriteLine(log);
        }

        static public void Rx(string log)
        {
            rxLog = log + Environment.NewLine + rxLog;
        }

        static public void Tx(string log)
        {
            txLog = log + Environment.NewLine + txLog;
        }
    }
}
