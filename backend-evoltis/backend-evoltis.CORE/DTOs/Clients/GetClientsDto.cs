using backend_evoltis.CORE.Models;

namespace backend_evoltis.CORE.DTOs.Clients
{
    public class GetClientsDto : BaseResult
    {
        public List<ClientResponse> Clients { get; set; }
    }
}
