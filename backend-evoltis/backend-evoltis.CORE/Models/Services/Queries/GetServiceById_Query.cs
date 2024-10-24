using backend_evoltis.CORE.DTOs.Services;
using MediatR;

namespace backend_evoltis.CORE.Models.Services.Queries
{
    public class GetServiceById_Query : IRequest<ServiceDto>
    {
        public Guid Id { get; set; }
    }
}
