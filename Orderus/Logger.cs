using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderus
{
    class Logger
    {
        public static List<string> log = new List<string>();

        public Logger()
        {
            log = new List<string>();
        }

        public static void AddToLog(string message)
        {
            log.Add(message);
        }

        public static void ShowLog()
        {
            foreach(string message in log)
            {
                Console.WriteLine(message);
            }
        }
    }
}
