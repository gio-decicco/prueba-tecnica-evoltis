using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.DTOs.Services;
using MediatR;

namespace backend_evoltis.CORE.Models.Services.Queries
{
    public class GetServices_Query : IRequest<GetServicesDto>
    {
        public string? Aprox {  get; set; }
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedUntil { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}
