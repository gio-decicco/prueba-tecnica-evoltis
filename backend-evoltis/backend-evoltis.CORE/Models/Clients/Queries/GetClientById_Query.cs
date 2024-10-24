using backend_evoltis.CORE.DTOs.Clients;
using MediatR;

namespace backend_evoltis.CORE.Models.Clients.Queries
{
    public class GetClientById_Query : IRequest<ClientDto>
    {
        public Guid Id { get; set; }
    }
}
