namespace gad.aaportal.models.Entity.Aplicacion
{
    public class DistribucionPago
    {
        public string RUC { get; set; }
        public int AnioFiscal { get; set; }
        public int Id { get; set; }
        public bool PagoAA { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Valor { get; set; }
    }
}
