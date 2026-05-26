using gad.aaportal.models.Entity.Declaracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.dataaccess.Configuration
{
    public class ContribuyenteConfiguracion : IEntityTypeConfiguration<Contribuyente>
    {
        public void Configure(EntityTypeBuilder<Contribuyente> entity)
        {
            entity.HasKey(e => e.Identificacion);

            entity.ToTable("Contribuyente", "Declaracion");

            entity.Property(e => e.Identificacion).HasMaxLength(13);

            entity.Property(e => e.AgenteRetencion).HasMaxLength(10);

            entity.Property(e => e.Barrio).HasMaxLength(150);

            entity.Property(e => e.CallePrincipal).HasMaxLength(200);

            entity.Property(e => e.CalleSecundaria).HasMaxLength(200);

            entity.Property(e => e.ContribuyenteEspecial).HasMaxLength(10);

            entity.Property(e => e.ContribuyenteFantasma).HasMaxLength(10);

            entity.Property(e => e.Edificio)
                .HasMaxLength(150)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.EstadoContribuyenteRuc).HasMaxLength(50);

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

            entity.Property(e => e.FechaInicioActividades).HasColumnType("datetime");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaReinicioActividades).HasColumnType("datetime");

            entity.Property(e => e.Kilometro)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Manzana)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.NumeroCasa).HasMaxLength(50);

            entity.Property(e => e.NumeroPredio)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.ObligadoLlevarContabilidad).HasMaxLength(10);

            entity.Property(e => e.Parroquia).HasMaxLength(150);

            entity.Property(e => e.Piso)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.RazonSocial).HasMaxLength(300);

            entity.Property(e => e.ReferenciaUbicacion).HasMaxLength(500);

            entity.Property(e => e.Regimen).HasMaxLength(100);

            entity.Property(e => e.TipoContribuyente).HasMaxLength(100);

            entity.Property(e => e.TransaccionesInexistente).HasMaxLength(10);

            entity.Property(e => e.Via)
                .HasMaxLength(150)
                .HasDefaultValueSql("('')");
        }
    }
}
