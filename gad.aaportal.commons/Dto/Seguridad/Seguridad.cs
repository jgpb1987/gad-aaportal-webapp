using gad.aaportal.commons.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class UserRegistrationDtoParam : InfoBrowserUsuario
    {
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string User { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Nombres { get; set; } = null!;
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Email { get; set; } = null!;
    }
}
