namespace gad.aaportal.consumers.Config
{
    public class EndPointsConfig
    {
        public string GetPublicKey { get; set; } = null!;
        public string GetLogin { get; set; } = null!;
        public string GetUserRegistration { get; set; } = null!;
        public string GetForgotPassword { get; set; } = null!;
        public string GetResumenContribuyente { get; set; } = null!;
        public string GetCambiarClave { get; set; } = null!;
        public string ConsultarDatosContribuyente { get; set; } = null!;
        public string ActualizarDatosContribuyente { get; set; } = null!;
        public string ConsultarTiposMedioContacto { get; set; } = null!;
        public string ConsultarCantones { get; set; } = null!;
        public string ConsultarPeriodosDeclaracion { get; set; } = string.Empty;
        public string IniciarDeclaracion { get; set; } = string.Empty;
        public string RegistrarDeclaracion { get; set; } = string.Empty;
        public string ConsultarDeclaracionesContribuyente { get; set; } = string.Empty;

        /*Inicio Store Procedure Municipio*/
        public string CalcularImpuestoPatente { get; set; } = null!;
        public string CalcularImpuestoIat { get; set; } = null!;
        public string CalcularMulta { get; set; } = null!;
        public string CalcularTerceraEdad { get; set; } = null!;
        public string InsertActividadAnual { get; set; } = null!;
        public string InsertTerceraEdad { get; set; } = null!;
        public string InsertPagoPorTitulo { get; set; } = null!;
        public string ActualizarCodigoIngreso { get; set; } = null!;
        public string ConsultarValoresPagar { get; set; } = null!;
        public string ValidadorPermisos { get; set; } = null!;
        public string ConsultarValorBomberos { get; set; } = null!;
        public string ConsultarRucExoneraciones { get; set; } = null!;
        public string InsertarTranferenciaIat { get; set; } = null!;
        public string ConsultarAnioAdeuda { get; set; } = null!;
        public string ConsultarFechaVencimiento { get; set; } = null!;
        public string ConsultaValorP { get; set; } = null!;
        public string ConsultarEstadoRuc { get; set; } = null!;

        public string ConsultarMensaje { get; set; } = null!;
        /*Fin Store Procedure Municipio*/
    }
}

