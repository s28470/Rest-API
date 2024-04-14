namespace WebApplication1.Models;

public class VisitRepository : IVisitRepository
{
    private static List<Visit> _dataBase = new List<Visit>();

    
    public void AddVisit(Visit visit)
    {
        _dataBase.Add(visit);
    }

    public List<Visit> GetVisitsWithAnimal(int id)
    {
        return GetVisits().FindAll(visit => visit.Animal.Id == id);
    }

    public List<Visit> GetVisits()
    {
        return _dataBase;
    }
}