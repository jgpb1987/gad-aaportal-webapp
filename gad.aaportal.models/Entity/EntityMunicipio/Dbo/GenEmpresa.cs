using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenEmpresa
    {
        public string EmpCodigo { get; set; } = null!;
        public string? EmpNombre { get; set; }
        public string? EmpNombreCom { get; set; }
        public string EmpEstado { get; set; } = null!;
        public string EmpRuc { get; set; } = null!;
        public string? EmpCarnetCm { get; set; }
        public string? EmpDireccion { get; set; }
        public string? EmpTelef1 { get; set; }
        public string? EmpTelef2 { get; set; }
        public string? EmpGerente { get; set; }
        public string? EmpContador { get; set; }
        public string? EmpNumContador { get; set; }
        public string? EmpAdmin { get; set; }
        public string? EmpDireccionEst { get; set; }
        public int? EmpCodigoEst { get; set; }
        public int? EmpCodigoPun { get; set; }
        public int? EmpContribuyenteEsp { get; set; }
        public string? EmpContabilidad { get; set; }
        public int? EmpIdentificacion { get; set; }
        public bool? EmpContespecial { get; set; }
        public bool? EmpAgenteretencion { get; set; }
        public string? EmpRegimen { get; set; }
        public string EmpNagenteretencion { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public bool? EmpInventarioneg { get; set; }
        public bool? EmpTipoprecio { get; set; }
        public int EmpMoneda { get; set; }
        public int? EmpAmbiente { get; set; }
        public int? EmpTipoemision { get; set; }
    }
}
