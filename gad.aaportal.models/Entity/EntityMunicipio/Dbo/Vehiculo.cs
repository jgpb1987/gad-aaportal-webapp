using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            MantenimientoAlerta = new HashSet<MantenimientoAlertum>();
            Movilizacions = new HashSet<Movilizacion>();
            RutaVehiculos = new HashSet<RutaVehiculo>();
        }

        public int IdVehiculo { get; set; }
        public string Numero { get; set; } = null!;
        public string? Placas { get; set; }
        public string? Motor { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Tipo { get; set; }
        public int? Anio { get; set; }
        public float? Kilometraje { get; set; }
        public float? CantidadCombustible { get; set; }
        public double? KmPorGalon { get; set; }
        public DateTime? MesDelPromedio { get; set; }
        public string? TipoCombustible { get; set; }
        public bool? Municipal { get; set; }
        public string? Propietario { get; set; }
        public bool? ConsumioCombustible { get; set; }
        public byte? Activo { get; set; }
        public string? CiEncargado { get; set; }
        public string? CiOperador { get; set; }
        public float? Toneladas { get; set; }
        public float? Cilindraje { get; set; }
        public string? Chasis { get; set; }
        public string? Clase { get; set; }
        public string? Color { get; set; }
        public string? Matricula { get; set; }
        public string? RendimientoMaximo { get; set; }
        public string? RendimientoMinimo { get; set; }
        public string? AreaTrabajo { get; set; }
        /// <summary>
        /// Campo que se suma anualmente pasado los 5 años a los galones por km recorridos
        /// </summary>
        public double? Depreciacion { get; set; }

        public virtual ICollection<MantenimientoAlertum> MantenimientoAlerta { get; set; }
        public virtual ICollection<Movilizacion> Movilizacions { get; set; }
        public virtual ICollection<RutaVehiculo> RutaVehiculos { get; set; }
    }
}
