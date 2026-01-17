using gad.aaportal.dataaccess.Aplicacion.Aplicacion;
using gad.aaportal.dataaccess.Aplicacion.Dinardap;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.models.Entity.Aplicacion;
using gad.aaportal.models.Entity.Dinardap;
using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
namespace gad.aaportal.dataaccess;

public partial class AaportalContext : DbContext
{
    public AaportalContext(DbContextOptions<AaportalContext> options)
        : base(options)
    { }

    #region Schema Seguridad
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UsuarioSesion> UsuarioSesions { get; set; }
    #endregion

    #region Schema Dinardap
    public DbSet<Form101> Form101 { get; set; }
    public DbSet<Form102> Form102 { get; set; } = null!;
    #endregion

    #region Schema Aplicacion
    public DbSet<Canton> Cantones => Set<Canton>();
    public DbSet<TarifaImpositiva> TarifasImpositivas { get; set; }
    public DbSet<DeclaracionPJ> DeclaracionPJs { get; set; }
    public DbSet<DistribucionPago> DistribucionPagos { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioSesionConfiguracion());
        modelBuilder.ApplyConfiguration(new Form101Configuracion());
        modelBuilder.ApplyConfiguration(new Form102Configuracion());
        modelBuilder.ApplyConfiguration(new CantonConfiguracion());
        modelBuilder.ApplyConfiguration(new TarifaImpositivaConfig());
        modelBuilder.ApplyConfiguration(new DeclaracionPJConfiguracion());
        modelBuilder.ApplyConfiguration(new DistribucionPagoConfiguracion());
    }
}
