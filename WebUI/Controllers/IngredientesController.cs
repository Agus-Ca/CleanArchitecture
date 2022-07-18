using Application.Ingredientes.Commands;
using Application.Ingredientes.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<IngredientesController>
        [HttpGet]
        public async Task<IEnumerable<Ingrediente>> Get([FromQuery] GetIngredientesQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<IngredientesController>/5
        [HttpGet("GetById")]
        public async Task<Ingrediente> Get([FromQuery] GetIngredienteByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<IngredientesController>
        [HttpPost]
        public async Task<Unit> Post([FromBody] AddIngredienteCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<IngredientesController>/5
        [HttpPut]
        public async Task<Unit> Put([FromBody] UpdateIngredienteCommand command)
        {
            return await _mediator.Send(command);
        }

        // DELETE api/<IngredientesController>/5
        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteIngredienteCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
