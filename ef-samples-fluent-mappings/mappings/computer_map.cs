using Ef.Samples.Mappings.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ef.Samples.Mappings.Mappings
{
    public class ComputerMap : EntityTypeConfiguration<Computer>
    {
        public ComputerMap()
        {
            this.ToTable("computer");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id");

            this.Property(x => x.HostName).HasMaxLength(32).IsRequired().HasColumnName("host_name");

            this.Property(x => x.ProcessorId)
                .HasColumnName("processor_id");

            this.HasMany(x => x.OperatingSystems)
                .WithMany(x => x.Computers)
                .Map(x => x.ToTable("os_computer").MapLeftKey("os_id").MapRightKey("computer_id"));

            this.HasRequired(x => x.Processor);
        }
    }
}
