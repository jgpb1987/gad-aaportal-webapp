using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaCartera
    {
        public string? DescripcionTitulo { get; set; }
        public int CodCreacionTitulo { get; set; }
        public string? DescripcionDescripcion { get; set; }
        public int CodigoDescripcion { get; set; }
        public double Valor { get; set; }
    }
}
