using backend_evoltis.CORE.DTOs.Services;

namespace backend_evoltis.CORE.DTOs.Clients
{
    public class ClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<ServiceResponse> Services { get; set; }
    }
}
