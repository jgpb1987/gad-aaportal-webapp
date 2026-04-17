using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApLectura
    {
        public int? Sector { get; set; }
        public int Cuenta { get; set; }
        public string? Anio { get; set; }
        public string? Mes { get; set; }
        public int? LecturaAnterior { get; set; }
        public int? LecturaActual { get; set; }
        public int? CodigoIngresoArentas { get; set; }
        public string? Novedad { get; set; }
        public double? ValorApagar { get; set; }
        public double? TasaAlcantarillado { get; set; }
        public double? Reconexion { get; set; }
        public long CodIngreso { get; set; }
        public DateTime? FechaCaptura { get; set; }
        public string? HoraCaptura { get; set; }
        public string? MetodoProceso { get; set; }
        public string? IdUsuarioProfac { get; set; }
        public long? Cus { get; set; }
        public int? LecturaSugerida { get; set; }
        public string? ValoresEmitidos { get; set; }
        public string? NumeroDocumento { get; set; }

        public virtual ApAcometida? ApAcometida { get; set; }
    }
}
