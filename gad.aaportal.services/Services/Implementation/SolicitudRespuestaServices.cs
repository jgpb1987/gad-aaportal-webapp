using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Log;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Log;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class SolicitudRespuestaServices : ISolicitudRespuestaServices
    {
        private readonly ILogger<SolicitudRespuestaServices> logger;

        public SolicitudRespuestaServices(ILogger<SolicitudRespuestaServices> logger)
        {
            this.logger = logger;
        }
        public async Task<LogResult> GenerarLogApis(AaportalContext contexto, LogParam parametro)
        {
            LogResult result = new();
            var transaction = await contexto.Database.BeginTransactionAsync();
            try
            {
                var newLog = new SolicitudRespuesta()
                {
                    Codigo = parametro.Codigo,
                    CodigoUsuario = parametro.CodigoUsuario,
                    Exito = parametro.Exito,
                    FechaHoraEnvio = parametro.FechaHoraEnvio,
                    FechaHoraRespuesta = parametro.FechaHoraRespuesta,
                    FechaRegistro = DateTime.Now,
                    Mensaje = parametro.Mensaje,
                    Metodo = parametro.Metodo,
                    NumeroDocumento = parametro.NumeroDocumento,
                    Proveedor = parametro.Proveedor,
                    Secuencial = parametro.Secuencial,
                    TramaEnvio = parametro.TramaEnvio,
                    TramaRespuesta = parametro.TramaRespuesta
                };
                contexto.SolicitudRespuestas.Add(newLog);
                contexto.SaveChanges();
                await transaction.CommitAsync();
                result = new LogResult() { IdInsercion = newLog.Id };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code.ToString());
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
    }
}
