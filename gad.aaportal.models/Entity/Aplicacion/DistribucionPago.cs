namespace gad.aaportal.models.Entity.Aplicacion
{
    public class DistribucionPago
    {
        public string RUC { get; set; }
        public int AnioFiscal { get; set; }
        public int Canton { get; set; }
        public bool Paga { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
