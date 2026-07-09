using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface IContribuyenteConsumers
    {
        Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(ContribuyenteResumenDtoParam parametro);
        Task<ConsultarDatosContribuyenteDataResult> ConsultarDatosContribuyente(ConsultarDatosContribuyenteDtoParam parametro);
        Task<ActualizarDatosContribuyenteDataResult> ActualizarDatosContribuyente(ActualizarDatosContribuyenteDtoParam parametro);
        Task<TipoMedioContactoDataResult> ConsultarTiposMedioContacto();
        Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracion(ContribuyenteDtoParam parametro);
        Task<IniciarDeclaracionDataResult> IniciarDeclaracion(IniciarDeclaracionDtoParam parametro);
        Task<RegistrarDeclaracionDataResult> RegistrarDeclaracion( RegistrarDeclaracionDtoParam parametro);
        Task<ConsultarDeclaracionContribuyenteDataResult> ConsultarDeclaracionesContribuyente(ConsultarDeclaracionContribuyenteDtoParam parametro);
    }
}
