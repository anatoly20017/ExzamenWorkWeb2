using HelloAngularApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Services
{
  public class ReceptService
  {
    ApplicationContext db;
    public ReceptService(ApplicationContext context)
    {
      db = context;
    }

    public List<Recept> GetAllRecepts()
    {
      return db.Recepts.ToList();
    }

    public void CreateRecept(Recept recept)
    {
      db.Recepts.Add(recept);
      db.SaveChanges();
    }

    public Recept UpdateRecepts(Recept recept)
    {
      db.Recepts.Update(recept);
      return recept;
    }

    public void DeleteRecept(string name, string author)
    {
      var recept = db.Recepts.FirstOrDefault(r => r.Autor == author && r.Name == name);
      db.Recepts.Remove(recept);
    }
  }
}
