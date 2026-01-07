using System;
using System.Collections.Generic;
using gad.aaportal.models.Entity.Seguridad;
using Microsoft.EntityFrameworkCore;
namespace gad.aaportal.dataaccess;

public partial class AaportalContext : DbContext
{
    public AaportalContext(DbContextOptions<AaportalContext> options)
        : base(options)
    { }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSesion> UsuarioSesions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new Configuration.UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new Configuration.UsuarioSesionConfiguracion());
    }
}
