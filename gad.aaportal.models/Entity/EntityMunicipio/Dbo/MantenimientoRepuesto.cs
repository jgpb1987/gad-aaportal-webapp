using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoRepuesto
    {
        public int IdRepuestos { get; set; }
        public string? NombreDetalle { get; set; }
        public double? Valor { get; set; }
        public int? IdTipo { get; set; }
        public int? IdSistemaVehiculo { get; set; }

        public virtual MantenimientoSistemasVehiculo? IdSistemaVehiculoNavigation { get; set; }
        public virtual MantenimientoTipoRepuesto? IdTipoNavigation { get; set; }
    }
}
