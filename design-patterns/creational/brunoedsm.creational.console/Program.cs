using System;

namespace brunoedsm.creational.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Abstract Factory Sample:");
            AbstractFactoryPlayer.PlayExample();
            Console.WriteLine("Starting Builder Sample:");
            BuilderPlayer.PlayExample();
            Console.WriteLine("Starting Factory Method Sample:");
            FactoryMethodPlayer.PlayExample();
            Console.WriteLine("Starting Prototype Sample:");
            PrototypePlayer.PlayExample();
            Console.WriteLine("Starting Singleton Sample:");
            SingletonPlayer.PlayExample();
            Console.ReadKey();
        }
    }
}
