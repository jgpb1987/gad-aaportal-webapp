using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Implementation
{
    public class SpMunicipioServices : ISpMunicipioServices
    {
        private readonly ILogger<SpMunicipioServices> logger;

        public SpMunicipioServices(ILogger<SpMunicipioServices> logger)
        {
            this.logger = logger;
        }

        public async Task<CalcularImpuestoPatenteDtoResult> CalcularImpuestoPatente(BddGmaaContext contexto, CalcularImpuestoPatenteDtoParam parametro)
        {
            CalcularImpuestoPatenteDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_CalcularImpuestoPatente";
                command.CommandType = CommandType.StoredProcedure;

                var parametroBaseImponible = new SqlParameter("@BaseImponible", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.BaseImponible
                };

                var parametroValorImpuesto = new SqlParameter("@ValorImpuesto", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(parametroBaseImponible);
                command.Parameters.Add(parametroValorImpuesto);

                await command.ExecuteNonQueryAsync();

                result.Data = new CalcularImpuestoPatenteDtoDataResult
                {
                    ValorImpuesto = parametroValorImpuesto.Value != DBNull.Value
                        ? Convert.ToDecimal(parametroValorImpuesto.Value)
                        : 0
                };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<CalcularImpuestoIatDtoResult> CalcularImpuestoIat(BddGmaaContext contexto, CalcularImpuestoIatDtoParam parametro)
        {
            CalcularImpuestoIatDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_CalcularImpuestoIAT";
                command.CommandType = CommandType.StoredProcedure;

                var parametroBaseImponible = new SqlParameter("@BaseImponible", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.BaseImponible
                };

                var parametroImpuestoIat = new SqlParameter("@ImpuestoIAT", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(parametroBaseImponible);
                command.Parameters.Add(parametroImpuestoIat);

                await command.ExecuteNonQueryAsync();

                result.Data.ImpuestoIat = parametroImpuestoIat.Value != DBNull.Value
                    ? Convert.ToDecimal(parametroImpuestoIat.Value)
                    : 0;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<CalcularMultaDtoResult> CalcularMulta(BddGmaaContext contexto, CalcularMultaDtoParam parametro)
        {
            CalcularMultaDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_CalcularMulta";
                command.CommandType = CommandType.StoredProcedure;

                var parametroPeriodoFin = new SqlParameter("@Ruc", SqlDbType.VarChar)
                {
                    Value = parametro.Ruc
                };

                var parametroFechaEmision = new SqlParameter("@AnioDeclaracion", SqlDbType.Int)
                {
                    Value = parametro.AnioDeclaracion
                };

                var parametroValor = new SqlParameter("@Valor", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.Valor
                };

                var parametroMeses = new SqlParameter("@Meses", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                var parametroMulta = new SqlParameter("@Multa", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(parametroPeriodoFin);
                command.Parameters.Add(parametroFechaEmision);
                command.Parameters.Add(parametroValor);
                command.Parameters.Add(parametroMeses);
                command.Parameters.Add(parametroMulta);

                await command.ExecuteNonQueryAsync();

                result.Data.Meses = parametroMeses.Value != DBNull.Value
                    ? Convert.ToInt32(parametroMeses.Value)
                    : 0;

                result.Data.Multa = parametroMulta.Value != DBNull.Value
                    ? Convert.ToDecimal(parametroMulta.Value)
                    : 0;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<CalcularTerceraEdadDtoResult> CalcularTerceraEdad(
    BddGmaaContext contexto,
    CalcularTerceraEdadDtoParam parametro)
        {
            CalcularTerceraEdadDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_CalcularTerceraEdad";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@BasePatrimonio", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.BasePatrimonio
                });

                command.Parameters.Add(new SqlParameter("@Ingresos", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.Ingresos
                });

                command.Parameters.Add(new SqlParameter("@Ruc", SqlDbType.VarChar, 18)
                {
                    Value = parametro.Ruc
                });

                command.Parameters.Add(new SqlParameter("@anio", SqlDbType.Int)
                {
                    Value = parametro.Anio
                });

                command.Parameters.Add(new SqlParameter("@valorImpuesto", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = parametro.ValorImpuesto
                });

                command.Parameters.Add(new SqlParameter("@TipoImpuesto", SqlDbType.VarChar, 20)
                {
                    Value = parametro.TipoImpuesto
                });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.PorcentajePatrimonio = reader["PorcentajePatrimonio"] != DBNull.Value ? Convert.ToDecimal(reader["PorcentajePatrimonio"]) : 0;
                    result.Data.PorcentajeIngresos = reader["PorcentajeIngresos"] != DBNull.Value ? Convert.ToDecimal(reader["PorcentajeIngresos"]) : 0;
                    result.Data.PorcentajeAplicar = reader["PorcentajeAplicar"] != DBNull.Value ? Convert.ToDecimal(reader["PorcentajeAplicar"]) : 0;
                    result.Data.ValorDescuento = reader["ValorDescuento"] != DBNull.Value ? Convert.ToDecimal(reader["ValorDescuento"]) : 0;
                    result.Data.TipoAplicacion = reader["TipoAplicacion"] != DBNull.Value ? reader["TipoAplicacion"].ToString()! : string.Empty;
                    result.Data.PorcentajeTe = reader["PorcentajeTE"] != DBNull.Value ? Convert.ToDecimal(reader["PorcentajeTE"]) : 0;
                    result.Data.Patrimonio = reader["Patrimonio"] != DBNull.Value ? Convert.ToDecimal(reader["Patrimonio"]) : 0;
                    result.Data.TipoImpuesto = reader["TipoImpuesto"] != DBNull.Value ? reader["TipoImpuesto"].ToString()! : string.Empty;
                    result.Data.Msj = reader["Msj"] != DBNull.Value ? reader["Msj"].ToString()! : string.Empty;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<InsertActividadAnualDtoResult> InsertActividadAnual(
    BddGmaaContext contexto,
    InsertActividadAnualDtoParam parametro)
        {
            InsertActividadAnualDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_InsertActividadAnual";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Ruc", SqlDbType.VarChar, 18) { Value = parametro.Ruc });
                command.Parameters.Add(new SqlParameter("@IngresoTotales", SqlDbType.Float) { Value = parametro.IngresoTotales });
                command.Parameters.Add(new SqlParameter("@TotalActivos", SqlDbType.Float) { Value = parametro.TotalActivos });
                command.Parameters.Add(new SqlParameter("@TotalPasivos", SqlDbType.Float) { Value = parametro.TotalPasivos });
                command.Parameters.Add(new SqlParameter("@Patrimonio", SqlDbType.Float) { Value = parametro.Patrimonio });
                command.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = parametro.FechaInicio.Date });
                command.Parameters.Add(new SqlParameter("@FechaVencimiento", SqlDbType.Date) { Value = parametro.FechaVencimiento.Date });
                command.Parameters.Add(new SqlParameter("@AnioPatente", SqlDbType.Int) { Value = parametro.AnioPatente });
                command.Parameters.Add(new SqlParameter("@BaseImponiblePatente", SqlDbType.Float) { Value = parametro.BaseImponiblePatente });
                command.Parameters.Add(new SqlParameter("@TarifaPatente", SqlDbType.Float) { Value = parametro.TarifaPatente });
                command.Parameters.Add(new SqlParameter("@MultaPatente", SqlDbType.Float) { Value = parametro.MultaPatente });
                command.Parameters.Add(new SqlParameter("@PorcentajeDescuentoTercera", SqlDbType.Float) { Value = parametro.PorcentajeDescuentoTercera });
                command.Parameters.Add(new SqlParameter("@UsuarioIngreso", SqlDbType.VarChar, 50) { Value = parametro.UsuarioIngreso });
                command.Parameters.Add(new SqlParameter("@Utilidad", SqlDbType.Float) { Value = parametro.Utilidad });
                command.Parameters.Add(new SqlParameter("@ContingenciaPasivos", SqlDbType.Float) { Value = parametro.ContingenciaPasivos });
                command.Parameters.Add(new SqlParameter("@BaseImponibleIAT", SqlDbType.Float) { Value = parametro.BaseImponibleIat });
                command.Parameters.Add(new SqlParameter("@ImpuestoIAT", SqlDbType.Float) { Value = parametro.ImpuestoIat });
                command.Parameters.Add(new SqlParameter("@MultaIAT", SqlDbType.Float) { Value = parametro.MultaIat });
                command.Parameters.Add(new SqlParameter("@PorcentajeCalculoIAT", SqlDbType.Float) { Value = parametro.PorcentajeCalculoIat });
                command.Parameters.Add(new SqlParameter("@AreaArriendo", SqlDbType.Float) { Value = parametro.AreaArriendo });
                command.Parameters.Add(new SqlParameter("@Sustitutiva", SqlDbType.Char, 1) { Value = parametro.Sustitutiva });
                command.Parameters.Add(new SqlParameter("@PagoSri", SqlDbType.Float) { Value = parametro.PagoSri });
                command.Parameters.Add(new SqlParameter("@PorcentajeTEIAT", SqlDbType.Float) { Value = parametro.PorcentajeTeiat });
                command.Parameters.Add(new SqlParameter("@DescuentoTEIAT", SqlDbType.Float) { Value = parametro.DescuentoTeiat });
                command.Parameters.Add(new SqlParameter("@ValorEmitidoIAT", SqlDbType.Float) { Value = parametro.ValorEmitidoIat });
                command.Parameters.Add(new SqlParameter("@DescuentoTEPma", SqlDbType.Float) { Value = parametro.DescuentoTepma });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.IdActividadGenerada = reader["IdActividadGenerada"] != DBNull.Value
                        ? Convert.ToInt32(reader["IdActividadGenerada"])
                        : 0;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<InsertTerceraEdadDtoResult> InsertTerceraEdad(
    BddGmaaContext contexto,
    InsertTerceraEdadDtoParam parametro)
        {
            InsertTerceraEdadDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_InsertTerceraEdad";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@AnioCalculo", SqlDbType.Int) { Value = parametro.AnioCalculo });
                command.Parameters.Add(new SqlParameter("@RBU", SqlDbType.Float) { Value = parametro.Rbu });
                command.Parameters.Add(new SqlParameter("@PatrimonioAA", SqlDbType.Float) { Value = parametro.PatrimonioAa });
                command.Parameters.Add(new SqlParameter("@Ingresos", SqlDbType.Float) { Value = parametro.Ingresos });
                command.Parameters.Add(new SqlParameter("@PorcentajeExoneracion", SqlDbType.Float) { Value = parametro.PorcentajeExoneracion });
                command.Parameters.Add(new SqlParameter("@ExedenteAplicado", SqlDbType.Float) { Value = parametro.ExedenteAplicado });
                command.Parameters.Add(new SqlParameter("@PorcentajePatrimonio", SqlDbType.Float) { Value = parametro.PorcentajePatrimonio });
                command.Parameters.Add(new SqlParameter("@PorcentajeIngreso", SqlDbType.Float) { Value = parametro.PorcentajeIngreso });
                command.Parameters.Add(new SqlParameter("@BaseImponible", SqlDbType.Float) { Value = parametro.BaseImponible });
                command.Parameters.Add(new SqlParameter("@ImpuestoGravado", SqlDbType.Float) { Value = parametro.ImpuestoGravado });
                command.Parameters.Add(new SqlParameter("@PorcentajeAplicado", SqlDbType.Float) { Value = parametro.PorcentajeAplicado });
                command.Parameters.Add(new SqlParameter("@ValorExonerado", SqlDbType.Float) { Value = parametro.ValorExonerado });
                command.Parameters.Add(new SqlParameter("@TipoImpuesto", SqlDbType.VarChar, 80) { Value = parametro.TipoImpuesto });
                command.Parameters.Add(new SqlParameter("@UsuarioIngreso", SqlDbType.VarChar, 80) { Value = parametro.UsuarioIngreso });
                command.Parameters.Add(new SqlParameter("@IdCalculoImpuesto", SqlDbType.Int) { Value = parametro.IdCalculoImpuesto });

                var filasAfectadas = await command.ExecuteNonQueryAsync();
                result.Data.Insertado = filasAfectadas > 0;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<InsertPagoPorTituloDtoResult> InsertPagoPorTitulo(
    BddGmaaContext contexto,
    InsertPagoPorTituloDtoParam parametro)
        {
            InsertPagoPorTituloDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_InsertPagoPorTitulo";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Ruc", SqlDbType.NVarChar, 18) { Value = parametro.Ruc });
                command.Parameters.Add(new SqlParameter("@Cod_Titulo_Datos", SqlDbType.VarChar, 5) { Value = parametro.CodTituloDatos });
                command.Parameters.Add(new SqlParameter("@Fecha_Ingreso", SqlDbType.Date) { Value = parametro.FechaIngreso.Date });
                command.Parameters.Add(new SqlParameter("@Fecha_Vencimiento", SqlDbType.DateTime) { Value = parametro.FechaVencimiento });
                command.Parameters.Add(new SqlParameter("@Fecha_Venc_Interes", SqlDbType.DateTime) { Value = parametro.FechaVencInteres });
                command.Parameters.Add(new SqlParameter("@User_Ingreso", SqlDbType.NVarChar, 25) { Value = parametro.UserIngreso });
                command.Parameters.Add(new SqlParameter("@Base_Imponible", SqlDbType.Float) { Value = parametro.BaseImponible });
                command.Parameters.Add(new SqlParameter("@ValorPatente", SqlDbType.Float) { Value = parametro.ValorPatente });
                command.Parameters.Add(new SqlParameter("@MultaPatente", SqlDbType.Float) { Value = parametro.MultaPatente });
                command.Parameters.Add(new SqlParameter("@ValorIAT", SqlDbType.Float) { Value = parametro.ValorIat });
                command.Parameters.Add(new SqlParameter("@MultaIAT", SqlDbType.Float) { Value = parametro.MultaIat });
                command.Parameters.Add(new SqlParameter("@anioDeclaracion", SqlDbType.Int) { Value = parametro.AnioDeclaracion });
                command.Parameters.Add(new SqlParameter("@ValorPagadoOtroCanton", SqlDbType.Float) { Value = parametro.ValorPagadoOtroCanton });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.CodigoIngreso = reader["CodigoIngreso"] != DBNull.Value
                        ? Convert.ToInt32(reader["CodigoIngreso"])
                        : 0;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ActualizarCodigoIngresoDtoResult> ActualizarCodigoIngreso(BddGmaaContext contexto, 
    ActualizarCodigoIngresoDtoParam parametro)
        {
            ActualizarCodigoIngresoDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ActualizarCodigoIngreso";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@codigoIngreso", SqlDbType.Int) { Value = parametro.CodigoIngreso });
                command.Parameters.Add(new SqlParameter("@IdDeclaracionAnual", SqlDbType.Int) { Value = parametro.IdDeclaracionAnual });
                command.Parameters.Add(new SqlParameter("@CodTitulo", SqlDbType.VarChar, 10) { Value = parametro.CodTitulo });

                var filasAfectadas = await command.ExecuteNonQueryAsync();
                result.Data.Actualizado = filasAfectadas > 0;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ConsultarValoresPagarDtoResult> ConsultarValoresPagar(BddGmaaContext contexto, ConsultarValoresPagarDtoParam parametro)
        {
            ConsultarValoresPagarDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ConsultarValoresPagar";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@codigoIngreso", SqlDbType.Int)
                {
                    Value = parametro.CodigoIngreso
                });

                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Data.Detalles.Add(new ConsultarValoresPagarDetalleDtoDataResult
                    {
                        Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : 0,
                        DescripcionDescripcion = reader["Descripcion_descripcion"] != DBNull.Value
                            ? reader["Descripcion_descripcion"].ToString()!
                            : string.Empty
                    });
                }

                if (await reader.NextResultAsync() && await reader.ReadAsync())
                {
                    result.Data.Resumen = new ConsultarValoresPagarResumenDtoDataResult
                    {
                        Total = reader["Total"] != DBNull.Value ? Convert.ToDecimal(reader["Total"]) : 0,
                        RecargoTit = reader["RecargoTit"] != DBNull.Value ? Convert.ToDecimal(reader["RecargoTit"]) : 0,
                        Interes = reader["Interes"] != DBNull.Value ? Convert.ToDecimal(reader["Interes"]) : 0,
                        Recargo = reader["Recargo"] != DBNull.Value ? Convert.ToDecimal(reader["Recargo"]) : 0,
                        Descuento = reader["Descuento"] != DBNull.Value ? Convert.ToDecimal(reader["Descuento"]) : 0,
                        CostaJ = reader["CostaJ"] != DBNull.Value ? Convert.ToDecimal(reader["CostaJ"]) : 0
                    };
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ValidadorPermisosDtoResult> ValidadorPermisos(BddGmaaContext contexto, ValidadorPermisosDtoParam parametro)
        {
            ValidadorPermisosDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ValidadorPermisos";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@RUC", SqlDbType.VarChar, 15)
                {
                    Value = parametro.Ruc
                });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.Estado = reader["Estado"] != DBNull.Value
                        && Convert.ToBoolean(reader["Estado"]);

                    result.Data.Mensaje = reader["Mensaje"] != DBNull.Value
                        ? reader["Mensaje"].ToString()!
                        : string.Empty;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ConsultarValorBomberosDtoResult> ConsultarValorBomberos(
    BddGmaaContext contexto,
    ConsultarValorBomberosDtoParam parametro)
        {
            ConsultarValorBomberosDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ConsultarValorBomberos";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@RUC", SqlDbType.VarChar, 15)
                {
                    Value = parametro.Ruc
                });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.Ruc = reader["RUC"] != DBNull.Value
                        ? reader["RUC"].ToString()!
                        : string.Empty;

                    result.Data.ValorBomberos = reader["ValorBomberos"] != DBNull.Value
                        ? Convert.ToDouble(reader["ValorBomberos"])
                        : 0;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ConsultarRucExoneracionesDtoResult> ConsultarRucExoneraciones(BddGmaaContext contexto, ConsultarRucExoneracionesDtoParam parametro)
        {
            ConsultarRucExoneracionesDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ConsultarRucExoneraciones";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@RUC", SqlDbType.VarChar, 15)
                {
                    Value = parametro.Ruc
                });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.ExoneracionPatente = reader["ExoneracionPatente"] != DBNull.Value
                        ? reader["ExoneracionPatente"].ToString()!
                        : string.Empty;

                    result.Data.ExoneracionIat = reader["ExoneracionIAT"] != DBNull.Value
                        ? reader["ExoneracionIAT"].ToString()!
                        : string.Empty;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<InsertarTranferenciaIatDtoResult> InsertarTranferenciaIat(
    BddGmaaContext contexto,
    InsertarTranferenciaIatDtoParam parametro)
        {
            InsertarTranferenciaIatDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_InsertarTranferenciaIAT";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Canton", SqlDbType.VarChar, 100) { Value = parametro.Canton });
                command.Parameters.Add(new SqlParameter("@FechaPago", SqlDbType.Date) { Value = parametro.FechaPago.Date });
                command.Parameters.Add(new SqlParameter("@FormaPago", SqlDbType.VarChar, 150) { Value = parametro.FormaPago });
                command.Parameters.Add(new SqlParameter("@NroDocumento", SqlDbType.VarChar, 150) { Value = parametro.NroDocumento });
                command.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Float) { Value = parametro.Valor });
                command.Parameters.Add(new SqlParameter("@UsuarioIngreso", SqlDbType.VarChar, 50) { Value = parametro.UsuarioIngreso });
                command.Parameters.Add(new SqlParameter("@Banco", SqlDbType.VarChar, 150) { Value = parametro.Banco });

                var filasAfectadas = await command.ExecuteNonQueryAsync();
                result.Data.Insertado = filasAfectadas > 0;
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
        public async Task<ConsultarAnioAdeudaDtoResult> ConsultarAnioAdeuda(
    BddGmaaContext contexto,
    ConsultarAnioAdeudaDtoParam parametro)
        {
            ConsultarAnioAdeudaDtoResult result = new();

            try
            {
                await using var connection = contexto.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.SP_Pat_ConsultarAnioAdeuda";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@RUC", SqlDbType.VarChar, 15)
                {
                    Value = parametro.Ruc
                });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.Data.Anio = reader["Anio"] != DBNull.Value
                        ? Convert.ToInt32(reader["Anio"])
                        : 0;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }

            return result;
        }
    }
}
