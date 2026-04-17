using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioDatosIngreso
    {
        public string? CedulaPredio { get; set; }
        public string? PropietarioPredio { get; set; }
        public string ClaveCatastral { get; set; } = null!;
        public string CidatosIngreso { get; set; } = null!;
        public string TituloPago { get; set; } = null!;
        public double ValorTitulo { get; set; }
    }
}
