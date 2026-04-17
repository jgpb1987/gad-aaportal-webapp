using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItSwich
    {
        public int Id { get; set; }
        public string? NumeroDePuertos { get; set; }

        public virtual ItEquipo IdNavigation { get; set; } = null!;
    }
}
