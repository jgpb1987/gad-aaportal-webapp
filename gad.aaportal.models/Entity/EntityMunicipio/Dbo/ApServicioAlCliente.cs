using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApServicioAlCliente
    {
        public int CodIngreso { get; set; }
        public int? Sector { get; set; }
        public int? Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string? TipoTramite { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Usuario { get; set; }
        public string? CedulaCiudadano { get; set; }
        public int? Estado { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string? RecursosUtilizados { get; set; }
        public string? CedulaTrabajador { get; set; }
        public string? Materiales { get; set; }
        public string? Movilizacion { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string? AsignadoPor { get; set; }
        public string? Direccion { get; set; }
        public string? UsuarioSolicita { get; set; }
        public string? Referencia { get; set; }

        public virtual ApTrabajadore? CedulaTrabajadorNavigation { get; set; }
    }
}
