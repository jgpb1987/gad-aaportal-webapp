using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Sectore
    {
        public Sectore()
        {
            ApAcometida = new HashSet<ApAcometida>();
        }

        public string? Parroquia { get; set; }
        public int Sector { get; set; }

        public virtual DivPol? ParroquiaNavigation { get; set; }
        public virtual ICollection<ApAcometida> ApAcometida { get; set; }
    }
}
