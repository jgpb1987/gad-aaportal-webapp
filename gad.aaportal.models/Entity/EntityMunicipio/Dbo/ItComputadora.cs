using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItComputadora
    {
        public int Id { get; set; }
        public string? NombreDelEquipo { get; set; }
        public string? Procesador { get; set; }
        public string? ProcesadorVelocidad { get; set; }
        public string? Ram { get; set; }
        public byte? NumDiscos { get; set; }
        public string? Almacenamiento { get; set; }
        public string? TipoLectorCd { get; set; }
        public bool? FloppySn { get; set; }
        public bool? Modem { get; set; }
        public bool? Wireless { get; set; }
        public DateTime? GarantiaHastaCuando { get; set; }

        public virtual ItEquipo IdNavigation { get; set; } = null!;
    }
}
