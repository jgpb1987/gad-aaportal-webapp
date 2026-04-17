using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApAcometida
    {
        public string CedulaCiudadano { get; set; } = null!;
        public int Sector { get; set; }
        public int Cuenta { get; set; }
        public string? NumeroDeMedidor { get; set; }
        public string? Direccion { get; set; }
        public string? Tarifa { get; set; }
        public string? Comentario { get; set; }
        public int? Secuencia { get; set; }
        public string? NumeroDeContrato { get; set; }
        public string? Alcantarillado { get; set; }
        public int? Estado { get; set; }
        public string? CodCatastralPredio { get; set; }
        public int? TerceraEdad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? CedulaArrendatario { get; set; }
        public string? CodBarras { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public int? NumPersonas { get; set; }

        public virtual Ciudadano CedulaCiudadanoNavigation { get; set; } = null!;
        public virtual Sectore SectorNavigation { get; set; } = null!;
        public virtual ApTipodetarifa? TarifaNavigation { get; set; }
    }
}
