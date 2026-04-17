using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class BorradoresTramite
    {
        public int Id { get; set; }
        public int? NumeroTramite { get; set; }
        public string? TextoDocumento { get; set; }
        public string? De { get; set; }
        public string? Para { get; set; }
        public string? IdDe { get; set; }
        public string? IdPara { get; set; }
        public string? Copias { get; set; }
        public string? Asunto { get; set; }
        public string? ParaLista { get; set; }
        public string? CopiasAlista { get; set; }

        public virtual StTramite? NumeroTramiteNavigation { get; set; }
    }
}
