using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Consumers.Interface;
using gad.aaportal.consumers.Utilitarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Consumers.Implementation
{
    public class SeguridadConsumers : ISeguridadConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public SeguridadConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<RsaDtoResult> GetPublicKey()
        {
            RsaDtoResult result = new();
            try
            {
                result = await _httpClient.Get<RsaDtoResult>(configuraciones.EndPointsConfig.GetPublicKey);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<UsuarioDtoResult> Login(UsuarioDtoParam parametro)
        {
            UsuarioDtoResult result = new();
            try
            {
                result = await _httpClient.Post<UsuarioDtoParam, UsuarioDtoResult>(parametro, configuraciones.EndPointsConfig.GetLogin);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<BaseResult> UserRegistration(UserRegistrationDtoParam parametro)
        {
            BaseResult result = new();
            try
            {
                result = await _httpClient.Post<UserRegistrationDtoParam, BaseResult>(parametro, configuraciones.EndPointsConfig.GetUserRegistration);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<BaseResult> ForgotPassword(ForgotPasswordDtoParam parametro)
        {
            BaseResult result = new();
            try
            {
                result = await _httpClient.Post<ForgotPasswordDtoParam, BaseResult>(parametro, configuraciones.EndPointsConfig.GetForgotPassword);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
