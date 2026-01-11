using gad.aaportal.dataaccess.Aplicacion.Dinardap;
using gad.aaportal.dataaccess.Configuration;
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
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioSesionConfiguracion());
        modelBuilder.ApplyConfiguration(new Form101Configuracion());
    }
}
