using Project3.model;

namespace Project3.services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int animalId);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int animalId);
}