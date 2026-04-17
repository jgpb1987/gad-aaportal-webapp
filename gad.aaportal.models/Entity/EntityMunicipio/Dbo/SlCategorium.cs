using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlCategorium
    {
        public SlCategorium()
        {
            SlCatastroLicenciaTurismos = new HashSet<SlCatastroLicenciaTurismo>();
        }

        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public double? Porcentaje { get; set; }
        public int? IdClasificacion { get; set; }
        public double? Porcentaje2019 { get; set; }

        public virtual ICollection<SlCatastroLicenciaTurismo> SlCatastroLicenciaTurismos { get; set; }
    }
}
