using System;
using System.Reflection;
using Api.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Models.Entities
{
    public partial class SisAvikarDemoContext : DbContext
    {
        public SisAvikarDemoContext()
        {
        }

        public SisAvikarDemoContext(DbContextOptions<SisAvikarDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SalonModel> Salones { get; set; }
        public virtual DbSet<MesaModel> Mesas { get; set; }
        public virtual DbSet<RolModel> Roles { get; set; }
        public virtual DbSet<EmpleadoModel> Empleados { get; set; }



        public virtual DbSet<AperturaCaja> AperturaCajas { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AreaDespacho> AreaDespachos { get; set; }
        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ControlCaja> ControlCajas { get; set; }
        
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<FamiliaProducto> FamiliaProductos { get; set; }
        
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<ModulosDetalle> ModulosDetalles { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        
        
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<TipoProducto> TipoProductos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;initial catalog=SisAvikarDemo; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            //modelBuilder.ApplyConfiguration(new SalonConfiguration());
            //modelBuilder.ApplyConfiguration(new MesaConfiguration());
            //modelBuilder.ApplyConfiguration(new RolConfiguration());
            //modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<AperturaCaja>(entity =>
            {
                entity.HasKey(e => e.Apertura);

                entity.ToTable("AperturaCaja");

                entity.HasIndex(e => e.Fecha, "IX_FechaUnique")
                    .IsUnique();

                entity.Property(e => e.Cierre).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Descri)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Efectivo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Existe).HasColumnName("existe");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.ImporteTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Inicio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Maquina)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salida).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tarjeta).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CodCajaNavigation)
                    .WithMany(p => p.AperturaCajas)
                    .HasForeignKey(d => d.CodCaja)
                    .HasConstraintName("FK_AperturaCaja_Caja");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AreaDespacho>(entity =>
            {
                entity.HasKey(e => e.Despacho)
                    .HasName("PK__AreaDesp__C6187A487CCD9976");

                entity.ToTable("AreaDespacho");

                entity.HasIndex(e => e.Producto, "UQ__AreaDesp__0D41B8C1EFDFF716")
                    .IsUnique();

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.AreaDespachos)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_AreaDespacho_Area");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithOne(p => p.AreaDespacho)
                    .HasForeignKey<AreaDespacho>(d => d.Producto)
                    .HasConstraintName("FK_AreaDespacho_Productos");
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.CodCaja)
                    .HasName("PK__Caja__E0F809FEA4C670F8");

                entity.ToTable("Caja");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Persona)
                    .HasName("PK__Cliente__BDC5F71CA7A0FD04");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Documento, "UQ__Cliente__AF73706DF81901A5")
                    .IsUnique();

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FecSistema)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreCompelto)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ControlCaja>(entity =>
            {
                entity.HasKey(e => e.ConCaja)
                    .HasName("PK__ControlC__4887B39103DAB59C");

                entity.ToTable("ControlCaja");

                entity.Property(e => e.Cierre).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Efectivo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.ImporteTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Inicio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Maquina)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salida).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tarjeta).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoApertura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AperturaNavigation)
                    .WithMany(p => p.ControlCajas)
                    .HasForeignKey(d => d.Apertura)
                    .HasConstraintName("FK_ControlCaja_AperturaCaja");
            });

            //modelBuilder.Entity<EmpleadoModel>(entity =>
            //{
            //    entity.HasKey(e => e.Empleado1)
            //        .HasName("PK__Empleado__5AE93C2EFCFD7E61");

            //    entity.HasIndex(e => e.Documento, "UQ__Empleado__AF73706D1E83B93E")
            //        .IsUnique();

            //    entity.Property(e => e.Empleado1).HasColumnName("EmpleadoModel");

            //    entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Apellidos)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Contrasenia).IsUnicode(false);

            //    entity.Property(e => e.Direccion)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Documento)
            //        .IsRequired()
            //        .HasMaxLength(25)
            //        .IsUnicode(false);

            //    entity.Property(e => e.FecSistema)
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Foto).IsUnicode(false);

            //    entity.Property(e => e.Nombres)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Telefono)
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Usuario)
            //        .HasMaxLength(15)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Roles)
            //        .WithMany(p => p.Empleados)
            //        .HasForeignKey(d => d.Rol)
            //        .HasConstraintName("FK_Empleados_Roles");
            //});

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.HasIndex(e => e.Id, "IX_Empresa")
                    .IsUnique();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Logo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ruc")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FamiliaProducto>(entity =>
            {
                entity.HasKey(e => e.FamProducto)
                    .HasName("PK__FamiliaP__F392FEA2F47FAB74");

                entity.ToTable("FamiliaProducto");

                entity.HasIndex(e => e.Descripcion, "UQ__FamiliaP__92C53B6C502C58BD")
                    .IsUnique();

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FecSistema)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<MesaModel>(entity =>
            //{
            //    entity.HasKey(e => e.Mesa1)
            //        .HasName("PK__Mesa__1235E505A8E49531");
            //
            //    entity.ToTable("MesaModel");
            //
            //    entity.Property(e => e.Mesa1).HasColumnName("MesaModel");
            //
            //    entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            //
            //    entity.Property(e => e.Descripcion)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //
            //    entity.Property(e => e.FecSistema)
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");
            //
            //    entity.HasOne(d => d.SalonNavigation)
            //        .WithMany(p => p.Mesas)
            //        .HasForeignKey(d => d.Salon)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Mesa_Salones");
            //});

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.Modulo1)
                    .HasName("PK__Modulos__D47F63DC7AB0C570");

                entity.Property(e => e.Modulo1).HasColumnName("Modulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Menu)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModulosDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ModulosDetalle");

                entity.HasOne(d => d.ModuloNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Modulo)
                    .HasConstraintName("FK_ModulosDetalle_Modulos");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_ModulosDetalle_Roles");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.CodMovimientos)
                    .HasName("PK__Movimien__79A2336FEE374EA0");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FecHora).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Turno)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.AperturaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.Apertura)
                    .HasConstraintName("FK_Movimientos_AperturaCaja");

                entity.HasOne(d => d.TipoOperacionNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TipoOperacion)
                    .HasConstraintName("FK_Movimientos_TipoOperacion");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Pedido1)
                    .HasName("PK__Pedidos__92A43943CE858858");

                entity.Property(e => e.Pedido1)
                    .ValueGeneratedNever()
                    .HasColumnName("Pedido");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Xml).HasColumnType("xml");

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Empleado)
                    .HasConstraintName("FK_Pedidos_Empleado");

                entity.HasOne(d => d.MesaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Mesa)
                    .HasConstraintName("FK_Pedidos_Mesa");
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PedidoDetalle");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdAuto).ValueGeneratedOnAdd();

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PedidoDetalle_Pedidos");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Producto)
                    .HasConstraintName("FK_PedidoDetalle_Productos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Producto1)
                    .HasName("PK__Producto__0D41B8C07B524B21");

                entity.Property(e => e.Producto1).HasColumnName("Producto");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FecSistema)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FamProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.FamProducto)
                    .HasConstraintName("FK_Productos_FamiliaProducto");

                entity.HasOne(d => d.TipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProducto)
                    .HasConstraintName("FK_Productos_TipoProducto");
            });

            //modelBuilder.Entity<RolModel>(entity =>
            //{
            //    entity.HasKey(e => e.Rol)
            //        .HasName("PK__Roles__CAF00515FBE74653");
            //
            //    entity.Property(e => e.Descripcion)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<SalonModel>(entity =>
            //{
            //    entity.HasKey(e => e.Salon)
            //        .HasName("PK__Salones__49C0E33C4B6A6853");
            //
            //    entity.HasIndex(e => e.Descripcion, "UQ__Salones__92C53B6C887620C2")
            //        .IsUnique();
            //
            //    entity.Property(e => e.Descripcion)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.HasKey(e => e.TipoOperacion1)
                    .HasName("PK__TipoOper__61A1C34A11FD3825");

                entity.ToTable("TipoOperacion");

                entity.Property(e => e.TipoOperacion1).HasColumnName("TipoOperacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FecSistema)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.TipoP)
                    .HasName("PK__TipoPago__2DBEED48863F8C6D");

                entity.ToTable("TipoPago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequiereEfectivo).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequiereNumOp).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.TipoProducto1)
                    .HasName("PK__TipoProd__3185643ABDDAB4C1");

                entity.ToTable("TipoProducto");

                entity.Property(e => e.TipoProducto1).HasColumnName("TipoProducto");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.CodVenta)
                    .HasName("PK__Ventas__2813DD0EF9589E57");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.ImporteTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Turno)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AperturaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Apertura)
                    .HasConstraintName("FK_Ventas_AperturaCaja");

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Pedido)
                    .HasConstraintName("FK_Ventas_Pedidos");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Persona)
                    .HasConstraintName("FK_Ventas_Cliente");

                entity.HasOne(d => d.TipoPNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.TipoP)
                    .HasConstraintName("FK_Ventas_TipoPago");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
