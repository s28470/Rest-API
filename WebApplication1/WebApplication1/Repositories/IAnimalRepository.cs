namespace WebApplication1.Models;

public interface IAnimalRepository
{
    List<Animal> GetAnimals();

    Animal GetAnimal(int id);

    void AddAnimal(Animal animal);
    void RemoveAnimal(int id);
}