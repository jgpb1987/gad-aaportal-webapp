namespace gad.aaportal.services.Config
{
    public class ServicesConfig
    {
        public string NameApp { get; set; } = null!;
        public string WebSiteCompany { get; set; } = null!;
        public string Audiencia { get; set; } = null!;
        public int DiasParaCambiarClave { get; set; }
        public string AccionLogin { get; set; } = null!;
        public string AccionUserRegsitration { get; set; } = null!;
        public string AccionForgotPassword { get; set; } = null!;
        public string DinardapUser { get; set; } = null!;
        public string DinardapPwd { get; set; } = null!;
    }
}
