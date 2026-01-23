namespace gad.aainteroperador.soap.Configuration
{
    public class SoapClientOptions
    {
        public string Endpoint { get; set; } = string.Empty;
        public SoapSecurityOptions Security { get; set; } = new();
    }

    public class SoapSecurityOptions
    {
        public SoapSecurityType Type { get; set; } = SoapSecurityType.None;
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public enum SoapSecurityType
    {
        None,
        Basic,
        Certificate
    }
}
