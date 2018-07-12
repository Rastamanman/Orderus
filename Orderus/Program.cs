using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderus
{
    class Program
    {
        static void Main(string[] args)
        {
            LaunchGame();
            Logger.ShowLog();
            Console.ReadLine();
        }

        public static void LaunchGame()
        {
            Game joc = new Game();
            joc.Play();
        }
    }
}
