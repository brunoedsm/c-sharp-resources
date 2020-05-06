using System;

namespace brunoedsm.behavioral.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Command Pattern");
            CommandPlayer.PlayExample();
            Console.WriteLine("Running Observer Pattern");
            ObserverPlayer.PlayExample();

           
        }
    }
}
