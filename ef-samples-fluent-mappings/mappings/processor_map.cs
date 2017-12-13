using Ef.Samples.Mappings.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ef.Samples.Mappings.mappings
{
    public class ProcessorMap : EntityTypeConfiguration<Processor>
    {
        public ProcessorMap()
        {
            this.ToTable("processor");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id");

            this.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(255);
        }
    }
}
