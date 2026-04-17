using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlCatastroLicenciaTurismo
    {
        public SlCatastroLicenciaTurismo()
        {
            SlCatastroAnuals = new HashSet<SlCatastroAnual>();
        }

        public string Ruc { get; set; } = null!;
        public int? IdCategoria { get; set; }
        public int? NroPlazas { get; set; }
        public string? UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Estado { get; set; }
        public int? IdLocal { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual SlCategorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<SlCatastroAnual> SlCatastroAnuals { get; set; }
    }
}
