using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SnRazonNotificacion
    {
        public int IdRazonNotificaion { get; set; }
        public string? CiNotifico { get; set; }
        public string? CiRecibio { get; set; }
        public string? NombreRecibio { get; set; }
        public string? Parentesco { get; set; }
        public string? Observacion { get; set; }
        public string? NroNotificacion { get; set; }
        public int? IdNotificacion { get; set; }
        public string? NroTramite { get; set; }
        public string? NroMemo { get; set; }

        public virtual SnNotificacione? IdNotificacionNavigation { get; set; }
    }
}
