using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.commons.Enum;
using gad.generic.components.Components.Several;
using gad.generic.components.Modal;
using System.Net.Http.Json;

namespace gad.aaportal.components.Components.Aplicacion.Formularios
{
    public partial class DeclaracionImpuestos
    {
        BsModal? myModal;
        ToastsServices? Toast { get; set; }
        string modalTitle = string.Empty;
        ModalSize modalSize = ModalSize.ExtraLarge;
        string pdfBase64 = string.Empty;
        private string? razSocial { get; set; }
        private int anio = new();
        bool btnMains = true;
        bool bloqueoFormulario = false;
        ConsultaIngresosEgresosResponse? ingresosEgresos;
        private string LabelResultado =>
                        ingresosEgresos.UtilidadPerdida >= 0
                        ? "Utilidad"
                        : "Pérdida";

        private string ruc = "0190003299001";//SE DEBE TOMAR EL VALOR DE SESION
        private string tipoPersona = "PJ";//SE DEBE TOMAR EL VALOR DE SESION
        //private string ruc = "1002346649001";//SE DEBE TOMAR EL VALOR DE SESION
        //private string tipoPersona = "PN";//SE DEBE TOMAR EL VALOR DE SESION

        protected override async Task OnInitializedAsync()
        {
            var parametros = new { identificacion = ruc, tipoPersona = tipoPersona };
            await ConsultaRazSocial(parametros);
            await ConsultaAnios(parametros);
            await CargaData();
        }

        private async Task ConsultaRazSocial(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaRazSocial", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaRazSocialResponse>();
            razSocial = result.RazSocial;
        }

        private async Task ConsultaAnios(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaAnios", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaAniosResponse>();
            anio = result.anios;
        }

        private async Task CargaData()
        {
            var parametros = new { identificacion = ruc, anio = anio, tipoPersona = tipoPersona };
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaIngresosEgresos", parametros);
            resp.EnsureSuccessStatusCode();
            ingresosEgresos = await resp.Content.ReadFromJsonAsync<ConsultaIngresosEgresosResponse>();
            ingresosEgresos.UtilidadPerdida = ingresosEgresos.Ingresos - ingresosEgresos.CostosGastos;
        }

        private async Task GeneraOrdenPago() { }
    }
}
