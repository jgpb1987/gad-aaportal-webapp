using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.models.Entity.Declaracion;
using gad.aaportal.services.Config;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace gad.aaportal.services.Services.Implementation
{
    public class ContribuyenteServices : IContribuyenteServices
    {
        private readonly ILogger<ContribuyenteServices> logger;
        private readonly IDinardapService dinardapService;
        private readonly ServicesConfig servicesConfig;
        private readonly ISpMunicipioServices spMunicipioServices;
        public ContribuyenteServices(ILogger<ContribuyenteServices> logger, IDinardapService dinardapService, IOptions<ServicesConfig> servicesConfig, ISpMunicipioServices spMunicipioServices)
        {
            this.logger = logger;
            this.dinardapService = dinardapService;
            this.servicesConfig = servicesConfig.Value;
            this.spMunicipioServices = spMunicipioServices;
        }
        public async Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(AaportalContext contexto, ContribuyenteResumenDtoParam parametro)
        {
            ContribuyenteResumenDataDtoResult result = new();
            try
            {
                result.Data = await contexto.Contribuyentes.Where(c => c.Identificacion == parametro.Identificacion)
                    .Select(c => new ContribuyenteResumenDtoResult
                    {
                        Identificacion = c.Identificacion,
                        RazonSocial = c.RazonSocial,
                        TipoContribuyente = c.TipoContribuyente,
                        ActividadEconomica = c.ActividadEconomicaPrincipal,
                        InicioActividadEconomica = c.FechaInicioActividades.ToString("dd-MM-yyyy"),
                        ContribuyenteEspecial = c.ContribuyenteEspecial,
                        ObligadoLlevarContabilidad = c.ObligadoLlevarContabilidad
                    }).FirstOrDefaultAsync();
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }

        public async Task<ConsultarDatosContribuyenteDataResult> ConsultarDatosContribuyente(AaportalContext contexto, ConsultarDatosContribuyenteDtoParam parametro)
        {
            ConsultarDatosContribuyenteDataResult result = new();
            try
            {
                if (string.IsNullOrWhiteSpace(parametro.Identificacion))
                    throw SystemExceptionCustomized.CreateException("ADC001", "No se recibió la identificación del contribuyente");

                var contribuyente = await contexto.Contribuyentes
                    .AsNoTracking()
                    .Where(c => c.Identificacion == parametro.Identificacion)
                    .Select(c => new ActualizarDatosContribuyenteDtoParam
                    {
                        Identificacion = c.Identificacion,
                        CallePrincipal = c.CallePrincipal,
                        NumeroCasa = c.NumeroCasa,
                        CalleSecundaria = c.CalleSecundaria,
                        Parroquia = c.Parroquia,
                        Barrio = c.Barrio,
                        ReferenciaUbicacion = c.ReferenciaUbicacion,
                        Via = c.Via,
                        Kilometro = c.Kilometro,
                        Manzana = c.Manzana,
                        Edificio = c.Edificio,
                        Piso = c.Piso,
                        NumeroPredio = c.NumeroPredio
                    })
                    .FirstOrDefaultAsync();

                if (contribuyente == null)
                    throw SystemExceptionCustomized.CreateException("ADC002", "No se encontró información del contribuyente");

                contribuyente.MediosContacto = await contexto.ContribuyenteMedioContactos
                    .AsNoTracking()
                    .Where(m => m.Identificacion == parametro.Identificacion && m.Estado)
                    .Select(m => new ContribuyenteMedioContactoDtoResult
                    {
                        IdMedioContacto = m.IdMedioContacto,
                        CodigoTipoMedioContacto = m.CodigoTipoMedioContacto,
                        NombreTipoMedioContacto = m.CodigoTipoMedioContactoNavigation.Nombre,
                        Valor = m.Valor,
                        EsPrincipal = m.EsPrincipal,
                        Estado = m.Estado
                    })
                    .ToListAsync();

                contribuyente.Establecimientos = await contexto.ContribuyenteEstablecimientos
                    .AsNoTracking()
                    .Where(e => e.Identificacion == parametro.Identificacion)
                    .Select(e => new ContribuyenteEstablecimientoDtoParam
                    {
                        Calles = e.Calles,
                        DireccionCompleta = e.DireccionCompleta,
                        Estado = e.Estado,
                        Canton = e.Canton,
                        Matriz = e.Matriz,
                        NombreFantasiaComercial = e.NombreFantasiaComercial,
                        NumeroEstablecimiento = e.NumeroEstablecimiento,
                        Parroquia = e.Parroquia,
                        Provincia = e.Provincia,
                    })
                    .ToListAsync();

                result.Data = contribuyente;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }

        public async Task<TipoMedioContactoDataResult> ConsultarTiposMedioContacto(AaportalContext contexto)
        {
            TipoMedioContactoDataResult result = new();

            try
            {
                result.Data = await contexto.TipoMedioContactos
                    .AsNoTracking()
                    .Where(t => t.Estado)
                    .OrderBy(t => t.Nombre)
                    .Select(t => new TipoMedioContactoDtoResult
                    {
                        Codigo = t.Codigo,
                        Nombre = t.Nombre
                    })
                    .ToListAsync();
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }

        public async Task<ActualizarDatosContribuyenteDataResult> ActualizarDatosContribuyente(
            AaportalContext contexto,
            ActualizarDatosContribuyenteDtoParam parametro)
        {
            ActualizarDatosContribuyenteDataResult result = new();

            try
            {
                if (string.IsNullOrWhiteSpace(parametro.Identificacion))
                    throw SystemExceptionCustomized.CreateException("ADC003", "No se recibió la identificación del contribuyente");

                if (string.IsNullOrWhiteSpace(parametro.CallePrincipal))
                    throw SystemExceptionCustomized.CreateException("ADC004", "Debe ingresar la calle principal");

                if (string.IsNullOrWhiteSpace(parametro.NumeroCasa))
                    throw SystemExceptionCustomized.CreateException("ADC005", "Debe ingresar el número de casa");

                if (string.IsNullOrWhiteSpace(parametro.CalleSecundaria))
                    throw SystemExceptionCustomized.CreateException("ADC006", "Debe ingresar la calle secundaria");

                if (string.IsNullOrWhiteSpace(parametro.Parroquia))
                    throw SystemExceptionCustomized.CreateException("ADC007", "Debe seleccionar la parroquia");

                if (string.IsNullOrWhiteSpace(parametro.ReferenciaUbicacion))
                    throw SystemExceptionCustomized.CreateException("ADC008", "Debe ingresar la referencia de ubicación");

                if (parametro.MediosContacto == null || !parametro.MediosContacto.Any())
                    throw SystemExceptionCustomized.CreateException("ADC009", "Debe ingresar al menos un medio de contacto");

                if (!parametro.MediosContacto.Any(m => m.CodigoTipoMedioContacto == "EMAIL_PRINCIPAL" && !string.IsNullOrWhiteSpace(m.Valor)))
                    throw SystemExceptionCustomized.CreateException("ADC010", "Debe ingresar el email principal");

                if (!parametro.MediosContacto.Any(m => m.CodigoTipoMedioContacto == "CELULAR" && !string.IsNullOrWhiteSpace(m.Valor)))
                    throw SystemExceptionCustomized.CreateException("ADC011", "Debe ingresar el celular");

                var contribuyente = await contexto.Contribuyentes
                    .FirstOrDefaultAsync(c => c.Identificacion == parametro.Identificacion);

                if (contribuyente == null)
                    throw SystemExceptionCustomized.CreateException("ADC012", "No se encontró información del contribuyente");

                contribuyente.CallePrincipal = parametro.CallePrincipal.Trim();
                contribuyente.NumeroCasa = parametro.NumeroCasa.Trim();
                contribuyente.CalleSecundaria = parametro.CalleSecundaria.Trim();
                contribuyente.Parroquia = parametro.Parroquia.Trim();
                contribuyente.Barrio = parametro.Barrio?.Trim() ?? string.Empty;
                contribuyente.ReferenciaUbicacion = parametro.ReferenciaUbicacion.Trim();
                contribuyente.Via = parametro.Via?.Trim() ?? string.Empty;
                contribuyente.Kilometro = parametro.Kilometro?.Trim() ?? string.Empty;
                contribuyente.Manzana = parametro.Manzana?.Trim() ?? string.Empty;
                contribuyente.Edificio = parametro.Edificio?.Trim() ?? string.Empty;
                contribuyente.Piso = parametro.Piso?.Trim() ?? string.Empty;
                contribuyente.NumeroPredio = parametro.NumeroPredio?.Trim() ?? string.Empty;

                var contactosActuales = await contexto.ContribuyenteMedioContactos
                    .Where(m => m.Identificacion == parametro.Identificacion)
                    .ToListAsync();

                foreach (var contactoActual in contactosActuales)
                    contactoActual.Estado = false;

                foreach (var contacto in parametro.MediosContacto.Where(m => !string.IsNullOrWhiteSpace(m.Valor)))
                {
                    var tipoExiste = await contexto.TipoMedioContactos
                        .AnyAsync(t => t.Codigo == contacto.CodigoTipoMedioContacto && t.Estado);

                    if (!tipoExiste)
                        throw SystemExceptionCustomized.CreateException("ADC013", $"El tipo de medio de contacto {contacto.CodigoTipoMedioContacto} no es válido");

                    contexto.ContribuyenteMedioContactos.Add(new ContribuyenteMedioContacto
                    {
                        Identificacion = parametro.Identificacion,
                        CodigoTipoMedioContacto = contacto.CodigoTipoMedioContacto,
                        Valor = contacto.Valor.Trim(),
                        EsPrincipal = contacto.EsPrincipal,
                        Estado = true,
                        FechaRegistro = DateTime.Now
                    });
                }

                await contexto.SaveChangesAsync();

                result.Data = new ActualizarDatosContribuyenteDtoResult
                {
                    ActualizacionCorrecta = true
                };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }
        public async Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracion(AaportalContext contexto, ContribuyenteDtoParam parametro)
        {
            PeriodoDeclaracionDataResult result = new();
            List<PeriodoDeclaracionDtoResult> periodosDeclaracion = new();
            try
            {
                var contribuyente = await contexto.Contribuyentes.AsNoTracking().FirstOrDefaultAsync(c => c.Identificacion == parametro.Identificacion);

                if (contribuyente == null)
                    throw SystemExceptionCustomized.CreateException("CPD001", "No se encontró información del contribuyente");

                var municipioBase = servicesConfig.MunicipioBase.Trim();

                var establecimientos = await contexto.ContribuyenteEstablecimientos.AsNoTracking().Where(e => e.Identificacion == parametro.Identificacion && e.Estado == "ABIERTO")
                    .GroupBy(e => new
                    {
                        Provincia = e.Provincia.Trim(),
                        Canton = e.Canton.Trim()
                    })
                    .Select(g => new ContribuyenteEstablecimientoPago
                    {
                        Provincia = g.Key.Provincia,
                        Canton = g.Key.Canton,
                        AplicaPago = g.Key.Canton == municipioBase,
                        BaseImponible = 0,
                        Porcentaje = g.Key.Canton.Equals(municipioBase) ? 100 : 0,
                        Valor = 0,
                        EsMunicipioBase = g.Key.Canton == municipioBase
                    })
                    .OrderByDescending(p => p.EsMunicipioBase).ThenBy(p => p.Provincia).ThenBy(p => p.Canton).ToListAsync();

                if (establecimientos == null || !establecimientos.Any())
                    throw SystemExceptionCustomized.CreateException("CPD002", "No se encontró información de establecimientos activos para el contribuyente");

                var aniosDeclarados = await contexto.ContribuyenteDeclaracions
                    .AsNoTracking().Where(d => d.Identificacion == parametro.Identificacion && d.Estado)
                    .Select(d => d.Anio).ToListAsync();

                if (contribuyente.TipoContribuyente.Equals("PERSONA NATURAL"))
                {
                    var listForm102 = await dinardapService.ConsultPackage<ListForm102>(new PaqueteDinardapRequest() { Identificacion = parametro.Identificacion, Paquete = "6282", Usuario = servicesConfig.DinardapUser });

                    listForm102.Form102s = listForm102.Form102s.Where(f => f.AnioFiscal >= DateTime.Now.Year - servicesConfig.AniosDeclaracionMostrar && !aniosDeclarados.Contains(f.AnioFiscal)).ToList();

                    foreach (var form102 in listForm102.Form102s)
                    {
                        periodosDeclaracion.Add(new PeriodoDeclaracionDtoResult
                        {
                            AnioEjercicioFiscal = form102.AnioFiscal,
                            Descripcion = $"Ejercicio Fiscal {form102.AnioFiscal}",
                            ActivoCorriente = Math.Round(form102.TotActCorriente410 ?? 0, 2, MidpointRounding.AwayFromZero),
                            ActivoNoCorriente = Math.Round(form102.TotActivoNoCorriente812 ?? 0, 2, MidpointRounding.AwayFromZero),
                            CostosGastos = Math.Round(form102.TotalCostosGastos2760 ?? 0, 2, MidpointRounding.AwayFromZero),
                            Ingresos = Math.Round(form102.TotalIngresos1440 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoContingente = Math.Round(form102.TotalPasivo1310 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoCorriente = Math.Round(form102.TotPasivoCorriente1030 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoNoCorriente = Math.Round(form102.TotalPasivo1310 ?? 0, 2, MidpointRounding.AwayFromZero) - Math.Round(form102.TotPasivoCorriente1030 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                }
                else
                {
                    var listForm101 = await dinardapService.ConsultPackage<ListForm101>(new PaqueteDinardapRequest() { Identificacion = parametro.Identificacion, Paquete = "6281", Usuario = servicesConfig.DinardapUser });
                    listForm101.Form101s = listForm101.Form101s
                       .Where(f => f.AnioFiscal >= DateTime.Now.Year - servicesConfig.AniosDeclaracionMostrar
                           && !aniosDeclarados.Contains(f.AnioFiscal)).ToList();

                    foreach (var form101 in listForm101.Form101s)
                    {
                        periodosDeclaracion.Add(new PeriodoDeclaracionDtoResult
                        {
                            AnioEjercicioFiscal = form101.AnioFiscal,
                            Descripcion = $"Ejercicio Fiscal {form101.AnioFiscal}",
                            ActivoCorriente = Math.Round(form101.TotalActivoCorriente470 ?? 0, 2, MidpointRounding.AwayFromZero),
                            ActivoNoCorriente = Math.Round(form101.TotActivoNoCorriente1077 ?? 0, 2, MidpointRounding.AwayFromZero),
                            CostosGastos = Math.Round(form101.TotasCostosGastos3380 ?? 0, 2, MidpointRounding.AwayFromZero),
                            Ingresos = Math.Round(form101.TotalIngresos1930 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoContingente = Math.Round(form101.ProNoctePasCtgComNeg1577 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoCorriente = Math.Round(form101.TotPasivosCorrientes1340 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoNoCorriente = Math.Round(form101.TotalPasivosLargoPlazo1590 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                }

                result.Data = new() { Establecimientos = establecimientos, PeriodosDeclaracion = periodosDeclaracion.OrderBy(pd => pd.AnioEjercicioFiscal).ToList() };

            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }
        public async Task<PeriodoDeclaracionDataResult> ConsultarPeriodosDeclaracionMunicipio(AaportalContext contexto, ContribuyenteDtoParam parametro)
        {
            PeriodoDeclaracionDataResult result = new();
            List<PeriodoDeclaracionDtoResult> periodosDeclaracion = new();
            try
            {
                var contribuyente = await contexto.Contribuyentes.AsNoTracking().FirstOrDefaultAsync(c => c.Identificacion == parametro.Identificacion);

                if (contribuyente == null)
                    throw SystemExceptionCustomized.CreateException("CPD001", "No se encontró información del contribuyente");

                var municipioBase = servicesConfig.MunicipioBase.Trim();

                var establecimientos = await contexto.ContribuyenteEstablecimientos.AsNoTracking().Where(e => e.Identificacion == parametro.Identificacion && e.Estado == "ABIERTO")
                    .GroupBy(e => new
                    {
                        Provincia = e.Provincia.Trim(),
                        Canton = e.Canton.Trim()
                    })
                    .Select(g => new ContribuyenteEstablecimientoPago
                    {
                        Provincia = g.Key.Provincia,
                        Canton = g.Key.Canton,
                        AplicaPago = g.Key.Canton == municipioBase,
                        BaseImponible = 0,
                        Porcentaje = g.Key.Canton.Equals(municipioBase) ? 100 : 0,
                        Valor = 0,
                        EsMunicipioBase = g.Key.Canton == municipioBase
                    })
                    .OrderByDescending(p => p.EsMunicipioBase).ThenBy(p => p.Provincia).ThenBy(p => p.Canton).ToListAsync();

                if (establecimientos == null || !establecimientos.Any())
                    throw SystemExceptionCustomized.CreateException("CPD002", "No se encontró información de establecimientos activos para el contribuyente");

                var anioDeclarar = await spMunicipioServices.ConsultarAnioAdeuda(new ConsultarAnioAdeudaDtoParam() { Ruc = parametro.Identificacion });
                if (anioDeclarar == null || anioDeclarar.Data == null)
                    throw SystemExceptionCustomized.CreateException("CPD003", "No se pudo consultar el año a declarar en el municipio");


                if (contribuyente.TipoContribuyente.Equals("PERSONA NATURAL"))
                {
                    var listForm102 = await dinardapService.ConsultPackage<ListForm102>(new PaqueteDinardapRequest() { Identificacion = parametro.Identificacion, Paquete = "6282", Usuario = servicesConfig.DinardapUser });

                    listForm102.Form102s = listForm102.Form102s.Where(f => f.AnioFiscal.Equals(anioDeclarar.Data.Anio)).ToList();

                    foreach (var form102 in listForm102.Form102s)
                    {
                        periodosDeclaracion.Add(new PeriodoDeclaracionDtoResult
                        {
                            AnioEjercicioFiscal = form102.AnioFiscal,
                            Descripcion = $"Ejercicio Fiscal {form102.AnioFiscal}",
                            ActivoCorriente = Math.Round(form102.TotActCorriente410 ?? 0, 2, MidpointRounding.AwayFromZero),
                            ActivoNoCorriente = Math.Round(form102.TotActivoNoCorriente812 ?? 0, 2, MidpointRounding.AwayFromZero),
                            CostosGastos = Math.Round(form102.TotalCostosGastos2760 ?? 0, 2, MidpointRounding.AwayFromZero),
                            Ingresos = Math.Round(form102.TotalIngresos1440 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoContingente = Math.Round(form102.TotalPasivo1310 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoCorriente = Math.Round(form102.TotPasivoCorriente1030 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoNoCorriente = Math.Round(form102.TotalPasivo1310 ?? 0, 2, MidpointRounding.AwayFromZero) - Math.Round(form102.TotPasivoCorriente1030 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                }
                else
                {
                    var listForm101 = await dinardapService.ConsultPackage<ListForm101>(new PaqueteDinardapRequest() { Identificacion = parametro.Identificacion, Paquete = "6281", Usuario = servicesConfig.DinardapUser });
                    listForm101.Form101s = listForm101.Form101s
                       .Where(f => f.AnioFiscal.Equals(anioDeclarar.Data.Anio)).ToList();

                    foreach (var form101 in listForm101.Form101s)
                    {
                        periodosDeclaracion.Add(new PeriodoDeclaracionDtoResult
                        {
                            AnioEjercicioFiscal = form101.AnioFiscal,
                            Descripcion = $"Ejercicio Fiscal {form101.AnioFiscal}",
                            ActivoCorriente = Math.Round(form101.TotalActivoCorriente470 ?? 0, 2, MidpointRounding.AwayFromZero),
                            ActivoNoCorriente = Math.Round(form101.TotActivoNoCorriente1077 ?? 0, 2, MidpointRounding.AwayFromZero),
                            CostosGastos = Math.Round(form101.TotasCostosGastos3380 ?? 0, 2, MidpointRounding.AwayFromZero),
                            Ingresos = Math.Round(form101.TotalIngresos1930 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoContingente = Math.Round(form101.ProNoctePasCtgComNeg1577 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoCorriente = Math.Round(form101.TotPasivosCorrientes1340 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoNoCorriente = Math.Round(form101.TotalPasivosLargoPlazo1590 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                }

                result.Data = new() { Establecimientos = establecimientos, PeriodosDeclaracion = periodosDeclaracion.OrderBy(pd => pd.AnioEjercicioFiscal).ToList() };

            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }
        public async Task<IniciarDeclaracionDataResult> IniciarDeclaracion(
            AaportalContext contexto,
            IniciarDeclaracionDtoParam parametro)
        {
            IniciarDeclaracionDataResult result = new();

            try
            {
                if (string.IsNullOrWhiteSpace(parametro.Identificacion))
                    throw SystemExceptionCustomized.CreateException("DEC001", "No se recibió la identificación del contribuyente");

                if (parametro.AnioDeclaracion <= 0)
                    throw SystemExceptionCustomized.CreateException("DEC002", "Debe seleccionar el año de declaración");

                if (parametro.EjercicioFiscal <= 0)
                    throw SystemExceptionCustomized.CreateException("DEC003", "El ejercicio fiscal seleccionado no es válido");

                var contribuyente = await contexto.Contribuyentes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Identificacion == parametro.Identificacion);

                if (contribuyente == null)
                    throw SystemExceptionCustomized.CreateException("DEC004", "No se encontró información del contribuyente");

                result.Data = new IniciarDeclaracionDtoResult
                {
                    Identificacion = parametro.Identificacion,
                    AnioDeclaracion = parametro.AnioDeclaracion,
                    EjercicioFiscal = parametro.EjercicioFiscal,
                    DescripcionPeriodo = $"{parametro.AnioDeclaracion} >> Ejercicio Fiscal {parametro.EjercicioFiscal}"
                };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }

            return result;
        }
        private async Task<string> GenerarCodigoUnicoPago(AaportalContext contexto, DateTime fechaActual)
        {
            for (var intento = 1; intento <= 5; intento++)
            {
                var random = Random.Shared.Next(100000, 999999);
                var codigo = $"{fechaActual:yyyyMMddHHmmss}{random}";

                var existe = await contexto.ContribuyenteDeclaracions
                    .AsNoTracking().AnyAsync(d => d.CodigoUnicoPago == codigo);

                if (!existe)
                    return codigo;
            }

            throw SystemExceptionCustomized.CreateException(
                "DEC006",
                "No fue posible generar el código único de pago");
        }
        public async Task<RegistrarDeclaracionDataResult> RegistrarDeclaracion(AaportalContext contexto, RegistrarDeclaracionDtoParam parametro)
        {
            try
            {
                if (parametro == null)
                    throw SystemExceptionCustomized.CreateException("DEC001", "Los datos de la declaración son requeridos");

                if (string.IsNullOrWhiteSpace(parametro.Identificacion))
                    throw SystemExceptionCustomized.CreateException("DEC002", "La identificación del contribuyente es requerida");

                if (parametro.Anio <= 0)
                    throw SystemExceptionCustomized.CreateException("DEC003", "El año de declaración no es válido");

                var existeContribuyente = await contexto.Contribuyentes
                    .AsNoTracking()
                    .AnyAsync(c => c.Identificacion == parametro.Identificacion);

                if (!existeContribuyente)
                    throw SystemExceptionCustomized.CreateException("DEC004", "No existe el contribuyente registrado");

                var existeDeclaracion = await contexto.ContribuyenteDeclaracions
                    .AsNoTracking()
                    .AnyAsync(d =>
                        d.Identificacion == parametro.Identificacion &&
                        d.Anio == parametro.Anio &&
                        d.Estado);

                if (existeDeclaracion)
                    throw SystemExceptionCustomized.CreateException(
                        "DEC005",
                        $"Ya existe una declaración registrada para el año {parametro.Anio}");

                var fechaActual = DateTime.Now;
                var codigoUnicoPago = await GenerarCodigoUnicoPago(contexto, fechaActual);

                var entity = new ContribuyenteDeclaracion
                {
                    Identificacion = parametro.Identificacion,
                    FechaRegistro = fechaActual,
                    Fecha = fechaActual.Date,
                    Anio = parametro.Anio,
                    CodigoUnicoPago = codigoUnicoPago,

                    ActivoCorriente = parametro.ActivoCorriente,
                    ActivoNoCorriente = parametro.ActivoNoCorriente,
                    PasivoCorriente = parametro.PasivoCorriente,
                    PasivoNoCorriente = parametro.PasivoNoCorriente,
                    PasivoContingente = parametro.PasivoContingente,
                    Ingresos = parametro.Ingresos,
                    CostosGastos = parametro.CostosGastos,

                    _15XMil = parametro.UnoCincoXMil,
                    Patente = parametro.Patente,
                    ValorBomberos = parametro.ValorBomberos,
                    MultaPatente = parametro.MultaPatente,
                    MultaIat = parametro.MultaIat,
                    DescuentoTerceraEdadPatente = parametro.PorcentajeDescuentoTerceraEdadPatente,
                    DescuentoTerceraEdadIat = parametro.PorcentajeDescuentoTerceraEdadIAT,
                    InteresPatente = parametro.InteresPatente,
                    RecargoPatente = parametro.RecargoPatente,
                    CostasPatente = parametro.CostasPatente,
                    TasaAdministrativaPatente = parametro.TasaAdministrativaPatente,
                    InteresIat = parametro.InteresIat,
                    RecargoIat = parametro.RecargoIat,
                    CostasIat = parametro.CostasIat,
                    TasaAdministrativaIat = parametro.TasaAdministrativaIat,                    
                    Estado = true
                };

                await contexto.ContribuyenteDeclaracions.AddAsync(entity);


                InsertActividadAnualDtoParam insert = new InsertActividadAnualDtoParam
                {
                    Ruc = parametro.Identificacion,
                    IngresoTotales = (double)parametro.Ingresos,
                    TotalActivos = (double)parametro.ActivoCorriente + (double)parametro.ActivoNoCorriente,
                    TotalPasivos = (double)parametro.PasivoCorriente + (double)parametro.PasivoNoCorriente + (double)parametro.PasivoContingente,
                    Patrimonio = (double)parametro.ActivoCorriente + (double)parametro.ActivoNoCorriente - (double)parametro.PasivoCorriente + (double)parametro.PasivoNoCorriente + (double)parametro.PasivoContingente,
                    FechaInicio = DateTime.Now,
                    FechaVencimiento = parametro.FechaVencimiento,
                    AnioPatente = parametro.Anio,
                    BaseImponiblePatente = (double)parametro.ActivoCorriente + (double)parametro.ActivoNoCorriente - (double)parametro.PasivoCorriente + (double)parametro.PasivoNoCorriente + (double)parametro.PasivoContingente,
                    TarifaPatente = (double)parametro.Patente,
                    MultaPatente = (double)parametro.MultaPatente,
                    PorcentajeDescuentoTercera = (double)parametro.PorcentajeDescuentoTerceraEdadPatente,
                    UsuarioIngreso = "PATWEB",//CONFIGURAR PARA TOMAR DE CONFIG
                    Utilidad = (double)parametro.Ingresos - (double)parametro.CostosGastos,
                    ContingenciaPasivos = (double)parametro.PasivoContingente,
                    BaseImponibleIat = (double)parametro.BaseImponibleIAT,
                    ImpuestoIat = (double)parametro.UnoCincoXMil,
                    MultaIat = (double)parametro.MultaIat,
                    PorcentajeCalculoIat = (double)parametro.PorcentajeCalculoIat,
                    PorcentajeTeiat = (double)parametro.PorcentajeDescuentoTerceraEdadIAT
                };

                var resultActividadAnual = await spMunicipioServices.InsertActividadAnual(insert);
                var actividadGenerada = resultActividadAnual.Data.IdActividadGenerada;//TRATAR CODIGO DE ACTIVIDAD GENERADO Y VER QUE SE HACE CON EL

                if (parametro.PorcentajeDescuentoTerceraEdadPatente > 0)
                {
                    InsertTerceraEdadDtoParam insertTP = new InsertTerceraEdadDtoParam
                    {
                        AnioCalculo = parametro.Anio,
                        Patrimonio = (double)parametro.BaseImponiblePatente,
                        Ingresos = (double)parametro.Ingresos,
                        PorcentajeTE = (double)parametro.PorcentajeDescuentoTerceraEdadPatente,
                        ExedenteAplicado = parametro.ExedentePatente,
                        PorcentajePatrimonio = (double)parametro.PorcentajeDescuentoTerceraEdadIAT,
                        PorcentajeIngreso = (double)parametro.PorcentajeIngreso,
                        BaseImponible = (double)parametro.BaseImponiblePatente,
                        ImpuestoGravado = (double)parametro.Patente,
                        PorcentajeAplicar = (double)parametro.PorcentajeDescuentoTerceraEdadPatente,
                        ValorDescuento = (double)parametro.ValorExoneradoPatente,
                        TipoImpuesto = "PMA",
                        UsuarioIngreso = "PATWEB",
                        IdCalculoImpuesto = actividadGenerada
                    };

                    await spMunicipioServices.InsertTerceraEdad(insertTP);
                }

                if (parametro.PorcentajeDescuentoTerceraEdadIAT > 0)
                {
                    InsertTerceraEdadDtoParam insertTP = new InsertTerceraEdadDtoParam
                    {
                        AnioCalculo = parametro.Anio,
                        Patrimonio = (double)parametro.BaseImponiblePatente,
                        Ingresos = (double)parametro.Ingresos,
                        PorcentajeTE = (double)parametro.PorcentajeDescuentoTerceraEdadPatente,
                        ExedenteAplicado = parametro.ExedenteIAT,
                        PorcentajePatrimonio = (double)parametro.PorcentajeDescuentoTerceraEdadIAT,
                        PorcentajeIngreso = (double)parametro.PorcentajeIngreso,
                        BaseImponible = (double)parametro.BaseImponibleIAT,
                        ImpuestoGravado = (double)parametro.UnoCincoXMil,
                        PorcentajeAplicar = (double)parametro.PorcentajeDescuentoTerceraEdadIAT,
                        ValorDescuento = (double)parametro.ValorExoneradoIAT,
                        TipoImpuesto = "IAT",
                        UsuarioIngreso = "PATWEB",
                        IdCalculoImpuesto = actividadGenerada
                    };

                    await spMunicipioServices.InsertTerceraEdad(insertTP);
                }

                InsertPagoPorTituloDtoParam insertPPT = new InsertPagoPorTituloDtoParam
                {
                    Ruc = parametro.Identificacion,
                    CodTituloDatos = "PMA",
                    FechaIngreso = DateTime.Now,
                    FechaVencimiento = parametro.FechaVencimiento,
                    FechaVencInteres = parametro.FechaVencimiento,
                    UserIngreso = "PATWEB",
                    BaseImponible = (double)parametro.BaseImponiblePatente,
                    Valor = (double)parametro.Patente,
                    AnioDeclaracion = parametro.Anio,
                    ValorPagadoOtroCanton = 0,//DEFINIR SI SON VARIOS CANTONES APARTE
                    Multa = 0
                };
                var tituloPatente = await spMunicipioServices.InsertPagoPorTitulo(insertPPT);

                ActualizarCodigoIngresoDtoParam codIngreso = new ActualizarCodigoIngresoDtoParam
                {
                    CodigoIngreso = tituloPatente.Data.CodigoIngreso,
                    IdDeclaracionAnual = actividadGenerada,
                    CodTitulo = "PMA"
                };
                await spMunicipioServices.ActualizarCodigoIngreso(codIngreso);

                insertPPT = new InsertPagoPorTituloDtoParam
                {
                    Ruc = parametro.Identificacion,
                    CodTituloDatos = "IAT",
                    FechaIngreso = DateTime.Now,
                    FechaVencimiento = parametro.FechaVencimiento,
                    FechaVencInteres = parametro.FechaVencimiento,
                    UserIngreso = "PATWEB",
                    BaseImponible = (double)parametro.BaseImponibleIAT,
                    Valor = (double)parametro.UnoCincoXMil,
                    AnioDeclaracion = parametro.Anio,
                    ValorPagadoOtroCanton = 0,//DEFINIR SI SON VARIOS CANTONES APARTE
                    Multa=0
                };
                var tituloIAT = await spMunicipioServices.InsertPagoPorTitulo(insertPPT);

                codIngreso = new ActualizarCodigoIngresoDtoParam
                {
                    CodigoIngreso = tituloIAT.Data.CodigoIngreso,
                    IdDeclaracionAnual = actividadGenerada,
                    CodTitulo = "IAT"
                };
                await spMunicipioServices.ActualizarCodigoIngreso(codIngreso);

                await contexto.SaveChangesAsync();

                return new RegistrarDeclaracionDataResult
                {
                    Data = new RegistrarDeclaracionDtoResult
                    {
                        Id = entity.Id,
                        Identificacion = entity.Identificacion,
                        FechaRegistro = entity.FechaRegistro,
                        Fecha = entity.Fecha,
                        Anio = entity.Anio,
                        CodigoUnicoPago = entity.CodigoUnicoPago,

                        ActivoCorriente = entity.ActivoCorriente,
                        ActivoNoCorriente = entity.ActivoNoCorriente,
                        PasivoCorriente = entity.PasivoCorriente,
                        PasivoNoCorriente = entity.PasivoNoCorriente,
                        PasivoContingente = entity.PasivoContingente,
                        Ingresos = entity.Ingresos,
                        CostosGastos = entity.CostosGastos,
                        ValorBomberos = entity.ValorBomberos,
                        UnoCincoXMil = entity._15XMil,
                        Patente = entity.Patente,
                        CostasIat = entity.CostasIat,
                        CostasPatente = entity.CostasPatente,
                        DescuentoTerceraEdadIat = entity.DescuentoTerceraEdadIat,
                        DescuentoTerceraEdadPatente = entity.DescuentoTerceraEdadPatente,
                        InteresIat = entity.InteresIat,
                        InteresPatente = entity.InteresPatente,
                        MultaIat = entity.MultaIat,
                        MultaPatente = entity.MultaPatente,
                        RecargoIat = entity.RecargoIat,
                        RecargoPatente = entity.RecargoPatente,
                        TasaAdministrativaIat = entity.TasaAdministrativaIat,
                        TasaAdministrativaPatente = entity.TasaAdministrativaPatente
                    },
                    Message = new MessageResult
                    {
                        Code = "DEC000",
                        Description = "Declaración registrada correctamente"
                    }
                };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
        }
        public async Task<ConsultarDeclaracionContribuyenteDataResult> ConsultarDeclaracionesContribuyente(
    AaportalContext contexto, ConsultarDeclaracionContribuyenteDtoParam parametro)
        {
            try
            {
                if (parametro is null)
                    throw SystemExceptionCustomized.CreateException("CDC001", "Los datos de consulta son requeridos");

                if (string.IsNullOrWhiteSpace(parametro.Identificacion))
                    throw SystemExceptionCustomized.CreateException("CDC002", "La identificación del contribuyente es requerida");

                var declaraciones = await contexto.ContribuyenteDeclaracions
                    .AsNoTracking().Where(d =>
                        d.Identificacion == parametro.Identificacion &&
                        d.Estado)
                    .OrderByDescending(d => d.FechaRegistro)
                    .Select(d => new ConsultarDeclaracionContribuyenteDtoResult
                    {
                        Id = d.Id,
                        Identificacion = d.Identificacion,
                        FechaRegistro = d.FechaRegistro,
                        Fecha = d.Fecha,
                        Anio = d.Anio,
                        CodigoUnicoPago = d.CodigoUnicoPago,

                        ActivoCorriente = d.ActivoCorriente,
                        ActivoNoCorriente = d.ActivoNoCorriente,
                        PasivoCorriente = d.PasivoCorriente,
                        PasivoNoCorriente = d.PasivoNoCorriente,
                        PasivoContingente = d.PasivoContingente,
                        Ingresos = d.Ingresos,
                        CostosGastos = d.CostosGastos,
                        ValorBomberos = d.ValorBomberos,
                        UnoCincoXMil = d._15XMil,
                        Patente = d.Patente,
                        CostasIat=d.CostasIat,
                        CostasPatente=d.CostasPatente,
                        DescuentoTerceraEdadIat=d.DescuentoTerceraEdadIat,
                        DescuentoTerceraEdadPatente=d.DescuentoTerceraEdadPatente,
                        InteresIat=d.InteresIat,
                        InteresPatente=d.InteresPatente,
                        MultaIat=d.MultaIat,
                        MultaPatente=d.MultaPatente,
                        RecargoIat=d.RecargoIat,
                        RecargoPatente=d.RecargoPatente,
                        TasaAdministrativaIat=d.TasaAdministrativaIat,
                        TasaAdministrativaPatente=d.TasaAdministrativaPatente,
                        Estado = d.Estado
                    })
                    .ToListAsync();

                return new ConsultarDeclaracionContribuyenteDataResult
                {
                    Data = new ConsultarDeclaracionContribuyenteListResult
                    {
                        Declaraciones = declaraciones
                    },
                    Message = new MessageResult
                    {
                        Code = "CDC000",
                        Description = "Declaraciones consultadas correctamente"
                    }
                };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
        }
        public async Task<SubirDeclaracionArchivoDtoResult> SubirArchivoDeclaracion(AaportalContext contexto, long idContribuyenteDeclaracion,  IFormFile archivo)
        {
            SubirDeclaracionArchivoDtoResult result = new();

            try
            {
                if (idContribuyenteDeclaracion <= 0)
                {
                    result.Message.Code = "DECLARACION_INVALIDA";
                    result.Message.Description = "La declaración enviada no es válida.";
                    return result;
                }

                if (archivo is null || archivo.Length == 0)
                {
                    result.Message.Code = "ARCHIVO_INVALIDO";
                    result.Message.Description = "Debe seleccionar un archivo válido.";
                    return result;
                }

                const long maxSizeBytes = 10 * 1024 * 1024;

                if (archivo.Length > maxSizeBytes)
                {
                    result.Message.Code = "ARCHIVO_SUPERA_TAMANO";
                    result.Message.Description = "El archivo no debe superar los 10 MB.";
                    return result;
                }

                var extensionesPermitidas = new[]
                {
            ".pdf", ".doc", ".docx", ".xls", ".xlsx"
        };

                var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();

                if (!extensionesPermitidas.Contains(extension))
                {
                    result.Message.Code = "EXTENSION_NO_PERMITIDA";
                    result.Message.Description = "Solo se permiten archivos PDF, Word o Excel.";
                    return result;
                }

                var declaracionExiste = await contexto.ContribuyenteDeclaracions
                    .AsNoTracking()
                    .AnyAsync(x => x.Id == idContribuyenteDeclaracion);

                if (!declaracionExiste)
                {
                    result.Message.Code = "DECLARACION_NO_EXISTE";
                    result.Message.Description = "No existe la declaración seleccionada.";
                    return result;
                }

                var yaTieneArchivo = await contexto.ContribuyenteDeclaracionArchivos
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.IdContribuyenteDeclaracion == idContribuyenteDeclaracion &&
                        x.Estado);

                if (yaTieneArchivo)
                {
                    result.Message.Code = "ARCHIVO_YA_REGISTRADO";
                    result.Message.Description = "La declaración ya tiene un archivo de sustento registrado.";
                    return result;
                }

                var nombreOriginal = Path.GetFileName(archivo.FileName);

                var nombreFisico =
                    $"{idContribuyenteDeclaracion}_{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid():N}{extension}";

                //var rutaBase = configuration["DeclaracionArchivos:RutaBase"];
                var rutaBase = "C:\\GadAA";
                if (string.IsNullOrWhiteSpace(rutaBase))
                {
                    rutaBase = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "ArchivosDeclaracion");
                }

                var carpetaDeclaracion = Path.Combine(
                    rutaBase,
                    idContribuyenteDeclaracion.ToString());

                if (!Directory.Exists(carpetaDeclaracion))
                {
                    Directory.CreateDirectory(carpetaDeclaracion);
                }

                var rutaCompleta = Path.Combine(carpetaDeclaracion, nombreFisico);

                await using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                var entidad = new ContribuyenteDeclaracionArchivo
                {
                    IdContribuyenteDeclaracion = idContribuyenteDeclaracion,
                    FechaHora = DateTime.Now,
                    UbicacionArchivo = rutaCompleta,
                    NombreArchivo = nombreOriginal,
                    ExtensionArchivo = extension,
                    Estado = true
                };

                contexto.ContribuyenteDeclaracionArchivos.Add(entidad);
                await contexto.SaveChangesAsync();

                result.Data = new DeclaracionArchivoDtoResult
                {
                    Id = entidad.Id,
                    IdContribuyenteDeclaracion = entidad.IdContribuyenteDeclaracion,
                    FechaHora = entidad.FechaHora,
                    NombreArchivo = entidad.NombreArchivo,
                    ExtensionArchivo = entidad.ExtensionArchivo,
                    Estado = entidad.Estado
                };

                return result;
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
                return result;
            }
        }

        public async Task<ConsultarDeclaracionArchivoDataResult> ConsultarArchivosDeclaracion(AaportalContext contexto,    ConsultarDeclaracionArchivoDtoParam parametro)
        {
            ConsultarDeclaracionArchivoDataResult result = new();

            try
            {
                if (parametro.IdContribuyenteDeclaracion <= 0)
                {
                    result.Message.Code = "DECLARACION_INVALIDA";
                    result.Message.Description = "La declaración enviada no es válida.";
                    return result;
                }

                var archivos = await contexto.ContribuyenteDeclaracionArchivos
                    .AsNoTracking()
                    .Where(x =>
                        x.IdContribuyenteDeclaracion == parametro.IdContribuyenteDeclaracion &&
                        x.Estado)
                    .OrderByDescending(x => x.FechaHora)
                    .Select(x => new DeclaracionArchivoDtoResult
                    {
                        Id = x.Id,
                        IdContribuyenteDeclaracion = x.IdContribuyenteDeclaracion,
                        FechaHora = x.FechaHora,
                        NombreArchivo = x.NombreArchivo,
                        ExtensionArchivo = x.ExtensionArchivo,
                        Estado = x.Estado
                    })
                    .ToListAsync();

                result.Data = new ConsultarDeclaracionArchivoListResult
                {
                    Archivos = archivos
                };

                return result;
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
                return result;
            }
        }
        public async Task<DescargarDeclaracionArchivoDtoResult?> ObtenerArchivoDeclaracion(AaportalContext contexto, long idArchivo)
        {
            if (idArchivo <= 0)
                return null;

            var archivo = await contexto.ContribuyenteDeclaracionArchivos
                .AsNoTracking()
                .Where(x => x.Id == idArchivo && x.Estado)
                .Select(x => new DescargarDeclaracionArchivoDtoResult
                {
                    Id = x.Id,
                    NombreArchivo = x.NombreArchivo,
                    ExtensionArchivo = x.ExtensionArchivo,
                    UbicacionArchivo = x.UbicacionArchivo
                })
                .FirstOrDefaultAsync();

            return archivo;
        }
    }
}
