using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmObrasTr
    {
        public SmObrasTr()
        {
            SmObras = new HashSet<SmObra>();
        }

        public int CodigoObraTr { get; set; }
        public string? NombreObra { get; set; }
        public double? CostoObra { get; set; }
        public double? CostoAsumeMunicipio { get; set; }
        public double? CostoAcobrar { get; set; }
        public string? ResponsableObra { get; set; }
        public string? ContratistaObra { get; set; }
        /// <summary>
        /// Si el estado es P (Obra Preliminar) si el estado es D (Obra es definitiva)
        /// </summary>
        public string? EstadoObra { get; set; }
        /// <summary>
        /// El estado que indica en que dependencia se encuentra el proceso
        /// &apos;O&apos;(Obras Publicas), &apos;A&apos;(Avaluos y Catastros), &apos;F&apos; (Fiscalización), &apos;R&apos;(Rentas)
        /// </summary>
        public string? EstadoDependencia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Usuario { get; set; }

        public virtual ICollection<SmObra> SmObras { get; set; }
    }
}
