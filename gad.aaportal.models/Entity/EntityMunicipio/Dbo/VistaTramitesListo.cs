using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTramitesListo
    {
        public string? TipoTramite { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? NombreAdicional { get; set; }
        public string? PredioClave { get; set; }
        public string? Valor { get; set; }
        public string? Profesional { get; set; }
        public string? EstadoCarpeta { get; set; }
        public string? SecuenciaDelFlujo { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
    }
}
