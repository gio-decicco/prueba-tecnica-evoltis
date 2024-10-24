using backend_evoltis.CORE.DTOs.Clients;
using MediatR;

namespace backend_evoltis.CORE.Models.Clients.Queries
{
    public class GetClients_Query : IRequest<GetClientsDto>
    {
        public string? Aprox { get; set; }
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedUntil { get; set; }
        public List<Guid>? Services { get; set; } = [];
    }
}
