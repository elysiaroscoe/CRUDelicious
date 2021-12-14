using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }

        
        // the "Monsters" table name will come from the DbSet variable name
        // public DbSet<Monster> Monsters { get; set; }


    // DbSet for every model that is going to database
    // Make it plural of items in set
        public DbSet<Dish> Dishes { get; set; }
    }
}