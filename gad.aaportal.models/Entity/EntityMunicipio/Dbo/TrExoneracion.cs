using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrExoneracion
    {
        public int CodigoExoneracion { get; set; }
        public string Descripcion { get; set; } = null!;
        public double PorcentajeAlcabala { get; set; }
        public double PorcentajeUtilidadUrbana { get; set; }
        public string Estado { get; set; } = null!;
    }
}
