using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteEspectaculosPublico
    {
        public int CodigoEspectaculosPublicos { get; set; }
        public string CedulaIdentidadCiudadano { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Evento { get; set; }
        public string? Lugar { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Tipo { get; set; }
        public string? NroAutorizacionSri { get; set; }
        public string? NroFormularioEspectaculos { get; set; }
        public short? Tarifa { get; set; }
        public double? Garantia { get; set; }
        public string? Usuario { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? TipoGarantia { get; set; }
        public string? CometarioGarantia { get; set; }
        public string? LeyEspectaculos60 { get; set; }
        public DateTime? FechaLiquidacionRemanente { get; set; }
        public int? CodIngresoDatos { get; set; }
        public string? EstadoEspectaculo { get; set; }

        public virtual RteTipoEspectaculo? TipoNavigation { get; set; }
    }
}
