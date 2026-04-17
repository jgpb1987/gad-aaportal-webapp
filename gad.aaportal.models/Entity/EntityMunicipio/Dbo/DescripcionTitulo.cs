using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionTitulo
    {
        public DescripcionTitulo()
        {
            Valors = new HashSet<Valor>();
        }

        public int CodigoDescripcion { get; set; }
        public string? DescripcionDescripcion { get; set; }
        public string? CodIngresosDescripcion { get; set; }
        public string? CodCobrarDescripcion { get; set; }
        public string? CodPresupuestarioDescripcion { get; set; }
        public string? CodRecaudacionCarteraDescripcion { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? CodPartidasPresupuestarioOlympo { get; set; }
        public string? CodResumenDescripcion { get; set; }
        public string? DescripcionResumenDescripcion { get; set; }
        public string? DescripcionCuentasPorCobrar { get; set; }
        public string? DescripcionCuentaDeIngresos { get; set; }
        public string? DescripcionPartidasPresupuestarioOlympo { get; set; }

        public virtual ICollection<Valor> Valors { get; set; }
    }
}
