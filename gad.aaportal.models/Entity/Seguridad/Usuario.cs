using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Seguridad;

public partial class Usuario
{
    public string User { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public DateTime FechaUltimoCambioClave { get; set; }

    public int DiasParaCambiarClave { get; set; }

    public bool CambiaClave { get; set; }

    public bool EstaBloqueado { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<UsuarioSesion> UsuarioSesion { get; set; } = new List<UsuarioSesion>();
}

