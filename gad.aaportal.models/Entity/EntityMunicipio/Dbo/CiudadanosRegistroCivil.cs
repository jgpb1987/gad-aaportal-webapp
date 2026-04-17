using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CiudadanosRegistroCivil
    {
        public int IdCiudadanosRegistroCivil { get; set; }
        public string? Cedula { get; set; }
        public string? NombreCompleto { get; set; }
        public string? CondicionCiudadano { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? LugarNacimiento { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Conyugue { get; set; }
        public string? Domicilio { get; set; }
        public string? CallesDomicilio { get; set; }
        public string? NumeroCasa { get; set; }
        public DateTime? FechaDefuncion { get; set; }
        public string? CedulaConyugue { get; set; }
        public DateTime? FechaConsulta { get; set; }
    }
}
