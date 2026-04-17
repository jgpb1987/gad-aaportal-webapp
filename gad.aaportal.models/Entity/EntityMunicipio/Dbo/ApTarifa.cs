using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApTarifa
    {
        public string? Nombre { get; set; }
        public int? Minimo { get; set; }
        public int? Maximo { get; set; }
        public double? Base { get; set; }
        public double? Adicional { get; set; }
        public int Indice { get; set; }

        public virtual ApTipodetarifa? NombreNavigation { get; set; }
    }
}
