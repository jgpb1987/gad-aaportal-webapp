namespace gad.aaportal.models.Entity.Dinardap
{
    public class ActividadEstablecimiento
    {
        public string NumeroRuc { get; set; } = null!;
        public int NumeroEstablecimiento { get; set; }
        public string CodigoActividad { get; set; } = null!;
        public string? ActividadEconomica { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
