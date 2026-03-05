using gad.aaportal.commons.Base;
using System.ComponentModel;

namespace gad.aaportal.commons.Dto.Aplicacion
{
    public class ConsultaIdentificacionRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public string TipoPersona { get; set; } = string.Empty;
    }

    public class ConsultaIngresosEgresosRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public string TipoPersona { get; set; } = string.Empty;
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
        public decimal? ActivoCorriente { get; set; }
        public decimal? ActivoNoCorriente { get; set; }
        public decimal? TotalActivos { get; set; }
        public decimal? PasivoCorriente { get; set; }
        public decimal? PasivoNoCorriente { get; set; }
        public decimal? PasivoContingente { get; set; }
        public decimal? TotalPasivos { get; set; }
        public decimal? Ingresos { get; set; }
        public decimal? CostosGastos { get; set; }
        public decimal? UtilidadPerdida { get; set; }
        public decimal? ValorPatente { get; set; }
    }

    public class Canton
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string NombreCanton { get; set; }
        public bool Seleccionado { get; set; }
        public decimal Porcentaje { get; set; }
        public bool PagoAA { get; set; }
        public decimal Valor { get; set; }
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

    public class DeclaracionData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Notify(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string RUC { get; set; }
        public int AnioFiscal { get; set; }

        private decimal _Acorriente = 0;
        private decimal _Anocorriente = 0;

        public decimal ActivoCorriente
        {
            get => _Acorriente;
            set
            {
                _Acorriente = value;
                RecalculateA();
                RecalculateUnoPuntoCinco();
                Notify(nameof(ActivoCorriente));
            }
        }

        public decimal ActivoNoCorriente
        {
            get => _Anocorriente;
            set
            {
                _Anocorriente = value;
                RecalculateA();
                RecalculateUnoPuntoCinco();
                Notify(nameof(ActivoNoCorriente));
            }
        }

        public decimal TotalActivos { get; private set; } = 0;
        private void RecalculateA()
        {
            TotalActivos = _Acorriente + _Anocorriente;
            Notify(nameof(TotalActivos));
        }

        private decimal _Pcorriente = 0;
        private decimal _PlargoPlazo = 0;
        private decimal _Pcontingente = 0;

        public decimal PasivoCorriente
        {
            get => _Pcorriente;
            set
            {
                _Pcorriente = value;
                RecalculateP();
                RecalculateUnoPuntoCinco();
                Notify(nameof(PasivoCorriente));
            }
        }

        public decimal PasivoLargoPlazo
        {
            get => _PlargoPlazo;
            set
            {
                _PlargoPlazo = value;
                RecalculateP();
                Notify(nameof(PasivoLargoPlazo));
            }
        }

        public decimal PasivoContingente
        {
            get => _Pcontingente;
            set
            {
                _Pcontingente = value;
                RecalculateP();
                Notify(nameof(PasivoContingente));
            }
        }

        public decimal TotalPasivos { get; private set; } = 0;
        private void RecalculateP()
        {
            TotalPasivos = _Pcorriente + _PlargoPlazo + _Pcontingente;
            Notify(nameof(TotalPasivos));
        }

        public decimal ValorUnoPorMil { get; private set; } = 0;
        private void RecalculateUnoPuntoCinco()
        {
            ValorUnoPorMil = Math.Round((TotalActivos - PasivoCorriente) * 1.5m / 1000, 2);
            ValorUnoPorMil = Math.Max(ValorUnoPorMil, 0m);
            Notify(nameof(ValorUnoPorMil));
        }

        private decimal _ingresos = 0;
        public decimal Ingresos
        {
            get => _ingresos;
            set
            {
                _ingresos = value;
                RecalculateUtilidad();
                Notify(nameof(Ingresos));
            }
        }

        private decimal _egresos = 0;
        public decimal CostosGastos
        {
            get => _egresos;
            set
            {
                _egresos = value;
                RecalculateUtilidad();
                Notify(nameof(CostosGastos));
            }
        }

        public decimal UtilidadEjercicio3420 { get; private set; } = 0;
        private void RecalculateUtilidad()
        {
            UtilidadEjercicio3420 = Ingresos - CostosGastos;
            Notify(nameof(UtilidadEjercicio3420)); // ← agregado aquí
        }

        public decimal ValorPatente { get; set; } = 0;
    }

    public class DeclaracionRequest
    {
        public DeclaracionData declaracion { get; set; }
        public List<Canton> Cantones { get; set; } = new List<Canton>();
    }

    public class SaveDeclaracionPJResult : BaseResult
    {
        public bool grabado { get; set; } = false;
    }

    public class TasaAdministrativa
    {
        public string Concepto { get; set; }
        public decimal Valor { get; set; }
    }

    public class TasasAdministrativas : BaseResult
    {
        public List<TasaAdministrativa> Tasas { get; set; } = new();
    }

    public class ConsultaDeclaracionRequest
    {
        public string RUC { get; set; }
        public int AnioFiscal { get; set; }
    }

    public class DistribucionPagoDto
    {
        public int Id { get; set; }
        public bool PagoAA { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Valor { get; set; }
    }

    public class DeclaracionResponse : BaseResult
    {
        public DeclaracionData declaracion { get; set; }
        public List<DistribucionPagoDto> distribuciones { get; set; }
    }
}
