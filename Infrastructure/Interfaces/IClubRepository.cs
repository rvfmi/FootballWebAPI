using Infrastructure.ModelsDTO.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IClubRepository
    {
        Task<List<ClubDTO>> GetClubs();
        Task<Club> GetOneClub(int id);
        Task<Club> DeleteOneClub(int id);
        Task<Club> AddClub(CreateClubDTO club);
        Task<Club> Update(UpdateClubDTO club, int id);
    }
}
