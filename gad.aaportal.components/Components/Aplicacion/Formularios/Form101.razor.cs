using gad.aaportal.commons.Dto;
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
        private string ruc = "1091730940001";//SE DEBE TOMAR EL VALOR DE SESION

        private string? razSocial { get; set; }
        private List<int> anios = new();
        private int? anioSeleccionado { get; set; }
        private decimal? baseForm = 0;
        private decimal impuesto = 0;
        private decimal excedente = 0;
        bool btnMains = true;
        string modalTitle = string.Empty;
        ModalSize modalSize;
        MarkupString modalMessage;
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
            var parametros = new { identificacion = ruc };
            await ConsultaRazSocial(parametros);
            await ConsultaAnios(parametros);
            await ConsultaTarifas();
            await ConsultarTasasAdministrativas();
            await ConsultaCantones();
        }

        private async Task ConsultaAnios(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaAnios", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaAniosResponse>();
            anios = result.anios;
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
                if (args.PropertyName == nameof(DeclaracionData.TotalActivo1080) ||
                    args.PropertyName == nameof(DeclaracionData.TotalPasivos1620) ||
                    args.PropertyName == nameof(DeclaracionData.UtilidadEjercicio3420))
                {
                    CalcularPatenteDeclarada();
                    StateHasChanged();
                }
            };
            if (anioSeleccionado.HasValue)
            {
                btnMains = false;
                var parametros = new { identificacion = ruc, anio = anioSeleccionado };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaIngresosEgresos", parametros);
                resp.EnsureSuccessStatusCode();
                ingresosEgresos = await resp.Content.ReadFromJsonAsync<ConsultaIngresosEgresosResponse>();
                var act = ingresosEgresos?.TotalActivo1080 ?? 0m;
                var pas = ingresosEgresos?.TotPasivosCorrientes1340 ?? 0m;
                baseForm = (act - pas) * 1.5m / 1000m;
                baseForm = baseForm.HasValue ? Math.Round(baseForm.Value, 2) : 0;
                StateHasChanged();
                CalcularPatenteSugerido();
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
            var porcentajeXPagar = cantones.Cantones.Where(c => c.PagoAA).Sum(c => c.Porcentaje);

            modalTitle = "Valores Declarados";
            var tasasHtml = string.Join("<br>",
                                tasas.Tasas.Select(t => $"<b>{t.Concepto}:</b> ${t.Valor}")
                            );

            modalMessage = (MarkupString)($@"
                                De acuerdo a sus datos declarados usted deberá pagar: <br>
                                <b>Valor Patente:</b> ${declaracion.ValorPatente}<br>
                                <b>Valor 1.5 x Mil:</b> ${Math.Round((declaracion.ValorUnoPorMil * porcentajeXPagar / 100), 2)}<br>
                                {tasasHtml} <br>
                                <b>TOTAL: ${(declaracion.ValorPatente
                                    + Math.Round((declaracion.ValorUnoPorMil * porcentajeXPagar / 100), 2)
                                    + tasas.Tasas.Sum(t=>t.Valor))}</b><br>
                                ¿Acepta los valores?");

            modalSize = ModalSize.Default;
            bool confirm = await myModal.ShowAsync();
            if (confirm)
            {
                DeclaracionRequest parametros = new DeclaracionRequest();
                parametros.declaracion = declaracion;
                declaracion.RUC = ruc;
                declaracion.AnioFiscal = anioSeleccionado.Value;
                parametros.Cantones = cantones.Cantones.Where(c => c.Seleccionado).ToList();
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/Declaracion/DeclaracionPJ", parametros);
                resp.EnsureSuccessStatusCode();
                var declaracionResult = await resp.Content.ReadFromJsonAsync<SaveDeclaracionPJResult>();
            }
        }

        private async Task LimpiarForm()
        {
            modalTitle = "Limpiar Datos";
            modalMessage = (MarkupString)("¿Seguro de borrar datos?");
            modalSize = ModalSize.Small;
            bool confirm = await myModal.ShowAsync();
            if (confirm)
            {
                declaracion = new();
                declaracion.PropertyChanged += async (_, args) =>
                {
                    if (args.PropertyName == nameof(DeclaracionData.TotalActivo1080) ||
                        args.PropertyName == nameof(DeclaracionData.TotalPasivos1620) ||
                        args.PropertyName == nameof(DeclaracionData.UtilidadEjercicio3420))
                    {
                        CalcularPatenteDeclarada();
                        StateHasChanged();
                    }
                };
            }
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

        private async Task UsarSugeridos()
        {
            declaracion = ingresosEgresos.Adapt<DeclaracionData>();
            declaracion.PropertyChanged += async (_, args) =>
            {
                if (args.PropertyName == nameof(DeclaracionData.TotalActivo1080) ||
                    args.PropertyName == nameof(DeclaracionData.TotalPasivos1620) ||
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
            decimal patrimonio = Math.Max(ingresosEgresos.TotalActivo1080.Value - ingresosEgresos.TotalPasivos1620.Value, 0m);
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
            decimal patrimonio = Math.Max(declaracion.TotalActivo1080 - declaracion.TotalPasivos1620, 0m);
            decimal porcentajeAA = cantones.Cantones.Where(c => c.Id == 116).FirstOrDefault().Porcentaje / 100m;
            decimal baseCalculo = patrimonio * porcentajeAA;
            var tarifa = tarifas.tarifas.Where(t => t.Desde <= baseCalculo && t.Hasta >= baseCalculo).FirstOrDefault();
            impuesto = tarifa.Impuesto;
            excedente = baseCalculo - tarifa.Desde;
            valor_excedente = excedente * tarifa.Excedente;
            declaracion.ValorPatente = Math.Round(impuesto + valor_excedente, 2);
            if (!LabelResultado.Equals("Utilidad"))
                declaracion.ValorPatente = declaracion.ValorPatente / 2;

            foreach (var item in cantones.Cantones)
            {
                if (item.Seleccionado && item.PagoAA)
                    item.Valor = declaracion.ValorUnoPorMil * item.Porcentaje / 100;
            }
        }
    }
}
