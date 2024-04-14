using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Visit
{
    private static int ID = 1;

    public int Id { get; }

    public DateTime Date { get; set; }
    
    public Animal Animal { get; set; }

    public String Description { get; set; }
    
    public double Price { get; set; }

    public Visit(DateTime date, Animal animal, string description, double price)
    {
        Id = ID++;
        Date = date;
        Animal = animal;
        Description = description;
        Price = price;
    }

    public Visit()
    {
        Id = ID++;
    }
}