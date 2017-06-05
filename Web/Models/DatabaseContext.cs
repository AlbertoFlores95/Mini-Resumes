
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Web.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}