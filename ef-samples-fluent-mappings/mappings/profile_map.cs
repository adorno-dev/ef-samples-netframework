using Ef.Samples.Mappings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.Samples.Mappings.Mappings
{
    public class ProfileMap : EntityTypeConfiguration<Profile>
    {
        public ProfileMap()
        {
            this.ToTable("profile");

            this.HasKey(x => x.UID)
                .Property(x => x.UID)
                .HasColumnName("uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .HasColumnName("name");
        }
    }
}
