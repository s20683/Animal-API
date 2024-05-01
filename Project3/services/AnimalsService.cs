using Project3.model;
using Project3.repositories;

namespace Project3.services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _animalsRepository.GetAnimals();
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);

    }

    public Animal GetAnimal(int animalId)
    {
        return _animalsRepository.GetAnimal(animalId);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalsRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int animalId)
    {
        return _animalsRepository.DeleteAnimal(animalId);
    }
}