using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class EstadosMantenimiento
    {
        public EstadosMantenimiento()
        {
            MantenimientoAlerta = new HashSet<MantenimientoAlertum>();
        }

        public int IdEstados { get; set; }
        public string? NombreEstado { get; set; }
        public bool? Mostrar { get; set; }
        public int? OrdenEstados { get; set; }

        public virtual ICollection<MantenimientoAlertum> MantenimientoAlerta { get; set; }
    }
}
