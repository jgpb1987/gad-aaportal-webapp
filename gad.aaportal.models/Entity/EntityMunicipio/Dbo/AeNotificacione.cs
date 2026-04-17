using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeNotificacione
    {
        public string Ruc { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string NroNotificacion { get; set; } = null!;
        public int AnioNotificacion { get; set; }
        public string? Nomenclatura { get; set; }
        public string? ContNomenclatura { get; set; }
        public string? NroOficioSri { get; set; }
        public string? FechaOficioSri { get; set; }

        public virtual AeIdentificacionContribuyente RucNavigation { get; set; } = null!;
    }
}
