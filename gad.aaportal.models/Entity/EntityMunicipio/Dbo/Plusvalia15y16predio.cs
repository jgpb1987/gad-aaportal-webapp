using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Plusvalia15y16predio
    {
        public int CodIngreso { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaVencInteres { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? Comentario { get; set; }
        public string? Direccion { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? ApellidosCiudadano { get; set; }
        public string? NombresCiudadano { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? Calle { get; set; }
        public string? Num { get; set; }
        public string? Nompredio { get; set; }
        public string? Cedulap { get; set; }
        public string? Yotros { get; set; }
        public string? Cedularep { get; set; }
        public string? TipoPred { get; set; }
        public bool? Bloq { get; set; }
        public string? Uso { get; set; }
    }
}
