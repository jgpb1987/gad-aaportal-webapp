using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SnRazonPatente
    {
        public int IdRazon { get; set; }
        public int? IdNotificacion { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? NombreLocal { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public DateTime? FechaMaximaNot { get; set; }
        public string? FechaSegundaNot { get; set; }
        public bool? Validado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Actividad { get; set; }

        public virtual SnNotificacione? IdNotificacionNavigation { get; set; }
    }
}
