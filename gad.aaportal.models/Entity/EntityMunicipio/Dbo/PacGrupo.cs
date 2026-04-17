using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacGrupo
    {
        public PacGrupo()
        {
            PacSubGrupos = new HashSet<PacSubGrupo>();
        }

        public int IdGrupo { get; set; }
        public string NombreGrupo { get; set; } = null!;
        /// <summary>
        /// Campo descriptivo, no se utiliza ya que la clasificacipon de las cuentas se asigna en los subgrupos
        /// </summary>
        public string CuentaContableGrupo { get; set; } = null!;

        public virtual ICollection<PacSubGrupo> PacSubGrupos { get; set; }
    }
}
