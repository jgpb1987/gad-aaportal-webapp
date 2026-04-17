using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaActividadesEconomica
    {
        public string? RepresentanteNombres { get; set; }
        public string? RepresentanteApellidos { get; set; }
        public string RepresentanteCedula { get; set; } = null!;
        public string? RepresentanteDireccion { get; set; }
        public string? RepresentanteNacionalidad { get; set; }
        public string? RepresentanteEmail { get; set; }
        public string? RepresentanteTelefono { get; set; }
        public int IdActividad { get; set; }
        public string? Ruc { get; set; }
        public string? Personeria { get; set; }
        public string? RazonSocial { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public string? Actividad { get; set; }
        public string? Activo { get; set; }
        public string? NombreLocales { get; set; }
        public string? Ciiu { get; set; }
        public string? Nivel2 { get; set; }
    }
}
