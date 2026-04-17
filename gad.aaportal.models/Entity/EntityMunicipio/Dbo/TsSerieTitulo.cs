using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TsSerieTitulo
    {
        public int CodigoSerieTitulos { get; set; }
        public int? NumInicialSerieTitulos { get; set; }
        public int? NumFinalSerieTitulos { get; set; }
        public string? UserVentanillaSerieTitulos { get; set; }
        public DateTime? FechaIngresoSerieTitulos { get; set; }
        public string? UserIngresoSerieTitulos { get; set; }
        public string? TipoSerieTitulos { get; set; }
    }
}
