namespace gad.aaportal.models.Entity.Seguridad;

public partial class UsuarioSesion
{
    public string Jti { get; set; } = null!;

    public string CodigoUser { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public DateTime FechaHora { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public DateTime FechaRevocatoria { get; set; }

    public string Browser { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public string OperatingSystem { get; set; } = null!;

    public string Plugins { get; set; } = null!;

    public string Geolocation { get; set; } = null!;

    public string TimeZone { get; set; } = null!;

    public bool EstaRevocado { get; set; }

    public virtual Usuario CodigoUserNavigation { get; set; } = null!;
}

