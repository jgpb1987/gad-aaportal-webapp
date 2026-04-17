using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsItemMenu
    {
        public int IdItem { get; set; }
        public int IdMenu { get; set; }
        public string Titulo { get; set; } = null!;

        public virtual AsMenuSistema IdMenuNavigation { get; set; } = null!;
    }
}
