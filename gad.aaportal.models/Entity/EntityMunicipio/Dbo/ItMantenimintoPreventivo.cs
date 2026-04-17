using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItMantenimintoPreventivo
    {
        public int? Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Empresa { get; set; }
        public string? Contrato { get; set; }
        public string? Descripcion { get; set; }

        public virtual ItEquipo? IdNavigation { get; set; }
    }
}
