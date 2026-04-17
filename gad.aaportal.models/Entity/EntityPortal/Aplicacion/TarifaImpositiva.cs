namespace gad.aaportal.models.Entity.Aplicacion
{
    public class TarifaImpositiva
    {
        public int Id { get; set; }
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Excedente { get; set; }
    }
}
