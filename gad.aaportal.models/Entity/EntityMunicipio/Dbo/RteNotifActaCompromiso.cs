using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteNotifActaCompromiso
    {
        public int CodActaCompromiso { get; set; }
        public DateTime? FechaActaCompromiso { get; set; }
        public string? TesoreroActaCompromiso { get; set; }
        public string? CiudadanoActaCompromiso { get; set; }
        public string? Cciudadano { get; set; }
        public string? Telefono { get; set; }
        public string? UbicacionInmueble { get; set; }
        public double? ValorPendientePago { get; set; }
        public double? PagoParcial { get; set; }
        public double? SaldoActaCompromiso { get; set; }
        public int? PagosMensuales { get; set; }
        public string? FechaPagosPendientes { get; set; }
        public string? UsuarioActaCompromiso { get; set; }
        public string? EstadoActaCompromiso { get; set; }
        public int? NumeroActa { get; set; }
        public string? ObservacionActa { get; set; }
        public string? LlamarActa { get; set; }
        public string? ProcesoDescuento { get; set; }
    }
}
