namespace gad.admin.app.Settings
{
    public class ApplicationSettings
    {
        public string ApiServer { get; set; } = string.Empty;
        public string EndPointPaqueteIndividuatl { get; set; } = string.Empty;
        public string UsuarioProceso { get; set; } = null!;
        public string ApiPackages { get; set; } = null!;
        public List<string> CodigosPaquetes { get; set; } = new();
    }
}
