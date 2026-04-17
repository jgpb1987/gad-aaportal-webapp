using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividad
    {
        public AeActividad()
        {
            AeActividadEconomicas = new HashSet<AeActividadEconomica>();
            AeActividadValorCobrars = new HashSet<AeActividadValorCobrar>();
        }

        public int CodigoAct { get; set; }
        public string? IdNivel2 { get; set; }
        public string? Actividad { get; set; }

        public virtual AeActividadNivel2? IdNivel2Navigation { get; set; }
        public virtual ICollection<AeActividadEconomica> AeActividadEconomicas { get; set; }
        public virtual ICollection<AeActividadValorCobrar> AeActividadValorCobrars { get; set; }
    }
}
