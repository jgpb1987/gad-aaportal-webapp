using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioAccionesDerecho
    {
        public PredioAccionesDerecho()
        {
            PredioAccionarios = new HashSet<PredioAccionario>();
        }

        public int IdAcciones { get; set; }
        public string? ClaveCatastral { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? UsuarioIngreso { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
        public virtual ICollection<PredioAccionario> PredioAccionarios { get; set; }
    }
}
