using BarnCase.Entities;
using BarnCase.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarnCase.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly List<Animal> _animals;

        public AnimalService()
        {
            _animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            _animals.Remove(animal);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }
    }
}