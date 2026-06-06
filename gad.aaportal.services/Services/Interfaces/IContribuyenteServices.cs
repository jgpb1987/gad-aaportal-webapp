using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.dataaccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IContribuyenteServices
    {
        Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(AaportalContext contexto, ContribuyenteResumenDtoParam parametro);
        Task<ConsultarDatosContribuyenteDataResult> ConsultarDatosContribuyente(AaportalContext contexto, ConsultarDatosContribuyenteDtoParam parametro);
        Task<ActualizarDatosContribuyenteDataResult> ActualizarDatosContribuyente(AaportalContext contexto,  ActualizarDatosContribuyenteDtoParam parametro);
        Task<TipoMedioContactoDataResult> ConsultarTiposMedioContacto(AaportalContext contexto);
        Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracion(AaportalContext contexto, ContribuyenteDtoParam parametro);
        Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracionMunicipio(AaportalContext contexto, ContribuyenteDtoParam parametro);
        Task<IniciarDeclaracionDataResult> IniciarDeclaracion(AaportalContext contexto,   IniciarDeclaracionDtoParam parametro);
        Task<RegistrarDeclaracionDataResult> RegistrarDeclaracion( AaportalContext contexto, RegistrarDeclaracionDtoParam parametro);
        Task<ConsultarDeclaracionContribuyenteDataResult> ConsultarDeclaracionesContribuyente(AaportalContext contexto,  ConsultarDeclaracionContribuyenteDtoParam parametro);

    }
}
