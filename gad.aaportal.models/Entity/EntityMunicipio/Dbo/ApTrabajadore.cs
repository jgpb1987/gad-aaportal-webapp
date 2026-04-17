using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApTrabajadore
    {
        public ApTrabajadore()
        {
            ApServicioAlClientes = new HashSet<ApServicioAlCliente>();
        }

        public string CedulaTrabajador { get; set; } = null!;
        public string? NombreTrabajador { get; set; }

        public virtual ICollection<ApServicioAlCliente> ApServicioAlClientes { get; set; }
    }
}
