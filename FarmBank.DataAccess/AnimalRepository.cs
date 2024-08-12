using BarnCase.Entities;
using System.Collections.Generic;

namespace BarnCase.DataAccess
{
    public class AnimalRepository
    {
        private List<Animal> _animals;

        public AnimalRepository()
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

        public IEnumerable<Animal> GetAll()
        {
            return _animals;
        }
    }
}
