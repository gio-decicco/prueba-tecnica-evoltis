using AutoMapper;
using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.DTOs.Services;
using backend_evoltis.CORE.Models.Clients.Commands;
using backend_evoltis.CORE.Models.Services.Commands;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Services
{
    public class DeleteService_Business
    {
        public class Validation : AbstractValidator<DeleteService_Command>
        {
            public Validation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<DeleteService_Command, ServiceDto>
        {
            private readonly IValidator<DeleteService_Command> _validator;
            private readonly IServicesService _service;
            private readonly IMapper _mapper;

            public Handler(IValidator<DeleteService_Command> validator, IServicesService service, IMapper mapper)
            {
                _validator = validator;
                _service = service;
                _mapper = mapper;
            }

            public async Task<ServiceDto> Handle(DeleteService_Command request, CancellationToken cancellationToken)
            {
                var response = new ServiceDto();
                var validation = await _validator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    response.SetError(string.Join(Environment.NewLine, validation.Errors), System.Net.HttpStatusCode.BadRequest);
                    return response;
                }
                try
                {
                    var result = await _service.DeleteService(request.Id);
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
