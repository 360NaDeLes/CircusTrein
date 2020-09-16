using System;
using Logic;

namespace CircusTrein
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal beaver = new Herbivore("Bever", 1);

            Console.WriteLine("Beaver Name = {0} Size = {1}", beaver.GetName(), beaver.GetSize());
        }
    }
}
