using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CanonDeArrendamiento
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public byte Mes { get; set; }
        public int Anio { get; set; }
        public DateTime FechaDeEmision { get; set; }
        public double ValorArrendamiento { get; set; }
        public double Iva { get; set; }
        public double ValorTotal { get; set; }
        public string? Descripcion { get; set; }
        public int? CodigoTesoreria { get; set; }
        public string UsuarioDelSistema { get; set; } = null!;
    }
}
