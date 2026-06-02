using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class Contribuyente
    {
        public Contribuyente()
        {
            ContribuyenteDeclaracions = new HashSet<ContribuyenteDeclaracion>();
            ContribuyenteEstablecimientos = new HashSet<ContribuyenteEstablecimiento>();
            ContribuyenteMedioContactos = new HashSet<ContribuyenteMedioContacto>();
            ContribuyenteUsuarios = new HashSet<ContribuyenteUsuario>();
        }

        public string Identificacion { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string EstadoContribuyenteRuc { get; set; } = null!;
        public string ActividadEconomicaPrincipal { get; set; } = null!;
        public string TipoContribuyente { get; set; } = null!;
        public string Regimen { get; set; } = null!;
        public string ObligadoLlevarContabilidad { get; set; } = null!;
        public string AgenteRetencion { get; set; } = null!;
        public string ContribuyenteEspecial { get; set; } = null!;
        public DateTime FechaInicioActividades { get; set; }
        public DateTime FechaReinicioActividades { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ContribuyenteFantasma { get; set; } = null!;
        public string TransaccionesInexistente { get; set; } = null!;
        public string CallePrincipal { get; set; } = null!;
        public string NumeroCasa { get; set; } = null!;
        public string CalleSecundaria { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string ReferenciaUbicacion { get; set; } = null!;
        public string Via { get; set; } = null!;
        public string Kilometro { get; set; } = null!;
        public string Manzana { get; set; } = null!;
        public string Edificio { get; set; } = null!;
        public string Piso { get; set; } = null!;
        public string NumeroPredio { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<ContribuyenteDeclaracion> ContribuyenteDeclaracions { get; set; }
        public virtual ICollection<ContribuyenteEstablecimiento> ContribuyenteEstablecimientos { get; set; }
        public virtual ICollection<ContribuyenteMedioContacto> ContribuyenteMedioContactos { get; set; }
        public virtual ICollection<ContribuyenteUsuario> ContribuyenteUsuarios { get; set; }
    }
}
