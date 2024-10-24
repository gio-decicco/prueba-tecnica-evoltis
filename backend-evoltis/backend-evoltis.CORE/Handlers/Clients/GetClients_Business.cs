using AutoMapper;
using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.Models.Clients.Queries;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Clients
{
    public class GetClients_Business
    {
        public class Handler : IRequestHandler<GetClients_Query, GetClientsDto>
        {
            private readonly IClientService _service;
            private readonly IMapper _mapper;

            public Handler(IClientService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<GetClientsDto> Handle(GetClients_Query request, CancellationToken cancellationToken)
            {
                var response = new GetClientsDto();
                try
                {
                    var result = await _service.GetClients(request.Aprox, request.DateCreatedFrom, request.DateCreatedUntil, request.Services);
                    response.Clients = _mapper.Map<List<ClientResponse>>(result);
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
