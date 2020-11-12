using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Train
    {
        private List<Wagon> allWagons = new List<Wagon>();

        public Train()
        {
            allWagons = new List<Wagon>();
        }

        public string GetAnimalsFromWagon()
        {
            StringBuilder builder = new StringBuilder();

            for (var i = 0; i < allWagons.ToList().Count; i++)
            {
                var wagon = allWagons.ToList()[i];
                builder.AppendLine($"Wagon {i} : {wagon.AnimalsInWagon()} size remaining: {wagon.GetSize()}.");
            }

            return builder.ToString();
        }

        public void AddAnimal(Animal animal)
        {

        }
    }
}
