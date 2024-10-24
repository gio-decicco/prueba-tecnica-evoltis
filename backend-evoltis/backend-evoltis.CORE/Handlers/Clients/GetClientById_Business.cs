using AutoMapper;
using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.Models.Clients.Queries;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Clients
{
    public class GetClientById_Business
    {
        public class Validation : AbstractValidator<GetClientById_Query>
        {
            public Validation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<GetClientById_Query, ClientDto>
        {
            private readonly IValidator<GetClientById_Query> _validator;
            private readonly IClientService _service;
            private readonly IMapper _mapper;

            public Handler(IValidator<GetClientById_Query> validator, IClientService service, IMapper mapper)
            {
                _validator = validator;
                _service = service;
                _mapper = mapper;
            }

            public async Task<ClientDto> Handle(GetClientById_Query request, CancellationToken cancellationToken)
            {
                var response = new ClientDto();
                var validation = await _validator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    response.SetError(string.Join(Environment.NewLine, validation.Errors), System.Net.HttpStatusCode.BadRequest);
                    return response;
                }
                try
                {
                    var result = await _service.GetClientById(request.Id);
                    response = _mapper.Map(result, response);
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
