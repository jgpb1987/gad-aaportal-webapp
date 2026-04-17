using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItEmpresaProveedora
    {
        public ItEmpresaProveedora()
        {
            ItEquipos = new HashSet<ItEquipo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Contacto { get; set; }
        public string? SitioWeb { get; set; }

        public virtual ICollection<ItEquipo> ItEquipos { get; set; }
    }
}
