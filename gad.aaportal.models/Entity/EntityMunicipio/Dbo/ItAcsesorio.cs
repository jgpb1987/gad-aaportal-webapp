using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItAcsesorio
    {
        public int? Idequipo { get; set; }
        public string? CodigoActivo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaAdquicicion { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }

        public virtual ItAcsesoriosTipo? DescripcionNavigation { get; set; }
        public virtual ItEquipo? IdequipoNavigation { get; set; }
    }
}
