using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Ciiu
    {
        public Ciiu()
        {
            Locals = new HashSet<Local>();
        }

        public string Codigo { get; set; } = null!;
        public string? Caracter { get; set; }
        public string? Descripcion { get; set; }
        public string? DescripcionCorta { get; set; }
        public double? CategoriaA { get; set; }
        public double? CategoriaB { get; set; }
        public double? CategoriaC { get; set; }
        public double? CategoriaD { get; set; }
        public double? Bpequenio { get; set; }
        public double? Bmedianos { get; set; }
        public double? Bgrandes { get; set; }
        public double? BsuperGrande { get; set; }

        public virtual ICollection<Local> Locals { get; set; }
    }
}
