using gad.aaportal.dataaccess.Aplicacion.Aplicacion;
using gad.aaportal.dataaccess.Aplicacion.Dinardap;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.models.Configuration.Seguridad;
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
    public virtual DbSet<Jwt> Jwts { get; set; }
    public virtual DbSet<Rsa> Rsas { get; set; }
    public virtual DbSet<ConfiguracionEmail> ConfiguracionEmails { get; set; }
    #endregion

    #region Schema Dinardap
    public DbSet<Form101> Form101 { get; set; }
    public DbSet<Form101bkp> Form101Bkps { get; set; }
    public DbSet<Form102> Form102 { get; set; } = null!;
    public DbSet<Form102bkp> Form102Bkps { get; set; } = null!;
    public DbSet<ActividadEstablecimiento> ActividadesEstablecimiento { get; set; }
    public DbSet<SriRucContribuyente> SriRucContribuyentes { get; set; }
    public DbSet<SriRucEstablecimiento> SriRucEstablecimientos { get; set; }
    public DbSet<SriRucListaBlanca> SriRucListaBlanca { get; set; }
    public DbSet<SriContribuyenteDatos> SriContribuyenteDatos { get; set; }
    public DbSet<SriActividadEconomica> SriActividadEconomica { get; set; }
    public DbSet<SriTipoContribuyente> SriTipoContribuyente { get; set; }
    public DbSet<SriContador> SriContador { get; set; }
    public DbSet<SriEstructuraOrganizacional> SriEstructuraOrganizacional { get; set; }
    public DbSet<SriRepresentanteLegal> SriRepresentanteLegal { get; set; }
    public DbSet<SriEstadoTributario> SriEstadoTributario { get; set; }
    public DbSet<SepsOrganizacion> SepsOrganizacion { get; set; }
    #endregion

    #region Schema Aplicacion
    public DbSet<Canton> Cantones => Set<Canton>();
    public DbSet<TarifaImpositiva> TarifasImpositivas { get; set; }
    public DbSet<DeclaracionPJ> DeclaracionPJs { get; set; }
    public DbSet<DistribucionPago> DistribucionPagos { get; set; }
    public DbSet<TasaAdministrativa> TasaAdministrativas { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioSesionConfiguracion());
        modelBuilder.ApplyConfiguration(new Form101Configuracion());
        modelBuilder.ApplyConfiguration(new Form101Configuracionbkp());
        modelBuilder.ApplyConfiguration(new Form102Configuracion());
        modelBuilder.ApplyConfiguration(new Form102bkpConfiguracion());
        modelBuilder.ApplyConfiguration(new ActividadEstablecimientoConfig());
        modelBuilder.ApplyConfiguration(new SriRucContribuyenteConfig());
        modelBuilder.ApplyConfiguration(new SriRucEstablecimientoConfig());
        modelBuilder.ApplyConfiguration(new SriRucListaBlancaConfig());
        modelBuilder.ApplyConfiguration(new SriContribuyenteDatosConfig());
        modelBuilder.ApplyConfiguration(new SriActividadEconomicaConfig());
        modelBuilder.ApplyConfiguration(new SriTipoContribuyenteConfig());
        modelBuilder.ApplyConfiguration(new SriContadorConfig());
        modelBuilder.ApplyConfiguration(new SriEstructuraOrganizacionalConfig());
        modelBuilder.ApplyConfiguration(new SriRepresentanteLegalConfig());
        modelBuilder.ApplyConfiguration(new SriEstadoTributarioConfig());
        modelBuilder.ApplyConfiguration(new SepsOrganizacionConfig());
        modelBuilder.ApplyConfiguration(new CantonConfiguracion());
        modelBuilder.ApplyConfiguration(new TarifaImpositivaConfig());
        modelBuilder.ApplyConfiguration(new DeclaracionPJConfiguracion());
        modelBuilder.ApplyConfiguration(new DistribucionPagoConfiguracion());
        modelBuilder.ApplyConfiguration(new TasaAdministrativaConfiguracion());
        modelBuilder.ApplyConfiguration(new JwtConfiguracion());
        modelBuilder.ApplyConfiguration(new RsaConfiguracion());
        modelBuilder.ApplyConfiguration(new ConfiguracionEmailConfiguracion());
    }
}
