using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class EmpCiudadano
    {
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public short? Sexo { get; set; }
        public decimal? Sueldo { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Numero { get; set; }
        public string? Telefono { get; set; }
        public string? Ifcnombre { get; set; }
    }
}
