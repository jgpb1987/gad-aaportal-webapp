using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalMercado
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string? Mercado { get; set; }
        public string? SectorDelMercado { get; set; }
        public string? NumeroEstablecimiento { get; set; }
        public int? PuestosMercado { get; set; }
        public string? Organizacion { get; set; }
        public string? TipoDePuesto { get; set; }
        public byte? RecolectorDeBasura { get; set; }
        public byte? ServicioHigienico { get; set; }
        public DateTime? FechaArrendamiento { get; set; }
        public byte? ServicioMedico { get; set; }
        public byte? Vigilancia { get; set; }
        public byte? Extinguidor { get; set; }
        public byte? Uniforme { get; set; }
        public byte? Agua { get; set; }
        public byte? Luz { get; set; }
        public byte? Alcantarillado { get; set; }
        public byte? Telefono { get; set; }
        public string? EstadoConstruccion { get; set; }
        public string? MaterialConstruccion { get; set; }
        public string? AreaTotal { get; set; }
        public string? AreaOcupada { get; set; }
        public string? NumeroContrato { get; set; }
        public DateTime? FechaContrato { get; set; }
        public string? PlazoContrato { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public string? Notaria { get; set; }
        public byte? ImplementosDeAseo { get; set; }
        public string? EstadoDelPuesto { get; set; }
        public double? ValorArrendamiento { get; set; }

        public virtual Local Local { get; set; } = null!;
    }
}
