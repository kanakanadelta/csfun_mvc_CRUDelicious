using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    // The context class is what actually forms the relationship between our models and the database
    public class CruddyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along

        public CruddyContext(DbContextOptions options) : base(options) {}
    }
}