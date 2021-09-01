using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Entities.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<RolModel>
    {
        public void Configure(EntityTypeBuilder<RolModel> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(e => e.Id)
                    .HasName("PK__Roles__CAF00515FBE74653");

            builder.Property(e => e.Id).HasColumnName("Rol");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
