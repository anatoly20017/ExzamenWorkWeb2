using HelloAngularApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
  public class UserService
  {
    ApplicationContext db;

    public UserService(ApplicationContext context)
    {
      db = context;
    }

    public void Register(string name, string password)
    {
      var hashPassword = password.GetHashCode().ToString();
      var user = new Users
      {
        Name = name,
        Password = hashPassword
      };
      db.Users.Add(user);
      db.SaveChanges();
  }

    public bool Authorize(string name, string password)
    {
      var hashPassword = password.GetHashCode().ToString();
      var user = db.Users.FirstOrDefault(u => u.Name == name && u.Password == hashPassword);
      return user == null;
    }


}
}
