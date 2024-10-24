using backend_evoltis.CORE.Models;
using backend_evoltis.CORE.Models.Services.Commands;
using backend_evoltis.CORE.Models.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend_evoltis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<BaseResult> GetServices([FromQuery] GetServices_Query command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet("{Id}")]
        public async Task<BaseResult> GetService([FromRoute]GetServiceById_Query query)
        {
            return await _mediator.Send(query);
        }
        [HttpPost]
        public async Task<BaseResult> PostService([FromBody]PostService_Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<BaseResult> ModifyService([FromBody] ModifyService_Command request, Guid id)
        {
            request.Id = id;
            return await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        public async Task<BaseResult> DeleteService([FromRoute] DeleteService_Command command) 
        {
            return await _mediator.Send(command);
        }
    }
}
