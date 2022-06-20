using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Performance_Counters_Test
{
    class Program
    {
        static void Main()
        {
            PerformanceCountersTest();

            Console.ReadKey();
        }

        static void PerformanceCountersTest()
        {
            // This Performance Counter will read how much available memory there is.
            // And displays it on the screen.

            Console.WriteLine("Press excape key to stop");

            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.WriteLine(text);
                
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Thread.Sleep(300);
                        Console.WriteLine(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }

        }
    }
}
