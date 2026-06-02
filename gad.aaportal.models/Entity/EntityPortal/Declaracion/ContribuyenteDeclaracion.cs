using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Declaracion
{
    public partial class ContribuyenteDeclaracion
    {
        public ContribuyenteDeclaracion()
        {
            ContribuyenteDeclaracionPagoEstablecimientos = new HashSet<ContribuyenteDeclaracionPagoEstablecimiento>();
        }

        public long Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public int Anio { get; set; }
        public string CodigoUnicoPago { get; set; } = null!;
        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorriente { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal PasivoContingente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal CostosGastos { get; set; }
        public decimal _15XMil { get; set; }
        public decimal Patente { get; set; }
        public bool Estado { get; set; }

        public virtual Contribuyente IdentificacionNavigation { get; set; } = null!;
        public virtual ICollection<ContribuyenteDeclaracionPagoEstablecimiento> ContribuyenteDeclaracionPagoEstablecimientos { get; set; }
    }
}
