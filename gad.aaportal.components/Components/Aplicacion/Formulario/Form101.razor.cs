using gad.aaportal.commons.Dto;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace gad.aaportal.components.Components.Aplicacion.Formulario
{
    public partial class Form101 : ComponentBase
    {
        public string razSocial = string.Empty;
        public string ruc = "1091730940001";
        public List<int> anios = new();
        public int? anioSeleccionado { get; set; }
        ConsultaIngresosEgresosResponse? ingresosEgresos;
        decimal? baseForm = 0;
        CantonesResponse cantones = new CantonesResponse();


        protected override async Task OnInitializedAsync()
        {
            var parametros = new { identificacion = ruc };
            await ConsultaRazSocial(parametros);
            await ConsultaAnios(parametros);
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
                var act = ingresosEgresos.TotalActivo1080 ?? 0m;
                var pas = ingresosEgresos.TotPasivosCorrientes1340 ?? 0m;
                baseForm = (act - pas) * 1.5m / 1000m;
                baseForm = baseForm.HasValue ? Math.Round(baseForm.Value, 2) : 0;
                StateHasChanged();
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

        List<string> selectedCantones = new();

        void RecalcularActivos()
        {
            ingresosEgresos.TotalActivo1080 =
                ingresosEgresos.TotalActivoCorriente470 +
                ingresosEgresos.TotActivoNoCorriente1077;

            StateHasChanged();
        }

        void RecalcularPasivos()
        {
            ingresosEgresos.TotalPasivos1620 =
                ingresosEgresos.TotPasivosCorrientes1340 +
                ingresosEgresos.TotalPasivosLargoPlazo1590;

            StateHasChanged();
        }
    }
}
