namespace WebApplication1.Models;

public class AnimalRepository : IAnimalRepository
{
    private static readonly List<Animal> Database = new List<Animal>();


    public AnimalRepository()
    {
 
    }

    public List<Animal> GetAnimals()
    {
        return Database;
    }

    public Animal GetAnimal(int id)
    {
        return Database.Find(animal => animal.Id == id);
    }

    public Animal ReplaceAnimal(int id, Animal animal)
    {
        Database[id] = animal;
        return animal;
    }

    public Animal UpdateAnimal(int id, Animal animal)
    {
        Animal a = GetAnimal(id);
        a.Category = animal.Category;
        a.Mass = animal.Mass;
        a.Name = animal.Name;
        a.FurColor = animal.FurColor;
        return a;
    }


    public void AddAnimal(Animal animal)
    {
        Database.Add(animal);
    }
    
    public void RemoveAnimal(int id)
    {
        Database.Remove(Database.Find(animal => animal.Id == id));
    }
}