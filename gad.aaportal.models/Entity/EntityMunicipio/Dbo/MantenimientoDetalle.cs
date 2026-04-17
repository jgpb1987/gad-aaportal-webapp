using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoDetalle
    {
        public int IdDetalleAlertaMantenimiento { get; set; }
        public int? IdMantenimientoRepuestos { get; set; }
        public int? IdAlertaMantenimiento { get; set; }
        public bool? EstadoDetalle { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public double? Cantidad { get; set; }
        public double? Valor { get; set; }
        public int? IdTalleresMantenimiento { get; set; }
        public bool? EstadoRecepcionBodega { get; set; }
        public string? TrabajoRealizado { get; set; }

        public virtual MantenimientoAlertum? IdAlertaMantenimientoNavigation { get; set; }
        public virtual MantenimientoTallere? IdTalleresMantenimientoNavigation { get; set; }
    }
}
