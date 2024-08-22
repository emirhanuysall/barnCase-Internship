using BarnCase.Entities;
using BarnCase.DataAccess;
using System.Collections.Generic;

namespace BarnCase.Business
{
    public class AnimalServices
    {
        //Hayvanlar eklendiğinde tetiklenecek olay.
        public event Action AnimalsAdded;
        //Belirli bir türde ve yaşta hayvan ekler.
        public void AddAnimal(string animalType, int age)
        {
            Animal animalToAdd;

            //Hayvan türüne göre uygun hayvan nesnesi oluşturur
            switch (animalType)
            {
                case "Cow":
                    animalToAdd = new Cow { Name = animalType, Age = age };
                    break;
                case "Sheep":
                    animalToAdd = new Sheep { Name = animalType, Age = age };
                    break;
                case "Chicken":
                    animalToAdd = new Chicken { Name = animalType, Age = age };
                    break;
                default:
                    throw new ArgumentException("Unknown animal type."); //Geçersiz hayvan türü durumunda hata döndürür.
            }

            //Oluşturulan hayvanı listeye ekler.
            AnimalStorage.AnimalList.Add(animalToAdd);

            //Hayvan eklendiğinde tetiklenecek olayı çağırır.
            AnimalsAdded?.Invoke();
        }

        //Tüm hayvanları döndürür.
        public List<Animal> GetAnimals()
        {
            return AnimalStorage.AnimalList;
        }
    }
}