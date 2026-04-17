using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Ciudadano
    {
        public Ciudadano()
        {
            AccionesDePredios = new HashSet<AccionesDePredio>();
            AeIdentificacionContribuyentes = new HashSet<AeIdentificacionContribuyente>();
            ApAcometida = new HashSet<ApAcometida>();
            DatosIngresos = new HashSet<DatosIngreso>();
            Locals = new HashSet<Local>();
            NcNotaCreditos = new HashSet<NcNotaCredito>();
            PredioAccionarios = new HashSet<PredioAccionario>();
            PredioComodatos = new HashSet<PredioComodato>();
            Predios = new HashSet<Predio>();
            //SaDenunciasAciudadanoCedulaCiudadanoDenunciadoNavigations = new HashSet<SaDenunciasAciudadano>();
            //SaDenunciasAciudadanoCedulaCiudadanoDenuncianteNavigations = new HashSet<SaDenunciasAciudadano>();
            SaDenunciasActividadesEconomicas = new HashSet<SaDenunciasActividadesEconomica>();
            TelefonoCiudadanos = new HashSet<TelefonoCiudadano>();
        }

        public string CedIdentCiudadano { get; set; } = null!;
        public string? ApellidosCiudadano { get; set; }
        public string? NombresCiudadano { get; set; }
        public string? Canton { get; set; }
        public string? CiudadDomCiudadano { get; set; }
        public string? DireccionDomCiudadano { get; set; }
        public string? TelefonoCiudadano { get; set; }
        public string? Celular { get; set; }
        public string? EmailCiudadano { get; set; }
        public DateTime? FechaNacCiudadano { get; set; }
        public string? EstadoCivilCiudadano { get; set; }
        public string? Pais { get; set; }
        public bool? VecinoCiudadano { get; set; }
        public string? BorrarTipoIdentificacion { get; set; }
        public string? BorrarUsuario { get; set; }
        public bool? Bloqueado { get; set; }
        public string? Sexo { get; set; }
        public string? Conyuge { get; set; }
        public bool Fallecido { get; set; }
        public int? NumeroCargasFamiliares { get; set; }
        public int? Contador { get; set; }
        public string? Usuario { get; set; }
        public bool? Validado { get; set; }
        public int IdCiudadano { get; set; }
        public DateTime? FechaDefuncion { get; set; }
        public bool? VerificaDocumentos { get; set; }
        /// <summary>
        /// Estado &apos;N&apos; ciudadanos ingresados cruce sri
        /// Estado &apos;M&apos; ciudadanos del registro civil conyuge tercera edad
        /// </summary>
        public string? EstadoCiudadano { get; set; }

        public virtual Paise? PaisNavigation { get; set; }
        public virtual Empleado? Empleado { get; set; }
        public virtual ICollection<AccionesDePredio> AccionesDePredios { get; set; }
        public virtual ICollection<AeIdentificacionContribuyente> AeIdentificacionContribuyentes { get; set; }
        public virtual ICollection<ApAcometida> ApAcometida { get; set; }
        public virtual ICollection<DatosIngreso> DatosIngresos { get; set; }
        public virtual ICollection<Local> Locals { get; set; }
        public virtual ICollection<NcNotaCredito> NcNotaCreditos { get; set; }
        public virtual ICollection<PredioAccionario> PredioAccionarios { get; set; }
        public virtual ICollection<PredioComodato> PredioComodatos { get; set; }
        public virtual ICollection<Predio> Predios { get; set; }
        //public virtual ICollection<SaDenunciasAciudadano> SaDenunciasAciudadanoCedulaCiudadanoDenunciadoNavigations { get; set; }
        //public virtual ICollection<SaDenunciasAciudadano> SaDenunciasAciudadanoCedulaCiudadanoDenuncianteNavigations { get; set; }
        public virtual ICollection<SaDenunciasActividadesEconomica> SaDenunciasActividadesEconomicas { get; set; }
        public virtual ICollection<TelefonoCiudadano> TelefonoCiudadanos { get; set; }
    }
}
