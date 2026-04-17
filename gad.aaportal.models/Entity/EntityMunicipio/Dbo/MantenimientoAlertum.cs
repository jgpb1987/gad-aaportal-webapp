using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoAlertum
    {
        public MantenimientoAlertum()
        {
            MantenimientoDetalles = new HashSet<MantenimientoDetalle>();
        }

        public int IdAlertaMantenimiento { get; set; }
        public int? IdVehiculo { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public int? IdEstado { get; set; }
        public int? KmParaMantenimiento { get; set; }
        public bool? EstadoAprobadaCancelada { get; set; }
        public DateTime? FechaAprobacionDa { get; set; }
        public int? IdDocumentoAprobacion { get; set; }
        public DateTime? FechaSolicitudRepuestos { get; set; }
        public int? IdSolicitudRepuestos { get; set; }
        public string? Concepto { get; set; }
        public string? ObservacionHojaDeVida { get; set; }
        public DateTime? FechaHojaDeVida { get; set; }
        public DateTime? FechaEnvioMantenimiento { get; set; }
        /// <summary>
        /// Es referencia debido a que el taller para los reportes se selecciona al momento de ingresar la hoja de vida, por cada repuesto un taller
        /// </summary>
        public int? IdTallerReferencia { get; set; }

        public virtual EstadosMantenimiento? IdEstadoNavigation { get; set; }
        public virtual Vehiculo? IdVehiculoNavigation { get; set; }
        public virtual ICollection<MantenimientoDetalle> MantenimientoDetalles { get; set; }
    }
}
