using gad.aaportal.commons.Base;

namespace gad.aaportal.commons.Dto
{
    public class ConsultaIdentificacionRequest
    {
        public string Identificacion { get; set; } = string.Empty;
    }

    public class ConsultaIngresosEgresosRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public int anio { get; set; }
    }

    public class ConsultaAniosResponse : BaseResult
    {
        public List<int> anios { get; set; } = new List<int>();
    }

    public class ConsultaRazSocialResponse : BaseResult
    {
        public string RazSocial { get; set; } = string.Empty;
    }
    public class ConsultaIngresosEgresosResponse : BaseResult
    {
        public decimal? TotalActivoCorriente470 { get; set; }
        public decimal? TotActivoNoCorriente1077 { get; set; }
        public decimal? TotalActivo1080 { get; set; }
        public decimal? TotPasivosCorrientes1340 { get; set; }
        public decimal? TotalPasivosLargoPlazo1590 { get; set; }
        public decimal? TotalPasivos1620 { get; set; }
        public decimal? TotalIngresos1930 { get; set; }
        public decimal? TotasCostosGastos3380 { get; set; }
        public decimal? UtilidadEjercicio3420 { get; set; }
    }

    public class Canton
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string NombreCanton { get; set; }
    }

    public class CantonesResponse : BaseResult
    {
        public List<Canton> Cantones { get; set; }
    }

    public class TarifaImpositiva
    {
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Excedente { get; set; }
    }

    public class ListaTarifas : BaseResult
    {
        public List<TarifaImpositiva> tarifas { get; set; }
    }
}
