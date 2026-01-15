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
        public bool Seleccionado { get; set; }
        public decimal Porcentaje { get; set; }
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

    public class DeclaracionData
    {
        public string RUC { get; set; }
        public string AnioFiscal { get; set; }
        private decimal _Acorriente = 0;
        private decimal _Anocorriente = 0;
        public decimal TotalActivoCorriente470
        {
            get => _Acorriente;
            set
            {
                _Acorriente = value;
                RecalculateA();
                RecalculatePatente();
            }
        }
        public decimal TotActivoNoCorriente1077
        {
            get => _Anocorriente;
            set
            {
                _Anocorriente = value;
                RecalculateA();
                RecalculatePatente();
            }
        }
        public decimal TotalActivo1080 { get; private set; } = 0;
        private void RecalculateA()
        {
            TotalActivo1080 = _Acorriente + _Anocorriente;
        }
        private decimal _Pcorriente = 0;
        private decimal _PlargoPlazo = 0;
        private decimal _Pcontingente = 0;
        public decimal TotPasivosCorrientes1340
        {
            get => _Pcorriente;
            set
            {
                _Pcorriente = value;
                RecalculateP();
                RecalculatePatente();
            }
        }
        public decimal TotalPasivosLargoPlazo1590
        {
            get => _PlargoPlazo;
            set
            {
                _PlargoPlazo = value;
                RecalculateP();
            }
        }
        public decimal TotalPasivosContingente
        {
            get => _Pcontingente;
            set
            {
                _Pcontingente = value;
                RecalculateP();
            }
        }

        public decimal TotalPasivos1620 { get; private set; } = 0;
        private void RecalculateP()
        {
            TotalPasivos1620 = _Pcorriente + _PlargoPlazo + _Pcontingente;
        }
        public decimal ValorPatente { get; set; } = 0;
        private void RecalculatePatente()
        {
            ValorPatente = Math.Round((TotalActivo1080 - TotPasivosCorrientes1340) * 1.5m / 1000, 2);
            ValorPatente = Math.Max(ValorPatente, 1m);
        }
        private decimal _ingresos = 0;
        public decimal Ingresos
        {
            get => _ingresos;
            set
            {
                _ingresos = value;
                RecalculateUtilidad();
            }
        }
        private decimal _egresos = 0;
        public decimal Egresos
        {
            get => _egresos;
            set
            {
                _egresos = value;
                RecalculateUtilidad();
            }

        }
        public decimal UtilidadPerdida { get; set; } = 0;
        private void RecalculateUtilidad()
        {
            UtilidadPerdida = Ingresos - Egresos;
        }
    }

}
