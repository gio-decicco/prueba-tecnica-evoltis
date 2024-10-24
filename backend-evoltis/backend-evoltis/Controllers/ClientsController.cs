using backend_evoltis.CORE.Models;
using backend_evoltis.CORE.Models.Clients.Commands;
using backend_evoltis.CORE.Models.Clients.Queries;
using backend_evoltis.CORE.Models.Services.Commands;
using backend_evoltis.CORE.Models.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend_evoltis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]   
        public async Task<BaseResult> GetClients([FromQuery]GetClients_Query query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("{Id}")]
        public async Task<BaseResult> GetClient([FromRoute]GetClientById_Query query)
        {
            return await _mediator.Send(query);
        }
        [HttpPost]
        public async Task<BaseResult> PostService([FromBody]PostClient_Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{clientId}")]
        public async Task<BaseResult> ModifyClient([FromBody]ModifyClient_Command request, Guid clientId)
        {
            request.Id = clientId;
            return await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        public async Task<BaseResult> DeleteClient([FromRoute]DeleteClient_Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
