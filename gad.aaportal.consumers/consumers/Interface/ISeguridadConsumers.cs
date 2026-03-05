using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;

namespace gad.aaportal.consumers.Consumers.Interface
{
    public interface ISeguridadConsumers
    {
        public Task<RsaDtoResult> GetPublicKey();
        public Task<UsuarioDtoResult> Login(UsuarioDtoParam parametro);
        public Task<BaseResult> UserRegistration(UserRegistrationDtoParam parametro);
        public Task<BaseResult> ForgotPassword(ForgotPasswordDtoParam parametro);
    }
}
