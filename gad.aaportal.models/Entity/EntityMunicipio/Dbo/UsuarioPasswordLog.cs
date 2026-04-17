using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class UsuarioPasswordLog
    {
        public int IdPasswordLog { get; set; }
        public int? IdUsuario { get; set; }
        public string? Oldpassword { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
