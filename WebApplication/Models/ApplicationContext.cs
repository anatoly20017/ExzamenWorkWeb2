using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace HelloAngularApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Recept> Recepts { get; set; }
        public DbSet<Users> Users { get; set; }
  }
}