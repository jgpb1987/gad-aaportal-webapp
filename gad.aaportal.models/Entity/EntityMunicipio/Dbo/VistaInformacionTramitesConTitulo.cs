using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaInformacionTramitesConTitulo
    {
        public string? TipoTramite { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? NombreAdicional { get; set; }
        public string? PredioClave { get; set; }
        public DateTime? ConcluidoFecha { get; set; }
        public string? UsuarioConcluido { get; set; }
        public int Secuencia { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public int CodIngreso { get; set; }
        public int? NumeroTitulo { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? NombreEsp { get; set; }
        public string? Direccion { get; set; }
        public string UserIngreso { get; set; } = null!;
        public string? ClaveCatastral { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? TipoDeIngreso { get; set; }
        public string? Nombre { get; set; }
    }
}
