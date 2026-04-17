using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class InformacionsriNoobligado
    {
        public string? NúmeroIdentificación { get; set; }
        public string? RazonSocial { get; set; }
        public string? AñoFiscal { get; set; }
        public double? LibreEjeProfesional { get; set; }
        public double? OcupacionLiberal { get; set; }
        public double? ArriendoInmuebles { get; set; }
        public double? ArriendoOtrosAct { get; set; }
        public double? IngresosRegalias { get; set; }
        public double? RendimientosFinancieros { get; set; }
        public double? SubtotalIngresos { get; set; }
        public double? SueldosYSalarios { get; set; }
    }
}
