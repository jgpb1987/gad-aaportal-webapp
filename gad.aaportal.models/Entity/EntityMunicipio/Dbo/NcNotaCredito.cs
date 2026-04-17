using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcNotaCredito
    {
        public NcNotaCredito()
        {
            NcEndosos = new HashSet<NcEndoso>();
            NcMovimientos = new HashSet<NcMovimiento>();
            NcObservaciones = new HashSet<NcObservacione>();
            NcObservacionesImpresions = new HashSet<NcObservacionesImpresion>();
        }

        public int IdNotaCredito { get; set; }
        public string? CedulaCiudadano { get; set; }
        public string? CodigoIngreso { get; set; }
        public double? ValorOriginal { get; set; }
        public double? SaldoTotal { get; set; }
        public string? CodigoDeObra { get; set; }
        public string? Resolucion { get; set; }
        public string? Concepto { get; set; }
        public string? EmitidoPor { get; set; }
        public string? AutorizadoPor { get; set; }
        public DateTime? FechaDePago { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        /// <summary>
        /// &apos;G&apos;=Generado &apos;A&apos;=Aprobado &apos;I&apos;=Impreso &apos;N&apos;=Negado &apos;E&apos;=Endoso &apos;IE&apos;=ImpresoEndoso
        /// &apos;X&apos; = Anulada
        /// </summary>
        public string? Estado { get; set; }
        public string? ImpresoPor { get; set; }
        public int? NroEspecie { get; set; }
        public string? MemoEmitidoPor { get; set; }
        public string? MotivoDevolucion { get; set; }

        public virtual Ciudadano? CedulaCiudadanoNavigation { get; set; }
        public virtual ICollection<NcEndoso> NcEndosos { get; set; }
        public virtual ICollection<NcMovimiento> NcMovimientos { get; set; }
        public virtual ICollection<NcObservacione> NcObservaciones { get; set; }
        public virtual ICollection<NcObservacionesImpresion> NcObservacionesImpresions { get; set; }
    }
}
