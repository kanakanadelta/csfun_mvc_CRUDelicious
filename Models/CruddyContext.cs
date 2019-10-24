using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    // The context class is what actually forms the relationship between our models and the database
    public class CruddyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along

        public CruddyContext(DbContextOptions options) : base(options) {}

        //property will be a DbSet - a collection type from the Entity Framework library 
        //that you will provide your Model class in angle brackets
        //Your DBSet will refer to all data in your corresponding table as objects of the Model type you provide.
        public DbSet<Dish> Dishes {get; set;}
    }
}