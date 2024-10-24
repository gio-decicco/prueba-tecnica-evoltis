using AutoMapper;
using backend_evoltis.CORE.DTOs.Services;
using backend_evoltis.CORE.Models.Services.Queries;
using backend_evoltis.CORE.Services;
using FluentValidation;
using MediatR;

namespace backend_evoltis.CORE.Handlers.Services
{
    public class GetServiceById_Business
    {
        public class Validation : AbstractValidator<GetServiceById_Query>
        {
            public Validation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<GetServiceById_Query, ServiceDto>
        {
            private readonly IValidator<GetServiceById_Query> _validator;
            private readonly IServicesService _service;
            private readonly IMapper _mapper;

            public Handler(IValidator<GetServiceById_Query> validator, IServicesService service, IMapper mapper)
            {
                _validator = validator;
                _service = service;
                _mapper = mapper;
            }

            public async Task<ServiceDto> Handle(GetServiceById_Query request, CancellationToken cancellationToken)
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
                    var result = await _service.GetServiceById(request.Id);
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
