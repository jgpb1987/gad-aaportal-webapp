using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmCostosObra
    {
        public int IdCosto { get; set; }
        public double? ValorTotal { get; set; }
        public double? PorcentajeAsumeMuni { get; set; }
        public double? PorcenjatePagaUsuario { get; set; }
        public int? IdTipoMejora { get; set; }
        public int? CodigoDeObra { get; set; }

        public virtual SmObra? CodigoDeObraNavigation { get; set; }
        public virtual SmTipoMejora? IdTipoMejoraNavigation { get; set; }
    }
}
