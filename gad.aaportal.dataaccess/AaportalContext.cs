using gad.aaportal.models.Configuration.Seguridad;
using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace gad.aaportal.dataaccess;

public partial class AaportalContext : DbContext
{
    public AaportalContext(DbContextOptions<AaportalContext> options)
        : base(options)
    { }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UsuarioSesion> UsuarioSesions { get; set; }
    public virtual DbSet<Jwt> Jwts { get; set; }
    public virtual DbSet<Rsa> Rsas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new Configuration.UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new Configuration.UsuarioSesionConfiguracion());
        modelBuilder.ApplyConfiguration(new Configuration.JwtConfiguracion());
        modelBuilder.ApplyConfiguration(new Configuration.RsaConfiguracion());
    }
}
