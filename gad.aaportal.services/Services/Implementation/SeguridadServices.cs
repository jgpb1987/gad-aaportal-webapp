using System.Threading.Tasks;

using gad.aaportal.services.Services.Interfaces;
using gad.aaportal.services.MessageException;
using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation;

public class SeguridadServices : ISeguridadServices
{
    private readonly ILogger<SeguridadServices> logger;

    public SeguridadServices(ILogger<SeguridadServices> logger)
    {
        this.logger = logger;
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

    public async Task<UsuarioDtoResult> Login(AaportalContext contexto, UsuarioDtoParam parametro)
    {
        UsuarioDtoResult result = new();
        try
        {
            result = new UsuarioDtoResult()
            {
                Token = string.Empty,
                Expiration = System.DateTime.Now,
                UltimoAcceso = System.DateTime.Now,
                Nombres = string.Empty
            };
        }
        catch (SystemExceptionCustomized sex)
        {
            logger.LogError(sex, sex.Description, sex.Code);
            throw;
        }
        return result;
    }
}
