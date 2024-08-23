using BarnCase.Entities;
using BarnCase.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarnCase.Business
{
    public class AnimalServices
    {
        // Hayvanlar eklendiğinde tetiklenecek olay.
        public event Action AnimalsAdded;
        private const int MaxAnimalCount = 5; // Bir hayvan türünden maksimum eklenebilecek sayı

        private ProductService _productService;

        public AnimalServices(ProductService productService)
        {
            _productService = productService;
        }

        // Belirli bir türde ve yaşta hayvan ekler ve hata mesajını döner.
        public string AddAnimal(string animalType, int age)
        {
            // Hayvan türünden maksimum sayıya ulaşılıp ulaşılmadığını kontrol et.
            if (IsAnimalLimitReached(animalType))
            {
                return $"Cannot add more than {MaxAnimalCount} {animalType}s."; // Hata mesajını döner
            }

            Animal animalToAdd;

            // Hayvan türüne göre uygun hayvan nesnesi oluşturur
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
                    throw new ArgumentException("Unknown animal type."); // Geçersiz hayvan türü durumunda hata döndürür.
            }

            // Oluşturulan hayvanı listeye ekler.
            AnimalStorage.AnimalList.Add(animalToAdd);

            // Hayvan eklendiğinde tetiklenecek olayı çağırır.
            AnimalsAdded?.Invoke();
            return null; // Hata mesajı yok, başarılı
        }

        // Belirtilen hayvan türünden 5'ten fazla eklenip eklenmediğini kontrol eder.
        private bool IsAnimalLimitReached(string animalType)
        {
            int count = AnimalStorage.AnimalList.Count(a => a.GetType().Name == animalType);
            return count >= MaxAnimalCount;
        }

        // Tüm hayvanları döndürür.
        public List<Animal> GetAnimals()
        {
            return AnimalStorage.AnimalList;
        }
    }
}


