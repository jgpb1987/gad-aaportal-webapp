using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeRenunciaExoneracion
    {
        public TeRenunciaExoneracion()
        {
            TeRenunciaExoneracionDets = new HashSet<TeRenunciaExoneracionDet>();
        }

        public int Id { get; set; }
        public string? Observacion { get; set; }
        public string? CedulaC { get; set; }
        public string? TipoImpuesto { get; set; }
        public DateTime? FecaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }

        public virtual ICollection<TeRenunciaExoneracionDet> TeRenunciaExoneracionDets { get; set; }
    }
}
