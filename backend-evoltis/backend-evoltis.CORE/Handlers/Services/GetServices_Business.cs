using AutoMapper;
using backend_evoltis.CORE.DTOs.Services;
using backend_evoltis.CORE.Models.Services.Queries;
using backend_evoltis.CORE.Services;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Services
{
    public class GetServices_Business
    {
        public class Handler : IRequestHandler<GetServices_Query, GetServicesDto>
        {
            private readonly IServicesService _service;
            private readonly IMapper _mapper;

            public Handler(IServicesService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<GetServicesDto> Handle(GetServices_Query request, CancellationToken cancellationToken)
            {
                var response = new GetServicesDto();
                try
                {
                    var result = await _service.GetServices(
                        request.Aprox, 
                        request.DateCreatedFrom, 
                        request.DateCreatedUntil, 
                        request.PriceMin, 
                        request.PriceMax);
                    response.Services = _mapper.Map<List<ServiceResponse>>(result);
                    return response;
                }
                catch (Exception ex)
                {
                    response.SetError(string.Join(Environment.NewLine, ex.Message), System.Net.HttpStatusCode.InternalServerError);
                    return response;
                }
            }
        }
    }
}
