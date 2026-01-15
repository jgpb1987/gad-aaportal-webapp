using gad.aaportal.commons.Dto;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Canton = gad.aaportal.commons.Dto.Canton;

namespace gad.aaportal.components.Components.Aplicacion.Formulario
{
    public partial class Form101 : ComponentBase
    {
        private string ruc = "1091730940001";//SE DEBE TOMAR EL VALOR DE SESION

        private string? razSocial { get; set; }
        private List<int> anios = new();
        private int? anioSeleccionado { get; set; }
        private decimal? baseForm = 0;
        private ListaTarifas tarifas = new();
        private HashSet<string> collapsedStates = new();
        private string LabelResultado =>
                        declaracion.UtilidadPerdida >= 0
                        ? "Utilidad"
                        : "Pérdida";

        ConsultaIngresosEgresosResponse? ingresosEgresos;
        DeclaracionData declaracion = new DeclaracionData();
        CantonesResponse cantones = new CantonesResponse();

        protected override async Task OnInitializedAsync()
        {
            var parametros = new { identificacion = ruc };
            await ConsultaRazSocial(parametros);
            await ConsultaAnios(parametros);
            await ConsultaTarifas();
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
            if (anioSeleccionado.HasValue)
            {
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
            }
            else
            {
                ingresosEgresos = null;
            }
        }
        private async Task ConsultaCantones()
        {
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

        private void ToggleCollapse(string provincia)
        {
            if (!collapsedStates.Add(provincia))
                collapsedStates.Remove(provincia);
        }

        protected override void OnParametersSet()
        {
            foreach (var c in cantones.Cantones)
            {
                if (c.Id == 116)
                {
                    c.Seleccionado = true;
                    c.Porcentaje = 100;
                }
            }
        }

        void ToggleCanton(Canton canton, object? value)
        {
            bool selected = (bool)value;
            canton.Seleccionado = selected;
            if (!selected)
            {
                canton.Porcentaje = 0;
            }
        }
    }
}
