using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Commands;
using WebApplication1.Queries;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StadiumsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStadiums()
        {
            var query = new GetAllStadiumsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStadiumById(int id)
        {
            var query = new GetStadiumByIdQuery(id);
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet("ByClubId/{id}")]
        public async Task<IActionResult> GetStadiumByClubId(int id)
        {
            var query = new GetStadiumByClubIdQuery(id);
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStadium(CreateStadiumCommand command)
        {
            var result = await _mediator.Send(command);
            //return Created($"api/stadiums/{command}", result);
            return CreatedAtAction("CreateStadium", result);

        }
    }
}
