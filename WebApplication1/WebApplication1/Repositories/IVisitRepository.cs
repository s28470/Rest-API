namespace WebApplication1.Models;

public interface IVisitRepository
{
    void AddVisit(Visit visit);

    List<Visit> GetVisits();

    List<Visit> GetVisitsWithAnimal(int id);
    
    

}