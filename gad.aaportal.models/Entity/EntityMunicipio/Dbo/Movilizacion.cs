using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Movilizacion
    {
        public int Codigo { get; set; }
        public int CodigoVehiculo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public string Destino { get; set; } = null!;
        public string Actividad { get; set; } = null!;
        public string? Novedades { get; set; }
        public string? CiResponsable { get; set; }
        public string? CiConductor { get; set; }
        public string? CiAutoriza { get; set; }
        public string? Duracion { get; set; }
        public string? HoraEmision { get; set; }
        public DateTime? FechaDuracion { get; set; }
        public string? HoraDesde { get; set; }
        public string? HoraHasta { get; set; }

        public virtual Vehiculo CodigoVehiculoNavigation { get; set; } = null!;
    }
}
