using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.commons.Dto.DtoMunicipio;
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
        private int anio = 0;
        bool btnMains = true;
        bool bloqueoFormulario = false;
        decimal multaPatente = 0;
        decimal multaIAT = 0;
        decimal descuentoPatente = 0;
        decimal descuentoIAT = 0;
        ConsultaIngresosEgresosResponse? ingresosEgresos;
        CantonesResponse cantones;
        CalcularImpuestoPatenteDtoResult impuestoPatente;
        CalcularImpuestoIatDtoResult impuestoIAT;
        private System.Timers.Timer? _debounceTimer;

        decimal TotalPasivos =>
            _pasivoCorriente + _pasivoNoCorriente + _pasivoContingente;

        private string LabelResultado =>
                                ingresosEgresos.UtilidadPerdida >= 0
                                ? "Utilidad"
                                : "Pérdida";

        private string identificacion = "0190003299001";//SE DEBE TOMAR EL VALOR DE SESION
        private string tipoPersona = "PJ";//SE DEBE TOMAR EL VALOR DE SESION
        //private string ruc = "1002346649001";//SE DEBE TOMAR EL VALOR DE SESION
        //private string tipoPersona = "PN";//SE DEBE TOMAR EL VALOR DE SESION

        private decimal _pasivoCorriente;
        public decimal PasivoCorriente
        {
            get => _pasivoCorriente;
            set
            {
                if (_pasivoCorriente != value)
                {
                    _pasivoCorriente = value;
                    OnPasivosChanged("PC");
                }
            }
        }

        private decimal _pasivoNoCorriente;
        public decimal PasivoNoCorriente
        {
            get => _pasivoNoCorriente;
            set
            {
                if (_pasivoNoCorriente != value)
                {
                    _pasivoNoCorriente = value;
                    OnPasivosChanged("PNC");
                }
            }
        }

        private decimal _pasivoContingente;
        public decimal PasivoContingente
        {
            get => _pasivoContingente;
            set
            {
                if (_pasivoContingente != value)
                {
                    _pasivoContingente = value;
                    OnPasivosChanged("PCT");
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var parametros = new { identificacion = identificacion, tipoPersona = tipoPersona };
            await ConsultaCantones();
            await ConsultaRazSocial(parametros);
            await ConsultaAnios();
            await CargaData();
            await ValorPatente();
            multaPatente = await CalculaMulta(impuestoPatente.Data.ValorImpuesto);
            descuentoPatente = await CalculaDescuentoEdad((ingresosEgresos.TotalActivos - TotalPasivos), impuestoPatente.Data.ValorImpuesto, "PAT");
            await ImpuestoActivosTotales();
            multaIAT = await CalculaMulta(impuestoIAT.Data.ImpuestoIat);
            descuentoIAT = await CalculaDescuentoEdad((ingresosEgresos.TotalActivos - PasivoCorriente), impuestoIAT.Data.ImpuestoIat, "IAT");
        }

        private async Task ConsultaRazSocial(object parametros)
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaRazSocial", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultaRazSocialResponse>();
            razSocial = result.RazSocial;
        }

        private async Task ConsultaAnios()
        {
            var parametros = new { ruc = identificacion };
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var resp = await http.PostAsJsonAsync("api/SpMunicipio/consultarAnioAdeuda", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsultarAnioAdeudaDtoResult>();
            anio = result.Data.Anio;
        }

        private async Task<decimal> CalculaMulta(decimal valor)
        {
            if (impuestoPatente.Data.ValorImpuesto != 0)
            {
                var parametros = new { ruc = identificacion, anioDeclaracion = anio, valor = valor };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/SpMunicipio/calcularMulta", parametros);
                resp.EnsureSuccessStatusCode();
                var result = await resp.Content.ReadFromJsonAsync<CalcularMultaDtoResult>();
                return result.Data.Multa;
            }
            else
                return 0;
        }

        private async Task<decimal> CalculaDescuentoEdad(decimal? basePatrimonio, decimal valorImpuesto, string TipoImpuesto)
        {
            if (impuestoPatente.Data.ValorImpuesto != 0)
            {
                var parametros = new
                {
                    BasePatrimonio = basePatrimonio,
                    Ingresos = ingresosEgresos.Ingresos,
                    ruc = identificacion,
                    anio = anio,
                    valorImpuesto = valorImpuesto,
                    tipoImpuesto = TipoImpuesto
                };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/SpMunicipio/calcularTerceraEdad", parametros);
                resp.EnsureSuccessStatusCode();
                var result = await resp.Content.ReadFromJsonAsync<CalcularTerceraEdadDtoResult>();
                return result.Data.ValorDescuento;
            }
            else
                return 0;
        }

        private async Task CargaData()
        {
            var parametros = new { identificacion = identificacion, anio = (anio - 1), tipoPersona = tipoPersona };
            if (!string.IsNullOrEmpty(identificacion) || anio != 0 || !string.IsNullOrEmpty(tipoPersona))
            {
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/Consultas/ConsultaIngresosEgresos", parametros);
                // 👇 manejar status primero
                if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ingresosEgresos = null;
                    return;
                }
                resp.EnsureSuccessStatusCode();
                ingresosEgresos = await resp.Content.ReadFromJsonAsync<ConsultaIngresosEgresosResponse>();
                if (ingresosEgresos != null)
                {
                    ingresosEgresos.UtilidadPerdida = ingresosEgresos.Ingresos - ingresosEgresos.CostosGastos;
                    // ⚠️ cuidado aquí con los nulls
                    PasivoCorriente = ingresosEgresos.PasivoCorriente ?? 0;
                    PasivoNoCorriente = ingresosEgresos.PasivoNoCorriente ?? 0;
                }
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

        private async Task ValorPatente()
        {
            if (ingresosEgresos != null)
            {
                var parametros = new { baseImponible = ingresosEgresos.TotalActivos - TotalPasivos };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/SpMunicipio/calcularImpuestoPatente", parametros);
                resp.EnsureSuccessStatusCode();
                impuestoPatente = await resp.Content.ReadFromJsonAsync<CalcularImpuestoPatenteDtoResult>();
            }
        }

        private void OnPasivosChanged(string origen)
        {
            _debounceTimer?.Stop();
            _debounceTimer?.Dispose();

            _debounceTimer = new System.Timers.Timer(500); // espera 500ms
            _debounceTimer.Elapsed += async (_, __) =>
            {
                _debounceTimer?.Stop();

                await InvokeAsync(async () =>
                {
                    await ValorPatente();
                    multaPatente = await CalculaMulta(impuestoPatente.Data.ValorImpuesto);
                    descuentoPatente = await CalculaDescuentoEdad((ingresosEgresos.TotalActivos - TotalPasivos), impuestoPatente.Data.ValorImpuesto, "PAT");
                    if (origen == "PC")
                    {
                        await ImpuestoActivosTotales();
                        multaIAT = await CalculaMulta(impuestoIAT.Data.ImpuestoIat);
                        descuentoIAT = await CalculaDescuentoEdad((ingresosEgresos.TotalActivos - PasivoCorriente), impuestoIAT.Data.ImpuestoIat, "IAT");
                    }
                    StateHasChanged();
                });
            };

            _debounceTimer.Start();
        }

        private async Task ImpuestoActivosTotales()
        {
            if (ingresosEgresos != null)
            {
                var parametros = new { baseImponible = ingresosEgresos.TotalActivos - PasivoCorriente };
                using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
                var resp = await http.PostAsJsonAsync("api/SpMunicipio/calcularImpuestoIat", parametros);
                resp.EnsureSuccessStatusCode();
                impuestoIAT = await resp.Content.ReadFromJsonAsync<CalcularImpuestoIatDtoResult>();
            }
        }
        private async Task GeneraOrdenPago() { }
    }
}
