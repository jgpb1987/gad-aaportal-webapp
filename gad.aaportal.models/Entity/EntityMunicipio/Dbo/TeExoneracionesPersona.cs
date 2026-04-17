using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeExoneracionesPersona
    {
        public TeExoneracionesPersona()
        {
            TeInfoPrestamosHipotecarios = new HashSet<TeInfoPrestamosHipotecario>();
            TeInformacionDiscapacidads = new HashSet<TeInformacionDiscapacidad>();
            TeRecargoSolarInfos = new HashSet<TeRecargoSolarInfo>();
        }

        public int IdExoneracion { get; set; }
        public string? CiTitular { get; set; }
        public string? CiConyuge { get; set; }
        public string? EstadoCivil { get; set; }
        public int? IdTipoExoneracion { get; set; }
        public double? PorcentajeAplicado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? Documento { get; set; }
        public string? Observacion { get; set; }
        public int? Anio { get; set; }
        public string? Estado { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? IngresosTe { get; set; }

        public virtual TeTipoExoneracion? IdTipoExoneracionNavigation { get; set; }
        public virtual ICollection<TeInfoPrestamosHipotecario> TeInfoPrestamosHipotecarios { get; set; }
        public virtual ICollection<TeInformacionDiscapacidad> TeInformacionDiscapacidads { get; set; }
        public virtual ICollection<TeRecargoSolarInfo> TeRecargoSolarInfos { get; set; }
    }
}
