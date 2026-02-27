using Azure;
using Azure.Core;
using gad.aainteroperador.soap.Client;
using gad.aainteroperador.soap.Configuration;
using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.commons.Dto.Log;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Dinardap;
using gad.aaportal.services.Config;
using gad.aaportal.services.Services.Interfaces;
using gad.aaportal.services.Util;
using gad.interoperador;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace gad.aaportal.services.Services.Implementation
{
    public class DinardapService : IDinardapService
    {
        private readonly ILogger<DinardapService> logger;
        private readonly ISolicitudRespuestaServices solicitudRespuestaServices;
        private readonly ApiServerConfig apiServerConfig;
        private readonly EndPointsConfig endPointsConfig;

        public DinardapService(ILogger<DinardapService> logger, ISolicitudRespuestaServices solicitudRespuestaServices, IOptions<ApiServerConfig> apiServerConfig, EndPointsConfig endPointsConfig)
        {
            this.logger = logger;
            this.apiServerConfig = apiServerConfig.Value;
            this.endPointsConfig = endPointsConfig;
            this.solicitudRespuestaServices = solicitudRespuestaServices;
        }
        public async Task<bool> SaveForm101(AaportalContext contexto, ListForm101 form101)
        {
            bool result = false;
            try
            {
                var entity = form101.Form101s.Adapt<List<Form101>>();
                entity.ForEach(e => e.FechaInsert = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.Form101
                        .FirstOrDefaultAsync(f =>
                            f.NumeroIdentificacion == item.NumeroIdentificacion &&
                            f.AnioFiscal == item.AnioFiscal);

                    if (query == null)
                    {
                        await contexto.Form101.AddAsync(item);
                    }
                    else
                    {
                        await contexto.Form101Bkps
                            .AddAsync(query.Adapt<Form101bkp>());
                        item.Adapt(query);
                        query.FechaModificado = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }

            return result;
        }
        public async Task<bool> SaveForm102(AaportalContext contexto, ListForm102 form102)
        {
            bool result = false;
            try
            {
                var entity = form102.Form102s.Adapt<List<Form102>>();
                entity.ForEach(e => e.FechaInsercion = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.Form102
                        .FirstOrDefaultAsync(f =>
                            f.NumeroIdentificacion == item.NumeroIdentificacion &&
                            f.AnioFiscal == item.AnioFiscal);

                    if (query == null)
                    {
                        await contexto.Form102.AddAsync(item);
                    }
                    else
                    {
                        await contexto.Form102Bkps
                            .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7728(AaportalContext contexto, Lista7728 paquete7728)
        {
            bool result = false;
            try
            {
                var entity = paquete7728.paquete7728s.Adapt<List<ActividadEstablecimiento>>();
                entity.ForEach(e => e.FechaRegistro = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.ActividadesEstablecimiento
                        .FirstOrDefaultAsync(f =>
                            f.NumeroRuc == item.NumeroRuc &&
                            f.NumeroEstablecimiento == item.NumeroEstablecimiento &&
                            f.CodigoActividad == item.CodigoActividad);

                    if (query == null)
                    {
                        await contexto.ActividadesEstablecimiento.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7730(AaportalContext contexto, Lista7730 paquete7730)
        {
            bool result = false;
            try
            {
                var entity = paquete7730.paquete7730s.Adapt<List<SriRucContribuyente>>();
                entity.ForEach(e => e.FechaRegistro = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.SriRucContribuyentes
                        .FirstOrDefaultAsync(f =>
                            f.ClaseContribuyente == item.ClaseContribuyente &&
                            f.EstadoContribuyente == item.EstadoContribuyente);

                    if (query == null)
                    {
                        await contexto.SriRucContribuyentes.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7731(AaportalContext contexto, Lista7731 paquete7731)
        {
            bool result = false;
            try
            {
                var entity = paquete7731.paquete7731s.Adapt<List<SriRucEstablecimiento>>();
                entity.ForEach(e => e.FechaGrabado = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.SriRucEstablecimientos
                        .FirstOrDefaultAsync(f =>
                            f.NumeroRuc == item.NumeroRuc
                            && f.NumeroEstablecimiento == item.NumeroEstablecimiento);

                    if (query == null)
                    {
                        await contexto.SriRucEstablecimientos.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7732(AaportalContext contexto, Lista7732 paquete7732)
        {
            bool result = false;
            try
            {
                var entity = paquete7732.paquete7732s.Adapt<List<SriRucListaBlanca>>();
                entity.ForEach(e => e.FechaGrabado = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.SriRucListaBlanca
                        .FirstOrDefaultAsync(f =>
                            f.NumeroRuc == item.NumeroRuc);

                    if (query == null)
                    {
                        await contexto.SriRucListaBlanca.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete6279(AaportalContext contexto, Lista6279 paquete6279)
        {
            bool result = false;
            try
            {
                foreach (var item in paquete6279.paquete6279s)
                {
                    var entity = item.ContribuyenteDatos.Adapt<List<ContribuyenteDatos>>();
                    entity.ForEach(e => e.FechaGrabado = DateTime.Now);

                    foreach (var item2 in entity)
                    {
                        paquete6279.NumeroRuc = item2.NumeroRuc;
                        var casting = item2.Adapt<SriContribuyenteDatos>();
                        var query = await contexto.SriContribuyenteDatos
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriContribuyenteDatos.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }

                    var entity2 = item.ActividadEconomica.Adapt<List<ActividadEconomica>>();
                    entity2.ForEach(e =>
                    {
                        e.FechaGrabado = DateTime.Now;
                        e.NumeroRuc = paquete6279.NumeroRuc;
                    });

                    foreach (var item2 in entity2)
                    {
                        var casting = item2.Adapt<SriActividadEconomica>();
                        var query = await contexto.SriActividadEconomica
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriActividadEconomica.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }

                    var entity3 = item.TipoContribuyente.Adapt<List<TipoContribuyente>>();
                    entity3.ForEach(e =>
                    {
                        e.FechaGrabado = DateTime.Now;
                        e.NumeroRuc = paquete6279.NumeroRuc;
                    });

                    foreach (var item2 in entity3)
                    {
                        var casting = item2.Adapt<SriTipoContribuyente>();
                        var query = await contexto.SriTipoContribuyente
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriTipoContribuyente.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }

                    var entity4 = item.Contador.Adapt<List<Contador>>();
                    entity4.ForEach(e =>
                    {
                        e.FechaGrabado = DateTime.Now;
                        e.NumeroRuc = paquete6279.NumeroRuc;
                    });

                    foreach (var item2 in entity4)
                    {
                        var casting = item2.Adapt<SriContador>();
                        var query = await contexto.SriContador
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriContador.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }

                    var entity5 = item.Estructura.Adapt<List<EstructuraOrganizacional>>();
                    entity5.ForEach(e =>
                    {
                        e.FechaGrabado = DateTime.Now;
                        e.NumeroRuc = paquete6279.NumeroRuc;
                    });

                    foreach (var item2 in entity2)
                    {
                        var casting = item2.Adapt<SriEstructuraOrganizacional>();
                        var query = await contexto.SriEstructuraOrganizacional
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriEstructuraOrganizacional.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }

                    var entity6 = item.RepresentanteLegal.Adapt<List<RepresentanteLegal>>();
                    entity6.ForEach(e =>
                    {
                        e.FechaGrabado = DateTime.Now;
                        e.NumeroRuc = paquete6279.NumeroRuc;
                    });

                    foreach (var item2 in entity6)
                    {
                        var casting = item2.Adapt<SriRepresentanteLegal>();
                        var query = await contexto.SriRepresentanteLegal
                            .FirstOrDefaultAsync(f =>
                                f.NumeroRuc == item2.NumeroRuc);

                        if (query == null)
                        {
                            await contexto.SriRepresentanteLegal.AddAsync(casting);
                        }
                        else
                        {
                            //await contexto.ActividadesEstablecimiento
                            //    .AddAsync(query.Adapt<Form102bkp>());
                            item.Adapt(query);
                            //query.FechaActualizacion = DateTime.Now;
                        }
                    }
                }
                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7736(AaportalContext contexto, Lista7736 paquete7736)
        {
            bool result = false;
            try
            {
                var entity = paquete7736.paquete7736s.Adapt<List<SriEstadoTributario>>();
                entity.ForEach(e => e.FechaGrabado = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.SriEstadoTributario
                        .FirstOrDefaultAsync(f =>
                            f.NumeroRuc == item.NumeroRuc);

                    if (query == null)
                    {
                        await contexto.SriEstadoTributario.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }

                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<bool> SavePaquete7742(AaportalContext contexto, Lista7742 paquete7742)
        {
            bool result = false;
            try
            {
                var entity = paquete7742.paquete7742s.Adapt<List<SepsOrganizacion>>();
                entity.ForEach(e => e.FechaGrabado = DateTime.Now);

                foreach (var item in entity)
                {
                    var query = await contexto.SepsOrganizacion
                        .FirstOrDefaultAsync(f =>
                            f.Ruc == item.Ruc);

                    if (query == null)
                    {
                        await contexto.SepsOrganizacion.AddAsync(item);
                    }
                    else
                    {
                        //await contexto.ActividadesEstablecimiento
                        //    .AddAsync(query.Adapt<Form102bkp>());
                        item.Adapt(query);
                        //query.FechaActualizacion = DateTime.Now;
                    }
                }
                await contexto.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public LogParam GeneraLog(string codigoUsuario, DateTime fechaHoraEnvio, string numeroDocumento, string proveedor, long secuencial, string tramaEnvio, string tramaRespuesta, string metodo, string mensaje, string codigo, bool exito)
        {
            return new LogParam()
            {
                CodigoUsuario = codigoUsuario,
                FechaHoraEnvio = fechaHoraEnvio,
                FechaHoraRespuesta = DateTime.Now,
                NumeroDocumento = numeroDocumento,
                Proveedor = proveedor,
                Secuencial = secuencial,
                TramaEnvio = tramaEnvio,
                TramaRespuesta = string.IsNullOrEmpty(tramaRespuesta) ? mensaje : tramaRespuesta,
                Metodo = metodo,
                Mensaje = mensaje,
                Codigo = codigo,
                Exito = exito
            };
        }
        public async Task<ConsumoDinardapResult> SavePackage(AaportalContext contexto, PaqueteDinardapRequest request, consultarResponse response)
        {
            ConsumoDinardapResult result=new();
            try
            {
                switch (request.Paquete)
                {
                    case "6281":
                        var Form101 = Utilitarios.MapearAForm101Lista(response);
                        result.SaveForm101 = await SaveForm101(contexto, Form101);
                        break;
                    case "6282":
                        var Form102 = Utilitarios.MapearAForm102Lista(response);
                        result.SaveForm102 = await SaveForm102(contexto, Form102);
                        break;
                    case "7728":
                        var paquete7728 = Utilitarios.MapearA7728Lista(response);
                        result.Save7728 = await SavePaquete7728(contexto, paquete7728);
                        break;
                    case "7730":
                        var paquete7730 = Utilitarios.MapearA7730Lista(response);
                        result.Save7730 = await SavePaquete7730(contexto, paquete7730);
                        break;
                    case "7731":
                        var paquete7731 = Utilitarios.MapearA7731Lista(response);
                        result.Save7731 = await SavePaquete7731(contexto, paquete7731);
                        break;
                    case "7732":
                        var paquete7732 = Utilitarios.MapearA7732Lista(response);
                        result.Save7732 = await SavePaquete7732(contexto, paquete7732);
                        break;
                    case "6279":
                        var paquete6279 = Utilitarios.MapearA6279Lista(response);
                        result.Save6279 = await SavePaquete6279(contexto, paquete6279);
                        break;
                    case "7736":
                        var paquete7736 = Utilitarios.MapearA7736Lista(response);
                        paquete7736.paquete7736s.ForEach(p => p.NumeroRuc = request.Identificacion);
                        result.Save7736 = await SavePaquete7736(contexto, paquete7736);
                        break;
                    case "7742":
                        var paquete7742 = Utilitarios.MapearA7742Lista(response);
                        result.Save7742 = await SavePaquete7742(contexto, paquete7742);
                        break;
                    default:
                        string pausa = request.Paquete;
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
            }
            return result;
        }
        public async Task<ConsumoDinardapResult> ConsultPackage(AaportalContext contexto, PaqueteDinardapRequest request)
        {
            ConsumoDinardapResult result = new();
            DateTime fechaInicioConsulta= DateTime.Now;
            consultarResponse response = new();
            try
            {
                var options = new SoapClientOptions
                {
                    Endpoint = apiServerConfig.Dinardap + endPointsConfig.InteroperadorConsultPackge, //http
                    //Endpoint = "http://interoperabilidad.dinardap.gob.ec/interoperador-v2", //QA

                    Security = new SoapSecurityOptions
                    {
                        Type = SoapSecurityType.None
                        //Type = SoapSecurityType.Basic, //QA
                        //Username = "InAtRoGeMu", //QA
                        //Password = "NKG3jt5%zFWeWZ" //QA
                    }
                };

                var service = new InteroperadorSoapService(options);

                var parametros = new[]
                {
                    new parametro { nombre = "codigoPaquete", valor = request.Paquete },
                    new parametro { nombre = "identificacion", valor = request.Identificacion },
                    new parametro { nombre = "fuenteDatos", valor = "T" }
                };

                response = await service.ConsultarAsync(parametros);
                await SavePackage(contexto, request, response);
                await solicitudRespuestaServices.GenerarLogApis(contexto, GeneraLog(request.Usuario, fechaInicioConsulta, request.Identificacion, "Dinardap", 1, JsonSerializer.Serialize(request), JsonSerializer.Serialize(response), request.Paquete, "Proceso Ejecutado exitosamente", "OK", true));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.StackTrace, ex.Message);
                await solicitudRespuestaServices.GenerarLogApis(contexto, GeneraLog(request.Usuario, fechaInicioConsulta, request.Identificacion, "Dinardap", 1, JsonSerializer.Serialize(request), JsonSerializer.Serialize(response), request.Paquete, ex.Message, "ERROR", false));

            }
            return result;
        }
    }
}
