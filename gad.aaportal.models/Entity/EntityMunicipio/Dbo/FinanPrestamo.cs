using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class FinanPrestamo
    {
        public int CodFinanPrestamo { get; set; }
        public string? DescripcionFinanPrestamo { get; set; }
        public string? EstadoFinanPrestamo { get; set; }
    }
}
