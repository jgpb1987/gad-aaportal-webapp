using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
