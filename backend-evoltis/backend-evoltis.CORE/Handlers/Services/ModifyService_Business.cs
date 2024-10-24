using AutoMapper;
using backend_evoltis.CORE.DTOs.Services;
using backend_evoltis.CORE.Models.Services.Commands;
using backend_evoltis.CORE.Models.Services.Requests;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Services
{
    public class ModifyService_Business
    {
        public class Validation : AbstractValidator<ModifyService_Command>
        {
            public Validation()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Price).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<ModifyService_Command, ServiceDto>
        {
            private readonly IValidator<ModifyService_Command> _validator;
            private readonly IServicesService _service;
            private readonly IMapper _mapper;

            public Handler(IValidator<ModifyService_Command> validator, IServicesService service, IMapper mapper)
            {
                _validator = validator;
                _service = service;
                _mapper = mapper;
            }

            public async Task<ServiceDto> Handle(ModifyService_Command request, CancellationToken cancellationToken)
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
                    var serviceRequest = _mapper.Map<ServiceRequest>(request);
                    var result = await _service.ModifyService(request.Id, serviceRequest);
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
