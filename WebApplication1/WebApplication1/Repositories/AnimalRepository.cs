namespace WebApplication1.Models;

public class AnimalRepository : IAnimalRepository
{
    private static readonly Dictionary<int, Animal> Database = new Dictionary<int, Animal>();
    
    public List<Animal> GetAnimals()
    {
        return Database.Values.ToList();
    }

    public Animal GetAnimal(int id)
    {
        return Database[id];
    }

    public void AddAnimal(Animal animal)
    {
        Database.Add(animal.Id, animal);
    }
    
    public void RemoveAnimal(int id)
    {
        Database.Remove(id);
    }
}