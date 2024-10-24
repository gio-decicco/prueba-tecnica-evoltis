using backend_evoltis.CORE.DTOs.Services;
using MediatR;

namespace backend_evoltis.CORE.Models.Services.Commands
{
    public class ModifyService_Command : IRequest<ServiceDto>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
