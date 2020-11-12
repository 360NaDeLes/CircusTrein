using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logic
{
    public class Wagon
    {
        private List<Animal> allAnimals;
        private int _size = 10;

        public Wagon()
        {
            allAnimals = new List<Animal>();
        }

        // Returns the wagons' current size
        public int GetSize()
        {
            return _size;
        }

        // Add animal to list and subtract it's size from the wagons' size
        public void AddAnimalToWagon(Animal animal)
        {
            allAnimals.Add(animal);
            _size -= animal.GetSize();
        }

        // Check if an animal is able to be added to an existing wagon. If that's not the case, add another wagon
        public bool AnimalAddCheck(Animal animal)
        {
            if (_size > animal.GetSize())
            {
                // Check if there are other carnivores already
                if (!CheckCarnivore()) // Animal is a herbivore
                {
                    // Get smallest herbivore
                    Animal smallestHerbivore = GetSmallestHerbivore();

                    if (smallestHerbivore != null && smallestHerbivore.GetSize() > animal.GetSize())
                    {
                        return true;
                    }
                }
                else // Animal is a carnivore
                {
                    // Get biggest carnivore
                    Animal biggestCarnivore = GetBiggestCarnivore();

                    if (animal.GetSize() > biggestCarnivore.GetSize())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Check if there are other carnivores already
        private bool CheckCarnivore()
        {
            foreach(Animal animal in allAnimals)
            {
                if (animal is Carnivore)
                {
                    return true;
                }
            }

            return false;
        }

        // Get the smallest herbivore
        private Herbivore GetSmallestHerbivore()
        {
            Herbivore herbivore = null;

            foreach (Animal animal in allAnimals)
            {
                // Check for herbivores
                if (animal is Herbivore)
                {
                    // If herbivore == null, give it a value
                    if (herbivore == null)
                    {
                        herbivore = (Herbivore)animal;
                    }
                    else if (animal.GetSize() < herbivore.GetSize()) // herbivore !== null
                    {
                        // Fill herbivore with smallest herbivore
                        herbivore = (Herbivore)animal;
                    }
                }
            }
            
            return herbivore;
        }

        // Get biggest carnivore. Only 1 carnivore can exist per wagon
        private Carnivore GetBiggestCarnivore()
        {
            Carnivore carnivore = new Carnivore("", 0);

            foreach (Animal animal in allAnimals)
            {
                // Check for carnivores
                if (animal is Carnivore)
                {
                    carnivore = (Carnivore)animal;
                    
                    // Break the loop if the biggest carnivore is found
                    break;
                }
            }

            return carnivore;
        }

        // Return all animal names and sizes
        public string CheckAnimalsInWagon()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Animal animal in allAnimals)
            {
                builder.Append($"{animal.GetName()} {animal.GetSize()}");
            }

            return builder.ToString();
        }
    }
}
