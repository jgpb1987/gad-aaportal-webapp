using gad.aaportal.commons.Dto.Aplicacion;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface IConsultaServices
    {
        Task<CantonesResponse> ConsultaCantones();
    }
}
