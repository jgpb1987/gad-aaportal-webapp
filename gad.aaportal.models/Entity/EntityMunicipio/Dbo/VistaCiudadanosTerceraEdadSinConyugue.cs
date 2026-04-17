using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaCiudadanosTerceraEdadSinConyugue
    {
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
        public string? EstadoCiudadano { get; set; }
    }
}
