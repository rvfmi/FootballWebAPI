using AutoMapper;
using Infrastructure;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.Players;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace WebApplication1.Services
{
    public class PlayerService : IPlayerRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public PlayerService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            if(player == null)
            {
                throw new NotModifiedException("Cannot add new player");
            }
            else
            {
                _databaseContext.Add(player);
                await _databaseContext.SaveChangesAsync();
                return player;
            }
            
        }

        public async Task<Player> DeleteOnePlayer(int id)
        {
            var player = await _databaseContext.Players.SingleOrDefaultAsync(x => x.Id == id);
            if (player != null)
            {
                _databaseContext.Players.Remove(player);
                _databaseContext.SaveChanges();
                return player;
            }
            else
                throw new NotModifiedException($"Cannot delete player with id {id}");
        }

        public async Task<Player> GetOnePlayer(int id)
        {
            var player = await _databaseContext.Players.SingleOrDefaultAsync(x => x.Id == id);
            if (player != null)
                return player;
            else
                throw new NotFoundException($"Player with id {id} not found!");
        }

        public async Task<List<PlayerDTO>> GetPlayers()
        {
            var player = await _databaseContext.Players.ToListAsync();
            if (player.Count > 0)
            {
                var playerDTO = _mapper.Map<List<PlayerDTO>>(player);
                return playerDTO;
            }
            throw new NotFoundException("Players not found");
        }

        public async Task<List<Player>> GetPlayersByClubId(int id)
        {
            var player = await _databaseContext.Players.Where(x => x.ClubId == id).ToListAsync();
            if(player != null)
                return player;
            else
                throw new NotFoundException($"Player with clubId {id} not found!");
        }

        public async Task<Player> UpdatePlayer(UpdatePlayerDTO player, int id)
        {
            var players = await _databaseContext.Players.SingleOrDefaultAsync(x => x.Id == id);
            if (players is null || player is null)
                throw new NotModifiedException("Cannot modify player");
            else
            {
                players.Assists = player.Assists;
                players.Goals = player.Goals;
                players.Position = player.Position;
                await _databaseContext.SaveChangesAsync();
                return players;
            }
        }
        // metoda do pobierania wszystkich, jednego piłkarza, usuwania, modyfikacja i dodawanie, pobieranie wszystkich piłkarzy dla konkretnego klubu
    }
}
