using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class EmpleadosDelGrupo
    {
        public string? NombreGrupo { get; set; }
        public string? CedIdentCiudadano { get; set; }

        public virtual Empleado? CedIdentCiudadanoNavigation { get; set; }
        public virtual GruposDelMunicipio? NombreGrupoNavigation { get; set; }
    }
}
