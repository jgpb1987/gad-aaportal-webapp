using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class BpConsultum
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? CodClienteIngreso { get; set; }
        public string? Moneda { get; set; }
        public double? ValorTitulo { get; set; }
        public string? FormaPago { get; set; }
        public string? TipoCuenta { get; set; }
        public string? NroCuenta { get; set; }
        public string? Ref { get; set; }
        public string? TipoId { get; set; }
        public int? NroCliente { get; set; }
        public string? Nombre { get; set; }
    }
}
