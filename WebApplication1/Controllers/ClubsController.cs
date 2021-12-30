using Infrastructure;
using Infrastructure.ModelsDTO.Club;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubRepository _clubService;

        public ClubsController(IClubRepository clubService)
        {
            _clubService = clubService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClubs()
        {
            var clubs = await _clubService.GetClubs();
            return clubs == null ? NotFound() : Ok(clubs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneClub(int id)
        {
            var clubs = await _clubService.GetOneClub(id);
            return clubs == null ? NotFound() : Ok(clubs);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneClub(int id)
        {
            var clubs = await _clubService.DeleteOneClub(id);
            return clubs == null ? NotFound() : Ok(clubs);
        }
        [HttpPost]
        public async Task<IActionResult> AddClub(CreateClubDTO createClub)
        {
            var clubs = await _clubService.AddClub(createClub);
            return Created($"api/clubs/{clubs.Id}", clubs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClub(UpdateClubDTO updateClub, int id)
        {
            var clubs = await _clubService.Update(updateClub, id);
            return Ok(clubs);
        }
    }
}
