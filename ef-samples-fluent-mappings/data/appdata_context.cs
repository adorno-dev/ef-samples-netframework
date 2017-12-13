using Ef.Samples.Mappings.mappings;
using Ef.Samples.Mappings.Models;
using System.Data.Entity;

namespace Ef.Samples.Mappings.Mappings
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base(nameOrConnectionString: "app_connection_string")
        {
            this.Database.Initialize(true);
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProcessorMap());
            modelBuilder.Configurations.Add(new ComputerMap());
            modelBuilder.Configurations.Add(new OSMap());
            modelBuilder.Configurations.Add(new ProfileMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Processor> Processors { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<OS> OperatingSystems { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
