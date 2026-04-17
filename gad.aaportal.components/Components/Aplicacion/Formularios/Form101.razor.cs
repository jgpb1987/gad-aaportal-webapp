using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.commons.Enum;
using gad.generic.components.Components.Several;
using gad.generic.components.Modal;
using Mapster;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace gad.aaportal.components.Components.Aplicacion.Formularios
{
    public partial class Form101 : ComponentBase
    {
        private string ruc = "0190003299001";//SE DEBE TOMAR EL VALOR DE SESION
        private string tipoPersona = "PJ";//SE DEBE TOMAR EL VALOR DE SESION
        //private string ruc = "1002346649001";//SE DEBE TOMAR EL VALOR DE SESION
        //private string tipoPersona = "PN";//SE DEBE TOMAR EL VALOR DE SESION

        private string? razSocial { get; set; }
        private int anio = new();
        private decimal? baseForm = 0;
        private decimal impuesto = 0;
        private decimal excedente = 0;
        bool btnMains = true;
        bool bloqueoFormulario = false;
        string modalTitle = string.Empty;
        ModalSize modalSize = ModalSize.ExtraLarge;
        RenderFragment? modalMessage;
        private decimal valor_excedente = 0;
        private string LabelResultado =>
                        declaracion.UtilidadEjercicio3420 >= 0
                        ? "Utilidad"
                        : "Pérdida";

        BsModal? myModal;
        ToastsServices? Toast { get; set; }
        ConsultaIngresosEgresosResponse? ingresosEgresos;
        DeclaracionData declaracion;
        CantonesResponse cantones;
        ListaTarifas tarifas = new();
        TasasAdministrativas tasas = new();

        protected override async Task OnInitializedAsync()
        {
            var parametros = new { identificacion = ruc, tipoPersona = tipoPersona };
            await ConsultaRazSocial(parametros);
            await ConsultaCantones();
            await ConsultaTarifas();
            await ConsultaAnios(parametros);
        }

        private async Task ConsultaAnios(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaAnios", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaAniosResponse>();
            anio = result.anios;
            await OnAnioChanged();
        }

        private async Task ConsultaDeclaracion()
        {
            var parametros = new { RUC = ruc, anioFiscal = anio, tipoPersona = tipoPersona };
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaDeclaracion", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<DeclaracionResponse>();
            if (result.declaracion != null)
            {
                bloqueoFormulario = true;
                declaracion = result.declaracion;
                foreach (var item in result.distribuciones)
                {
                    var canton = cantones.Cantones.FirstOrDefault(c => c.Id == item.Id);
                    canton.Seleccionado = true;
                    canton.PagoAA = item.PagoAA;
                    canton.Porcentaje = item.Porcentaje;
                }
            }
            else
            {
                bloqueoFormulario = false;
                cantones.Cantones.ForEach(c =>
                {
                    c.Seleccionado = false;
                    c.PagoAA = false;
                    c.Porcentaje = 0;
                });
                var aa = cantones.Cantones.Where(c => c.Id == 116).FirstOrDefault();
                aa.Seleccionado = true;
                aa.PagoAA = true;
                aa.Porcentaje = 100;
            }
        }

        private async Task ConsultaRazSocial(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaRazSocial", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaRazSocialResponse>();
            razSocial = result.RazSocial;
        }

        private async Task OnAnioChanged()
        {
            declaracion = new DeclaracionData();
            declaracion.PropertyChanged += async (_, args) =>
            {
                if (args.PropertyName == nameof(DeclaracionData.TotalActivos) ||
                    args.PropertyName == nameof(DeclaracionData.TotalPasivos) ||
                    args.PropertyName == nameof(DeclaracionData.UtilidadEjercicio3420))
                {
                    CalcularPatenteDeclarada();
                    StateHasChanged();
                }
            };
            if (anio != 0)
            {
                await ConsultaDeclaracion();

                btnMains = false;
                var parametros = new { identificacion = ruc, anio = anio, tipoPersona = tipoPersona };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaIngresosEgresos", parametros);
                resp.EnsureSuccessStatusCode();
                ingresosEgresos = await resp.Content.ReadFromJsonAsync<ConsultaIngresosEgresosResponse>();
                var act = ingresosEgresos?.TotalActivos ?? 0m;
                var pas = ingresosEgresos?.PasivoCorriente ?? 0m;
                baseForm = (act - pas) * 1.5m / 1000m;
                baseForm = baseForm.HasValue ? Math.Round(baseForm.Value, 2) : 0;
                StateHasChanged();
                CalcularPatenteSugerido();
                await UsarSugeridos();
            }
            else
            {
                btnMains = true;
                ingresosEgresos = null;
            }
        }
        private async Task ConsultaCantones()
        {
            cantones = new();
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.GetAsync("api/Consultas/ConsultaCantones");
            resp.EnsureSuccessStatusCode();
            cantones = await resp.Content.ReadFromJsonAsync<CantonesResponse>();
            StateHasChanged();
        }

        private async Task ConsultaTarifas()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.GetAsync("api/Consultas/ConsultaTarifas");
            resp.EnsureSuccessStatusCode();
            tarifas = await resp.Content.ReadFromJsonAsync<ListaTarifas>();
            StateHasChanged();
        }

        private async Task ConsultarTasasAdministrativas()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.GetAsync("api/Consultas/ConsultaTasasAdministrativas");
            resp.EnsureSuccessStatusCode();
            tasas = await resp.Content.ReadFromJsonAsync<TasasAdministrativas>();
            StateHasChanged();
        }

        private async Task GeneraOrdenPago()
        {
            if (cantones.Cantones.Where(c => c.Seleccionado).Sum(c => c.Porcentaje) < 100)
            {
                Toast.ShowMessage("error", "Distribución de pago", "La suma de porcentajes debe ser del 100%");
                return;
            }

            await ConsultarTasasAdministrativas();

            var porcentajeXPagar = cantones.Cantones
                .Where(c => c.PagoAA)
                .Sum(c => c.Porcentaje);

            modalTitle = "Confirmación de Pago";

            DeclaracionRequest parametros = new DeclaracionRequest();
            parametros.declaracion = declaracion;
            declaracion.RUC = ruc;
            declaracion.AnioFiscal = anio;
            parametros.RazonSocial = razSocial;

            parametros.Cantones = cantones.Cantones
                .Where(c => c.Seleccionado)
                .ToList();

            await GeneraPdf(parametros);

            modalMessage = builder =>
            {
                var valor15 = Math.Round((declaracion.ValorUnoPorMil * porcentajeXPagar / 100), 2);

                var total = declaracion.ValorPatente
                    + valor15
                    + tasas.Tasas.Sum(t => t.Valor);

                builder.AddMarkupContent(0, $@"
                    <div class='text-center mb-3'>
                        <div style='font-size: 2rem;'>💰</div>
                        <h5 class='fw-bold text-success'>Resumen de Pago</h5>
                        <small class='text-muted'>Verifique antes de confirmar</small>
                    </div>
                    <div class='card border-0 shadow-sm mb-3'>
                        <div class='card-body'>
                            <div class='d-flex justify-content-between mb-2'>
                                <span>Valor Patente</span>
                                <strong>${declaracion.ValorPatente:N2}</strong>
                            </div>
                            <div class='d-flex justify-content-between mb-2'>
                                <span>1.5 x Mil</span>
                                <strong>${valor15:N2}</strong>
                            </div>
                            <hr />
                            {string.Join("", tasas.Tasas.Select(t => $@"
                                <div class='d-flex justify-content-between mb-1'>
                                    <span>{t.Concepto}</span>
                                    <span>${t.Valor:N2}</span>
                                </div>
                            "))}
                            <hr />
                            <div class='d-flex justify-content-between fw-bold fs-5 text-primary'>
                                <span>Total</span>
                                <span>${total:N2}</span>
                            </div>
                        </div>
                    </div>
                    <div class='text-center'>
                        <span class='text-muted'>¿Desea confirmar esta declaración?</span>
                    </div>");
            };

            bool confirm = await myModal.ShowAsync();

            if (confirm)
            {
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/Declaracion/DeclaracionPJ", parametros);
                resp.EnsureSuccessStatusCode();

                var declaracionResult = await resp.Content.ReadFromJsonAsync<SaveDeclaracionPJResult>();

                if (declaracionResult.grabado)
                {
                    bloqueoFormulario = true;

                    Toast.ShowMessage("succes",
                        "Declaración Procesada",
                        "Su declaración ha sido procesada correctamente");
                }
                else
                {
                    Toast.ShowMessage("error",
                        "Declaración No Procesada",
                        "Ocurrió un error, inténtelo nuevamente");
                }
            }
        }

        private async Task UsarSugeridos()
        {
            declaracion = ingresosEgresos.Adapt<DeclaracionData>();
            declaracion.PasivoLargoPlazo = ingresosEgresos.PasivoNoCorriente.Value;
            declaracion.PropertyChanged += async (_, args) =>
            {
                if (args.PropertyName == nameof(DeclaracionData.TotalActivos) ||
                    args.PropertyName == nameof(DeclaracionData.TotalPasivos) ||
                    args.PropertyName == nameof(DeclaracionData.UtilidadEjercicio3420))
                {
                    CalcularPatenteDeclarada();
                    StateHasChanged();
                }
            };
            CalcularPatenteDeclarada();
            StateHasChanged();
        }

        private void CalcularPatenteSugerido()
        {
            decimal patrimonio = Math.Max(ingresosEgresos.TotalActivos.Value - ingresosEgresos.TotalPasivos.Value, 0m);
            decimal porcentajeAA = cantones.Cantones.Where(c => c.Id == 116).FirstOrDefault().Porcentaje / 100m;
            decimal baseCalculo = patrimonio * porcentajeAA;
            var tarifa = tarifas.tarifas.Where(t => t.Desde <= baseCalculo && t.Hasta >= baseCalculo).FirstOrDefault();
            impuesto = tarifa.Impuesto;
            excedente = baseCalculo - tarifa.Desde;
            valor_excedente = excedente * tarifa.Excedente;
            ingresosEgresos.ValorPatente = Math.Round(impuesto + valor_excedente, 2);
            if (!LabelResultado.Equals("Utilidad"))
                ingresosEgresos.ValorPatente = ingresosEgresos.ValorPatente / 2;
        }

        private void CalcularPatenteDeclarada()
        {
            decimal patrimonio = Math.Max(declaracion.TotalActivos - declaracion.TotalPasivos, 0m);
            decimal porcentajeAA = cantones.Cantones.Where(c => c.Id == 116).FirstOrDefault().Porcentaje / 100m;
            decimal baseCalculo = patrimonio * porcentajeAA;
            var tarifa = tarifas.tarifas.Where(t => t.Desde <= baseCalculo && t.Hasta >= baseCalculo).FirstOrDefault();
            impuesto = tarifa.Impuesto;
            excedente = baseCalculo - tarifa.Desde;
            valor_excedente = excedente * tarifa.Excedente;
            declaracion.ValorPatente = Math.Round(impuesto + valor_excedente, 2);

            foreach (var item in cantones.Cantones)
            {
                if (item.Seleccionado)
                    item.Valor = declaracion.ValorUnoPorMil * item.Porcentaje / 100;
            }
        }

        private void ValidarPasivo()
        {
            if (declaracion.PasivoCorriente > ingresosEgresos.PasivoCorriente)
                declaracion.PasivoCorriente = ingresosEgresos.PasivoCorriente.Value;

            if (declaracion.PasivoCorriente < 0)
                declaracion.PasivoCorriente = 0;
        }

        private void AplicaDescuento(ChangeEventArgs e)
        {
            if ((bool)e.Value)
            {
                declaracion.ValorPatente = declaracion.ValorPatente / 2;
            }
            else
            {
                declaracion.ValorPatente = ingresosEgresos.ValorPatente.Value;
            }
        }

        string pdfBase64 = string.Empty;
        private async Task GeneraPdf(DeclaracionRequest request)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Declaracion/OrdenPagoPdf", request);
            resp.EnsureSuccessStatusCode();
            var pdfBytes = await resp.Content.ReadAsByteArrayAsync();
            pdfBase64 = Convert.ToBase64String(pdfBytes);
        }
    }
}
