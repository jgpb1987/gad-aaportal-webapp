using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StCuentasAcargoDelEmpleado
    {
        public string? CedulaEmpleado { get; set; }
        public string? Cargo { get; set; }
        public byte? Ejerce { get; set; }
        /// <summary>
        /// Carga por default al ingresar al sistema
        /// </summary>
        public byte? Primario { get; set; }
        public byte? CargarEnPara { get; set; }

        public virtual CargosEmpleado? CargoNavigation { get; set; }
        public virtual Empleado? CedulaEmpleadoNavigation { get; set; }
    }
}
