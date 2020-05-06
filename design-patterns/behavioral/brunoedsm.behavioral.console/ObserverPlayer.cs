using System;
using System.Linq;
using System.Collections.Generic;

namespace brunoedsm.behavioral.console
{
    public static class ObserverPlayer
    {
        public static void PlayExample()
        {
            Subject investmentHub = new Subject();
            new StateTreasureObserver(investmentHub);
            new DebentureObserver(investmentHub);
            new COEObserver(investmentHub);

            for(int i = 0; i < 5; i++){
                Console.WriteLine("Enter your investment option (1,2,3)");
                int test = 0;
                bool isNumber = int.TryParse(Console.ReadLine(),out test);
                investmentHub.setState(test);
            }

        }

    }

    // abstracts
    abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }

    // concretes
    class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;

        public void add(Observer o)
        {
            observers.Add(o);
        }

        public int getState()
        {
            return state;
        }

        public void setState(int value)
        {
            this.state = value;
            execute();
        }

        private void execute()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    class StateTreasureObserver : Observer
    {
        public StateTreasureObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.add(this);
        }

        public override void Update()
        {
            if (this.subject.getState() == 1)
            {
                Console.WriteLine("You will invest your money on State Treasure");
            }
             else
                Console.WriteLine("State Treasure:Pass...");
        }
    }

    class DebentureObserver : Observer
    {
        public DebentureObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.add(this);
        }

        public override void Update()
        {
            if (this.subject.getState() == 2)
            {
                Console.WriteLine("You will invest your money on Debenture Treasure");
            }
            else
                Console.WriteLine("Debenture:Pass...");
        }
    }
    class COEObserver : Observer
    {
        public COEObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.add(this);
        }

        public override void Update()
        {
            if (this.subject.getState() == 3)
            {
                Console.WriteLine("You will invest your money on COE Edge Fund");
            } 
            else
                Console.WriteLine("COE:Pass...");
        }
    }

}
