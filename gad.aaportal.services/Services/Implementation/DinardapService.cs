using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Dinardap;
using gad.aaportal.services.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class DinardapService : IDinardapService
    {
        private readonly ILogger<DinardapService> logger;

        public DinardapService(ILogger<DinardapService> logger)
        {
            this.logger = logger;
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
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
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
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
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
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
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
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
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
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }
    }
}
