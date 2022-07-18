using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.Comida.Queries;
using Application.Comida.Commands;
using Domain.Entities;



namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComidaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<Comida>
        [HttpGet]
        public async Task<IEnumerable<Comida>> Get([FromQuery] GetComidasQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<Comida>/5
        [HttpGet("GetById")]
        public async Task<Comida> Get([FromQuery] GetComidaByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<Comida>
        [HttpPost]
        public async Task<Domain.Entities.Comida> Post([FromBody] AddComidaCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<Comida>/5
        [HttpPut]
        public async Task<Unit> Put([FromBody] UpdateComidaCommand command)
        {
            return await _mediator.Send(command);
        }

        // DELETE api/<Comida>/5
        [HttpDelete]
        public async Task<Unit> Delete([FromQuery] DeleteComidaCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}