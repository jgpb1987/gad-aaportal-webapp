using gad.aaportal.commons.Base;
using System.ComponentModel;

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

        public decimal TotalActivoCorriente470
        {
            get => _Acorriente;
            set
            {
                _Acorriente = value;
                RecalculateA();
                RecalculateUnoPuntoCinco();
                Notify(nameof(TotalActivoCorriente470));
            }
        }

        public decimal TotActivoNoCorriente1077
        {
            get => _Anocorriente;
            set
            {
                _Anocorriente = value;
                RecalculateA();
                RecalculateUnoPuntoCinco();
                Notify(nameof(TotActivoNoCorriente1077));
            }
        }

        public decimal TotalActivo1080 { get; private set; } = 0;
        private void RecalculateA()
        {
            TotalActivo1080 = _Acorriente + _Anocorriente;
            Notify(nameof(TotalActivo1080));
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
                RecalculateUnoPuntoCinco();
                Notify(nameof(TotPasivosCorrientes1340));
            }
        }

        public decimal TotalPasivosLargoPlazo1590
        {
            get => _PlargoPlazo;
            set
            {
                _PlargoPlazo = value;
                RecalculateP();
                Notify(nameof(TotalPasivosLargoPlazo1590));
            }
        }

        public decimal TotalPasivosContingente
        {
            get => _Pcontingente;
            set
            {
                _Pcontingente = value;
                RecalculateP();
                Notify(nameof(TotalPasivosContingente));
            }
        }

        public decimal TotalPasivos1620 { get; private set; } = 0;
        private void RecalculateP()
        {
            TotalPasivos1620 = _Pcorriente + _PlargoPlazo + _Pcontingente;
            Notify(nameof(TotalPasivos1620));
        }

        public decimal ValorUnoPorMil { get; private set; } = 0;
        private void RecalculateUnoPuntoCinco()
        {
            ValorUnoPorMil = Math.Round((TotalActivo1080 - TotPasivosCorrientes1340) * 1.5m / 1000, 2);
            ValorUnoPorMil = Math.Max(ValorUnoPorMil, 0m);
            Notify(nameof(ValorUnoPorMil));
        }

        private decimal _ingresos = 0;
        public decimal TotalIngresos1930
        {
            get => _ingresos;
            set
            {
                _ingresos = value;
                RecalculateUtilidad();
                Notify(nameof(TotalIngresos1930));
            }
        }

        private decimal _egresos = 0;
        public decimal TotasCostosGastos3380
        {
            get => _egresos;
            set
            {
                _egresos = value;
                RecalculateUtilidad();
                Notify(nameof(TotasCostosGastos3380));
            }
        }

        public decimal UtilidadEjercicio3420 { get; private set; } = 0;
        private void RecalculateUtilidad()
        {
            UtilidadEjercicio3420 = TotalIngresos1930 - TotasCostosGastos3380;
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
}
