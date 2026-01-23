using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces;

public interface ISeguridadServices
{
    Task<string> HelloWorld();
    Task<UsuarioDtoResult> Login(AaportalContext contexto, UsuarioDtoParam parametro);
    Task<RsaDtoResult> GetRsaPublicKey(AaportalContext contexto);
    Task<BaseResult> GetUserRegistration(AaportalContext contexto, UserRegistrationDtoParam parametro);
    Task<BaseResult> GetForgotPassword(AaportalContext contexto, ForgotPasswordDtoParam parametro);
}
