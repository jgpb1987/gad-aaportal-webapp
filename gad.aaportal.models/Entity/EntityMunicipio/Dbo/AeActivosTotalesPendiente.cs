using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActivosTotalesPendiente
    {
        public int IdActivos { get; set; }
        public int? IdActividadAnual { get; set; }
        public double? Porcentaje { get; set; }
        public double? ValorTranferencia { get; set; }
        public double? PorcentajeComision { get; set; }
        public bool? EstadoVerificacion { get; set; }
        public int? IdTransferencia { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public string? UsuarioConfirmacion { get; set; }
        public int? IdTransferenciaGuardada { get; set; }

        public virtual AeActividadAnual? IdActividadAnualNavigation { get; set; }
        public virtual AeTransferenciaBancarium? IdTransferenciaNavigation { get; set; }
    }
}
