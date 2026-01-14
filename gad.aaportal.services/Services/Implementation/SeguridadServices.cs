using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Seguridad;
using gad.aaportal.services.Config;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Implementation;

public class SeguridadServices : ISeguridadServices
{
    private readonly ILogger<SeguridadServices> logger;
    private readonly ISecurityAlgorithmServices securityAlgorithmServices;
    private readonly ServicesConfig servicesConfig;
    public SeguridadServices(ILogger<SeguridadServices> logger, ISecurityAlgorithmServices securityAlgorithmServices, IOptions<ServicesConfig> servicesConfig)
    {
        this.logger = logger;
        this.securityAlgorithmServices = securityAlgorithmServices;
        this.servicesConfig = servicesConfig.Value;
    }
    public async Task<string> HelloWorld()
    {
        string hello = string.Empty;
        try
        {
            hello = "Hello World Seguridad";
        }
        catch (SystemExceptionCustomized sex)
        {
            logger.LogError(sex, sex.Description, sex.Code);
            throw;
        }
        return hello;
    }

    public async Task<RsaDtoResult> GetRsaPublicKey(AaportalContext contexto)
    {
        RsaDtoResult result = new();
        try
        {
            var consulta= await contexto.Rsas.FirstOrDefaultAsync(r => r.Estado);
            result.Data = new() {PublicKey= consulta != null ? consulta.PublicKey : string.Empty };
        }
        catch (SystemExceptionCustomized sex)
        {
            logger.LogError(sex, sex.Description, sex.Code);
            throw;
        }
        return result;
    }
    public string GenerateJWT(string nameApp, string webSite, string jtiSession, string name, string email, string securityKey, DateTime expiration, string audiencia, string issuer, DateTime horaEmisionToken, DateTime ultimaAutenticacionUsuario)
    {
        string result;
        try
        {
            var iat = new DateTimeOffset(horaEmisionToken).ToUnixTimeSeconds();
            var uat = new DateTimeOffset(ultimaAutenticacionUsuario).ToUnixTimeSeconds();
            var claims = new List<Claim>()
                {
                     new Claim("app", nameApp),
                     new Claim(JwtRegisteredClaimNames.Jti, jtiSession),
                     new Claim(JwtRegisteredClaimNames.Name, name),
                     new Claim(JwtRegisteredClaimNames.Email, email),
                     new Claim(JwtRegisteredClaimNames.Website, webSite),
                     new Claim(JwtRegisteredClaimNames.Iat, iat.ToString(), ClaimValueTypes.Integer64),
                     new Claim("uat", uat.ToString(), ClaimValueTypes.Integer64)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audiencia,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );
            result = new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception)
        {
            throw;
        }
        return result;
    }

    public async Task<UsuarioDtoResult> Login(AaportalContext contexto, UsuarioDtoParam parametro)
    {
        UsuarioDtoResult result = new();
        try
        {
            var rsa = await contexto.Rsas.FirstOrDefaultAsync(r => r.Estado);
            if (rsa==null)
                throw SystemExceptionCustomized.CreateException("SEGOO1", "Error al obtener llaves");

            var decryptUser= await securityAlgorithmServices.GetDecryptRsa(new EncryptDecryptDtoParam() {Key=rsa.PrivateKey, Data=parametro.User});
            var decryptPwd= await securityAlgorithmServices.GetDecryptRsa(new EncryptDecryptDtoParam() { Key = rsa.PrivateKey, Data = parametro.Password });

            if (decryptUser.Data.EncryptDecrypt.Length<=0)
                throw SystemExceptionCustomized.CreateException("SEGOO2", "Error no es posible desencriptar claves.");

            var user= await contexto.Usuarios.FirstOrDefaultAsync(u => u.User == decryptUser.Data.EncryptDecrypt && u.Estado);
            
            if (user==null)
                throw SystemExceptionCustomized.CreateException("SEGOO3", "Usuario no existe");

            var pwd= await securityAlgorithmServices.GetGenerateComputeHashSha(new ComputeHashSha1DtoParam() {Usuario= decryptUser.Data.EncryptDecrypt, Password= decryptPwd.Data.EncryptDecrypt });
            if(user.Password!=pwd.Data.Hash)
                throw SystemExceptionCustomized.CreateException("SEGOO4", "Password incorrecto");

            var appJwt = await contexto.Jwts.FirstOrDefaultAsync(a => a.Estado);
            if (appJwt==null)
                throw SystemExceptionCustomized.CreateException("SEGOO5", "Error al obtener configuracion de token.");

            var usuarioSesion=await contexto.UsuarioSesions.Where(us => us.CodigoUser == user.User).OrderByDescending(us => us.FechaHora).FirstOrDefaultAsync();

            var expiration = DateTime.Now.AddSeconds(appJwt.JwtTime);
            var fechaHora = DateTime.Now;
            var jtiSession = System.Guid.NewGuid().ToString();
            var token = GenerateJWT(servicesConfig.NameApp, servicesConfig.WebSiteCompany, jtiSession, user.Nombres, user.Email, appJwt.SecurityKey, expiration, servicesConfig.Audiencia, servicesConfig.WebSiteCompany, fechaHora, usuarioSesion!=null ? usuarioSesion.FechaHora : fechaHora);

            var userSesion = new UsuarioSesion()
            {
                FechaHora = fechaHora,
                FechaExpiracion = expiration,
                Jti = jtiSession,
                CodigoUser = user.User,
                Browser = parametro.Browser,
                UserAgent = parametro.UserAgent,
                CodigoUserNavigation = user,
                Language = parametro.Language,
                EstaRevocado = false,
                Ip = parametro.Ip,
                OperatingSystem = parametro.OperatingSystem,
                Plugins = parametro.Plugins,
                Geolocation = parametro.Geolocation,
                TimeZone = parametro.TimeZone,
                Fecha=fechaHora,
                FechaRevocatoria=fechaHora
            };
            await contexto.UsuarioSesions.AddAsync(userSesion);
            await contexto.SaveChangesAsync();

            result.Data = new UsuarioDataDtoResult()
            {
                Token = token,
                Expiration = expiration,
                UltimoAcceso = usuarioSesion!=null ? usuarioSesion.FechaHora : fechaHora,
                Nombres = user.Nombres
            };
        }
        catch (SystemExceptionCustomized sex)
        {
            logger.LogError(sex, sex.Description, sex.Code);
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
            throw;
        }
        return result;
    }


}
