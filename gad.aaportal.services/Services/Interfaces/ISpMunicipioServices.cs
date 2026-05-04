using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.dataaccess.Configuration;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface ISpMunicipioServices
    {
        Task<CalcularImpuestoPatenteDtoResult> CalcularImpuestoPatente(BddGmaaContext contexto, CalcularImpuestoPatenteDtoParam parametro);
        Task<CalcularImpuestoIatDtoResult> CalcularImpuestoIat(BddGmaaContext contexto,    CalcularImpuestoIatDtoParam parametro);
        Task<CalcularMultaDtoResult> CalcularMulta(BddGmaaContext contexto, CalcularMultaDtoParam parametro);
        Task<CalcularTerceraEdadDtoResult> CalcularTerceraEdad(BddGmaaContext contexto, CalcularTerceraEdadDtoParam parametro);
        Task<InsertActividadAnualDtoResult> InsertActividadAnual(BddGmaaContext contexto,InsertActividadAnualDtoParam parametro);
        Task<InsertTerceraEdadDtoResult> InsertTerceraEdad(BddGmaaContext contexto, InsertTerceraEdadDtoParam parametro);
        Task<InsertPagoPorTituloDtoResult> InsertPagoPorTitulo(BddGmaaContext contexto, InsertPagoPorTituloDtoParam parametro);
        Task<ActualizarCodigoIngresoDtoResult> ActualizarCodigoIngreso(BddGmaaContext contexto, ActualizarCodigoIngresoDtoParam parametro);
        Task<ConsultarValoresPagarDtoResult> ConsultarValoresPagar(BddGmaaContext contexto, ConsultarValoresPagarDtoParam parametro);
    }
}
