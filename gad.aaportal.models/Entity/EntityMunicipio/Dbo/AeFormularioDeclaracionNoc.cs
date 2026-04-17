using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeFormularioDeclaracionNoc
    {
        public int NroDeclaracion { get; set; }
        public double? ActEfectivo { get; set; }
        public double? ActCuentasCobrar { get; set; }
        public double? ActInventarios { get; set; }
        public double? ActLocales { get; set; }
        public double? ActMaquinaria { get; set; }
        public double? ActEquipoComputo { get; set; }
        public double? ActVehiculos { get; set; }
        public double? PasCuentasPagar { get; set; }
        public double? PasOtrosPasivos { get; set; }
        public double? PasFinancieras { get; set; }
        public double? PasPrestamos { get; set; }
        public string? Ruc { get; set; }
    }
}
