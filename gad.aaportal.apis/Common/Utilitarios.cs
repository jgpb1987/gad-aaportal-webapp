using gad.aaportal.commons.Dto;
using gad.interoperador;

namespace gad.aaportal.apis.Common
{
    public class Utilitarios
    {
        public static ListForm102 MapearAForm102Lista(consultarResponse response)
        {
            var lista = new ListForm102();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Form102Dto();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "anioFiscal":
                                    dto.AnioFiscal = int.Parse(col.valor);
                                    break;
                                case "numeroIdentificacion":
                                    dto.NumeroIdentificacion = col.valor;
                                    break;
                                case "razonSocial":
                                    dto.RazonSocial = col.valor;
                                    break;
                                case "sustitutivaOriginal":
                                    dto.SustitutivaOriginal = col.valor;
                                    break;
                                case "avaArriendoOtrosAct3070":
                                    dto.AvaArriendoOtrosAct3070 = TryDec(col.valor);
                                    break;
                                case "avaluoArriendoInmuebles3030":
                                    dto.AvaluoArriendoInmuebles3030 = TryDec(col.valor);
                                    break;
                                case "depreciacionAcumulada530":
                                    dto.DepreciacionAcumulada530 = TryDec(col.valor);
                                    break;
                                case "ecoSoftware480":
                                    dto.EcoSoftware480 = TryDec(col.valor);
                                    break;
                                case "ingresosLepOli3120":
                                    dto.IngresosLepOli3120 = TryDec(col.valor);
                                    break;
                                case "inmueblesExceptoTerrenos420":
                                    dto.InmueblesExceptoTerrenos420 = TryDec(col.valor);
                                    break;
                                case "maqEquInstalaciones450":
                                    dto.MaqEquInstalaciones450 = TryDec(col.valor);
                                    break;
                                case "mueblesEnseres440":
                                    dto.MueblesEnseres440 = TryDec(col.valor);
                                    break;
                                case "perdidaEjercicio2810":
                                    dto.PerdidaEjercicio2810 = TryDec(col.valor);
                                    break;
                                case "rebajaDiscapacidad3350":
                                    dto.RebajaDiscapacidad3350 = TryDec(col.valor);
                                    break;
                                case "rebajaTerceraEdad3340":
                                    dto.RebajaTerceraEdad3340 = TryDec(col.valor);
                                    break;
                                case "subIngRgrTyc3195":
                                    dto.SubIngRgrTyc3195 = TryDec(col.valor);
                                    break;
                                case "subIngRgrTycSrd3200":
                                    dto.SubIngRgrTycSrd3200 = TryDec(col.valor);
                                    break;
                                case "terrenos540":
                                    dto.Terrenos540 = TryDec(col.valor);
                                    break;
                                case "totActCorriente410":
                                    dto.TotActCorriente410 = TryDec(col.valor);
                                    break;
                                case "totActivoNoCorriente812":
                                    dto.TotActivoNoCorriente812 = TryDec(col.valor);
                                    break;
                                case "totPasivoCorriente1030":
                                    dto.TotPasivoCorriente1030 = TryDec(col.valor);
                                    break;
                                case "totPatrimonioNeto1330":
                                    dto.TotPatrimonioNeto1330 = TryDec(col.valor);
                                    break;
                                case "totalActivo830":
                                    dto.TotalActivo830 = TryDec(col.valor);
                                    break;
                                case "totalActivoFijo560":
                                    dto.TotalActivoFijo560 = TryDec(col.valor);
                                    break;
                                case "totalCostosGastos2760":
                                    dto.TotalCostosGastos2760 = TryDec(col.valor);
                                    break;
                                case "totalIngresos1440":
                                    dto.TotalIngresos1440 = TryDec(col.valor);
                                    break;
                                case "totalPasivo1310":
                                    dto.TotalPasivo1310 = TryDec(col.valor);
                                    break;
                                case "utilidadNetaEjercicio2800":
                                    dto.UtilidadNetaEjercicio2800 = TryDec(col.valor);
                                    break;
                                case "vehiculosEqtEqc490":
                                    dto.VehiculosEqtEqc490 = TryDec(col.valor);
                                    break;
                                case "vneGrvTce1360":
                                    dto.VneGrvTce1360 = TryDec(col.valor);
                                    break;
                                case "ingresosAemRie1280":
                                    dto.IngresosAemRie1280 = TryDec(col.valor);
                                    break;
                                case "ingSyoTrabajoRde3240":
                                    dto.IngSyoTrabajoRde3240 = TryDec(col.valor);
                                    break;
                                case "cdoCliRelExterior190":
                                    dto.CdoCliRelExterior190 = TryDec(col.valor);
                                    break;
                            }
                        }
                        lista.Form102s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public static ListForm101 MapearAForm101Lista(consultarResponse response)
        {
            var lista = new ListForm101();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Form101Dto();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "anioFiscal":
                                    dto.AnioFiscal = int.Parse(col.valor);
                                    break;
                                case "numeroIdentificacion":
                                    dto.NumeroIdentificacion = col.valor;
                                    break;
                                case "razonSocial":
                                    dto.RazonSocial = col.valor;
                                    break;
                                case "perdidaEjercicio3430":
                                    dto.PerdidaEjercicio3430 = TryDec(col.valor);
                                    break;
                                case "totActivoNoCorriente1077":
                                    dto.TotActivoNoCorriente1077 = TryDec(col.valor);
                                    break;
                                case "totPasivosCorrientes1340":
                                    dto.TotPasivosCorrientes1340 = TryDec(col.valor);
                                    break;
                                case "totalActivo1080":
                                    dto.TotalActivo1080 = TryDec(col.valor);
                                    break;
                                case "totalActivoCorriente470":
                                    dto.TotalActivoCorriente470 = TryDec(col.valor);
                                    break;
                                case "totalIngresos1930":
                                    dto.TotalIngresos1930 = TryDec(col.valor);
                                    break;
                                case "totalPasivos1620":
                                    dto.TotalPasivos1620 = TryDec(col.valor);
                                    break;
                                case "totalPatrimonioNeto1780":
                                    dto.TotalPatrimonioNeto1780 = TryDec(col.valor);
                                    break;
                                case "totasCostosGastos3380":
                                    dto.TotasCostosGastos3380 = TryDec(col.valor);
                                    break;
                                case "utilidadEjercicio3420":
                                    dto.UtilidadEjercicio3420 = TryDec(col.valor);
                                    break;
                                case "totalPasivosLargoPlazo1590":
                                    dto.TotalPasivosLargoPlazo1590 = TryDec(col.valor);
                                    break;
                                case "proNoctePasCtgComNeg1577":
                                    dto.ProNoctePasCtgComNeg1577 = TryDec(col.valor);
                                    break;
                            }
                        }
                        lista.Form101s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public static Lista7728 MapearA7728Lista(consultarResponse response)
        {
            var lista = new Lista7728();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7728();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "actividadEconomica":
                                    dto.ActividadEconomica = col.valor;
                                    break;
                                case "codigoActividadEconomica":
                                    dto.CodigoActividad = col.valor;
                                    break;
                                case "numeroEstablecimiento":
                                    dto.NumeroEstablecimiento = int.Parse(col.valor);
                                    break;
                                case "numeroRuc":
                                    dto.NumeroRuc = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7728s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public static Lista7730 MapearA7730Lista(consultarResponse response)
        {
            var lista = new Lista7730();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7730();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "claseContribuyente":
                                    dto.ClaseContribuyente = col.valor;
                                    break;
                                case "codigoClaseContribuyente":
                                    dto.CodigoClaseContribuyente = col.valor;
                                    break;
                                case "codigoEstadoContribuyente":
                                    dto.CodigoEstadoContribuyente = col.valor;
                                    break;
                                case "estadoContribuyente":
                                    dto.EstadoContribuyente = col.valor;
                                    break;
                                case "estadoPersona":
                                    dto.EstadoPersona = col.valor;
                                    break;
                                case "estadoSociedad":
                                    dto.EstadoSociedad = col.valor;
                                    break;
                                case "fechaActualizacion":
                                    dto.FechaActualizacion = TryDate(col.valor);
                                    break;
                                case "fechaCancelacion":
                                    dto.FechaCancelacion = TryDate(col.valor);
                                    break;
                                case "fechaReinicioActividades":
                                    dto.FechaReinicioActividades = TryDate(col.valor);
                                    break;
                                case "fechaSuspensionDefinitiva":
                                    dto.FechaSuspensionDefinitiva = TryDate(col.valor);
                                    break;
                                case "obligado":
                                    dto.Obligado = col.valor;
                                    break;
                                case "personaSociedad":
                                    dto.PersonaSociedad = col.valor;
                                    break;
                                case "fechaInscripcionRuc":
                                    dto.FechaInscripcionRuc = TryDate(col.valor);
                                    break;
                                case "fechaConstitucion":
                                    dto.FechaConstitucion = TryDate(col.valor);
                                    break;
                                case "numeroRegistroMercantil":
                                    dto.NumeroRegistroMercantil = col.valor;
                                    break;
                                case "fechaFusion":
                                    dto.FechaFusion = TryDate(col.valor);
                                    break;
                                case "fechaEscision":
                                    dto.FechaEscision = TryDate(col.valor);
                                    break;
                                case "capitalSuscrito":
                                    dto.CapitalSuscrito = col.valor;
                                    break;
                                case "fechaNombramiento":
                                    dto.FechaNombramiento = TryDate(col.valor);
                                    break;
                                case "categoriaRise":
                                    dto.CategoriaRise = col.valor;
                                    break;
                                case "comercioExterior":
                                    dto.ComercioExterior = col.valor;
                                    break;
                                case "numRucSociedadAdscrita":
                                    dto.NumRucSociedadAdscrita = col.valor;
                                    break;
                                case "numRucSociedadEscisionada":
                                    dto.NumRucSociedadEscisionada = col.valor;
                                    break;
                                case "numeroRucFusionado":
                                    dto.NumeroRucFusionado = col.valor;
                                    break;
                                case "numeroPatronal":
                                    dto.NumeroPatronal = col.valor;
                                    break;
                                case "numeroExpediente":
                                    dto.NumeroExpediente = col.valor;
                                    break;
                                case "origenSociedad":
                                    dto.OrigenSociedad = col.valor;
                                    break;
                                case "gerenteGeneral":
                                    dto.GerenteGeneral = col.valor;
                                    break;
                                case "fechaNombramientoGerente":
                                    dto.FechaNombramientoGerente = TryDate(col.valor);
                                    break;
                                case "numeroRegistroColegioGremio":
                                    dto.NumeroRegistroColegioGremio = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7730s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        static decimal? TryDec(string valor)
        {
            return decimal.TryParse(
                valor,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out var d
            ) ? d : null;
        }

        static DateTime? TryDate(string valor)
        {
            return DateTime.TryParse(valor, out var d)
                ? d
                : null;
        }
    }
}
