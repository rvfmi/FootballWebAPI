using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.Players;
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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerService;

        public PlayersController(IPlayerRepository playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var player = await _playerService.GetPlayers();
            if (player == null)
                return NotFound();
            return Ok(player);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetOnePlayer(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            var player = await _playerService.DeleteOnePlayer(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }
        [HttpGet("ByClub/{id}")]
        public async Task<IActionResult> GetPlayerClubById(int id)
        {
            var player = await _playerService.GetPlayersByClubId(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer(Player player)
        {
            var playerDTO = await _playerService.AddPlayer(player);
            return Created($"api/players/{player}", playerDTO);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDTO player, int id)
        {
            var playerDTO = await _playerService.UpdatePlayer(player, id);
            return Ok(playerDTO);
        }
    }
}
