using Infrastructure.Models;
using Infrastructure.ModelsDTO.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStadiumRepository
    {
        Task<List<StadiumDTO>> GetStadiums();
        Task<Stadium> GetStadiumById(int id);
        Task<Stadium> GetStadiumByClubId(int id);
        Task<Stadium> CreateStadium(Stadium stadium);
    }
}
