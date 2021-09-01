using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Entities.Configurations
{
    class MesaConfiguration : IEntityTypeConfiguration<MesaModel>
    {
        public void Configure(EntityTypeBuilder<MesaModel> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Mesa__1235E505A8E49531");

            builder.ToTable("Mesa");

            builder.Property(e => e.Id).HasColumnName("Mesa");

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FecSistema)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Salones)
                .WithMany(p => p.Mesas)
                .HasForeignKey(d => d.Salon)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Mesa_Salones");
        }
    }
}
