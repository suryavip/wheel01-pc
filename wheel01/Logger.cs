using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Logger
    {
        const int lengthLimit = 500;

        public static String appLog = "";
        //public static String rxLog = "";
        //public static String txLog = "";

        //public static String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\vipwheel\\log-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
        //static FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
        //static StreamWriter writer = new StreamWriter(fileStream);

        public static void App(string log)
        {
            appLog = "- " + log + Environment.NewLine + appLog;
            if (appLog.Length > lengthLimit)
            {
                appLog = appLog.Substring(0, lengthLimit);
            }

            Console.WriteLine(log);

            //writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + ", " + log);
        }

        public static void Rx(string log)
        {
            //rxLog = log + Environment.NewLine + rxLog;
            //if (rxLog.Length > lengthLimit)
            //{
            //    rxLog = rxLog.Substring(0, lengthLimit);
            //}
        }

        public static void Tx(string log)
        {
            //txLog = log + Environment.NewLine + txLog;
            //if (txLog.Length > lengthLimit)
            //{
            //    txLog = txLog.Substring(0, lengthLimit);
            //}
        }
    }
}
