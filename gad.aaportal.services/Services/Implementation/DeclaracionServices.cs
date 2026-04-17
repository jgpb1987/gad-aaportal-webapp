using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.models.Entity.Aplicacion;
using gad.aaportal.services.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace gad.aaportal.services.Services.Implementation
{
    public class DeclaracionServices : IDeclaracionServices
    {
        private readonly ILogger<DeclaracionServices> logger;

        public DeclaracionServices(ILogger<DeclaracionServices> logger)
        {
            this.logger = logger;
        }

        public async Task<SaveDeclaracionPJResult> GrabarDeclaracionPJ(AaportalContext contexto, DeclaracionRequest parametros)
        {
            SaveDeclaracionPJResult result = new SaveDeclaracionPJResult();
            try
            {
                var declaracion = new DeclaracionPJ
                {
                    AnioFiscal = parametros.declaracion.AnioFiscal,
                    ValorUnoPorMil = parametros.declaracion.ValorUnoPorMil,
                    ValorPatente = parametros.declaracion.ValorPatente,
                    UtilidadEjercicio3420 = parametros.declaracion.UtilidadEjercicio3420,
                    TotalPasivos1620 = parametros.declaracion.TotalPasivos,
                    FechaInser = DateTime.Now,
                    RUC = parametros.declaracion.RUC,
                    TotActivoNoCorriente1077 = parametros.declaracion.ActivoNoCorriente,
                    TotalActivo1080 = parametros.declaracion.TotalActivos,
                    TotalActivoCorriente470 = parametros.declaracion.ActivoCorriente,
                    TotalIngresos1930 = parametros.declaracion.Ingresos,
                    TotalPasivosContingente = parametros.declaracion.PasivoContingente,
                    TotalPasivosLargoPlazo1590 = parametros.declaracion.PasivoLargoPlazo,
                    TotasCostosGastos3380 = parametros.declaracion.CostosGastos,
                    TotPasivosCorrientes1340 = parametros.declaracion.PasivoCorriente
                };
                contexto.DeclaracionPJs.Add(declaracion);

                foreach (var item in parametros.Cantones)
                {
                    DistribucionPago distribucion = item.Adapt<DistribucionPago>();
                    distribucion.AnioFiscal = parametros.declaracion.AnioFiscal;
                    distribucion.RUC = parametros.declaracion.RUC;
                    contexto.DistribucionPagos.Add(distribucion);
                }

                await contexto.SaveChangesAsync();
                result.grabado = true;
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public byte[] Generar(DeclaracionRequest data)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    // =========================
                    // HEADER
                    // =========================
                    page.Header().Column(col =>
                    {
                        var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources/logo.png");

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(120);
                                columns.RelativeColumn();
                            });

                            // 🖼️ LOGO (FORMA SEGURA)
                            table.Cell()
                                 .Padding(5)
                                 .AlignMiddle()
                                 .AlignCenter()
                                 .Width(100)
                                 .Image(logoPath);

                            table.Cell()
                                 .Padding(5)
                                 .Background("#F2F2F2")
                                 .Border(1)
                                 .BorderColor("#CCCCCC")
                                 .AlignMiddle()
                                 .AlignCenter()
                                 .Column(c =>
                                 {
                                     c.Item().Text("DECLARACION DE PATENTE")
                                              .FontSize(16)
                                              .Bold()
                                              .AlignCenter();

                                     c.Item().Text("MUNICIPIO ANTONIO ANTE")
                                              .FontSize(13)
                                              .AlignCenter();
                                 });
                        });

                        col.Item()
                           .PaddingTop(5)
                           .LineHorizontal(1)
                           .LineColor("#CCCCCC");
                    });

                    // =========================
                    // CONTENIDO
                    // =========================
                    page.Content()
                    .DefaultTextStyle(x => x.FontSize(8))
                    .Column(col =>
                    {
                        col.Item().PaddingTop(10);
                        col.Spacing(8);
                        col.Item().Column(c =>
                        {
                            c.Item().Text(t =>
                            {
                                t.Span("RAZON SOCIAL: ").Bold();
                                t.Span(data.RazonSocial ?? "");
                            });
                        });

                        // 🟦 RUC - PATENTE
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("RUC: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.RUC ?? "");
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("No. PATENTE: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    //t.Span(data.declaracion.Patente ?? "");
                                    t.Span("--");
                                });
                            });
                        });

                        // 🟦 INICIO ACTIVIDADES - TIPO DECLARACION
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("INICIO DE ACTIVIDADES: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    //t.Span(data.declaracion.FechaInicio?.ToString("dd/MM/yyyy") ?? "");
                                    t.Span("2010");
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("TIPO DECLARACION: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("ORIGINAL");
                                });
                            });
                        });

                        // 🟦 AÑO DECLARACION - AÑO BALANCE
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("AÑO DECLARACION: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    //t.Span(data.declaracion.AnioDeclaracion.ToString());
                                    t.Span("2020");
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("AÑO BALANCE: ").Bold();
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("2021");
                                });
                            });
                        });

                        col.Item()
                           .PaddingTop(10)
                           .LineHorizontal(1)
                           .LineColor("#CCCCCC");

                        col.Item().PaddingTop(10);

                        // 🟦 ACTIVOS - PASIVOS - PATRIMONIO
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("ACTIVO CORRIENTE: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.ActivoCorriente.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("PASIVO CORRIENTE: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.PasivoCorriente.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("ACTIVO NO CORRIENTE: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.ActivoNoCorriente.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("PASIVO NO CORRIENTE: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.PasivoLargoPlazo.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(string.Empty);
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(string.Empty);
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("PASIVO CONTINGENTE: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.PasivoContingente.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("TOTAL DE ACTIVOS: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.TotalActivos.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("TOTAL PASIVOS: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.TotalPasivos.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(string.Empty);
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("PATRIMONIO: ").Bold();
                                });
                            });

                            table.Cell().AlignLeft().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span((data.declaracion.TotalActivos - data.declaracion.TotalPasivos).ToString());
                                });
                            });
                        });

                        col.Item()
                           .PaddingTop(10)
                           .LineHorizontal(1)
                           .LineColor("#CCCCCC");

                        col.Item().PaddingTop(10);

                        // 🟦 INGRESOS - COSTOS GASTOS - UTILIDAD - PERDIDA
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("INGRESOS: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.Ingresos.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("COSTOS Y GASTOS: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.CostosGastos.ToString());
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("UTILIDAD DEL EJERCICIO: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.UtilidadEjercicio3420 >= 0 ? data.declaracion.UtilidadEjercicio3420.ToString() : "0.00");
                                });
                            });

                            table.Cell().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span("PERDIDA DEL EJERCICIO: ").Bold();
                                });
                            });

                            table.Cell().AlignRight().Column(c =>
                            {
                                c.Item().Text(t =>
                                {
                                    t.Span(data.declaracion.UtilidadEjercicio3420 < 0 ? $"({Math.Abs(data.declaracion.UtilidadEjercicio3420):N2})" : "0.00");
                                });
                            });
                        });

                        col.Item().PaddingTop(10);

                        col.Item().Row(row =>
                        {
                            row.RelativeItem()
                               .AlignMiddle()
                               .LineHorizontal(1)
                               .LineColor("#CCCCCC");

                            row.ConstantItem(180)
                               .AlignCenter()
                               .Text("IMPUESTOS GENERADOS")
                               .Bold();

                            row.RelativeItem()
                               .AlignMiddle()
                               .LineHorizontal(1)
                               .LineColor("#CCCCCC");
                        });

                        col.Item().PaddingTop(10);

                        // 🟦 VALORES A PAGAR
                        col.Item().Row(row =>
                        {
                            // =========================
                            // TABLA IZQUIERDA - PATENTE
                            // =========================
                            row.RelativeItem().Column(colLeft =>
                            {
                                colLeft.Item()
                                       .Background("#F2F2F2")
                                       .Border(1)
                                       .Padding(5)
                                       .AlignCenter()
                                       .Text("PATENTE")
                                       .Bold();

                                colLeft.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    //foreach (var item in data.declaracion.ValorPatente) // 👈 ajusta a tu modelo
                                    //{
                                    //    table.Cell().Padding(3).Text(item.Nombre);   // o descripción
                                    //    table.Cell().Padding(3).AlignRight().Text(item.Valor.ToString());
                                    //}
                                    table.Cell().Padding(3).Text("DERECHO PATENTE ANUAL");   // o descripción
                                    table.Cell().Padding(3).AlignRight().Text(data.declaracion.ValorPatente);
                                });
                            });

                            row.ConstantItem(20);

                            // =========================
                            // TABLA DERECHA - 1.5 POR MIL
                            // =========================
                            row.RelativeItem().Column(colRight =>
                            {
                                colRight.Item()
                                        .Background("#F2F2F2")
                                        .Border(1)
                                        .Padding(5)
                                        .AlignCenter()
                                        .Text("1.5 POR MIL")
                                        .Bold();

                                colRight.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    //foreach (var item in data.declaracion.DetalleMil) // 👈 ajusta a tu modelo
                                    //{
                                    //    table.Cell().Padding(3).Text(item.Nombre);
                                    //    table.Cell().Padding(3).AlignRight().Text(item.Valor.ToString());
                                    //}
                                    table.Cell().Padding(3).Text("1.5 X MIL A ACTIVOS TOTALES");
                                    table.Cell().Padding(3).AlignRight().Text(data.declaracion.ValorUnoPorMil);
                                });
                            });
                        });

                        col.Item().PaddingTop(10);

                        col.Item().Row(row =>
                        {
                            row.RelativeItem()
                               .AlignMiddle()
                               .LineHorizontal(1)
                               .LineColor("#CCCCCC");

                            row.ConstantItem(180)
                               .AlignCenter()
                               .Text($"TOTAL A PAGAR: {data.declaracion.ValorPatente + data.declaracion.ValorUnoPorMil} ")
                               .Bold();

                            row.RelativeItem()
                               .AlignMiddle()
                               .LineHorizontal(1)
                               .LineColor("#CCCCCC");
                        });

                        col.Item().PaddingTop(10);

                        // 🟦 DETALLE PAGO X CANTONES
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(colLeft =>
                            {
                                colLeft.Item()
                                       .Background("#F2F2F2")
                                       .Border(1)
                                       .Padding(5)
                                       .AlignCenter()
                                       .Text("DESGLOCE DE CANTONES")
                                       .Bold();

                                colLeft.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    // 🔁 EJEMPLO DINÁMICO
                                    //foreach (var item in data.declaracion.ValorPatente) // 👈 ajusta a tu modelo
                                    //{
                                    //    table.Cell().Padding(3).Text(item.Nombre);   // o descripción
                                    //    table.Cell().Padding(3).AlignRight().Text(item.Valor.ToString());
                                    //}
                                    //HEADER
                                    table.Cell().Padding(3).Text("CANTON");
                                    table.Cell().Padding(3).Text("%CANTON");
                                    table.Cell().Padding(3).Text("BASE IMPONIBLE");
                                    table.Cell().Padding(3).Text("%ACT.ADICIONAL");
                                    table.Cell().Padding(3).Text("BASE IMP ACT. ADICIONAL");
                                    table.Cell().Padding(3).Text("VALOR 1.5");
                                    table.Cell().Padding(3).Text("PAGA EN ANTONIO ANTE");
                                    table.Cell().Padding(3).Text("%DSC EMPLEO JOVEN");
                                    table.Cell().Padding(3).Text("DSC EMPLEO JOVEN");
                                    table.Cell().Padding(3).Text("DSC EMPREN JOVEN");
                                    table.Cell().Padding(3).Text("%DSC TERCERA EDAD");
                                    table.Cell().Padding(3).Text("DSC TERCERA EDAD");
                                    //DATA DINAMICA
                                    foreach (var canton in data.Cantones)
                                    {
                                        table.Cell().Padding(3).Text(canton.NombreCanton);
                                        table.Cell().Padding(3).Text(canton.Porcentaje);
                                        table.Cell().Padding(3).Text("123123");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("203");
                                        table.Cell().Padding(3).Text(canton.PagoAA ? "SI" : "NO");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("0");
                                        table.Cell().Padding(3).Text("0");
                                    }
                                });
                            });
                        });
                    });



                    //// =========================
                    //// FOOTER
                    //// =========================
                    //page.Footer()
                    //    .AlignCenter()
                    //    .Text(txt =>
                    //    {
                    //        txt.Span("Generado el ");
                    //        txt.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    //    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
