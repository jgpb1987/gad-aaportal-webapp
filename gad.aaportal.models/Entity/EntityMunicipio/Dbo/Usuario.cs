using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Usuario
    {
        public Usuario()
        {
            AsAccesos = new HashSet<AsAcceso>();
            PacCompras = new HashSet<PacCompra>();
            PacDetalleCompras = new HashSet<PacDetalleCompra>();
            PacTechoPresupuestarios = new HashSet<PacTechoPresupuestario>();
        }

        public int Id { get; set; }
        public string CodUsuario { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public bool? EditarClave { get; set; }
        public string Descripcion { get; set; } = null!;
        public byte? Prioridad { get; set; }
        public DateTime? FechaPassword { get; set; }
        public bool? Activo { get; set; }
        public bool? OtraInstitucion { get; set; }

        public virtual Empleado CodUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<AsAcceso> AsAccesos { get; set; }
        public virtual ICollection<PacCompra> PacCompras { get; set; }
        public virtual ICollection<PacDetalleCompra> PacDetalleCompras { get; set; }
        public virtual ICollection<PacTechoPresupuestario> PacTechoPresupuestarios { get; set; }
    }
}
