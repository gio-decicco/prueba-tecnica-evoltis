using backend_evoltis.CORE.DTOs.Services;
using MediatR;

namespace backend_evoltis.CORE.Models.Services.Commands
{
    public class DeleteService_Command : IRequest<ServiceDto>
    {
        public Guid Id { get; set; }
    }
}
