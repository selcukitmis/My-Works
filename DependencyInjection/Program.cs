using System;
using DependencyInjection.Models;

namespace DependencyInjection
{
    internal class Program
    {
        private static void Main()
        {
            var human = new Human(new Jacket());
            var jacketDress = human.DressUp();
            Console.WriteLine("JACKET : {0}",jacketDress);

            human = new Human(new Pants());
            var pantsDress = human.DressUp();
            Console.WriteLine("PANTS : {0}", pantsDress);

            Console.ReadLine();
        }
    }
}
