namespace gad.aaportal.models.Entity.Dinardap
{
    public class SepsOrganizacion
    {
        public string? Calle { get; set; }
        public string? Canton { get; set; }
        public string? CedulaRepresentante { get; set; }
        public string? CedulaSecretario { get; set; }
        public string? ClaseOrganizacion { get; set; }
        public int? CodigoError { get; set; }
        public string? CodigoRegistroSeps { get; set; }
        public string? CorreoOrganizacion { get; set; }
        public string? Error { get; set; }
        public string? EstadoOrganizacion { get; set; }
        public DateTime? FechaRegistroSeps { get; set; }
        public string? GrupoOrganizacion { get; set; }
        public string? Interseccion { get; set; }
        public string? NombreRepresentanteLegal { get; set; }
        public string? NombreSecretario { get; set; }
        public string? Numero { get; set; }
        public string? NumeroResolucionSeps { get; set; }
        public string? Parroquia { get; set; }
        public string? Provincia { get; set; }
        public string? RazonSocial { get; set; }
        public string? Referencia { get; set; }

        public string Ruc { get; set; } = null!;   // PK

        public string? Telefono { get; set; }
        public string? TipoOrganizacion { get; set; }

        public DateTime FechaGrabado { get; set; }
    }
}
