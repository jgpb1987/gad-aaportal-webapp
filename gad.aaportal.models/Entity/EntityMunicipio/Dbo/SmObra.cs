using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmObra
    {
        public SmObra()
        {
            SmCostosObras = new HashSet<SmCostosObra>();
            SmMejoras = new HashSet<SmMejora>();
            SmMejorasAuxes = new HashSet<SmMejorasAux>();
            SmObservaciones = new HashSet<SmObservacione>();
        }

        public int CodigoDeObra { get; set; }
        public string? CodigoAnteriorDeObra { get; set; }
        public string? Calle { get; set; }
        public string? TipoDeObra { get; set; }
        public DateTime? FechaEmision { get; set; }
        public int? AnioEmision { get; set; }
        public int? AnioFinalizacion { get; set; }
        public int? AniosPlazo { get; set; }
        public string? Descripcion { get; set; }
        public double? CostoObra { get; set; }
        public double? Descuento { get; set; }
        public double? MontoAcobrar { get; set; }
        public string? ClaveParroquia { get; set; }
        public string? AreaDeObra { get; set; }
        public string? TipoDeBeneficiario { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? CalleHasta { get; set; }
        public string? CalleDesde { get; set; }
        public int? CodigoObraTram { get; set; }
        /// <summary>
        /// Si el estado es P (Obra Preliminar) si el estado es D (Obra es definitiva)
        /// </summary>
        public string? EstadoObra { get; set; }
        /// <summary>
        /// El estado que indica en que dependencia se encuentra el proceso
        /// &apos;O&apos;(Obras Publicas), &apos;A&apos;(Avaluos y Catastros), &apos;R&apos;(Rentas), &apos;C&apos; (Calculadas), &apos;G&apos; (Generadas Calculo), &apos;E&apos; (Eliminadas) , &apos;F&apos; (Fiscalización), &apos;D&apos; (Obra Recalcualda)
        /// </summary>
        public string? EstadoDependencia { get; set; }
        public string? Observacion { get; set; }
        public string? Usuario { get; set; }
        public string? NroTramite { get; set; }
        public DateTime? FechaEmisionRentas { get; set; }
        public DateTime? AnioRealizacionObra { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public string? DescripcionTramo { get; set; }
        public bool? EstadoVerificacion { get; set; }
        public int? CodigoObraRecal { get; set; }

        public virtual SmObrasTr? CodigoObraTramNavigation { get; set; }
        public virtual ICollection<SmCostosObra> SmCostosObras { get; set; }
        public virtual ICollection<SmMejora> SmMejoras { get; set; }
        public virtual ICollection<SmMejorasAux> SmMejorasAuxes { get; set; }
        public virtual ICollection<SmObservacione> SmObservaciones { get; set; }
    }
}
