using Ef.Samples.Mappings.Models;
using System.Data.Entity.ModelConfiguration;

namespace Ef.Samples.Mappings.Mappings
{
    public class OSMap : EntityTypeConfiguration<OS>
    {
        public OSMap()
        {
            this.ToTable("os");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id");

            this.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(255);

            this.HasMany(x => x.Computers);                
        }
    }
}
