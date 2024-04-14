namespace WebApplication1.Models;

public class Animal
{
    private static int ID = 1;
    
    public int Id { get; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Mass { get; set; }
    public string FurColor { get; set; }

    public Animal(string name, string category, double mass, string furColor)
    {
        Id = ID++; 
        Name = name;
        Category = category;
        Mass = mass;
        FurColor = furColor;
    }

    public Animal()
    {
        Id = ID++;
    }

    public override string ToString()
    {
        return "Animal:Id: " + Id + ", Category: " + Category;
    }
}