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
            Wagon wagon = null;

            // We have to loop through all the wagons to determine if we can put it in an existing one
            foreach (Wagon _wagon in allWagons)
            {
                // Check if we can add the current animal in an existing wagon
                if (_wagon.CheckAnimalAdd(animal))
                {
                    wagon = _wagon;
                    // We have been able to add the animal to a wagon so break out of the loop
                    break;
                }
            }

            // wagon is still null meaning the animal could not be added. Add it to a new one instead
            if (wagon == null)
            {
                wagon = new Wagon();
                Wagons.Add(wagon);
            }

            wagon.AddAnimal(animal);
        }
    }
}
