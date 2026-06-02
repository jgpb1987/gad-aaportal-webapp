using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.models.Entity.Dbo;
using gad.aaportal.models.Entity.Declaracion;
using gad.aaportal.services.Config;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace gad.aaportal.services.Services.Implementation
{
    public class ContribuyenteServices : IContribuyenteServices
    {
        private readonly ILogger<ContribuyenteServices> logger;
        private readonly IDinardapService dinardapService;
        private readonly ServicesConfig servicesConfig;
        public ContribuyenteServices(ILogger<ContribuyenteServices> logger, IDinardapService dinardapService, IOptions<ServicesConfig> servicesConfig)
        {
            this.logger = logger;
            this.dinardapService = dinardapService;
            this.servicesConfig = servicesConfig.Value;
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
                        Matriz=e.Matriz,
                        NombreFantasiaComercial= e.NombreFantasiaComercial,
                        NumeroEstablecimiento= e.NumeroEstablecimiento,
                        Parroquia = e.Parroquia,
                        Provincia= e.Provincia,
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
                    var listForm102=await dinardapService.ConsultPackage<ListForm102>(new PaqueteDinardapRequest() { Identificacion = "1091730940001", Paquete = "6282", Usuario =servicesConfig.DinardapUser });

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
                            Ingresos = Math.Round(form102.TotActCorriente410 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoContingente = Math.Round(form102.TotalPasivo1310 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoCorriente = Math.Round(form102.TotPasivoCorriente1030 ?? 0, 2, MidpointRounding.AwayFromZero),
                            PasivoNoCorriente = Math.Round(form102.TotPatrimonioNeto1330 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                } else
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
                            PasivoNoCorriente = Math.Round(form101.TotalPasivos1620 ?? 0, 2, MidpointRounding.AwayFromZero)
                        });
                    }
                }

                result.Data = new() {Establecimientos=establecimientos, PeriodosDeclaracion=periodosDeclaracion.OrderBy(pd => pd.AnioEjercicioFiscal).ToList() };

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
    }
}
