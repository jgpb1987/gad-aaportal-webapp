using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Utilitarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Implementation
{
    public class ContribuyenteConsumers : IContribuyenteConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public ContribuyenteConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(ContribuyenteResumenDtoParam parametro)
        {
            ContribuyenteResumenDataDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ContribuyenteResumenDtoParam, ContribuyenteResumenDataDtoResult>(parametro, configuraciones.EndPointsConfig.GetResumenContribuyente);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<ConsultarDatosContribuyenteDataResult> ConsultarDatosContribuyente(
           ConsultarDatosContribuyenteDtoParam parametro)
        {
            ConsultarDatosContribuyenteDataResult result = new();

            try
            {
                result = await _httpClient.Post<ConsultarDatosContribuyenteDtoParam, ConsultarDatosContribuyenteDataResult>(
                    parametro,
                    configuraciones.EndPointsConfig.ConsultarDatosContribuyente);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<ActualizarDatosContribuyenteDataResult> ActualizarDatosContribuyente(
            ActualizarDatosContribuyenteDtoParam parametro)
        {
            ActualizarDatosContribuyenteDataResult result = new();

            try
            {
                result = await _httpClient.Post<ActualizarDatosContribuyenteDtoParam, ActualizarDatosContribuyenteDataResult>(
                    parametro,
                    configuraciones.EndPointsConfig.ActualizarDatosContribuyente);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<TipoMedioContactoDataResult> ConsultarTiposMedioContacto()
        {
            TipoMedioContactoDataResult result = new();

            try
            {
                result = await _httpClient.Post<object, TipoMedioContactoDataResult>(
                    new { },
                    configuraciones.EndPointsConfig.ConsultarTiposMedioContacto);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
        public async Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracion(ContribuyenteDtoParam parametro)
        {
            PeriodoDeclaracionDataResult result = new();

            try
            {
                result = await _httpClient.Post<ContribuyenteDtoParam, PeriodoDeclaracionDataResult>(
                    parametro,
                    configuraciones.EndPointsConfig.ConsultarPeriodosDeclaracion);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IniciarDeclaracionDataResult> IniciarDeclaracion(
            IniciarDeclaracionDtoParam parametro)
        {
            IniciarDeclaracionDataResult result = new();

            try
            {
                result = await _httpClient.Post<IniciarDeclaracionDtoParam, IniciarDeclaracionDataResult>(
                    parametro,
                    configuraciones.EndPointsConfig.IniciarDeclaracion);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
        public async Task<RegistrarDeclaracionDataResult> RegistrarDeclaracion(RegistrarDeclaracionDtoParam parametro)
        {
            RegistrarDeclaracionDataResult result = new();

            try
            {
                result = await _httpClient.Post<RegistrarDeclaracionDtoParam, RegistrarDeclaracionDataResult>(parametro, configuraciones.EndPointsConfig.RegistrarDeclaracion);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
        public async Task<ConsultarDeclaracionContribuyenteDataResult> ConsultarDeclaracionesContribuyente(
            ConsultarDeclaracionContribuyenteDtoParam parametro)
        {
            return await _httpClient.Post<ConsultarDeclaracionContribuyenteDtoParam, ConsultarDeclaracionContribuyenteDataResult>(parametro,
                configuraciones.EndPointsConfig.ConsultarDeclaracionesContribuyente);
        }
    }
}
