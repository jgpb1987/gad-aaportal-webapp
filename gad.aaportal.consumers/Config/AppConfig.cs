namespace gad.aaportal.consumers.Config
{
    public class AppConfig
    {
        public string Company { get; set; } = null!;
        public string CodeApp { get; set; } = null!;
        public int TimeToast { get; set; }
        public uint Size { get; set; }
        public uint SizeBytes { get; set; }
        public string SesionStoragePublicKeyServer { get; set; } = null!;
        public string Expiration { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string UltimoAcceso { get; set; } = null!;
        public string Nombres { get; set; } = null!;
    }
}

