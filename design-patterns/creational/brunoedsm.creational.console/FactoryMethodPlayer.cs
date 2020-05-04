/*
    Scenario for use Factory method:
    Have a method to build objects that correspond with rules of abstract factory method implementation
    repare that concrete object is received inside an absract (at this case Document)
    For better reference, please visit https://www.dofactory.com/net/design-patterns
*/
using System;
using System.Collections.Generic;

namespace brunoedsm.creational.console
{

    public static class FactoryMethodPlayer
    {
        public static void PlayExample()
        {
            Document[] documents = new Document[2];
            documents[0] = new ScientificPaper();
            documents[1] = new NewsPaper();

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
        }

    }
    // Abstracts
    abstract class Page
    {

    }
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        // Constructor calls abstract Factory method

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // Factory Method

        public abstract void CreatePages();
    }
    // Concretes
    class ScientificPaper : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new DevelopmentPage());
            Pages.Add(new ConclusionPage());
        }
    }

    class NewsPaper : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new DevelopmentPage());
        }
    }
    class IntroductionPage : Page
    {

    }
    class DevelopmentPage : Page
    {

    }
    class ConclusionPage : Page
    {

    }

}
