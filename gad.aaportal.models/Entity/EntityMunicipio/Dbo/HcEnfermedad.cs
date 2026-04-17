using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcEnfermedad
    {
        public string EnfCed { get; set; } = null!;
        public string? Enf1 { get; set; }
        public string? Enf2 { get; set; }
        public string? App { get; set; }
        public string? Apf { get; set; }
        public string? HabitosToxicos { get; set; }
        public string? Traumatismos { get; set; }
        public string? Transfusiones { get; set; }
        public string? Operaciones { get; set; }

        public virtual Empleado EnfCedNavigation { get; set; } = null!;
    }
}
