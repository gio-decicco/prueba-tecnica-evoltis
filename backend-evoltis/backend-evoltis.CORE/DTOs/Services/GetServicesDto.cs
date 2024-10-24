using backend_evoltis.CORE.Models;

namespace backend_evoltis.CORE.DTOs.Services
{
    public class GetServicesDto : BaseResult
    {
        public List<ServiceResponse> Services { get; set; }
    }
}
