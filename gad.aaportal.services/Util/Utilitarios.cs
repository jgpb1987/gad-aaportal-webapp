using gad.aaportal.commons.Dto.Dinardap;
using gad.interoperador;

namespace gad.aaportal.services.Util
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

        public static Lista7731 MapearA7731Lista(consultarResponse response)
        {
            var lista = new Lista7731();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7731();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "calle":
                                    dto.Calle = col.valor;
                                    break;
                                case "estadoEstablecimiento":
                                    dto.EstadoEstablecimiento = col.valor;
                                    break;
                                case "interseccion":
                                    dto.Interseccion = col.valor;
                                    break;
                                case "nombreFantasiaComercial":
                                    dto.NombreFantasiaComercial = col.valor;
                                    break;
                                case "numeroEstablecimiento":
                                    dto.NumeroEstablecimiento = col.valor;
                                    break;
                                case "numeroRuc":
                                    dto.NumeroRuc = col.valor;
                                    break;
                                case "tipoEstablecimiento":
                                    dto.TipoEstablecimiento = col.valor;
                                    break;
                                case "referenciaUbicacion":
                                    dto.ReferenciaUbicacion = col.valor;
                                    break;
                                case "fechaInicioActividades":
                                    dto.FechaInicioActividades = TryDate(col.valor);
                                    break;
                                case "fechaReinicioActividades":
                                    dto.FechaReinicioActividades = TryDate(col.valor);
                                    break;
                                case "fechaCierre":
                                    dto.FechaCierre = TryDate(col.valor);
                                    break;
                                case "verificacionUbicacion":
                                    dto.VerificacionUbicacion = col.valor;
                                    break;
                                case "ubicacionGeografica":
                                    dto.UbicacionGeografica = col.valor;
                                    break;
                                case "barrio":
                                    dto.Barrio = col.valor;
                                    break;
                                case "ciudadela":
                                    dto.Ciudadela = col.valor;
                                    break;
                                case "conjunto":
                                    dto.Conjunto = col.valor;
                                    break;
                                case "bloque":
                                    dto.Bloque = col.valor;
                                    break;
                                case "nombreEdificio":
                                    dto.NombreEdificio = col.valor;
                                    break;
                                case "numeroOficina":
                                    dto.NumeroOficina = col.valor;
                                    break;
                                case "manzana":
                                    dto.Manzana = col.valor;
                                    break;
                                case "supermanzana":
                                    dto.Supermanzana = col.valor;
                                    break;
                                case "kilometro":
                                    dto.Kilometro = col.valor;
                                    break;
                                case "carretero":
                                    dto.Carretero = col.valor;
                                    break;
                                case "camino":
                                    dto.Camino = col.valor;
                                    break;
                                case "numeroPiso":
                                    dto.NumeroPiso = col.valor;
                                    break;
                                case "resultadoVerificacion":
                                    dto.ResultadoVerificacion = col.valor;
                                    break;
                                case "direccionPresunta":
                                    dto.DireccionPresunta = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7731s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public static Lista7732 MapearA7732Lista(consultarResponse response)
        {
            var lista = new Lista7732();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7732();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "numeroRuc":
                                    dto.NumeroRuc = col.valor;
                                    break;
                                case "marcaListaBlanca":
                                    dto.MarcaListaBlanca = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7732s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public static Lista6279 MapearA6279Lista(consultarResponse response)
        {
            var lista = new Lista6279();
            Paquete6279 paquete6279 = new Paquete6279();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        switch (entidad.nombre)
                        {
                            case "Contribuyente Datos Completo":
                                var contrib = new ContribuyenteDatos();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "codClaseContrib":
                                            contrib.CodClaseContrib = col.valor;
                                            break;
                                        case "codEstado":
                                            contrib.CodEstado = col.valor;
                                            break;
                                        case "desClaseContrib":
                                            contrib.DesClaseContrib = col.valor;
                                            break;
                                        case "desEstado":
                                            contrib.DesEstado = col.valor;
                                            break;
                                        case "direccionCorta":
                                            contrib.DireccionCorta = col.valor;
                                            break;
                                        case "email":
                                            contrib.Email = col.valor;
                                            break;
                                        case "nombreComercial":
                                            contrib.NombreComercial = col.valor;
                                            break;
                                        case "numeroRuc":
                                            contrib.NumeroRuc = col.valor;
                                            break;
                                        case "razonSocial":
                                            contrib.RazonSocial = col.valor;
                                            break;
                                        case "telefonoDomicilio":
                                            contrib.TelefonoDomicilio = col.valor;
                                            break;
                                        case "telefonoTrabajo":
                                            contrib.TelefonoTrabajo = col.valor;
                                            break;
                                        case "calificacionArtesanal":
                                            contrib.CalificacionArtesanal = col.valor;
                                            break;
                                        case "direccionLarga":
                                            contrib.DireccionLarga = col.valor;
                                            break;
                                        case "fax":
                                            contrib.Fax = col.valor;
                                            break;
                                        case "fechaAltaParaEspecial":
                                            contrib.FechaAltaParaEspecial = TryDate(col.valor);
                                            break;
                                        case "fechaCalificacionArtesanal":
                                            contrib.FechaCalificacionArtesanal = TryDate(col.valor);
                                            break;
                                        case "fechaCambioObligado":
                                            contrib.FechaCambioObligado = TryDate(col.valor);
                                            break;
                                        case "fechaInicioActividades":
                                            contrib.FechaInicioActividades = TryDate(col.valor);
                                            break;
                                        case "fechaNacimiento":
                                            contrib.FechaNacimiento = TryDate(col.valor);
                                            break;
                                        case "fechaNotificacionEspeciales":
                                            contrib.FechaNotificacionEspeciales = TryDate(col.valor);
                                            break;
                                        case "fechaUltimaDeclaracion":
                                            contrib.FechaUltimaDeclaracion = TryDate(col.valor);
                                            break;
                                        case "numeroCalificacionArtesanal":
                                            contrib.NumeroCalificacionArtesanal = col.valor;
                                            break;
                                        case "obligadoContabilidad":
                                            contrib.ObligadoContabilidad = col.valor;
                                            break;
                                        case "resolucionAltaParaEspecial":
                                            contrib.ResolucionAltaParaEspecial = col.valor;
                                            break;
                                        case "tipoCalificacionArtesanal":
                                            contrib.TipoCalificacionArtesanal = col.valor;
                                            break;
                                        case "ultimoPeriodoFiscalCumplido":
                                            contrib.UltimoPeriodoFiscalCumplido = col.valor;
                                            break;
                                        case "nombreAgenteRetencion":
                                            contrib.NombreAgenteRetencion = col.valor;
                                            break;
                                        case "estadoListaBlanca":
                                            contrib.EstadoListaBlanca = col.valor;
                                            break;
                                        case "marcaFantasma":
                                            contrib.MarcaFantasma = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.ContribuyenteDatos.Add(contrib);
                                break;

                            case "Actividad Economica":
                                var act = new ActividadEconomica();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "actividadGeneral":
                                            act.ActividadGeneral = col.valor;
                                            break;
                                        case "codN1Familia":
                                            act.CodN1Familia = col.valor;
                                            break;
                                        case "codN2Grupo":
                                            act.CodN2Grupo = col.valor;
                                            break;
                                        case "codN3SubGrupo":
                                            act.CodN3SubGrupo = col.valor;
                                            break;
                                        case "codN4Clase":
                                            act.CodN4Clase = col.valor;
                                            break;
                                        case "codN5SubClase":
                                            act.CodN5SubClase = col.valor;
                                            break;
                                        case "codN6Actividad":
                                            act.CodN6Actividad = col.valor;
                                            break;
                                        case "n1Familia":
                                            act.N1Familia = col.valor;
                                            break;
                                        case "n2Grupo":
                                            act.N2Grupo = col.valor;
                                            break;
                                        case "n3SubGrupo":
                                            act.N3SubGrupo = col.valor;
                                            break;
                                        case "n4Clase":
                                            act.N4Clase = col.valor;
                                            break;
                                        case "n5SubClase":
                                            act.N5SubClase = col.valor;
                                            break;
                                        case "n6Actividad":
                                            act.N6Actividad = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.ActividadEconomica.Add(act);
                                break;

                            case "Tipo Contribuyente":
                                var tipo = new TipoContribuyente();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "nivel1":
                                            tipo.Nivel1 = col.valor;
                                            break;
                                        case "nivel2":
                                            tipo.Nivel2 = col.valor;
                                            break;
                                        case "nivel3":
                                            tipo.Nivel3 = col.valor;
                                            break;
                                        case "nivel4":
                                            tipo.Nivel4 = col.valor;
                                            break;
                                        case "ultimoNivel":
                                            tipo.UltimoNivel = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.TipoContribuyente.Add(tipo);
                                break;

                            case "Contador":
                                var cont = new Contador();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "cedulaContador":
                                            cont.CedulaContador = col.valor;
                                            break;
                                        case "nombreContador":
                                            cont.NombreContador = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.Contador.Add(cont);
                                break;

                            case "Estructura Organizacional":
                                var est = new EstructuraOrganizacional();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "codigoProvincia":
                                            est.CodigoProvincia = col.valor;
                                            break;
                                        case "codigoRegional":
                                            est.CodigoRegional = col.valor;
                                            break;
                                        case "nombreProvincia":
                                            est.NombreProvincia = col.valor;
                                            break;
                                        case "nombreRegional":
                                            est.NombreRegional = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.Estructura.Add(est);
                                break;

                            case "Representante Legal":
                                var rep = new RepresentanteLegal();

                                foreach (var col in fila.columnas)
                                {
                                    switch (col.campo)
                                    {
                                        case "cargo":
                                            rep.Cargo = col.valor;
                                            break;
                                        case "identificacion":
                                            rep.Identificacion = col.valor;
                                            break;
                                        case "nombre":
                                            rep.Nombre = col.valor;
                                            break;
                                    }
                                }
                                paquete6279.RepresentanteLegal.Add(rep);
                                break;
                        }
                    }
                }
                lista.paquete6279s.Add(paquete6279);
            }
            catch
            {
            }

            return lista;
        }

        public static Lista7736 MapearA7736Lista(consultarResponse response)
        {
            var lista = new Lista7736();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7736();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "descripcionEstadoTributario":
                                    dto.Descripcion = col.valor;
                                    break;
                                case "estadoTributario":
                                    dto.Estado = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7736s.Add(dto);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public static Lista7742 MapearA7742Lista(consultarResponse response)
        {
            var lista = new Lista7742();
            try
            {
                foreach (var entidad in response.paquete.entidades)
                {
                    foreach (var fila in entidad.filas)
                    {
                        var dto = new Paquete7742();

                        foreach (var col in fila.columnas)
                        {
                            switch (col.campo)
                            {
                                case "calle":
                                    dto.Calle = col.valor;
                                    break;
                                case "canton":
                                    dto.Canton = col.valor;
                                    break;
                                case "cedulaRepresentante":
                                    dto.CedulaRepresentante = col.valor;
                                    break;
                                case "cedulaSecretario":
                                    dto.CedulaSecretario = col.valor;
                                    break;
                                case "claseOrganizacion":
                                    dto.ClaseOrganizacion = col.valor;
                                    break;
                                case "codigoError":
                                    dto.CodigoError = int.Parse(col.valor);
                                    break;
                                case "codigoRegistroSeps":
                                    dto.CodigoRegistroSeps = col.valor;
                                    break;
                                case "correoOrganizacion":
                                    dto.CorreoOrganizacion = col.valor;
                                    break;
                                case "error":
                                    dto.Error = col.valor;
                                    break;
                                case "estadoOrganizacion":
                                    dto.EstadoOrganizacion = col.valor;
                                    break;
                                case "fechaRegistroSeps":
                                    dto.FechaRegistroSeps = TryDate(col.valor);
                                    break;
                                case "grupoOrganizacion":
                                    dto.GrupoOrganizacion = col.valor;
                                    break;
                                case "interseccion":
                                    dto.Interseccion = col.valor;
                                    break;
                                case "nombreRepresentanteLegal":
                                    dto.NombreRepresentanteLegal = col.valor;
                                    break;
                                case "nombreSecretario":
                                    dto.NombreSecretario = col.valor;
                                    break;
                                case "numero":
                                    dto.Numero = col.valor;
                                    break;
                                case "numeroResolucionSeps":
                                    dto.NumeroResolucionSeps = col.valor;
                                    break;
                                case "parroquia":
                                    dto.Parroquia = col.valor;
                                    break;
                                case "provincia":
                                    dto.Provincia = col.valor;
                                    break;
                                case "razonSocial":
                                    dto.RazonSocial = col.valor;
                                    break;
                                case "referencia":
                                    dto.Referencia = col.valor;
                                    break;
                                case "ruc":
                                    dto.Ruc = col.valor;
                                    break;
                                case "telefono":
                                    dto.Telefono = col.valor;
                                    break;
                                case "tipoOrganizacion":
                                    dto.TipoOrganizacion = col.valor;
                                    break;
                            }
                        }
                        lista.paquete7742s.Add(dto);
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
