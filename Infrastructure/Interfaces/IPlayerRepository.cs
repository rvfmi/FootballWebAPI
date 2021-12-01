using Infrastructure.Models;
using Infrastructure.ModelsDTO.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<PlayerDTO>> GetPlayers();
        Task<Player> GetOnePlayer(int id);
        Task<Player> DeleteOnePlayer(int id);
        Task<List<Player>> GetPlayersByClubId(int clubId);
        Task<Player> AddPlayer(Player player);
        Task<Player> UpdatePlayer(UpdatePlayerDTO player, int id);
    }
}
