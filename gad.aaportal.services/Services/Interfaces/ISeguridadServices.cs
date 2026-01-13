using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Interfaces;

public interface ISeguridadServices
{
    Task<string> HelloWorld();
    Task<UsuarioDtoResult> Login(AaportalContext contexto, UsuarioDtoParam parametro);
    Task<RsaDtoResult> GetRsaPublicKey(AaportalContext contexto);
}
