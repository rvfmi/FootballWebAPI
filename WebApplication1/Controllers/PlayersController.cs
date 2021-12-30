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
            return player == null ? NotFound() : Ok(player);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetOnePlayer(id);
            return player == null ? NotFound() : Ok(player);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            var player = await _playerService.DeleteOnePlayer(id);
            return player == null ? NotFound() : Ok(player);
        }
        [HttpGet("ByClub/{id}")]
        public async Task<IActionResult> GetPlayerClubById(int id)
        {
            var player = await _playerService.GetPlayersByClubId(id);
            return player == null ? NotFound() : Ok(player);
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
