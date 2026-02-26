using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IConsultaServices
    {
        Task<ConsultaAniosResponse> ConsultaAnios(AaportalContext contexto, ConsultaIdentificacionRequest parametos);
        Task<ConsultaRazSocialResponse> ConsultaRazSocial(AaportalContext contexto, ConsultaIdentificacionRequest parametos);
        Task<ConsultaIngresosEgresosResponse> ConsultaIngresosEgresos(AaportalContext contexto, ConsultaIngresosEgresosRequest parametos);
        Task<CantonesResponse> ConsultaCantones(AaportalContext contexto);
        Task<ListaTarifas> ConsultaTarifas(AaportalContext contexto);
        Task<TasasAdministrativas> ConsultaTasasAdministrativas(AaportalContext contexto);
        Task<DeclaracionResponse> ConsultaDeclaracion(AaportalContext contexto, ConsultaDeclaracionRequest parametos);
    }
}
