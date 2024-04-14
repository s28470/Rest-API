using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IAnimalRepository animalRepository = new AnimalRepository();
Animal a1 = new Animal
{
    Name = "Pet1",
    Category = "Cat",
    Mass = 20.2,
    FurColor = "black"
};
        
Animal a2 = new Animal
{
    Name = "Pet2",
    Category = "Dog",
    Mass = 100,
    FurColor = "black"
};
        
Animal a3 = new Animal
{
    Name = "Pet3",
    Category = "Bird",
    Mass = 2,
    FurColor = "black"
};
        
animalRepository.AddAnimal(a1);
animalRepository.AddAnimal(a2);
animalRepository.AddAnimal(a3);
IVisitRepository visitRepository = new VisitRepository();
Visit v = new Visit
{
    Description = "",
    Date = DateTime.Now,
    Animal = a1,
    Price = 100
    
};
visitRepository.AddVisit(v);
app.UseHttpsRedirection();

// get
app.MapGet("animals", () => animalRepository.GetAnimals());
app.MapGet("animals/{id:int}", (int id) => animalRepository.GetAnimal(id));
app.MapGet("animals/{id}/visits", (int id) =>
{
    if (animalRepository.GetAnimal(id) == null)
    {
        return Results.NotFound();
    }
    return Results.Json(visitRepository.GetVisitsWithAnimal(id));
});
app.MapGet("visits", () => visitRepository.GetVisits());
// post
app.MapPost("animals", (Animal animal) =>
{
    animalRepository.AddAnimal(animal);
    return animal;
});

app.MapPost("animals/{id:int}/visits", (int id, DateTime dateTime, string description, double price) =>
{
    Animal animal = animalRepository.GetAnimal(id);
    if (animal == null)
    {
        return Results.NotFound();
    }

    Visit visit = new Visit
    {
        Date = dateTime,
        Description = description,
        Price = price,
        Animal = animal
    };
    visitRepository.AddVisit(visit);
    return Results.Json(visit);
});
app.MapPost("visits", (Visit visit) =>
{
    visitRepository.AddVisit(visit);
    animalRepository.AddAnimal(visit.Animal);
    return Results.Json(visit);
});
// put
app.MapPut("animals/{id:int}", (int id,string? category, string? furColor, string? name, double? mass) =>
{
    Animal animal = animalRepository.GetAnimal(id);
    animal.Category = category ?? animal.Category;
    animal.FurColor = furColor ?? animal.FurColor;
    animal.Name = name ?? animal.Name;
    animal.Mass = mass ?? animal.Mass;
    return animal;
});
// delete
app.MapDelete("animals/{id:int}", (int id) =>
{
    animalRepository.RemoveAnimal(id);
});




app.Run();