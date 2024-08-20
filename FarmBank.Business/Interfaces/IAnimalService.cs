using BarnCase.Entities;

namespace BarnCase.Business.Interfaces
{
    public  interface IAnimalService
    {
        void AddAnimal(Animal animal);
        void RemoveAnimal(Animal animal);
        IEnumerable<Animal> GetAnimals();
    }
}

