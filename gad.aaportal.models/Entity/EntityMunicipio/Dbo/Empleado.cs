using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Empleado
    {
        public Empleado()
        {
            HcCertificados = new HashSet<HcCertificado>();
            HcConsulta = new HashSet<HcConsultum>();
            HcDiagnosticos = new HashSet<HcDiagnostico>();
            HcExamen = new HashSet<HcExaman>();
            HcInters = new HashSet<HcInter>();
            SaInformesDesnuncia = new HashSet<SaInformesDesnuncia>();
            SaInspeccionesDenunciaEmpleadoAsignadoNavigations = new HashSet<SaInspeccionesDenuncia>();
            SaInspeccionesDenunciaEmpleadoAsignadorNavigations = new HashSet<SaInspeccionesDenuncia>();
            SaParteInformativos = new HashSet<SaParteInformativo>();
            Usuarios = new HashSet<Usuario>();
        }

        public string? CodigoAreaTrabajo { get; set; }
        public string CedIdentCiudadano { get; set; } = null!;
        public string? Cargo { get; set; }
        public string? Profesion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? TipoRelacion { get; set; }
        public string? Estado { get; set; }
        public string? NumeroLicencia { get; set; }
        public string? Email { get; set; }
        public string? Denominacion { get; set; }
        public bool? Tramitador { get; set; }
        public string? HorarioTrabajo { get; set; }
        public string? HorasLaborales { get; set; }
        public int EmpHc { get; set; }
        public string? TipoContrato { get; set; }

        public virtual Ciudadano CedIdentCiudadanoNavigation { get; set; } = null!;
        public virtual AreaTrabajo? CodigoAreaTrabajoNavigation { get; set; }
        public virtual Profesione? ProfesionNavigation { get; set; }
        public virtual HcEnfermedad? HcEnfermedad { get; set; }
        public virtual ICollection<HcCertificado> HcCertificados { get; set; }
        public virtual ICollection<HcConsultum> HcConsulta { get; set; }
        public virtual ICollection<HcDiagnostico> HcDiagnosticos { get; set; }
        public virtual ICollection<HcExaman> HcExamen { get; set; }
        public virtual ICollection<HcInter> HcInters { get; set; }
        public virtual ICollection<SaInformesDesnuncia> SaInformesDesnuncia { get; set; }
        public virtual ICollection<SaInspeccionesDenuncia> SaInspeccionesDenunciaEmpleadoAsignadoNavigations { get; set; }
        public virtual ICollection<SaInspeccionesDenuncia> SaInspeccionesDenunciaEmpleadoAsignadorNavigations { get; set; }
        public virtual ICollection<SaParteInformativo> SaParteInformativos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
