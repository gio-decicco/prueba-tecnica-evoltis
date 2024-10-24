using backend_evoltis.CORE.DTOs.Clients;
using MediatR;

namespace backend_evoltis.CORE.Models.Clients.Commands
{
    public class PostClient_Command : IRequest<ClientDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Guid>? Services { get; set; } = [];
    }
}
