using gad.aaportal.dataaccess.Configuration.Dbo;
using gad.aaportal.models.Entity.Dbo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration
{
    public class BddGmaaContext : DbContext
    {
    public BddGmaaContext(DbContextOptions<BddGmaaContext> options)
    : base(options)
        { }

        public virtual DbSet<AeIdentificacionContribuyente> AeIdentificacionContribuyentes { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AeIdentificacionContribuyenteConfiguracion());
        }
    }
}