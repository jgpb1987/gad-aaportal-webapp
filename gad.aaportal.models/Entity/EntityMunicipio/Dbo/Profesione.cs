using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Profesione
    {
        public Profesione()
        {
            Empleados = new HashSet<Empleado>();
        }

        public string Profesion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
