using Identify.Entity;
using Microsoft.EntityFrameworkCore;

namespace Identify.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> iDs { get; set; }
    }
}
