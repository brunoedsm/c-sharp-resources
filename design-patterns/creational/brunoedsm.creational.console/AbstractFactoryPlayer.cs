/*
    Scenario for use Abstract Factory:
    World regions (Africa,America,Asia) that have distinct food chains and animals,    
    the factory will return a concrete implementation of these rules.
    For better reference, please visit https://www.dofactory.com/net/design-patterns
*/
using System;

namespace brunoedsm.creational.console
{

    public static class AbstractFactoryPlayer
    {
        public static void PlayExample()
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            ContinentFactory asia = new AsiaFactory();
            world = new AnimalWorld(asia);
            world.RunFoodChain();
        }

    }

    // Abstracts
    abstract class Herbivore
    {

    }
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    // Concretes
    class Bison : Herbivore
    {

    }
    class Wildebeest : Herbivore
    {

    }
    class Auroch : Herbivore
    {

    }
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    class Bear : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class AsiaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Auroch();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Bear();
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }

    }


}