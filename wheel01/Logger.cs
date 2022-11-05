using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wheel01
{
    internal class Logger
    {
        static public String allLogs = "";

        static public void AddLine(string log)
        {
            allLogs = "- " + log + Environment.NewLine + allLogs;
            Console.WriteLine(log);
        }
    }
}
