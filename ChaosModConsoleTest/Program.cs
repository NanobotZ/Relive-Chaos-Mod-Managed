using AEChaosModManaged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosModConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChaosMod._init();

            Console.ReadKey();

            ChaosMod._close();
        }
    }
}
