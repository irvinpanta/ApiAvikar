using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Entities.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<EmpleadoModel>
    {
        public void Configure(EntityTypeBuilder<EmpleadoModel> builder)
        {
            builder.ToTable("Empleados");

            builder.HasKey(e => e.Id)
                    .HasName("PK__Empleado__5AE93C2EFCFD7E61");

            builder.HasIndex(e => e.Documento, "UQ__Empleado__AF73706D1E83B93E")
                    .IsUnique();

            builder.Property(e => e.Id).HasColumnName("Empleado");

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            builder.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Contrasenia).IsUnicode(false);

            builder.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

            builder.Property(e => e.FecSistema)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Foto).IsUnicode(false);

            builder.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.Usuario)
                    .HasMaxLength(15)
                    .IsUnicode(false);

            builder.HasOne(d => d.Roles)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_Empleados_Roles");
        }
    }
}
