using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlCatastroAnual
    {
        public int Id { get; set; }
        public string? Ruc { get; set; }
        public double? Porcentaje { get; set; }
        public int? NroPlazas { get; set; }
        public double? ValorTasa { get; set; }
        public double? ValorMulta { get; set; }
        public int? NroMeses { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? AnioDeclaracion { get; set; }
        public string? UsuarioRegistro { get; set; }
        public int? CodigoIngreso { get; set; }
        public int? SalarioB { get; set; }
        public string? NroTramite { get; set; }

        public virtual SlCatastroLicenciaTurismo? RucNavigation { get; set; }
    }
}
