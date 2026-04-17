using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteNotificacione
    {
        public int CodigoNotificaciones { get; set; }
        public string? CiNotificaciones { get; set; }
        public string? TipoNotificaciones { get; set; }
        public string? ComentarioNotificaciones { get; set; }
        public DateTime? FechaNotificaciones { get; set; }
        public int? NumeroNotificaciones { get; set; }
        public string NotificadorNotificaciones { get; set; } = null!;
        public int? NumeroTramiteNotificaciones { get; set; }
        public double? ValorTotalNotificaciones { get; set; }
        public DateTime? FechaIngresoNotificaciones { get; set; }
        public string? UsuarioNotificaciones { get; set; }
        public string? EstadoNotificaciones { get; set; }
        public DateTime? FechaInactiva { get; set; }
    }
}
