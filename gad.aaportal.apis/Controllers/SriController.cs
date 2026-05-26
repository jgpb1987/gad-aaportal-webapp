using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SriController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SriController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("contribuyente/{ruc}")]
        public async Task<IActionResult> ObtenerContribuyentePorRuc(string ruc)
        {
            if (string.IsNullOrWhiteSpace(ruc))
                return BadRequest("El RUC es obligatorio.");

            var client = _httpClientFactory.CreateClient("SRI");
            var endpoint =
                $"rest/ConsolidadoContribuyente/obtenerPorNumerosRuc?ruc={Uri.EscapeDataString(ruc)}";

            try
            {
                using var response = await client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "El SRI respondió con error.");

                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(502, $"Error al consumir SRI: {ex.Message}");
            }
        }

        [HttpGet("establecimientos/{ruc}")]
        public async Task<IActionResult> ConsultarEstablecimientosPorRuc(string ruc)
        {
            if (string.IsNullOrWhiteSpace(ruc))
                return BadRequest("El RUC es obligatorio.");

            var client = _httpClientFactory.CreateClient("SRI");

            var endpoint =
                $"rest/Establecimiento/consultarPorNumeroRuc?numeroRuc={Uri.EscapeDataString(ruc)}";

            try
            {
                using var response = await client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "El SRI respondió con error.");

                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(502, $"Error al consumir SRI: {ex.Message}");
            }
        }
    }
}
