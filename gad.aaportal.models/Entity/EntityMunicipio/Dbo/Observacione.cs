using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Observacione
    {
        public string? ClaveCatastral { get; set; }
        public int? TomadasDelPlano { get; set; }
        public int? OtraFuenteInformacion { get; set; }
        public int? SeConocePropietario { get; set; }
        public int? LinderosDefinidos { get; set; }
        public int? Exento { get; set; }
        public int? EnConstruccion { get; set; }
        public string? BloqueNro { get; set; }
        public int? NuevoBloque { get; set; }
        public int? SolarNoEdificado { get; set; }
        public int? ArriendoArnticresis { get; set; }
        public int? CerramintoFrentePrincipal { get; set; }
        public string? Comentario { get; set; }
        public bool? Estado { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
    }
}
