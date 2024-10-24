using backend_evoltis.CORE.DTOs.Clients;
using MediatR;

namespace backend_evoltis.CORE.Models.Clients.Commands
{
    public class DeleteClient_Command : IRequest<ClientDto>
    {
        public Guid Id { get; set; }
    }
}
