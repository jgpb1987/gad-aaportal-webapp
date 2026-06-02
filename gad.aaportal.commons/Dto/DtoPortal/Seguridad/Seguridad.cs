using gad.aaportal.commons.Base;
using System.ComponentModel.DataAnnotations;

namespace gad.aaportal.commons.Dto.Seguridad
{
    public class InfoBrowserUsuario
    {
        public string Browser { get; set; } = null!;

        public string UserAgent { get; set; } = null!;

        public string Language { get; set; } = null!;

        public string Ip { get; set; } = null!;

        public string OperatingSystem { get; set; } = null!;

        public string Plugins { get; set; } = null!;

        public string Geolocation { get; set; } = null!;

        public string TimeZone { get; set; } = null!;
    }
    public class UsuarioDtoParam : InfoBrowserUsuario
    {
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string User { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Password { get; set; } = null!;
    }
    public class UsuarioDataDtoResult
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = null!;
        public DateTime UltimoAcceso { get; set; }
        public string Nombres { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
    }
    public class UsuarioDtoResult : BaseResult
    {
        public UsuarioDataDtoResult Data { get; set; } = null!;
    }
    public class RsaDtoDataResult
    {
        public string PublicKey { get; set; } = null!;
    }
    public class RsaDtoResult : BaseResult
    {
        public RsaDtoDataResult Data { get; set; } = null!;
    }
    public class ForgotPasswordDtoParam : InfoBrowserUsuario
    {
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string User { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Email { get; set; } = null!;
    }
    public class ContribuyenteEstablecimientoDtoParam
    {
        public string NombreFantasiaComercial { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Calles { get; set; } = null!;
        public string DireccionCompleta { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string NumeroEstablecimiento { get; set; } = null!;
        public string Matriz { get; set; } = null!;
    }
    public class UserRegistrationDtoParam : InfoBrowserUsuario
    {
        public string User { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Nombres { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Email { get; set; } = null!;

      
        [Required(ErrorMessage = "{0} es obligatorio")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números.")]
        public string Identificacion { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string EstadoContribuyenteRuc { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string ActividadEconomicaPrincipal { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string TipoContribuyente { get; set; } = null!;
        public string Regimen { get; set; } = null!;
        public string ObligadoLlevarContabilidad { get; set; } = null!;
        public string AgenteRetencion { get; set; } = null!;
        public string ContribuyenteEspecial { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public DateTime FechaInicioActividades { get; set; }
        public DateTime FechaReinicioActividades { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ContribuyenteFantasma { get; set; } = null!;
        public string TransaccionesInexistente { get; set; } = null!;
        public List<ContribuyenteEstablecimientoDtoParam> Establecimientos { get; set; } = null!;

    }
    public class CambiarClaveDtoParam
    {
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        public string PasswordActual { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        public string PasswordNueva { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe repetir la nueva contraseña.")]
        public string PasswordNuevaConfirmacion { get; set; } = string.Empty;
    }
    public class CambiarClaveDtoResult
    {
        public bool CambioCorrecto { get; set; }
    }
    public class CambiarClaveDataResult : BaseResult
    {
        public CambiarClaveDtoResult Data { get; set; } = null!;
    }
}
