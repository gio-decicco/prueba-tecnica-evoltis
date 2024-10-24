using AutoMapper;
using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.Models.Clients.Commands;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Clients
{
    public class DeleteClient_Business
    {
        public class Validation : AbstractValidator<DeleteClient_Command>
        {
            public Validation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<DeleteClient_Command, ClientDto>
        {
            private readonly IValidator<DeleteClient_Command> _validator;
            private readonly IClientService _service;
            private readonly IMapper _mapper;
            
            public Handler(IValidator<DeleteClient_Command> validator, IClientService service, IMapper mapper)
            {
                _validator = validator;
                _service = service;
                _mapper = mapper;
            }

            public async Task<ClientDto> Handle(DeleteClient_Command request, CancellationToken cancellationToken)
            {
                var response = new ClientDto();
                var validation = await _validator.ValidateAsync(request);
                if(!validation.IsValid)
                {
                    response.SetError(string.Join(Environment.NewLine, validation.Errors), System.Net.HttpStatusCode.BadRequest);
                    return response;
                }
                try
                {
                    var result = await _service.DeleteClient(request.Id);
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
