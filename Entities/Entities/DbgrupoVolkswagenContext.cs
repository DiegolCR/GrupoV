using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class DbgrupoVolkswagenContext : DbContext
{
    public DbgrupoVolkswagenContext()
    {
    }

    public DbgrupoVolkswagenContext(DbContextOptions<DbgrupoVolkswagenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarritoVehiculo> CarritoVehiculos { get; set; }

    public virtual DbSet<CategoriaVehiculo> CategoriaVehiculos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVentaVehiculo> DetalleVentaVehiculos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<MantenimientoVehiculo> MantenimientoVehiculos { get; set; }

    public virtual DbSet<MarcaVehiculo> MarcaVehiculos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<VentaVehiculo> VentaVehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=DBGrupoVolkswagen;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarritoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdCarritoVehiculo).HasName("PK__CARRITO___578B3899DB281135");

            entity.ToTable("CARRITO_VEHICULO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CarritoVehiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__CARRITO_V__IdCli__48CFD27E");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.CarritoVehiculos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__CARRITO_V__IdVeh__49C3F6B7");
        });

        modelBuilder.Entity<CategoriaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaVehiculo).HasName("PK__CATEGORI__6CD2D5A7495E9EB5");

            entity.ToTable("CATEGORIA_VEHICULO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__D59466420C445B28");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reestablecer).HasDefaultValue(false);
        });

        modelBuilder.Entity<DetalleVentaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVentaVehiculo).HasName("PK__DETALLE___7B5DCD2DC200BC05");

            entity.ToTable("DETALLE_VENTA_VEHICULO");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.DetalleVentaVehiculos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__DETALLE_V__IdVeh__5165187F");

            entity.HasOne(d => d.IdVentaVehiculoNavigation).WithMany(p => p.DetalleVentaVehiculos)
                .HasForeignKey(d => d.IdVentaVehiculo)
                .HasConstraintName("FK__DETALLE_V__IdVen__5070F446");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DISTRITO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.IdProvincia)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MantenimientoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdMantenimientoVehiculo).HasName("PK__MANTENIM__3E6C4541F1CC6E8A");

            entity.ToTable("MANTENIMIENTO_VEHICULO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaMantenimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.MantenimientoVehiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__MANTENIMI__IdCli__5AEE82B9");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.MantenimientoVehiculos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__MANTENIMI__IdVeh__5BE2A6F2");
        });

        modelBuilder.Entity<MarcaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdMarcaVehiculo).HasName("PK__MARCA_VE__12D984D8F689645C");

            entity.ToTable("MARCA_VEHICULO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROVINCIA");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdProvincia)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF9796087BDD");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reestablecer).HasDefaultValue(true);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__VEHICULO__70861215E1DB2B9F");

            entity.ToTable("VEHICULO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCategoriaVehiculo)
                .HasConstraintName("FK__VEHICULO__IdCate__3F466844");

            entity.HasOne(d => d.IdMarcaVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdMarcaVehiculo)
                .HasConstraintName("FK__VEHICULO__IdMarc__3E52440B");
        });

        modelBuilder.Entity<VentaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVentaVehiculo).HasName("PK__VENTA_VE__8F030F38C198A645");

            entity.ToTable("VENTA_VEHICULO");

            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdTransaccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VentaVehiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__VENTA_VEH__IdCli__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
