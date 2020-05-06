using System;
using System.Linq;
using System.Collections.Generic;

namespace brunoedsm.behavioral.console
{

    public static class CommandPlayer
    {
        public static void PlayExample()
        {
            List<Command> queue = new List<Command>();
            queue.Add(new CreditCommand());
            queue.Add(new DebitCommand());
            queue.Add(new CreditCommand());

            ExecuteQueue(queue);

        }
        public static void ExecuteQueue(List<Command> queue)
        {
            foreach (var command in queue)
            {
                command.execute();
            }
        }
    }
    // abstracts
    public interface Command
    {
        void execute();
    }

    // concretes
    public class CreditCommand : Command
    {
        public void execute()
        {
            Console.WriteLine("A credit will be updated into your account in instants...");
        }
    }

    public class DebitCommand : Command
    {
        public void execute()
        {
            Console.WriteLine("The amount was discounted of your account...");
        }
    }
    public class CreditCardCommand : Command
    {
        public void execute()
        {
            Console.WriteLine("Your buy will be discounted of your account at next month...");
        }
    }



}