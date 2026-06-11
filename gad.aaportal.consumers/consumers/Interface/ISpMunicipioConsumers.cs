using gad.aaportal.commons.Dto.DtoMunicipio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface ISpMunicipioConsumers
    {
        Task<CalcularImpuestoPatenteDtoResult> CalcularImpuestoPatente(CalcularImpuestoPatenteDtoParam parametro);
        Task<CalcularImpuestoIatDtoResult> CalcularImpuestoIat(CalcularImpuestoIatDtoParam parametro);
        Task<CalcularMultaDtoResult> CalcularMulta(CalcularMultaDtoParam parametro);
        Task<CalcularTerceraEdadDtoResult> CalcularTerceraEdad(CalcularTerceraEdadDtoParam parametro);
        Task<InsertActividadAnualDtoResult> InsertActividadAnual(InsertActividadAnualDtoParam parametro);
        Task<InsertTerceraEdadDtoResult> InsertTerceraEdad(InsertTerceraEdadDtoParam parametro);
        Task<InsertPagoPorTituloDtoResult> InsertPagoPorTitulo(InsertPagoPorTituloDtoParam parametro);
        Task<ActualizarCodigoIngresoDtoResult> ActualizarCodigoIngreso(ActualizarCodigoIngresoDtoParam parametro);
        Task<ConsultarValoresPagarDtoResult> ConsultarValoresPagar(ConsultarValoresPagarDtoParam parametro);
        Task<ValidadorPermisosDtoResult> ValidadorPermisos(ValidadorPermisosDtoParam parametro);
        Task<ConsultarValorBomberosDtoResult> ConsultarValorBomberos(ConsultarValorBomberosDtoParam parametro);
        Task<ConsultarRucExoneracionesDtoResult> ConsultarRucExoneraciones(ConsultarRucExoneracionesDtoParam parametro);
        Task<InsertarTranferenciaIatDtoResult> InsertarTranferenciaIat(InsertarTranferenciaIatDtoParam parametro);
        Task<ConsultarAnioAdeudaDtoResult> ConsultarAnioAdeuda(ConsultarAnioAdeudaDtoParam parametro);
        Task<AnioVencimientoDtoResult> ConsultarFechaVencimiento(ConsultaAnioVencimientoDtoParam parametro);

        Task<ConsultaValorPDtoResult> ConsultaValorP(ConsultaValorPDtoParam parametro);
    }
}
