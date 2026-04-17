using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AreaTrabajo
    {
        public AreaTrabajo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public string Codigo { get; set; } = null!;
        public string? Padre { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Siglas { get; set; }
        public int? MemoNumero { get; set; }
        public string? MemoSiglas { get; set; }
        public string? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
