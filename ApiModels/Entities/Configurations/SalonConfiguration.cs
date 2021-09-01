using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Entities.Configurations
{
    public class SalonConfiguration : IEntityTypeConfiguration<SalonModel>
    {
        public void Configure(EntityTypeBuilder<SalonModel> builder)
        {
            builder.ToTable("Salones");

            builder.HasKey(e => e.Id)
                   .HasName("PK__Salones__49C0E33C4B6A6853");

            builder.Property(e => e.Id).HasColumnName("Salon");

            builder.HasIndex(e => e.Descripcion, "UQ__Salones__92C53B6C887620C2")
                .IsUnique();

            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
