using Infiniteskills.Common;
using Infiniteskills.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Data
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<PeriodoEmpresa> PeriodoEmpresa { get; set; }
        public virtual DbSet<Tabla> Tabla { get; set; }
        public virtual DbSet<PeriodoCorrelativo> PeriodoCorrelativo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<DocumentoComercial> DocumentoComercial { get; set; }
        public virtual DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenItem> OrdenItem { get; set; }
        public virtual DbSet<OrdenSaldo> OrdenSaldo { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ProveedorContacto> ProveedorContacto { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<BienServicio> BienServicio { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<TipoProveedor> TipoProveedor { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacion { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<ParametroSistema> ParametroSistema { get; set; }
        public virtual DbSet<SucursalPersonal> SucursalUsuario { get; set; }
        public virtual DbSet<DireccionProveedor> DireccionProveedor { get; set; }
        public virtual DbSet<TipoBien> TipoBien { get; set; }
        public virtual DbSet<MesContable> MesContable { get; set; }
        public virtual DbSet<TipoExistencia> TipoExistencia { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Orden)
                .WithOptional(e => e.Proveedor)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Marca>()
              .HasMany(e => e.Producto)
              .WithRequired(e => e.Marca)
              .WillCascadeOnDelete(false);


            modelBuilder.Entity<MesContable>()
            .HasMany(e => e.OrdenSaldo)
            .WithRequired(e => e.MesContable)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Periodo>()
                .HasMany(e => e.PeriodoEmpresa)
                .WithRequired(e => e.Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tabla>()
                .HasMany(e => e.PeriodoCorrelativo)
                .WithRequired(e => e.Tabla)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeriodoEmpresa>()
               .HasMany(e => e.PeriodoCorrelativo)
               .WithRequired(e => e.PeriodoEmpresa)
               .WillCascadeOnDelete(false);


            modelBuilder.Entity<BienServicio>()
                .Property(e => e.StockMinimo)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BienServicio>()
                .Property(e => e.StockMaximo)
                .HasPrecision(12, 4);

            modelBuilder.Entity<BienServicio>()
              .Property(e => e.PrecioUnitario)
              .HasPrecision(12, 4);

            modelBuilder.Entity<BienServicio>()
               .Property(e => e.PrecioVenta)
               .HasPrecision(12, 4);

            //modelBuilder.Entity<BienServicio>()
            //   .Property(e => e.PrecioCompra)
            //   .HasPrecision(12, 4);

            modelBuilder.Entity<Orden>()
               .Property(e => e.Cantidad)
               .HasPrecision(12, 4);

            modelBuilder.Entity<OrdenItem>()
              .Property(e => e.Cantidad)
              .HasPrecision(12, 4);

            modelBuilder.Entity<Periodo>()
                .HasRequired(c => c.PeriodoEmpresa)
                .WithMany()
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);


        }



        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (AuditableEntity)entry.Entity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.Now;
                    entity.Estado = EstadoConstante.ACTIVO;
                    if (entry.State == EntityState.Added)
                    {
                        entity.Estado = EstadoConstante.ACTIVO;
                        entity.UsuarioCreacionId = 1;
                        entity.FechaCreacion = now;
                    }
                    else
                    {
                        entity.Estado = EstadoConstante.ACTIVO;
                        base.Entry(entity).Property(x => x.UsuarioCreacionId).IsModified = false;
                        base.Entry(entity).Property(x => x.FechaCreacion).IsModified = false;
                    }

                    entity.UsuarioModificacionId = 1;
                    entity.FechaModificacion = now;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                var entity = (AuditableEntity)entry.Entity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.Now;

                    entity.Estado = EstadoConstante.ACTIVO;
                    if (entry.State == EntityState.Added)
                    {
                        entity.Estado = EstadoConstante.ACTIVO;
                        entity.UsuarioCreacionId = 1;
                        entity.FechaCreacion = now;
                    }
                    else
                    {
                        entity.Estado = EstadoConstante.ACTIVO;
                        base.Entry(entity).Property(x => x.UsuarioCreacionId).IsModified = false;
                        base.Entry(entity).Property(x => x.FechaCreacion).IsModified = false;
                    }

                    entity.UsuarioModificacionId = 1;
                    entity.FechaModificacion = now;
                }
            }


            return await base.SaveChangesAsync();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
