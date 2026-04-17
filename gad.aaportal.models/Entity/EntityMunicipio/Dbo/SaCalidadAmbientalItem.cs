using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaCalidadAmbientalItem
    {
        public SaCalidadAmbientalItem()
        {
            SaDenunciasAciudadanos = new HashSet<SaDenunciasAciudadano>();
            SaDenunciasActividadesEconomicas = new HashSet<SaDenunciasActividadesEconomica>();
        }

        public int IdCalidadAmbientalItems { get; set; }
        public int? IdCalidadAmbiental { get; set; }
        public string? Nombre { get; set; }
        public bool? Estado { get; set; }

        public virtual SaCalidadAmbiental? IdCalidadAmbientalNavigation { get; set; }
        public virtual ICollection<SaDenunciasAciudadano> SaDenunciasAciudadanos { get; set; }
        public virtual ICollection<SaDenunciasActividadesEconomica> SaDenunciasActividadesEconomicas { get; set; }
    }
}
