using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DatosTransporte
    {
        public int Id { get; set; }
        public string? RucCedula { get; set; }
        public string? RazonSocial { get; set; }
        public string? Placa { get; set; }
        public string? Compañia { get; set; }
        public string? Tipo { get; set; }
        public DateTime? FechaEmision { get; set; }
    }
}
