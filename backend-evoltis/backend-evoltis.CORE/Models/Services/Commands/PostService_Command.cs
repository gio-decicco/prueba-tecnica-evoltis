using backend_evoltis.CORE.DTOs.Services;
using MediatR;

namespace backend_evoltis.CORE.Models.Services.Commands
{
    public class PostService_Command : IRequest<ServiceDto>
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
