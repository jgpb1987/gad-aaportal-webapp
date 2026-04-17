using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaEstadoProceso
    {
        public SaEstadoProceso()
        {
            SaDenunciasAciudadanos = new HashSet<SaDenunciasAciudadano>();
            SaDenunciasActividadesEconomicas = new HashSet<SaDenunciasActividadesEconomica>();
        }

        public int IdEstadoProceso { get; set; }
        public string? EstadoDescripcion { get; set; }

        public virtual ICollection<SaDenunciasAciudadano> SaDenunciasAciudadanos { get; set; }
        public virtual ICollection<SaDenunciasActividadesEconomica> SaDenunciasActividadesEconomicas { get; set; }
    }
}
