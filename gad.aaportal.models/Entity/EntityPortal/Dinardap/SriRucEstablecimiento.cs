namespace gad.aaportal.models.Entity.Dinardap
{
    public class SriRucEstablecimiento
    {
        public string NumeroRuc { get; set; }
        public string NumeroEstablecimiento { get; set; }

        public string Calle { get; set; }
        public string EstadoEstablecimiento { get; set; }
        public string Interseccion { get; set; }
        public string NombreFantasiaComercial { get; set; }
        public string TipoEstablecimiento { get; set; }
        public string ReferenciaUbicacion { get; set; }

        public DateTime? FechaInicioActividades { get; set; }
        public DateTime? FechaReinicioActividades { get; set; }
        public DateTime? FechaCierre { get; set; }

        public string VerificacionUbicacion { get; set; }
        public string UbicacionGeografica { get; set; }

        public string Barrio { get; set; }
        public string Ciudadela { get; set; }
        public string Conjunto { get; set; }
        public string Bloque { get; set; }
        public string NombreEdificio { get; set; }
        public string NumeroOficina { get; set; }
        public string Manzana { get; set; }
        public string Supermanzana { get; set; }
        public string Kilometro { get; set; }
        public string Carretero { get; set; }
        public string Camino { get; set; }
        public string NumeroPiso { get; set; }
        public string ResultadoVerificacion { get; set; }
        public string DireccionPresunta { get; set; }

        public DateTime FechaGrabado { get; set; }
    }
}
