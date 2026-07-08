using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Utilitarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Implementation
{
    public class SpMunicipioConsumers : ISpMunicipioConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public SpMunicipioConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }

        public  async Task<CalcularImpuestoPatenteDtoResult> CalcularImpuestoPatente(CalcularImpuestoPatenteDtoParam parametro)
        {
            CalcularImpuestoPatenteDtoResult result = new();
            try
            {
                result = await _httpClient.Post<CalcularImpuestoPatenteDtoParam, CalcularImpuestoPatenteDtoResult>(parametro, configuraciones.EndPointsConfig.CalcularImpuestoPatente);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<CalcularImpuestoIatDtoResult> CalcularImpuestoIat(CalcularImpuestoIatDtoParam parametro)
        {
            CalcularImpuestoIatDtoResult result = new();
            try
            {
                result = await _httpClient.Post<CalcularImpuestoIatDtoParam, CalcularImpuestoIatDtoResult>(parametro, configuraciones.EndPointsConfig.CalcularImpuestoIat);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<CalcularMultaDtoResult> CalcularMulta(CalcularMultaDtoParam parametro)
        {
            CalcularMultaDtoResult result = new();
            try
            {
                result = await _httpClient.Post<CalcularMultaDtoParam, CalcularMultaDtoResult>(parametro, configuraciones.EndPointsConfig.CalcularMulta);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<CalcularTerceraEdadDtoResult> CalcularTerceraEdad(CalcularTerceraEdadDtoParam parametro)
        {
            CalcularTerceraEdadDtoResult result = new();
            try
            {
                result = await _httpClient.Post<CalcularTerceraEdadDtoParam, CalcularTerceraEdadDtoResult>(parametro, configuraciones.EndPointsConfig.CalcularTerceraEdad);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<InsertActividadAnualDtoResult> InsertActividadAnual(InsertActividadAnualDtoParam parametro)
        {
            InsertActividadAnualDtoResult result = new();
            try
            {
                result = await _httpClient.Post<InsertActividadAnualDtoParam, InsertActividadAnualDtoResult>(parametro, configuraciones.EndPointsConfig.InsertActividadAnual);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<InsertTerceraEdadDtoResult> InsertTerceraEdad(InsertTerceraEdadDtoParam parametro)
        {
            InsertTerceraEdadDtoResult result = new();
            try
            {
                result = await _httpClient.Post<InsertTerceraEdadDtoParam, InsertTerceraEdadDtoResult>(parametro, configuraciones.EndPointsConfig.InsertTerceraEdad);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<InsertPagoPorTituloDtoResult> InsertPagoPorTitulo(InsertPagoPorTituloDtoParam parametro)
        {
            InsertPagoPorTituloDtoResult result = new();
            try
            {
                result = await _httpClient.Post<InsertPagoPorTituloDtoParam, InsertPagoPorTituloDtoResult>(parametro, configuraciones.EndPointsConfig.InsertPagoPorTitulo);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ActualizarCodigoIngresoDtoResult> ActualizarCodigoIngreso(ActualizarCodigoIngresoDtoParam parametro)
        {
            ActualizarCodigoIngresoDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ActualizarCodigoIngresoDtoParam, ActualizarCodigoIngresoDtoResult>(parametro, configuraciones.EndPointsConfig.ActualizarCodigoIngreso);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ConsultarValoresPagarDtoResult> ConsultarValoresPagar(ConsultarValoresPagarDtoParam parametro)
        {
            ConsultarValoresPagarDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultarValoresPagarDtoParam, ConsultarValoresPagarDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarValoresPagar);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ValidadorPermisosDtoResult> ValidadorPermisos(ValidadorPermisosDtoParam parametro)
        {
            ValidadorPermisosDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ValidadorPermisosDtoParam, ValidadorPermisosDtoResult>(parametro, configuraciones.EndPointsConfig.ValidadorPermisos);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ConsultarValorBomberosDtoResult> ConsultarValorBomberos(ConsultarValorBomberosDtoParam parametro)
        {
            ConsultarValorBomberosDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultarValorBomberosDtoParam, ConsultarValorBomberosDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarValorBomberos);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ConsultarRucExoneracionesDtoResult> ConsultarRucExoneraciones(ConsultarRucExoneracionesDtoParam parametro)
        {
            ConsultarRucExoneracionesDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultarRucExoneracionesDtoParam, ConsultarRucExoneracionesDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarRucExoneraciones);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<InsertarTranferenciaIatDtoResult> InsertarTranferenciaIat(InsertarTranferenciaIatDtoParam parametro)
        {
            InsertarTranferenciaIatDtoResult result = new();
            try
            {
                result = await _httpClient.Post<InsertarTranferenciaIatDtoParam, InsertarTranferenciaIatDtoResult>(parametro, configuraciones.EndPointsConfig.InsertarTranferenciaIat);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ConsultarAnioAdeudaDtoResult> ConsultarAnioAdeuda(ConsultarAnioAdeudaDtoParam parametro)
        {
            ConsultarAnioAdeudaDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultarAnioAdeudaDtoParam, ConsultarAnioAdeudaDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarAnioAdeuda);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<AnioVencimientoDtoResult> ConsultarFechaVencimiento(ConsultaAnioVencimientoDtoParam parametro)
        {
            AnioVencimientoDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultaAnioVencimientoDtoParam, AnioVencimientoDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarFechaVencimiento);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<ConsultaValorPDtoResult> ConsultaValorP(ConsultaValorPDtoParam parametro)
        {
            ConsultaValorPDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ConsultaValorPDtoParam, ConsultaValorPDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultaValorP);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<ConsultarEstadoRucDtoResult> ConsultarEstadoRuc(
    ConsultarEstadoRucDtoParam parametro)
        {
            return await _httpClient.Post<ConsultarEstadoRucDtoParam, ConsultarEstadoRucDtoResult>(parametro, configuraciones.EndPointsConfig.ConsultarEstadoRuc);
        }
    }
}
