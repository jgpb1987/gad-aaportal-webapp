using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.Declaracion
{
    public class ContribuyenteResumenDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;
    }
    public class ContribuyenteResumenDtoResult
    {
        public string Identificacion { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string TipoContribuyente { get; set; } = string.Empty;
        public string ActividadEconomica { get; set; } = string.Empty;
        public string InicioActividadEconomica { get; set; } = string.Empty;
        public string ContribuyenteEspecial { get; set; } = string.Empty;
        public string ObligadoLlevarContabilidad { get; set; } = string.Empty;
    }
    public class ContribuyenteResumenDataDtoResult:BaseResult
    {
        public ContribuyenteResumenDtoResult Data { get; set; } = null!;
    }
    public class ActualizarDatosContribuyenteDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La calle principal es obligatoria.")]
        public string CallePrincipal { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de casa es obligatorio.")]
        public string NumeroCasa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La calle secundaria es obligatoria.")]
        public string CalleSecundaria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La parroquia es obligatoria.")]
        public string Parroquia { get; set; } = string.Empty;

        public string Barrio { get; set; } = string.Empty;

        [Required(ErrorMessage = "La referencia de ubicación es obligatoria.")]
        public string ReferenciaUbicacion { get; set; } = string.Empty;

        public string Via { get; set; } = string.Empty;
        public string Kilometro { get; set; } = string.Empty;
        public string Manzana { get; set; } = string.Empty;
        public string Edificio { get; set; } = string.Empty;
        public string Piso { get; set; } = string.Empty;
        public string NumeroPredio { get; set; } = string.Empty;

        public List<ContribuyenteMedioContactoDtoResult> MediosContacto { get; set; } = new();
        public List<ContribuyenteEstablecimientoDtoParam> Establecimientos { get; set; } = null!;
    }

    public class ContribuyenteMedioContactoDtoResult
    {
        public long IdMedioContacto { get; set; }
        public string CodigoTipoMedioContacto { get; set; } = string.Empty;
        public string NombreTipoMedioContacto { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public bool EsPrincipal { get; set; }
        public bool Estado { get; set; } = true;
    }
    public class ActualizarDatosContribuyenteDtoResult
    {
        public bool ActualizacionCorrecta { get; set; }
    }
    public class ActualizarDatosContribuyenteDataResult : BaseResult
    {
        public ActualizarDatosContribuyenteDtoResult Data { get; set; } = null!;
    }
    public class ConsultarDatosContribuyenteDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;
    }
    public class ConsultarDatosContribuyenteDataResult : BaseResult
    {
        public ActualizarDatosContribuyenteDtoParam Data { get; set; } = null!;
    }
    public class TipoMedioContactoDtoResult
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
    public class TipoMedioContactoDataResult : BaseResult
    {
        public List<TipoMedioContactoDtoResult> Data { get; set; } = new();
    }

}

