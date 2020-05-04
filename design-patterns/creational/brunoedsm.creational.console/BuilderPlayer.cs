/*
    Scenario for use Builder:
    We have a final product that will be builded following particular characteristics, as 
    a stratocaster guitar and telecaster guitar
    For better reference, please visit https://www.dofactory.com/net/design-patterns
*/
using System;
using System.Collections.Generic;

namespace brunoedsm.creational.console
{

    public static class BuilderPlayer
    {
        public static void PlayExample()
        {
            StratocasterBuilder sb = new StratocasterBuilder();
            TelecasterBuilder tb = new TelecasterBuilder();
            Manufacturer m  = new Manufacturer();
            m.Construct(sb);
            m.Construct(tb);

            var product1 = sb.GetResult();
            var product2 = tb.GetResult();

            product1.Show();
            product2.Show();    
        }

    }
    // Abstracts
    abstract class Builder
    {
        public abstract void AddModel();
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    // Concretes
    class Manufacturer{
        public void Construct(Builder builder)
        {
            builder.AddModel();
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
    class StratocasterBuilder : Builder
    {
        private Product _product = new Product();

        public override void AddModel()
        {
            _product.Add("Stratocaster Default");
        }
        public override void BuildPartA()
        {
            _product.Add("Alnico Bridge and Neck PickUps");
        }

        public override void BuildPartB()
        {
            _product.Add("Alnico Medium PickUp");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
    class TelecasterBuilder : Builder
    {
        private Product _product = new Product();
        public override void AddModel()
        {
            _product.Add("Telecaster Default");
        }
        public override void BuildPartA()
        {
            _product.Add("Vintage Bridge PickUp");
        }

        public override void BuildPartB()
        {
            _product.Add("Gloss Neck PickUp");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
    class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nGuitar Picks -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }

}
