using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest
{
    //http://geekswithblogs.net/danielggarcia/archive/2014/01/23/introduction-to-dependency-injection-with-unity.aspx
    class Program
    {
        private static UnityContainer container;

        static void Main(string[] args)
        {
            container = new UnityContainer();

            RegTest1();
            RegTest2();

            Console.ReadKey();
        }

        private static void First()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IGame, TrivialPursuit>();

            var table = unityContainer.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }

        private static void Second()
        {
            var unityContainer = new UnityContainer();

            InjectionProperty injectionProperty = new InjectionProperty("Name", "Trivial Pursuit Genus Edition");
            unityContainer.RegisterType<IGame, TrivialPursuit>(injectionProperty);

            var table = unityContainer.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }

        private static void Third()
        {
            var unityContainer = new UnityContainer();

            InjectionProperty injectionProperty = new InjectionProperty("Name", "Trivial Pursuit Genus Edition");
            unityContainer.RegisterType<IGame, TrivialPursuit>(injectionProperty);

            var table = unityContainer.Resolve<Table>(new ParameterOverride("game", new TicTacToe()));

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }

        private static void Singleton()
        {
            var unityContainer = new UnityContainer();

            //Singleton
            unityContainer.RegisterType<IGame, TrivialPursuit>(new ContainerControlledLifetimeManager());

            var table = unityContainer.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }

        private static void RegisterExistingObject()
        {
            var game = new TrivialPursuit();

            //Register existing object az a singleton
           container.RegisterInstance<IGame>(game);

            var table = container.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }

        private static void InjectionMethodTest()
        {
            IUnityContainer uContainer = new UnityContainer();
            InjectionMethodTestClass myInstance = uContainer.Resolve<InjectionMethodTestClass>();

            // access the dependent object
            myInstance.dependentObject.SomeProperty = "Some value";

            Console.WriteLine(myInstance.dependentObject.SomeProperty);
        }

        private static void InjectionMethodTest2()
        {
            IUnityContainer uContainer = new UnityContainer()
               .RegisterType<IMyInterface, FirstObject>()
               .RegisterType<MyBaseClass, SecondObject>();
            InjectionMethodTestClass2 myInstance = uContainer.Resolve<InjectionMethodTestClass2>();

            // now access the public variables containing the dependencies
            IMyInterface depObjA = myInstance.depObjectA;
            MyBaseClass depObjB = myInstance.depObjectB;
        }

        private static void RegTest1()
        {
            //var unityContainer = new UnityContainer();

            //Singleton
            container.RegisterType<IGame, TrivialPursuit>(new ContainerControlledLifetimeManager());
        }

        private static void RegTest2()
        {
            var table = container.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
        }
    }
}
