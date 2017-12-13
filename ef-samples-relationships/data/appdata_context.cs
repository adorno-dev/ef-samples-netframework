using Ef.Samples.Relationships.Models;
using System.Data.Entity;

namespace Ef.Samples.Relationships.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base(nameOrConnectionString: "app_connection_string")
        {
            this.Database.Initialize(true);
            this.Database.CreateIfNotExists();
        }

        public DbSet<Processor> Processors { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<OS> OperatingSystems { get; set; }
    }
}
